using Core.DataAccess;
using DataAccess.EntityFramework.Abstract;
using DataAccess.EntityFramework.Context;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}
