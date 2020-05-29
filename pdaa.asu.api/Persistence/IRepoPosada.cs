using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoPosada
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        //void Update(Kadr kadr);

        Posada Get(long id);
    }
}
