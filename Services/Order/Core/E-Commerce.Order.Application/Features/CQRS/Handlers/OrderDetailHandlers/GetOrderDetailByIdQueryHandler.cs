using E_Commerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using E_Commerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using E_Commerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using E_Commerce.Order.Application.Interfaces;
using E_Commerce.Order.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetByIdOrderDetailQueryResult> Handle(GetOrderDetailQuery getOrderDetailQuery)
        {
            var values = await _repository.GetByIdAsync(getOrderDetailQuery.Id);
            return new GetByIdOrderDetailQueryResult
            {
                OrderDetailId=values.OrderDetailId,
                ProductId=values.ProductId,
                ProductName=values.ProductName,
                ProductPrice=values.ProductPrice,
                ProductAmount=values.ProductAmount,
                ProductTotalPrice=values.ProductTotalPrice,
                OrderingId=values.OrderingId
                    
            };
        }
    }
}
