using DataAccessLayer.Interfaces;
using DataModel.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _iProductRepository;
        public ProductService(IProductRepository iProductRepository)
        {
            _iProductRepository = iProductRepository;
        }

        public Product AddProduct(Product product)
        {
            var maxId = _iProductRepository.GetAllProducts().Max(p => p.Id);
            product.Id = maxId + 1;

           return _iProductRepository.AddProduct(product);
        }

        public bool DeleteProduct(int id)
        {
            var product = _iProductRepository.GetAllProducts().FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _iProductRepository.DeleteProduct(product);

                return true;
            }
            return false;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _iProductRepository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return _iProductRepository.GetProduct(id);

        }

        public bool UpdateProduct(Product product)
        {
            var productFind = _iProductRepository.GetAllProducts().FirstOrDefault(p => p.Id == product.Id);
            if (productFind != null)
            {
                _iProductRepository.UpdateProduct(productFind,product);
                return true;
            }
            return false;
        }
    }
}
