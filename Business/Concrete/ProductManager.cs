using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;            //injection     -- ProductManager new lendiğinde bana bir tane IProductDal referansı ver
        public ProductManager(IProductDal productDal)
        {
                _productDal = productDal;
        }


        public List<Product> GetAll()
        {
            //iş kodları

            return _productDal.GetAll();


        }
    }
}
