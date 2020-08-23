using Core.Utilities;
using Core.Utilities.Security;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register( UserRegisterDto userRegisterDto);
        IDataResult<User> Login(UserLoginDto userLoginDto);

        IResult UserExists(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
