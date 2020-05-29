using System.Collections.Generic;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Services
{
    public class ServiceStudentOffice_DisciplineSelect
    {
        private IUnitOfWork _uow;
        private ServiceCurrentUser _serviceCurrentUser;

        public ServiceStudentOffice_DisciplineSelect(IUnitOfWork uow, ServiceCurrentUser serviceCurrentUser)
        {
            _uow = uow;
            _serviceCurrentUser = serviceCurrentUser;
        }


        public List<DisciplineForSelect> GetDisciplineForSelect(
            long educPlanSpecId, 
            int semesrt,
            long studentId,
            long movingId,
            EducPlanSpec educPlanSpec)
        {
            var elementList = _uow.repoEducPlanSpec.GetDisciplineForSelect(educPlanSpecId, semesrt, studentId, movingId, educPlanSpec);
            return elementList;
        }

        public List<DisciplineSelected> GetSelectedDiscipline(
            long educPlanSpecId,
            int semesrt,
            long studentId,
            long movingId)
        {
            var elementList = _uow.repoEducPlanSpec.GetSelectedDiscipline(educPlanSpecId, movingId, semesrt, studentId);
            return elementList;
        }

        public int AddStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, long studentId)
        {
            _uow.repoLog.AddLog(_serviceCurrentUser.GetCurrentUserId(), "BlazorSite_StudentDiscipline"
                , disciplineId
                , "Выбор дисциплины в кабинете студента"
                , ""
                , "{" + $"disciplineId: {disciplineId}, movingId: {movingId}, semestr: {semestr}, educPlanSpecId: {educPlanSpecId}, studentId: {studentId} "+"}");

            return _uow.repoEducPlanSpec.AddStudentDisciplineSelect(disciplineId, movingId, semestr, educPlanSpecId, studentId);
        }

        public int DelStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, long studentId)
        {
            _uow.repoLog.AddLog(_serviceCurrentUser.GetCurrentUserId(), "BlazorSite_StudentDiscipline"
                , disciplineId
                , "Удаление дисциплины в кабинете студента"
                , ""
                , "{" + $"disciplineId: {disciplineId}, movingId: {movingId}, semestr: {semestr}, educPlanSpecId: {educPlanSpecId}, rowNum: {rowNum}, studentId: {studentId} " + "}");

            return _uow.repoEducPlanSpec.DelStudentDisciplineSelect(disciplineId, movingId, semestr, educPlanSpecId, rowNum, studentId);
        }

        public int UpStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, int rowNumTo, long studentId)
        {
            _uow.repoLog.AddLog(_serviceCurrentUser.GetCurrentUserId(), "BlazorSite_StudentDiscipline"
                , disciplineId
                , "Повышение приоритета дисциплины в кабинете студента"
                , ""
                , "{" + $"disciplineId: {disciplineId}, movingId: {movingId}, semestr: {semestr}, educPlanSpecId: {educPlanSpecId}, rowNum: {rowNum}, rowNumTo: {rowNumTo}, studentId: {studentId} " + "}");

            return _uow.repoEducPlanSpec.MoveStudentDisciplineSelect(disciplineId, movingId, semestr, educPlanSpecId,
                rowNum, rowNumTo, studentId);
        }

        public int DownStudentDisciplineSelect(long disciplineId, long movingId, int semestr, long educPlanSpecId, int rowNum, int rowNumTo, long studentId)
        {
            _uow.repoLog.AddLog(_serviceCurrentUser.GetCurrentUserId(), "BlazorSite_StudentDiscipline"
                , disciplineId
                , "Понижение приоритета дисциплины в кабинете студента"
                , ""
                , "{" + $"disciplineId: {disciplineId}, movingId: {movingId}, semestr: {semestr}, educPlanSpecId: {educPlanSpecId}, rowNum: {rowNum}, rowNumTo: {rowNumTo}, studentId: {studentId} " + "}");

            return _uow.repoEducPlanSpec.MoveStudentDisciplineSelect(disciplineId, movingId, semestr, educPlanSpecId,
                rowNum, rowNumTo, studentId);
        }
    }
}
