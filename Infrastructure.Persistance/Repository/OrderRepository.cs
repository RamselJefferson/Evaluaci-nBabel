using Core.Application.Dto;
using Core.Application.Interfaces.Repositorys;
using Core.Application.Request;
using Core.Domain.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnection _dbConnection;

        public OrderRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection)); ;
        }
        public async Task<List<Orders>> GetOrders()
        {
            var query = "SELECT * FROM Orders"; 
            var result = await _dbConnection.QueryAsync<Orders>(query);
            return result.ToList();
        }


        public async Task<bool> InsertOrder(OrdersRequest newOrder)
        {

           var query = @"
                       INSERT INTO Orders (OrderDate, CustomerName, TotalAmount) 
                       VALUES (@OrderDate, @CustomerName, @TotalAmount)";


           var affectedRows = await _dbConnection.ExecuteAsync(query, newOrder);

           return affectedRows > 0;
        }

        public async Task<Orders> GetOrderById(int orderId)
        {
            var query = "SELECT * FROM Orders WHERE Id = @Id";
            var order = await _dbConnection.QueryFirstOrDefaultAsync<Orders>(query, new { Id = orderId });

            return order;
        }

        public async Task<bool> UpdateOrder(OrdersDto updatedOrder)
        {
            var query = @"
            UPDATE Orders 
            SET OrderDate = @OrderDate, CustomerName = @CustomerName, TotalAmount = @TotalAmount 
            WHERE Id = @Id";

            var affectedRows = await _dbConnection.ExecuteAsync(query, updatedOrder);

            return affectedRows > 0;
        }

        public async  Task<bool> Delete(int id)
        {
            var query = "DELETE FROM Orders WHERE Id = @Id";
            var parameters = new { Id = id };

            int rowsAffected = await _dbConnection.ExecuteAsync(query, parameters);

            return rowsAffected > 0;
        }
    }
}
