using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Services
{
    public class ServiceScheduler
    {
        private readonly string firstMonday = "31/08/2020";

        private IUnitOfWork _uow;
       // private ServiceCurrentUser _serviceCurrentUser;

        public ServiceScheduler(IUnitOfWork uow)
        {
            _uow = uow;
           // _serviceCurrentUser = serviceCurrentUser;
        }

        public string GetKadrFullName(long kadrPK)
        {
            if (kadrPK <= 0)
                return string.Empty;

            var kadr = _uow.repoKadr.Get(kadrPK);
            if (kadr == null)
                return String.Empty;

            return kadr.NameFull;
        }

        public Kadr GetKadr(long kadrPK)
        {
            if (kadrPK <= 0)
                return null;

            var kadr = _uow.repoKadr.Get(kadrPK);

            return kadr;
        }

        public Schedule GetScheduler(long kadrPK, int weekNum, long currentUserId)
        {
            var result = new Schedule();

            var firstMondayEducYear = DateTime.Parse(firstMonday);
            //если указан номер недели - парсим
            if (weekNum < 0)
            {
                result.ErrorDescription = "Номер тиждня має бути цілим числом";
                return result;
            }
            else if (weekNum == 0)
            {
                //номер недели не указан - высчитываем номер текущей недели от сегодняшней даты
                var findDate = firstMondayEducYear;
                weekNum = 0;
                while (true)
                {
                    weekNum += 1;

                    findDate = findDate.AddDays(7);
                    if (findDate > DateTime.Today)
                        break;
                }
            }

            var kadr = _uow.repoKadr.Get(kadrPK);
            if (kadr == null || kadr.PK <= 0)
            {
                result.ErrorDescription = "За кодом " + kadrPK + " викладача не знайдено.";
                return result;
            }
            else
            {
                var sql = ""; //строка запроса на расписание (в зависимости от человека - студент или выкладач)
                long groupID = 0;

                //определяем данные основной посады
                //var lastMov = kadr.Moving_Last_Main();
                var mov = _uow.repoMoving.GetLastMainByKadr(kadr.PK);

                //для выкладачей
                {
                    var educYearBegin = firstMondayEducYear.Year;

                    sql = "exec dbo.usp_Schedule_jrn_2015   @YearEduc=" +
                          educYearBegin + ", @EducYearBegin=" + educYearBegin +
                          ", @DateCalc='" +
                          DateTime.Now.ToString("yyyyMMdd HH:mm:ss") +
                          "', @SemesterEducYear=0, @IdKafedra=0, @IdEducPlanSpec=0, @IdKadr=" +
                          kadrPK +
                          ", @IdGrup=0, @forAuditory=1, @IdDiscipinesDistrib=0, @WeekNum=" +
                          weekNum +
                          ", @GrupSub=-1, @IdAuditory=-1, @firstMondayEducYear='" +
                          firstMondayEducYear.ToString("yyyyMMdd") +
                          " 12:00:00', @IdKadr_us=3";

                    var schedule = _uow.repoSchedule.GetScheduleForTeacher(sql, false);

                    result.KadrPK = kadr.PK;
                    result.KadrFullName = kadr.NameFull;
                    result.weekNum = weekNum;
                    result.weekFrom = GetMondayOfWeek(weekNum);
                    result.weekTo = result.weekFrom.AddDays(6);
                    result.IsTeacher = true;
                    result.ScheduleDatas.AddRange(schedule);

                }
                if (_uow.repoMoving.IsStudent(kadr.PK)) //если он ещё и студент
                {

                    //ищем активное перемещение, в котором он студент, для получения группы студента
                    //var dt1 = kadr.MovingListActive;
                    var studMovings = _uow.repoMoving.GetAllActiveByKadr(kadr.PK);
                    foreach (var moving in studMovings)
                    {
                        if (moving.PosadaFK == 3)
                        {

                            groupID = moving.DivisionFK;// .DivissionID;

                            var educYearBegin = firstMondayEducYear.Year;

                            var semestr = 1;
                            if (DateTime.Today.Year > educYearBegin)
                                semestr = 2;

                            sql =
                                "exec dbo.usp_Schedule_jrn   @EducYearBegin=" +
                                educYearBegin + ", @SemesterEducYear=" +
                                semestr +
                                ", @IdKafedra=0, @IdEducPlanSpec=0, @IdKadr=-1, @IdGrup=" +
                                groupID +
                                ", @forAuditory=1, @IdDiscipinesDistrib=0, @WeekNum=" +
                                weekNum +
                                ", @GrupSub=-1, @IdAuditory=-1, @firstMondayEducYear='" +
                                firstMondayEducYear.ToString("yyyyMMdd") +
                                " 12:00:00', @IdKadr_us=3";

                            var schedule = _uow.repoSchedule.GetScheduleForTeacher(sql, true);

                            result.IsStud = true;
                            result.ScheduleDatas.AddRange(schedule);
                        }
                    }

                }
            }

            _uow.repoLog.AddLog(
                currentUserId, 
                "BlazorSite", 
                kadrPK,
                $"Запрос расписания для кода '{kadrPK}' неделя {weekNum}", 
                string.Empty, 
                string.Empty);
            return result;
        }


        private DateTime GetMondayOfWeek(int weekNum)
        {
            var firstMondayEducYear = DateTime.Parse(firstMonday);
            var findDate = firstMondayEducYear;
            int weekCalc = 0;
            while (weekCalc < weekNum)
            {
                weekCalc += 1;
                findDate = findDate.AddDays(7);
            }

            return findDate.AddDays(-7).Date;
        }

        public List<Kadr> GetGroupStudentList(long groupPK)
        {
            if (groupPK <= 0)
                return new List<Kadr>();

            return _uow.repoGroup.GetGroupList(groupPK);
        }

        public Group GetGroup(long groupPK)
        {
            return _uow.repoGroup.Get(groupPK);
        }

        public void RegisterSiteQuerySchedule(string kadr, string week, long currentUserId)
        {
            _uow.repoLog.AddLog(currentUserId, "BlazorSite", 0, "Запрос расписания", $"kadr - {kadr}", $"week - {week}");

            //_uow.repoSchedule.RegisterSiteQuerySchedule(kadr, week);
        }
        public void RegisterSiteQueryGroupList(string kadr, long groupPK, long currentUserId)
        {
            _uow.repoLog.AddLog(currentUserId, "BlazorSite", groupPK, "Запрос списка группы", $"kadr - {kadr}", $"groupPK - {groupPK}");
            //_uow.repoSchedule.RegisterSiteQueryGroupList(kadr, groupPK);
        }

        public ExcelPackage GetGroupListFile(long groupPK)
        {
            var group = _uow.repoGroup.Get(groupPK);
            if (group == null || group.IsDel)
                return null;

            var groupList = _uow.repoGroup.GetGroupList(groupPK);
            if (groupList == null || !groupList.Any())
                return null;

            var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add($"ПДАА");

            worksheet.Cells["A1:A1"].Value = $"{group.NameAutoAll}";
            worksheet.Cells["A1:B1"].Merge = true;
            worksheet.Cells["A1:B1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            var headerRow = worksheet.Cells["A1:B1"];
            var cellFont = headerRow.Style.Font;
            cellFont.SetFromFont(new Font("Times New Roman", 12));
            cellFont.Bold = true;
            cellFont.Italic = false;

            // Use LINQ to project data into the worksheet
            var tableBody = worksheet.Cells["A3:A3"].LoadFromCollection(
                (from f in groupList
                 select f).ToList().Select((x, index) => new { Index = index + 1, x.NameFull }), false);

            tableBody.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            //tableBody.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //tableBody.Style.Fill.BackgroundColor.SetColor(Color.White);
            tableBody.Style.Border.BorderAround(ExcelBorderStyle.Medium);
            tableBody.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            tableBody.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            tableBody.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            tableBody.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            tableBody.AutoFitColumns();

            //// Add conditional formatting based on temperature
            //var temperatureCol = tableBody.Offset(1, 1, forecasts.Length, 1);
            //var rule = temperatureCol.ConditionalFormatting.AddThreeColorScale();
            //rule.LowValue.Color = Color.SkyBlue;
            //rule.MiddleValue.Color = Color.White;
            //rule.HighValue.Color = Color.Red;

            //// Add Temperature (F) computed via formula
            //worksheet.Cells[3, 4, forecasts.Length + 2, 4].Formula = "C3 * 1.8 + 32";
            //worksheet.Calculate();

            // Formatting
            //var header = worksheet.Cells["B2:E2"];
            //worksheet.DefaultColWidth = 25;
            ////worksheet.Cells[3, 2, groupList.Count + 2, 2].Style.Numberformat.Format = "DDD d MMM yyyy";
            //tableBody.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            //tableBody.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //tableBody.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //tableBody.Style.Border.BorderAround(ExcelBorderStyle.Medium);
            //header.Style.Font.Bold = true;
            //header.Style.Font.Color.SetColor(Color.White);
            //header.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);

            worksheet.Cells["A1:A1"].Value = $"{group.NameAutoAll}";
            worksheet.Cells["A1:B1"].Merge = true;


            worksheet.Cells[groupList.Count + 4, 1].Value =
                $"Список групи ПДДА станом на {DateTime.Now.ToString():dd.MM.yyyy HH:mm}";
            worksheet.Cells[groupList.Count + 5, 1].Value = "(с) АСУ ПДАА, 2019";
            var footerRow = worksheet.Cells[groupList.Count + 4, 1, groupList.Count + 5, 2];
            var footerFont = footerRow.Style.Font;
            footerFont.SetFromFont(new Font("Times New Roman", 8));
            footerFont.Bold = false;
            footerFont.Italic = false;




            return package;
        }

        public ExcelPackage GetJournalEmptyDaysFile(long schedulePK, long groupPK)
        {
            var schedule = _uow.repoSchedule.GetScheduleJrn(schedulePK);
            if (schedule == null || schedule.IsDel)
                return null;

            var disciplineDistrib = _uow.repoSchedule.GetDiscipinesDistribJrn(schedule.IdDiscipinesDistrib);
            if (disciplineDistrib == null || disciplineDistrib.IsDel)
                return null;

            var disciplineJrn = _uow.repoSchedule.GetDiscipinesJrn(disciplineDistrib.IdDisciplines_jrn);
            if (disciplineJrn == null || disciplineJrn.IsDel)
                return null;

            var discipline = _uow.repoSchedule.GetDiscipine(disciplineJrn.IdDisciplines);
            if (discipline == null || discipline.IsDel)
                return null;

            var group = _uow.repoGroup.Get(groupPK);
            if (group == null || group.IsDel)
                return null;

            var groupList = _uow.repoGroup.GetGroupList(groupPK);
            if (groupList == null || !groupList.Any())
                return null;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var package = new ExcelPackage();
            int yStart = 1;
            int xMax = 29;
            string xMaxColumnName = "AC";


            var worksheet = package.Workbook.Worksheets.Add($"Журнал ПДАА");

            int y = yStart;

            #region Шапка журнала 

            worksheet.Cells["A" + y + ":A" + y].Value = "1. Результати поточного та семестрового контролю";
            worksheet.Cells["A" + y + ":" + xMaxColumnName + y].Merge = true;
            worksheet.Cells["A" + y + ":A" + y].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            y += 1;
            y += 1;

            worksheet.Cells["A" + y + ":A" + y].Value = $"Назва навчальної дисципліни {discipline.DisciplinesName}";
            worksheet.Cells["A" + y + ":" + xMaxColumnName + y].Merge = true;
            worksheet.Cells["A" + y + ":A" + y].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            y += 1;

            worksheet.Cells["A" + y + ":A" + y].Value = $"Шифр курсу _____________________________ ";
            worksheet.Cells["A" + y + ":E" + y].Merge = true;
            worksheet.Cells["A" + y + ":E" + y].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

            worksheet.Cells["G" + y + ":G" + y].Value = $"Код групи {group.NameAutoAll}";
            worksheet.Cells["G" + y + ":T" + y].Merge = true;
            worksheet.Cells["G" + y + ":T" + y].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


            #endregion

            y += 2;

            #region Шапка таблицы

            worksheet.Cells["A" + y + ":A" + (y + 1)].Value = "№ з/п";
            worksheet.Cells["A" + y + ":A" + (y + 1)].Merge = true;
            worksheet.Cells["A" + y + ":A" + (y + 1)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["A" + y + ":A" + (y + 1)].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells["A" + y + ":A" + (y + 1)].Style.WrapText = true;
            worksheet.Column(1).Width = 3;

            worksheet.Cells["B" + y + ":B" + (y + 1)].Value = "Прізвище та ініціали здобувача вищої освіти";
            worksheet.Cells["B" + y + ":B" + (y + 1)].Merge = true;
            worksheet.Cells["B" + y + ":B" + (y + 1)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["B" + y + ":B" + (y + 1)].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells["B" + y + ":B" + (y + 1)].Style.WrapText = true;
            worksheet.Column(2).Width = 25;

            worksheet.Cells["C" + y + ":Z" + y].Value = "Облік відвідування та результати поточного контролю";
            worksheet.Cells["C" + y + ":Z" + y].Merge = true;
            worksheet.Cells["C" + y + ":Z" + y].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["C" + y + ":Z" + y].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Row(y).Height = 60;
            worksheet.Cells["Z" + (y + 1) + ":Z" + (y + 1)].Value = "Всього";
            worksheet.Cells["Z" + (y + 1) + ":Z" + (y + 1)].Style.WrapText = true;
            worksheet.Row(y + 1).Height = 60;

            for (int i = 3; i < 30; i++)
            {
                worksheet.Column(i).Width = 3;
            }

            worksheet.Cells["AA" + y + ":AC" + y].Value = "Підсумок семестрового контролю";
            worksheet.Cells["AA" + y + ":AC" + y].Merge = true;
            worksheet.Cells["AA" + y + ":AC" + y].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            worksheet.Cells["AA" + y + ":AC" + y].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells["AA" + y + ":AC" + y].Style.WrapText = true;
            worksheet.Cells["AA" + (y + 1) + ":AA" + (y + 1)].Value = "к – ть балів";
            worksheet.Cells["AA" + (y + 1) + ":AA" + (y + 1)].Style.WrapText = true;
            worksheet.Cells["AB" + (y + 1) + ":AB" + (y + 1)].Value = "Є К Т С";
            worksheet.Cells["AB" + (y + 1) + ":AB" + (y + 1)].Style.WrapText = true;
            worksheet.Cells["AC" + (y + 1) + ":AC" + (y + 1)].Value = "О ц і н к а";
            worksheet.Cells["AC" + (y + 1) + ":AC" + (y + 1)].Style.WrapText = true;

            var tableHeaderRows = worksheet.Cells["A" + y + ":AC" + (y + 1)];
            var cellFont = tableHeaderRows.Style.Font;
            cellFont.SetFromFont(new Font("Times New Roman", 10));
            cellFont.Bold = false;
            cellFont.Italic = false;

            tableHeaderRows.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            tableHeaderRows.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            tableHeaderRows.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            tableHeaderRows.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            tableHeaderRows.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            #endregion

            #region таблица учащихся

            y += 2;

            // Use LINQ to project data into the worksheet
            var tableBody = worksheet.Cells["A" + y + ":A" + y].LoadFromCollection(
                (from f in groupList
                 select f).ToList().Select((x, index) => new { Index = index + 1, x.NameShort }), false);

            var tableRows = worksheet.Cells["A" + y + ":AC" + (y + groupList.Count - 1)];
            var cellFont1 = tableRows.Style.Font;
            cellFont1.SetFromFont(new Font("Times New Roman", 10));
            cellFont1.Bold = false;
            cellFont1.Italic = false;

            tableRows.Style.Border.BorderAround(ExcelBorderStyle.Thin);
            tableRows.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            tableRows.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            tableRows.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            tableRows.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            #endregion

            // Set printer settings
            worksheet.PrinterSettings.PaperSize = ePaperSize.A4;
            worksheet.PrinterSettings.Orientation = eOrientation.Portrait;
            worksheet.PrinterSettings.FitToPage = true;
            worksheet.PrinterSettings.FitToHeight = 1;
            worksheet.PrinterSettings.FooterMargin = .05M;
            worksheet.PrinterSettings.TopMargin = .05M;
            worksheet.PrinterSettings.LeftMargin = .05M;
            worksheet.PrinterSettings.RightMargin = .05M;

            /*
            var headerRow = worksheet.Cells["A1:B1"];
            var cellFont = headerRow.Style.Font;
            cellFont.SetFromFont(new Font("Times New Roman", 12));
            cellFont.Bold = true;
            cellFont.Italic = false;

            // Use LINQ to project data into the worksheet
            var tableBody = worksheet.Cells["A3:A3"].LoadFromCollection(
                (from f in groupList
                 select f).ToList().Select((x, index) => new { Index = index + 1, x.NameFull }), false);

            tableBody.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            //tableBody.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //tableBody.Style.Fill.BackgroundColor.SetColor(Color.White);
            tableBody.Style.Border.BorderAround(ExcelBorderStyle.Medium);
            tableBody.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            tableBody.Style.Border.Left.Style = ExcelBorderStyle.Thin;
            tableBody.Style.Border.Right.Style = ExcelBorderStyle.Thin;
            tableBody.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            tableBody.AutoFitColumns();

            //// Add conditional formatting based on temperature
            //var temperatureCol = tableBody.Offset(1, 1, forecasts.Length, 1);
            //var rule = temperatureCol.ConditionalFormatting.AddThreeColorScale();
            //rule.LowValue.Color = Color.SkyBlue;
            //rule.MiddleValue.Color = Color.White;
            //rule.HighValue.Color = Color.Red;

            //// Add Temperature (F) computed via formula
            //worksheet.Cells[3, 4, forecasts.Length + 2, 4].Formula = "C3 * 1.8 + 32";
            //worksheet.Calculate();

            // Formatting
            //var header = worksheet.Cells["B2:E2"];
            //worksheet.DefaultColWidth = 25;
            ////worksheet.Cells[3, 2, groupList.Count + 2, 2].Style.Numberformat.Format = "DDD d MMM yyyy";
            //tableBody.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            //tableBody.Style.Fill.PatternType = ExcelFillStyle.Solid;
            //tableBody.Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
            //tableBody.Style.Border.BorderAround(ExcelBorderStyle.Medium);
            //header.Style.Font.Bold = true;
            //header.Style.Font.Color.SetColor(Color.White);
            //header.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);

            worksheet.Cells["A1:A1"].Value = $"{groupName}";
            worksheet.Cells["A1:B1"].Merge = true;


            worksheet.Cells[groupList.Count + 4, 1].Value = $"Список групи ПДДА станом на {DateTime.Now.ToString():dd.MM.yyyy HH:mm}";
            worksheet.Cells[groupList.Count + 5, 1].Value = "(с) АСУ ПДАА, 2019";
            var footerRow = worksheet.Cells[groupList.Count + 4, 1, groupList.Count + 5, 2];
            var footerFont = footerRow.Style.Font;
            footerFont.SetFromFont(new Font("Times New Roman", 8));
            footerFont.Bold = false;
            footerFont.Italic = false;*/

            return package;


        }
    }
}
