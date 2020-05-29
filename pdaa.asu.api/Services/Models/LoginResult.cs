using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdaa.asu.api.Services.Models
{
    public class LoginResult
    {
        public bool Result { get; private set; }
        public string Message { get; private set; }
        public string KadrFullName { get; set; }

        public LoginResult(bool result, string message)
        {
            Result = result;
            Message = message;
        }


    }
}
