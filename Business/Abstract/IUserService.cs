using Core.Utilities;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaimDto>> GetClaims(User user);
        IResult AddUser(User user);
        IDataResult<User> GetByEmail(string email);
    }
}
