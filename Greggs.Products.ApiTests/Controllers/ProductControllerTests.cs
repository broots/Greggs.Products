using Microsoft.VisualStudio.TestTools.UnitTesting;
using Greggs.Products.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Greggs.Products.Api.DataAccess;
using Microsoft.Extensions.Logging;
using Greggs.Products.Api.Models;
using System.Linq;

namespace Greggs.Products.Api.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        private readonly IDataAccess<Product> _dataAccess;
        private readonly ILogger<ProductController> _logger;
        private readonly ProductController _productController;

        public ProductControllerTests()
        {
            _dataAccess = new ProductAccess();
            _logger = new LoggerFactory().CreateLogger<ProductController>();
            _productController = new ProductController(_logger, _dataAccess);
        }

        [TestMethod()]
        public void GetRecentProductsTest()
        {
            var latest = _productController.Get();
            Assert.IsFalse(latest.Any(x => x.Name == "Coca Cola"));
        }

        [TestMethod()]
        public void GetOtherCurrencyPriceTest()
        {
            var euroExchange = 1.1m;
            var latest = _productController.GetOtherCurrency(euroExchange);
            var colaInPounds = latest.First(x => x.Name == "Coca Cola").PriceInPounds;
            var expected = colaInPounds / euroExchange;
            Assert.IsTrue(latest.First(x => x.Name == "Coca Cola").OtherCurrencyPrice == expected);
        }
    }
}