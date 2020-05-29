using System.Collections.Generic;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Services
{
    public class ServiceCommon
    {
        private IUnitOfWork _uow;

        public ServiceCommon(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public string GetPosadaName(long posadaId)
        {
            if (posadaId <= 0)
                return string.Empty;


            var element = _uow.repoPosada.Get(posadaId);
            if (element == null)
                return string.Empty;

            return element.Name;
        }

        public string GetKafedraName(long kafedraId)
        {
            if (kafedraId <= 0)
                return string.Empty;


            var element = _uow.repoKafedra.Get(kafedraId);
            if (element == null)
                return string.Empty;

            return element.Name;
        }

        public string GetStudentGroupName(long groupId)
        {
            if (groupId <= 0)
                return string.Empty;


            var element = _uow.repoGroup.GetName(groupId);
            if (element == null)
                return string.Empty;

            return element;
        }

        public EducPlanSpec GetEducPlanSpec(long id, int year)
        {
            if (id <= 0)
                return null;

            var element = _uow.repoEducPlanSpec.Get(id, year);
            return element;
        }

        public List<OrderDataVacation> GetUserVacation(long kadrId, long orderTypeId = -1, long vacationSubTypeId = -1)
        {
            return _uow.repoKadr.GetKadrVacation(kadrId, orderTypeId, vacationSubTypeId);
        } 
        
        public List<OrderDataBusinessTrip> GetUserBusinessTrips(long kadrId)
        {
            return _uow.repoKadr.GetKadrBusinessTrips(kadrId);
        }
    }
}
