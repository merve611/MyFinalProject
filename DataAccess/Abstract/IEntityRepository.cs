using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic constraint : jenerik kısıt
    //class:
    public interface IEntityRepository<T> where T:class,IEntity,new()         //T nin referans tip olması şartını koyuyor ve IEntity den implemente edilen bir class olabilir(Product,Customer,Category..) - new() yazdığımızda newlenebilir bir class olması zorunluluğu getiriyor
    {   
        List<T> GetAll(Expression<Func<T,bool>> filter = null);         //Bu yapı sayesinde,categorye göre getir ürünün fiyatına göre getir diyerek ayrı ayrı metotlar yazmamız gerekmeyecek
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
      
    }
}
