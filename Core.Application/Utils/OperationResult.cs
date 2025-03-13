using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Utils
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public dynamic Data { get; set; }

        public OperationResult(bool success, string message, dynamic data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // Método estático para éxito
        public static OperationResult Ok(string message = "Operación exitosa", int rowsAffected = 0) =>
            new OperationResult(true, message, rowsAffected);

        // Método estático para fallo
        public static OperationResult Fail(string message) =>
            new OperationResult(false, message);
    }
}
