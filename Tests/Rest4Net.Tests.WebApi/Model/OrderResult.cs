using System;
namespace Rest4Net.Tests.WebApi.Model
{
    public class OrderResult
    {
        public Order Order { get; set; }
        public double Price { get; set; } = 0;
    }
}
