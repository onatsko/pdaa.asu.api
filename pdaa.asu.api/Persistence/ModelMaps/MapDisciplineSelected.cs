using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapDisciplineSelected : EntityMappingBuilder<DisciplineSelected>
    {
        public MapDisciplineSelected()
        {
            Map(u => u.RowNumSelect).ToColumn("ROW_NUM_SELECT");
            Map(u => u.IdDisciplinesDiffSelectJrn).ToColumn("IdDisciplinesDiffSelect_jrn");
            Map(u => u.RowNum).ToColumn("ROW_NUM");
            Map(u => u.IdDisciplinesJrn).ToColumn("IdDisciplines_jrn");
            Map(u => u.IdMoving).ToColumn("IdMoving");
            Map(u => u.IdKadr).ToColumn("IdKadr");
            Map(u => u.IsAdminGranted).ToColumn("IsAdminGranted");
            Map(u => u.AllKadrName).ToColumn("AllKadrName");
            Map(u => u.DisciplinesName).ToColumn("DisciplinesName");
            Map(u => u.SemesterEduc).ToColumn("SemesterEduc");
            Map(u => u.EducPlanSpecName).ToColumn("EducPlanSpecName");
            Map(u => u.GrupNameAutoAll).ToColumn("GrupNameAutoAll");
            Map(u => u.DisciplinesDiffSelectStudCountMax).ToColumn("DisciplinesDiffSelectStudCountMax");
            Map(u => u.DisciplinesDiffSelectStudCountSelect).ToColumn("DisciplinesDiffSelectStudCountSelect");
            Map(u => u.IsLock).ToColumn("IsLock");
            Map(u => u.chkLock).ToColumn("chkLock");
        }
    }
}
