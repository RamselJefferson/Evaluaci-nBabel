using Core.Application.Dto;
using Core.Application.Interfaces.Repositorys;
using Core.Application.Interfaces.Services;
using Core.Application.Request;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluaciónBabel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController( IOrderService orderService) { _orderService = orderService; }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrdersRequest orders){

            return Ok(_orderService.AddAsync(orders));

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           return Ok( await _orderService.GetOrderById(id));

        }

        [HttpPut]
        public async Task<IActionResult> Update(OrdersDto updatedOrder)
        {
            var result = await _orderService.UpdateOrder(updatedOrder);
            return Ok();
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.Delete(id);
            return Ok();
        }

    }
}
