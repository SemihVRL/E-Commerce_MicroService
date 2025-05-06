﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class CreateAddressCommand
    {
        public string UserId { get; set; }
        public string District { get; set; }
        //bölge
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
