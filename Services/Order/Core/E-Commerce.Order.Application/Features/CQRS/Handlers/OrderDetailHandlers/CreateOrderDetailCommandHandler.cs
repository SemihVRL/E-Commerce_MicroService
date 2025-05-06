using E_Commerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using E_Commerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductId=createOrderDetailCommand.ProductId,
                ProductName=createOrderDetailCommand.ProductName,
                ProductPrice=createOrderDetailCommand.ProductPrice,
                ProductAmount=createOrderDetailCommand.ProductAmount,
                ProductTotalPrice=createOrderDetailCommand.ProductTotalPrice,
                OrderingId=createOrderDetailCommand.OrderingId,
            });
        }
    }
    
}
