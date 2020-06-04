using System;

namespace pdaa.asu.api.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IRepoKadr repoKadr { get; }
        IRepoMoving repoMoving { get; }
        IRepoSchedule repoSchedule { get; }
        IRepoGroup repoGroup { get; }
        IRepoPosada repoPosada { get; }
        IRepoKafedra repoKafedra{ get; }
        IRepoEducPlanSpec repoEducPlanSpec { get; }
        IRepoLog repoLog { get; }
        IRepoTests repoTests { get; }
        IRepoZno repoZno { get; }
    }
}
