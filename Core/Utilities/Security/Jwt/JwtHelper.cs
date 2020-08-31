using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _configuration;

        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;

            _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(User user, List<OperationClaimDto> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            //jwt security token
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaimDto> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                expires: _accessTokenExpiration,
                notBefore:DateTime.Now,
                signingCredentials: signingCredentials,
                claims: SetClaim(user, operationClaims)
                );

            return jwt;
        }

        private List<Claim> SetClaim (User user, List<OperationClaimDto> operationClaims)
        {
            var claims = new List<Claim>();
            
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddRoles(operationClaims.Select(i=>i.Name).ToArray());

            return claims;

        }
    }
}
