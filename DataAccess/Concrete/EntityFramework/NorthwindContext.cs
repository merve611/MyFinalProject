using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context: DB tabloları ile proje classlarını bağlamak
    public class NorthwindContext:DbContext     //DbContext: İndirdiğimiz entityframework ile gelen base sınıf
    {
        //override yazıp boşluktan sonra on ile başlayan metodu seçince aşağıdaki kısım gelir, Bu metot proje hangi veri tabanıyla ilişkili olduğunu belirttiğimiz yer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");      //Burda Sql server kullanacağımı belirtiyorum ve içerisinde database ın nerde olduğu , isimini ve şifresi girilmesini istediğii belirt

        }
        //Hangi tabloya hangi classın karşılık geldiğini belirtmek için -->DbSet kullandık
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customer { get; set; }


    }
}
