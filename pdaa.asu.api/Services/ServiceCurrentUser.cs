using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using pdaa.asu.api.Common;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.DataModels;
using pdaa.asu.api.Services.Models;
using Serilog;

namespace pdaa.asu.api.Services
{
    public class ServiceCurrentUser
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;

        private long _kadrPK;
        private bool _isLogin;
        private GoogleUserLogin _googleUser;

        public ServiceCurrentUser(IUnitOfWork uow, IConfiguration configuration)
        {
            _uow = uow;
            _configuration = configuration;

            RegisterSiteEnter();
        }

        public event Action OnChange;
        public bool IsLogin => (_isLogin && !NeedEnterNewPassword) || (_googleUser != null);
        public bool IsGoogleLogin => (_googleUser != null);
        public string GoogleLoginEmail => _googleUser?.Email ?? "";
        public string GoogleLoginError { get; private set; }
        public bool IsStuff { get; private set; }
        public bool IsStudent { get; private set; }
        public string LastError { get; private set; }
        public string KadrFullName { get; private set; }
        public string KadrName { get; private set; }
        public DateTime? KadrBirthday { get; private set; }

        public bool NeedEnterNewPassword { get; private set; }



        private bool _isAlreadyRegiister = false;
        public void RegisterSiteEnter()
        {
            if (!_isAlreadyRegiister)
            {
                _uow.repoLog.AddLog(0, "BlazorSite", 0, "Вход на сайт", "", "");
                _isAlreadyRegiister = true;
            }
        }


        public bool SetCurrentUser(string login, string psw)
        {
            _isLogin = false;
            IsStuff = false;
            IsStudent = false;
            _kadrPK = 0;
            KadrFullName = "";
            KadrName = "";
            KadrBirthday = null;
            NeedEnterNewPassword = false;
            _googleUser = null;
            OnChange?.Invoke();

            if (string.IsNullOrEmpty(login))
            {
                return false;
            }

            if (string.IsNullOrEmpty(psw))
            {
                return false;
            }

            string errMsg = string.Empty;

            if (!long.TryParse(login, out _kadrPK))
            {
                errMsg = $"Попытка входа с некорректным логином '{login}'";
                _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, errMsg, "", "");
                Log.Error(errMsg);

                LastError = "Код ПДАА повинен бути числом!";
                return false;
            }

            var kadr = _uow.repoKadr.Get(_kadrPK);
            if (kadr == null)
            {
                errMsg = $"Попытка входа с кодом '{_kadrPK}'. Код не найден.";
                _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, errMsg, $"{_kadrPK}", psw);
                Log.Error(errMsg);

                _kadrPK = 0;
                LastError = "Особу не знайдено!";
                return false;
            }

            MD5 md5Hash = MD5.Create();
            if (((VerifyMd5Hash(md5Hash, psw, kadr.Psw_md5)) && (psw != "")))
            {
                errMsg = $"Успешный вход #{_kadrPK} {kadr.NameFull}";
                _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, $"Успешный вход с кодом '{_kadrPK}'", $"{_kadrPK}", "");
                Log.Information(errMsg);

                _isLogin = true;
                KadrFullName = kadr.NameFull;
                KadrName = $"{kadr.Name} {kadr.Otch}";
                KadrBirthday = kadr.Birthday;

                var kadrMovingList = GetUserMoving();
                if (kadrMovingList != null)
                {
                    var allMovingsIsStudent = kadrMovingList.Any() && kadrMovingList.All(x => x.PosadaFK == 3);
                    IsStuff = !allMovingsIsStudent;
                    IsStudent = kadrMovingList.Any(x => x.PosadaFK == 3);

                    NeedEnterNewPassword = NeedChangeDefaultStudentPassword(psw);
                }

                OnChange?.Invoke();
                return true;
            }

            errMsg = $"Неправильный пароль для кода '{_kadrPK}'";
            _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, errMsg, $"{_kadrPK}", psw);
            Log.Error(errMsg);
            LastError = "Невірний код або пароль!";
            return false;
        }

        public bool SetCurrentUser(GoogleUserLogin user)
        {
            _isLogin = false;
            IsStuff = false;
            IsStudent = false;
            _kadrPK = 0;
            KadrFullName = "";
            KadrName = "";
            KadrBirthday = null;
            NeedEnterNewPassword = false;
            _googleUser = null;
            //GoogleLoginError = "";
            OnChange?.Invoke();

            if (string.IsNullOrEmpty(user.Email))
            {
                return false;
            }

            string errMsg = string.Empty;

            var kadr = _uow.repoKadr.GetByGoogleEmail(user.Email);
            if (kadr == null)
            {
                errMsg = $"Неудачная попытка входа с аккаунтом Google '{user.Email}'. Пользователь '{user.FirstName} {user.LastName}' не найден.";
                _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, errMsg, $"{user.Email}", $"{user.FirstName} {user.LastName}");
                Log.Error(errMsg);

                GoogleLoginError = $"Ваш EMail {user.Email} не розпізнано системою. Зверніться, будь ласка, до відділу розробки, до {MyConstants.ResponsiblePerson}";
                LastError = GoogleLoginError;
                OnChange?.Invoke();
                return false;
            }

            errMsg = $"Успешный вход с аккаунтом Google '{user.Email}', #{_kadrPK} {kadr.NameFull}";
            _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, $"Успешный вход с аккаунтом Google '{user.Email}', код '{_kadrPK}'", $"{_kadrPK}", $"{user.Email}");
            Log.Information(errMsg);

            _isLogin = true;
            _kadrPK = kadr.PK;
            KadrFullName = kadr.NameFull;
            KadrName = $"{kadr.Name} {kadr.Otch}";
            KadrBirthday = kadr.Birthday;
            _googleUser = user;
            GoogleLoginError = "";

            var kadrMovingList = GetUserMoving();
            if (kadrMovingList != null)
            {
                var allMovingsIsStudent = kadrMovingList.Any() && kadrMovingList.All(x => x.PosadaFK == 3);
                IsStuff = !allMovingsIsStudent;
                IsStudent = kadrMovingList.Any(x => x.PosadaFK == 3);

                NeedEnterNewPassword = false;
            }

            OnChange?.Invoke();
            return true;
        }

        private bool NeedChangeDefaultStudentPassword(string psw)
        {
            var configNeedChangeDefaultStudentPassword =  _configuration.GetValue<bool>("NeedChangeStudentDefaultPassword");
            return IsStudent && configNeedChangeDefaultStudentPassword && psw.Trim().Equals("1");
        }

        public bool SetNewPasswordForCurrentUser(string newPassword)
        {
            if (!_isLogin)
                return false;

            if (_kadrPK <= 0)
                return false;

            _uow.repoKadr.SetPassword(_kadrPK, newPassword, _kadrPK);
            return true;
        }

        public void Logout()
        {
            if (!IsLogin)
                return;

            _isLogin = false;
            IsStuff = false;
            IsStudent = false;
            NeedEnterNewPassword = false;
            LastError = string.Empty;
            KadrFullName = string.Empty;
            KadrName = string.Empty;

            _googleUser = null;

            _uow.repoLog.AddLog(_kadrPK, "BlazorSite", 0, $"Выход из сайта для кода '{_kadrPK}'", $"{_kadrPK}", "");

            OnChange?.Invoke();
        }

        public string GetUserPhoto()
        {
            if (!IsLogin)
                return string.Empty;

            var kadrPhoto = _uow.repoKadr.GetPhoto(_kadrPK);
            if (kadrPhoto == null)
                return string.Empty;

            return kadrPhoto;
        }

        public List<Moving> GetUserMoving()
        {
            return _uow.repoMoving.GetAllActiveByKadr(_kadrPK);
        }

        public long GetCurrentUserId()
        {
            return IsLogin ? _kadrPK : 0;
        }

        public long GetCurrentUserPosadaId()
        {
            var currentUserId = GetCurrentUserId();
            var kadrMovingMainId = _uow.repoKadr.GetMoving_Last_Main(currentUserId);
            if (kadrMovingMainId <= 0)
                return 0;

            var movMain = _uow.repoMoving.Get(kadrMovingMainId);
            if (movMain == null)
                return 0;

            var kadrDivisionId = movMain.DivisionFK;
            var kadrPosadaId = movMain.PosadaFK;

            return kadrPosadaId;
        }

        public long GetCurrentUserDivisionId()
        {
            var currentUserId = GetCurrentUserId();
            var kadrMovingMainId = _uow.repoKadr.GetMoving_Last_Main(currentUserId);
            if (kadrMovingMainId <= 0)
                return 0;

            var movMain = _uow.repoMoving.Get(kadrMovingMainId);
            if (movMain == null)
                return 0;

            var kadrDivisionId = movMain.DivisionFK;
            var kadrPosadaId = movMain.PosadaFK;

            return kadrDivisionId;
        }


        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


    }
}
