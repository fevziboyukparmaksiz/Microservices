using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FreeCourse.Shared.Dtos
{
    public class Response<T>
    {
<<<<<<< HEAD
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool isSuccessful { get; set; }
=======
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool isSuccessful { get; set; }
>>>>>>> 1ebdfdfe85e6a94a0880c610984d75601cf1acbc

        public List<string> Errors { get; set; }

        //Static Factory Method
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T>() { Data = data, isSuccessful = true, StatusCode = statusCode };
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T>() { Data = default, StatusCode = statusCode, isSuccessful = true };
        }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T>() { Errors = errors, StatusCode = statusCode, isSuccessful = false };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T>()
            { Errors = new List<string>() { error }, StatusCode = statusCode, isSuccessful = false };
        }

    }
}
