namespace pdaa.asu.api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _cnn;
        public UnitOfWork(string connectionString)
        {
            _cnn = connectionString;
        }
        public void Dispose()
        {
        }

        private IRepoKadr _repoKadr;
        public IRepoKadr repoKadr => _repoKadr ?? (_repoKadr = new RepoKadr(_cnn));

        private IRepoMoving _repoMoving;
        public IRepoMoving repoMoving => _repoMoving ?? (_repoMoving = new RepoMoving(_cnn));

        private IRepoSchedule _repoSchedule;
        public IRepoSchedule repoSchedule => _repoSchedule ?? (_repoSchedule = new RepoSchedule(_cnn));

        private IRepoGroup _repoGroup;
        public IRepoGroup repoGroup => _repoGroup ?? (_repoGroup = new RepoGroup(_cnn));

        private IRepoPosada _repoPosada;
        public IRepoPosada repoPosada => _repoPosada ?? (_repoPosada = new RepoPosada(_cnn));

        private IRepoKafedra _repoKafedra;
        public IRepoKafedra repoKafedra => _repoKafedra ?? (_repoKafedra = new RepoKafedra(_cnn));

        private IRepoEducPlanSpec _repoEducPlanSpec;
        public IRepoEducPlanSpec repoEducPlanSpec => _repoEducPlanSpec ?? (_repoEducPlanSpec = new RepoEducPlanSpec(_cnn));

        private IRepoLog _repoLog;
        public IRepoLog repoLog => _repoLog ?? (_repoLog = new RepoLog(_cnn));

        private IRepoTests _repoTests;
        public IRepoTests repoTests => _repoTests ?? (_repoTests = new RepoTests(_cnn));

    }
}
