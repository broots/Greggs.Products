using System;
using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.Models;

namespace Greggs.Products.Api.DataAccess
{
    /// <summary>
    /// DISCLAIMER: This is only here to help enable the purpose of this exercise, this doesn't reflect the way we work!
    /// </summary>
    public class ProductAccess : IDataAccess<Product>
    {
        private static readonly IEnumerable<Product> ProductDatabase = new List<Product>()
        {
            new Product {Name = "Sausage Roll", PriceInPounds = 1m, DateCreated = DateTime.Now},
            new Product {Name = "Vegan Sausage Roll", PriceInPounds = 1.1m, DateCreated = DateTime.Now.AddDays(-1)},
            new Product {Name = "Steak Bake", PriceInPounds = 1.2m, DateCreated = DateTime.Now.AddDays(-2)},
            new Product {Name = "Yum Yum", PriceInPounds = 0.7m, DateCreated = DateTime.Now.AddDays(-3)},
            new Product {Name = "Pink Jammie", PriceInPounds = 0.5m, DateCreated = DateTime.Now.AddDays(-4)},
            new Product {Name = "Mexican Baguette", PriceInPounds = 2.1m, DateCreated = DateTime.Now.AddDays(-5)},
            new Product {Name = "Bacon Sandwich", PriceInPounds = 1.95m, DateCreated = DateTime.Now.AddDays(-6)},
            new Product {Name = "Coca Cola", PriceInPounds = 1.2m, DateCreated = DateTime.Now.AddDays(-7)}
        };

        public IEnumerable<Product> List(int? pageStart, int? pageSize)
        {
            var queryable = ProductDatabase.AsQueryable();

            if (pageStart.HasValue)
                queryable = queryable.Skip(pageStart.Value);

            if (pageSize.HasValue)
                queryable = queryable.Take(pageSize.Value);

            return queryable.ToList();
        }
    }
}