using Core.Application.Dto;
using Core.Application.Request;
using Core.Application.Utils;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<List<OrdersDto>> GetOrders();
        Task<OperationResult> AddAsync(OrdersRequest request);

        Task<OrdersDto> GetOrderById(int orderId);

        Task<OperationResult> UpdateOrder(OrdersDto updatedOrder);

        Task<OperationResult> Delete(int id);
    }
}
