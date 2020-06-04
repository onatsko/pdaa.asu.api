using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using pdaa.asu.api.JwsAuthentication;
using pdaa.asu.api.Services;

namespace pdaa.asu.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceAuthentication _serviceAuthentication;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IServiceAuthentication serviceAuthentication, IConfiguration configuration)
        {
            _serviceAuthentication = serviceAuthentication;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public ActionResult<string> Post(
            AuthenticationRequest authRequest,
            [FromServices] IJwtSigningEncodingKey signingEncodingKey)
        {
            // 1. Проверяем данные пользователя из запроса.
            var loginResult = _serviceAuthentication.LoginUser(authRequest.Name, authRequest.Password);
            if (!loginResult.Result)
            {
                return BadRequest(loginResult.Message);
            }

            // 2. Создаем утверждения для токена.
            var claims = new Claim[]
            {
                new Claim("KadrId", authRequest.Name),
                new Claim("KadrFullName", loginResult.KadrFullName)
            };

            // 3. Генерируем JWT.
            var expiresInMinutes = 60;
            int.TryParse(_configuration.GetSection("PdaaToken:expiresMinute").Value, out expiresInMinutes);
            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("PdaaToken:issuer").Value, // "pdaa.asu.api",
                audience: _configuration.GetSection("PdaaToken:audience").Value, // "pdaa.asu.client",
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiresInMinutes),
                signingCredentials: new SigningCredentials(
                    signingEncodingKey.GetKey(),
                    signingEncodingKey.SigningAlgorithm)
            );

            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
