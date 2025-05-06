﻿using E_Commerce.Order.Domain.Entitites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Persistence.Context
{
    public class OrderContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SEMIH\\SQLEXPRESS;Initial Catalog=E-CommerceOrderDb;Integrated Security=True;TrustServerCertificate=True;");
        }

        public DbSet <Address> Addresses { get; set; }
        public DbSet <OrderDetail> OrderDetails { get; set; }
        public DbSet <Ordering> Orderings { get; set; }
    }
}
