using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalFinances.Application.ViewModel.Response.CommandResponse
{
    public class Response
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public object Error { get; set; }

        public Response() { }

        public Response(bool sucess, object data = null, object error = null)
        {
            Success = sucess;
            Data = data;
            Error = error;
        }
    }
}