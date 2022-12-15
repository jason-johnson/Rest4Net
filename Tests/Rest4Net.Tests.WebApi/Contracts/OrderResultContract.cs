﻿using Rest4NetCore.Attributes;

namespace Rest4Net.Tests.WebApi.Contracts
{
    [RestContract(typeof(OrderResultContract))]
    public class OrderResultContract
    {
        public OrderResultContract(OrderContract order)
        {
            Order = order;
        }
        public OrderContract Order { get; set; }
        public double Price { get; set; } = 0;
    }
}
