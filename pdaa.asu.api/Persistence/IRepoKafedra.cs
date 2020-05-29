using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoKafedra
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        //void Update(Kadr kadr);

        Kafedra Get(long id);
    }
}
