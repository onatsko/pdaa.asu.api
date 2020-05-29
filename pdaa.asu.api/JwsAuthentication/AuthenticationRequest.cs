using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdaa.asu.api.JwsAuthentication
{
    public class AuthenticationRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
