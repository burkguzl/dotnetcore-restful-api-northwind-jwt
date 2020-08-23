using Business.Abstract;
using Business.Contants;
using Core.Utilities;
using DataAccess.EntityFramework.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            //business codes
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(i => i.CategoryId == categoryId).ToList());
        }

        public IDataResult<Product> GetById(int productId)
        {
            try
            {
                return new SuccessDataResult<Product>(Messages.SuccessOperation,_productDal.Get(i => i.ProductId == productId));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Product>(Messages.ErrorOperation,_productDal.Get(i => i.ProductId == productId));
            }
            
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
