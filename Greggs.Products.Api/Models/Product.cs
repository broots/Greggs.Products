using System;

namespace Greggs.Products.Api.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal PriceInPounds { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? OtherCurrencyPrice 
        { 
            get
            {
                return ExchangeRate.HasValue ? (decimal?)PriceInPounds / ExchangeRate.Value : null;
            }
        }
        public DateTime? DateCreated { get; set; }
    }
}
