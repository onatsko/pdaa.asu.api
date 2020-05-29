using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Services
{
    public class ServiceCommon
    {
        private IUnitOfWork _uow;

        public ServiceCommon(IUnitOfWork uow)
        {
            _uow = uow;
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

        public string GetPosadaName(long posadaId)
        {
            if (posadaId <= 0)
                return string.Empty;


            var element = _uow.repoPosada.Get(posadaId);
            if (element == null)
                return string.Empty;

            return element.Name;
        }

        public string GetKafedraName(long kafedraId)
        {
            if (kafedraId <= 0)
                return string.Empty;


            var element = _uow.repoKafedra.Get(kafedraId);
            if (element == null)
                return string.Empty;

            return element.Name;
        }

        public string GetStudentGroupName(long groupId)
        {
            if (groupId <= 0)
                return string.Empty;


            var element = _uow.repoGroup.GetName(groupId);
            if (element == null)
                return string.Empty;

            return element;
        }

        public EducPlanSpec GetEducPlanSpec(long id, int year)
        {
            if (id <= 0)
                return null;

            var element = _uow.repoEducPlanSpec.Get(id, year);
            return element;
        }

        public List<OrderDataVacation> GetUserVacation(long kadrId, long orderTypeId = -1, long vacationSubTypeId = -1)
        {
            return _uow.repoKadr.GetKadrVacation(kadrId, orderTypeId, vacationSubTypeId);
        } 
        
        public List<OrderDataBusinessTrip> GetUserBusinessTrips(long kadrId)
        {
            return _uow.repoKadr.GetKadrBusinessTrips(kadrId);
        }
    }
}
