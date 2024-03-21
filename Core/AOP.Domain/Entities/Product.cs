﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Category Category { get; set; }

        public Product(int id, string name, decimal price, int stockQuantity, Category category)
        {
            Id = id;
            Name = name;
            Price = price;
            StockQuantity = stockQuantity;
            Category = category;
        }
    }
}