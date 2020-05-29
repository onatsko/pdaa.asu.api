using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoMoving
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        //void Update(Kadr kadr);

        Moving Get(long id);
        List<Moving> GetAllByKadr(long kadrPK);
        Moving GetLastMainByKadr(long kadrPK);
        bool IsStudent(long kadrPK);
        List<Moving> GetAllActiveByKadr(long kadrPK);
    }
}
