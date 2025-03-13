using Core.Application.Dto;
using Core.Application.Request;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositorys
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrders();

        Task<bool> InsertOrder(OrdersRequest newOrder);

        Task<Orders> GetOrderById(int orderId);

        Task<bool> Delete(int id);
        Task<bool> UpdateOrder(OrdersDto updatedOrder);

    }

}
