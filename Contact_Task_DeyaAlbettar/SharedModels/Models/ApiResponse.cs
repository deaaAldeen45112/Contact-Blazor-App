using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<string> ValidationErrors { get; set; }
        public ApiResponse()
        {
            Success = true;
        }
    

        public ApiResponse(T data)
        {
            Success = true;
            Data = data;
        }
        public ApiResponse(T data,bool status)
        {
            Success = status;
            Data = data;
        }
        public ApiResponse(T data, string errorMessage,bool status)
        {
            Success = status;
            Data = data;
            ErrorMessage = errorMessage;
        }
        public ApiResponse(string errorMessage, IEnumerable<string> validationErrors = null)
        {
            Success = false;
            Data = default;
            ErrorMessage = errorMessage;
            ValidationErrors = validationErrors;
        }
    }
}
