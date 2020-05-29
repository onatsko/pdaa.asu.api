using pdaa.asu.api.Persistence;
using pdaa.asu.api.Services.Models;
using Serilog;
using System.Security.Cryptography;

namespace pdaa.asu.api.Services
{
    public class ServiceAuthentication : IServiceAuthentication
    {
        private readonly IUnitOfWork _uow;

        public ServiceAuthentication(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public LoginResult LoginUser(string login, string psw)
        {
            if (string.IsNullOrEmpty(login))
            {
                return new LoginResult(false, "Empty login");
            }

            if (string.IsNullOrEmpty(psw))
            {
                return new LoginResult(false, "Empty password");
            }

            string errMsg = string.Empty;

            if (!long.TryParse(login, out var kadrId))
            {
                errMsg = $"Попытка входа с некорректным логином '{login}'";
                _uow.repoLog.AddLog(kadrId, "BlazorSite", 0, errMsg, "", "");
                Log.Error(errMsg);

                return new LoginResult(false, "Код ПДАА повинен бути числом!");
            }

            var kadr = _uow.repoKadr.Get(kadrId);
            if (kadr == null)
            {
                errMsg = $"Попытка входа с кодом '{kadrId}'. Код не найден.";
                _uow.repoLog.AddLog(kadrId, "BlazorSite", 0, errMsg, $"{kadrId}", psw);
                Log.Error(errMsg);

                return new LoginResult(false, "Особу не знайдено!");
            }

            MD5 md5Hash = MD5.Create();
            if (((ServiceCommon.VerifyMd5Hash(md5Hash, psw, kadr.Psw_md5)) && (psw != "")))
            {
                errMsg = $"Успешный вход #{kadrId} {kadr.NameFull}";
                _uow.repoLog.AddLog(kadrId, "BlazorSite", 0, $"Успешный вход с кодом '{kadrId}'", $"{kadrId}", "");
                Log.Information(errMsg);

                var loginResult = new LoginResult(true, "");
                loginResult.KadrFullName = kadr.NameFull;
                return loginResult;
            }

            errMsg = $"Неправильный пароль для кода '{kadrId}'";
            _uow.repoLog.AddLog(kadrId, "BlazorSite", 0, errMsg, $"{kadrId}", psw);
            Log.Error(errMsg);
            return new LoginResult(false, "Невірний код або пароль!");
        }


        
    }
}
