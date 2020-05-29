using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoEducPlanSpec
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        //void Update(Kadr kadr);

        EducPlanSpec Get(long id, int year);

        List<DisciplineForSelect> GetDisciplineForSelect(
            long educPlanSpecId,
            int semesrt,
            long studentId,
            long movingId,
            EducPlanSpec educPlanSpec);

        List<DisciplineSelected> GetSelectedDiscipline(
            long educPlanSpecId,
            long movingId,
            int semesrt,
            long studentId);

        int AddStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, long studentId);
        int DelStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, long studentId);

        int MoveStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, int rowNumNext, long studentId);
    }
}
