using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pdaa.asu.api.Services.Models;

namespace pdaa.asu.api.Services
{
    public interface IServiceAuthentication
    {
        LoginResult LoginUser(string login, string psw);
    }
}
