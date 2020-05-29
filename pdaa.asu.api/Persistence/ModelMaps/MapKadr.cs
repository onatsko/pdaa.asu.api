using Dapper.FluentMap.Mapping;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence.ModelMaps
{
    public class MapKadr : EntityMappingBuilder<Kadr>
    {
        public MapKadr()
        {
            Map(u => u.PK).ToColumn("IdKadr");
            Map(u => u.Surname).ToColumn("KadrSurname");
            Map(u => u.Name).ToColumn("KadrName");
            Map(u => u.Otch).ToColumn("KadrOtch");
            Map(u => u.SurnameEng).ToColumn("KadrSurnameEng");
            Map(u => u.NameEng).ToColumn("KadrNameEng");
            Map(u => u.Zkpo).ToColumn("ZKPO");
            Map(u => u.Edbo).ToColumn("IdEdbo");
            Map(u => u.Birthday).ToColumn("BirthdayDate");
            Map(u => u.BirthPlaceCountryFK).ToColumn("IdBirthPlaceCountry");
            Map(u => u.BirthPlace).ToColumn("BirthPlace");
            Map(u => u.Sex).ToColumn("Sex");
            Map(u => u.Nationality).ToColumn("Nationality");
            Map(u => u.Prim).ToColumn("Prim");
            Map(u => u.PedStagStart).ToColumn("PedStajStart");
            Map(u => u.DateN_PDAA).ToColumn("DataN_PDAA");
            Map(u => u.DataN).ToColumn("IdDataN");
            Map(u => u.IsDel).ToColumn("IsDel");
            Map(u => u.Psw_md5).ToColumn("Us_psw_md5");
            Map(u => u.SurnameRodovyi).ToColumn("KadrSurnameRodovyi");
            Map(u => u.NameRodovyi).ToColumn("KadrNameRodovyi");
            Map(u => u.OtchRodovyi).ToColumn("KadrOtchRodovyi");
            Map(u => u.SurnameDavalnyi).ToColumn("KadrSurnameDavalnyi");
            Map(u => u.NameDavalnyi).ToColumn("KadrNameDavalnyi");
            Map(u => u.OtchDavalnyi).ToColumn("KadrOtchDavalnyi");
            Map(u => u.SurnameOrudnyi).ToColumn("KadrSurnameOrudnyi");
            Map(u => u.NameOrudnyi).ToColumn("KadrNameOrudnyi");
            Map(u => u.OtchOrudnyi).ToColumn("KadrOtchOrudnyi");
            Map(u => u.SurnameZnahidnyi).ToColumn("KadrSurnameZnahidnyi");
            Map(u => u.NameZnahidnyi).ToColumn("KadrNameZnahidnyi");
            Map(u => u.OtchZnahidnyi).ToColumn("KadrOtchZnahidnyi");
            Map(u => u.TelegramID).ToColumn("TelegramID");
            Map(u => u.GoogleEmailLogin).ToColumn("GoogleEmailLogin");

        }
    }
}
