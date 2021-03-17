using System;
using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Products = new[]
        {
            "Sausage Roll", "Vegan Sausage Roll", "Steak Bake","Yum Yum", "Pink Jammie"
        };

        private readonly ILogger<ProductController> _logger;
        private readonly IDataAccess<Product> _productDataAccess;

        public ProductController(ILogger<ProductController> logger, IDataAccess<Product> productDataAccess)
        {
            _logger = logger;
            _productDataAccess = productDataAccess;
        }

        [HttpGet]
        public IEnumerable<Product> Get(int pageStart = 0, int pageSize = 5)
        {
            return _productDataAccess.List(pageStart, pageSize).OrderByDescending(x => x.DateCreated);
        }

        [HttpGet]
        public IEnumerable<Product> Get(decimal exchangeRate)
        {
            var products = _productDataAccess.List(null, null);
            products.ToList().ForEach(x => x.ExchangeRate = exchangeRate);
            return products;
        }
    }
}
