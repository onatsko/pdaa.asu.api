using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapMoving : EntityMappingBuilder<Moving>
    {
        public MapMoving()
        {
            Map(u => u.PK).ToColumn("pkMoving");
            Map(u => u.IsDel).ToColumn("IsDel");
            Map(u => u.KadrFK).ToColumn("fkKadr");
            Map(u => u.PosadaFK).ToColumn("fkPosada");
            Map(u => u.IsPoohBah).ToColumn("IsPoohBah");
            Map(u => u.IsExt).ToColumn("IsExt");
            Map(u => u.IsMaterially).ToColumn("IsMaterially");
            Map(u => u.DateBegin).ToColumn("DateBegin");
            Map(u => u.DateEnd).ToColumn("DateEnd");
            Map(u => u.IsNoCalc).ToColumn("IsNoCalc");
            Map(u => u.DivisionFK).ToColumn("fkDivision");
            Map(u => u.StudVidOplFK).ToColumn("fkStudVidOpl");
            Map(u => u.OldOrderNFK).ToColumn("fkOldOrderN");
            Map(u => u.OldOrderKFK).ToColumn("fkOldOrderK");
            Map(u => u.TarifRozryad).ToColumn("TarifRozryad");
            Map(u => u.TarifKt).ToColumn("TarifKt");
            Map(u => u.Oklad).ToColumn("Oklad");
            Map(u => u.Stavka).ToColumn("Stavka");
            Map(u => u.Prim).ToColumn("Prim");
            Map(u => u.AuthorFK).ToColumn("fkAuthor");
            Map(u => u.EducPlanSpecFK).ToColumn("fkEducPlanSpec");
            Map(u => u.IsAcademOtpusk).ToColumn("IsAcademOtpusk");
            Map(u => u.ReasonsDismFK).ToColumn("fkReasonsDism");
            Map(u => u.SalaryFundFK).ToColumn("fkSalaryFund");
            Map(u => u.IsNoShtat).ToColumn("IsNoShtat");
            Map(u => u.ContractTypeFK).ToColumn("fkContractType");
            Map(u => u.DocOrderBeginFK).ToColumn("fkDocOrderBegin");
            Map(u => u.DocOrderEndFK).ToColumn("fkDocOrderEnd");
            Map(u => u.IsPartTime).ToColumn("IsPartTime");

        }
    }
}
