using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoKadr
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        Kadr Get(long id);
        List<Kadr> GetKadrs();

        //void Update(Kadr kadr);
        string GetPhoto(long id);
        List<OrderDataVacation> GetKadrVacation(long kadrId, long orderTypeId = -1, long vacationSubTypeId = -1);
        List<OrderDataBusinessTrip> GetKadrBusinessTrips(long kadrId);
        void SetPassword(long kadrPK, string password, long whoChangePassword);
        Kadr GetByGoogleEmail(string email);
        long GetMoving_Last_Main(long kadrId);
    }
}
