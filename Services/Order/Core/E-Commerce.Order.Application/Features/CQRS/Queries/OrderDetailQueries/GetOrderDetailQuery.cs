﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailQuery
    {
        public GetOrderDetailQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
