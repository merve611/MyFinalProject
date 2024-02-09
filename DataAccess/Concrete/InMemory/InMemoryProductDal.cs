using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //Bellek üzerinde Product ile ilgili veri erişim kodlarının yazılacağı yer
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
                //Sql server, Oracle, Postgre..
                _products = new List<Product> { 
                
                    new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
                    new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
                    new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 20 },
                    new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 5 },
                    new Product{ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 80, UnitsInStock = 40 },
                };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {   //LİNQ - Lnaguage Integrated Query
            //Lambda

            //SingleOrDefault -> productsı tek tek dolaşmaya yarar. p dolaşırken verdiğin takma isim
            //Her p için, p nin product ıd si benim gönderdiğim product un ıd sine eşit mi eşitse productToDelete e eşitle
            //Eğer LİNQ olmasaydı tek tek forech ile _products ı dönüp if bloğu ile ıd kontrolu yapmak zorunda kalacaktık

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()       //Ürün listesini döndürüyor
        {
            return _products;
        }

       

        public void Update(Product product)
        {
            //Gönderdiğim ürün ıd sına sahip olan listedeki ürünü bul demek
           
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;      //Güncellenecek olan product un ismini, gönderdiğim product un ismi yap 
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;    
        }

        public List<Product> GetAllByCategory(int categoryıd)
        {
            return _products.Where(p=>p.CategoryId == categoryıd).ToList();     //Where koşulu içindeki şarta uyan bütün elemanları yeni bir liste haline getirip onu döndürür
            
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
