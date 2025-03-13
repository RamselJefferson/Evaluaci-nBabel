using AutoMapper;
using Core.Application.Dto;
using Core.Application.Interfaces.Repositorys;
using Core.Application.Interfaces.Services;
using Core.Application.Request;
using Core.Application.Utils;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Services
{
    public class OrderService : IOrderService
    {

        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<OperationResult> AddAsync(OrdersRequest request)
        {
            try
            {
                request.OrderDate = request.OrderDate.Date;
                var isSuccess = await _repo.InsertOrder(request);
                return isSuccess ? OperationResult.Ok("Orden insertada correctamente.") : OperationResult.Fail("No se pudo insertar.");
            }catch(Exception ex)
            {
                return OperationResult.Fail(ex.Message);
            } 
           
        }

        public async Task<OperationResult> Delete(int id)
        {
            var isSuccess = await _repo.Delete(id);
            return isSuccess ? OperationResult.Ok("Orden eliminada correctamente.") : OperationResult.Fail("Error eliminando el registro.");
        }

        public async Task<OrdersDto> GetOrderById(int orderId)
        {
            var order = await _repo.GetOrderById(orderId);
            var orderDto = _mapper.Map<OrdersDto>(order);

            return orderDto;
        }

        public async Task<List<OrdersDto>> GetOrders()
        {
            var orders = await _repo.GetOrders(); 

            var ordersDto = _mapper.Map<List<OrdersDto>>(orders);

            return ordersDto;
        }

        public async Task<OperationResult> UpdateOrder(OrdersDto updatedOrder)
        {
            var isSuccess = await _repo.UpdateOrder(updatedOrder);
            return isSuccess ? OperationResult.Ok("Orden actualizada correctamente.") : OperationResult.Fail("No se pudo actualizar.");

        }
    }
}
