using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        Product AddProduct(Product product);

        bool UpdateProduct(Product product);

        bool DeleteProduct(int id);

        Product GetProduct(int id);
    }
}
