using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapEducPlanSpec : EntityMappingBuilder<EducPlanSpec>
    {
        public MapEducPlanSpec()
        {
            Map(u => u.PK).ToColumn("IdEducPlanSpec");
            ////Map(u => u.IsDel).ToColumn("IsDel");
            //Map(u => u.Year).ToColumn("EducPlanYear");
            Map(u => u.FakultetFK).ToColumn("IdFakultet");
            Map(u => u.SpecFK).ToColumn("IdSpec");
            Map(u => u.EducVidFK).ToColumn("IdVidEduc");
            Map(u => u.KvalifFK).ToColumn("IdKvalif");
            Map(u => u.IntegratedNum).ToColumn("IntegratedNum");
            Map(u => u.chkIntegrated).ToColumn("chkIntegrated");
            Map(u => u.SemesterEducB).ToColumn("SemesterEducB");
            Map(u => u.SemesterEducE).ToColumn("SemesterEducE");
            Map(u => u.KursOfYearCalcB).ToColumn("KursOfYearCalcB");
            Map(u => u.KursOfYearCalcE).ToColumn("KursOfYearCalcE");
            Map(u => u.KursNumStart).ToColumn("KursNumStart");
            Map(u => u.Kurs).ToColumn("Kurs");
            Map(u => u.KursNow).ToColumn("KursNow");
            Map(u => u.IsDisciplinesDiffSelect_Spec).ToColumn("IsDisciplinesDiffSelect_Spec");
            Map(u => u.IsDisciplinesDiffSelect).ToColumn("IsDisciplinesDiffSelect");
            Map(u => u.EducYearBegin).ToColumn("EducYearBegin");
            Map(u => u.IsStn).ToColumn("IsStn");
        }
    }
}
