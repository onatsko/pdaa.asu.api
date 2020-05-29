using System;
using System.Collections.Generic;
using System.Linq;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;

namespace pdaa.asu.api.JwsAuthentication
{
    // Ключ для создания подписи (приватный)
    public interface IJwtSigningEncodingKey
    {
        string SigningAlgorithm { get; }

        SecurityKey GetKey();
    }

    // Ключ для проверки подписи (публичный)
    public interface IJwtSigningDecodingKey
    {
        SecurityKey GetKey();
    }
}
