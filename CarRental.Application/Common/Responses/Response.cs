using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Application.Common.Responses
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static Response SuccessResponse(string message)
        {
            return new Response
            {
                Message = message,
                Success = true
            };
        }
        public static Response FailResponse(string message)
        {
            return new Response
            {
                Message = message,
                Success = false
            };
        }
    }
    public class Response<T> : Response
    {
        public T Data { get; set; }


        public static Response<T> SuccessResponse(string message, T data)
        {
            return new Response<T>
            {
                Data = data,
                Success = true,
                Message = message
            };
        }
        public static Response<T> FailResponse(string message, T data)
        {
            return new Response<T>
            {
                Data = data,
                Success = false,
                Message = message
            };
        }
    }

}
