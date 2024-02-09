using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Product ile iligili veri tabanında yapacağım operasyonları(ekle-güncelle-listele) içeren ınterface
    //interface metotları defaultu public tir kendi değil
    public interface IProductDal:IEntityRepository<Product>
    {
        

    }
}
