using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoSchedule
    {
        List<ScheduleData> GetScheduleForTeacher(string sql, bool isForStudent);
        ScheduleJrn GetScheduleJrn(long Id);
        DiscipinesDistribJrn GetDiscipinesDistribJrn(long Id);
        DisciplinesJrn GetDiscipinesJrn(long Id);
        Discipline GetDiscipine(long Id);

    }
}
