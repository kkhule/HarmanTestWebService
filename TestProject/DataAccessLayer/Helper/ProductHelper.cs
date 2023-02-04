using DataModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Helper
{
    public class ProductHelper
    {

        public static IEnumerable<Product> GetAllProducts()
        {
            List<Product> productList = new List<Product>();

            Product product = new Product()
            {
                Id = 1,
                Name = "Parle",
                CategoryName= "Biscuit",
                Description = "fruits, sugar-free, chocolates",
                ImageURL = "",
                Price = 5,
                UnitType = UnitType.Package,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-9),
                LastUpdateDate = DateTime.Now

            };

            productList.Add(product);

            product = new Product()
            {
                Id = 2,
                Name = "Sunfeast",
                CategoryName = "Cookie",
                Description = "cream biscuits, cookies with nuts",
                ImageURL = "",
                Price = 13,
                UnitType = UnitType.Qty,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-2),
                LastUpdateDate = DateTime.Now

            };

            productList.Add(product);

            product = new Product()
            {
                Id = 3,
                Name = "Oreo",
                CategoryName = "Biscuit",
                Description = "chocolate",
                ImageURL = "",
                Price = 15,
                UnitType = UnitType.Weight,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-6),
                LastUpdateDate = DateTime.Now

            };
            
            productList.Add(product);

            product = new Product()
            {
                Id = 4,
                Name = "Priyagold",
                CategoryName = "Cookie",
                Description = "Coconut Crunch",
                ImageURL = "",
                Price = 10,
                UnitType = UnitType.Package,
                IsActive = true,
                CreatedDate = DateTime.Now.AddDays(-4),
                LastUpdateDate = DateTime.Now

            };
            productList.Add(product);

            product = new Product()
            {
                Id = 5,
                Name = "Marie Gold",
                CategoryName = "Biscuit",
                Description = "cheese, curd, and milk",
                ImageURL = "",
                Price = 12,
                UnitType = UnitType.Qty,
                IsActive = false,
                CreatedDate = DateTime.Now.AddDays(-5),
                LastUpdateDate = DateTime.Now

            };

            productList.Add(product);

            return productList;
        }

    }
}
