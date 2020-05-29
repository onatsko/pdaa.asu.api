using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoGroup
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        Group Get(long PK);
        List<Kadr> GetGroupList(long groupPK);
        string GetName(long groupId);
    }
}
