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
    public class UpdateOrderDetailCommandHandler
    {

        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            values.ProductId = updateOrderDetailCommand.ProductId;
            values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;
            values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            values.OrderingId = updateOrderDetailCommand.OrderingId;
            await _repository.UpdateAsync(values);

        }

    }
}
