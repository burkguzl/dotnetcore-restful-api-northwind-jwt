using Business.Abstract;
using Business.Contants;
using Core.Utilities;
using Core.Utilities.Security;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var result = _userService.GetByEmail(userLoginDto.Email);
            if (result.Success)
            {
                return null;
            }
            else
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

        }

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
