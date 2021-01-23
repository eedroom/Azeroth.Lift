using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azeroth.Util {
    public static class ApiResult
    {
        public static ApiResult<T> OK<T>(T data)
        {
            return new ApiResult<T>() { code = System.Net.HttpStatusCode.OK, data = data };
        }

        public static ApiResult<string> Error(string msg)
        {
            return new ApiResult<string>() { code = System.Net.HttpStatusCode.InternalServerError, msg = msg };
        }

        public static ApiResult<T> Create<T>(System.Net.HttpStatusCode code,string msg,T data)
        {
            return new ApiResult<T>() { code = code, msg = msg, data = data };
        }
    }
}
