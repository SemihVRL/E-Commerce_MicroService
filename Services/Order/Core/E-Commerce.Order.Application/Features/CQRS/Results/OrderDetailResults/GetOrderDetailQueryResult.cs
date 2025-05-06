﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Results.OrderDetailResults
{
    public class GetOrderDetailQueryResult
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductAmount { get; set; }  //ürün miktarı
        public decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
