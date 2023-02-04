using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product AddProduct(Product product);

        bool UpdateProduct(Product oldProduct , Product newProduct);

        bool DeleteProduct(Product product);

        Product GetProduct(int id);
    }
}
