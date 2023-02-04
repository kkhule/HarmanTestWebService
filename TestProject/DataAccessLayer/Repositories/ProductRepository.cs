using DataAccessLayer.Helper;
using DataAccessLayer.Interfaces;
using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        static List<Product> plist = new List<Product>();


        static ProductRepository()
        {
            plist.AddRange(ProductHelper.GetAllProducts());
        }

        public Product AddProduct(Product product)
        {
            plist.Add(product);
            return product;
        }

        public bool DeleteProduct(Product product)
        {
          
                plist.Remove(product);
                return true;
           
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return plist;
        }

        public Product GetProduct(int id)
        {
            return plist.FirstOrDefault(p => p.Id == id);
        }

        public bool UpdateProduct(Product oldProduct, Product newProduct)
        {
                plist.Remove(oldProduct);
                plist.Add(newProduct);
                return true;
        }
    }
}
