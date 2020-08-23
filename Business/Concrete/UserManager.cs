using Business.Abstract;
using Business.Contants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(User user)
        {
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(Messages.SuccessOperation, _userDal.Get(i => i.Email == email));
        }

        public IDataResult<List<OperationClaimDto>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaimDto>>(_userDal.operationClaims(user));
        }
    }
}
