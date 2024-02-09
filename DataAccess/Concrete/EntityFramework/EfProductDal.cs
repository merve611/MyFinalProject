using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //.net core içerisinde default olarak

    public class EfProductDal : IProductDal
    {
        public void Add(Product entity) 
        {
            using (NorthwindContext context = new NorthwindContext())       //using bittiği anda NortwindContext işi bitince bellekten atılacak, bu hareket daha performanslı ürün geliştirmeye yarar
            {
                var addedEntity = context.Entry(entity);                    //(Referansı yakala)Veri kaynağından benim gönderdiğim Product la bir tane nesneyi eşleştir
                addedEntity.State = EntityState.Added;                      //addedEntity nin eklenecek olan nesne
                context.SaveChanges();                                      //ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())      
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
