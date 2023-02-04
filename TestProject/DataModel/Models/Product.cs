using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }
        public int Price { get; set; }
        public UnitType UnitType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }

    public enum  UnitType
    {
        Qty,
        Weight,
        Package
    }
}
