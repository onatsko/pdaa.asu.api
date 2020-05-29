using System.Collections.Generic;

namespace pdaa.asu.api.Persistence.DataModels
{
    public class LessonInfo
    {
        public long IdShedule { get; set; }
        public string DisciplinesName { get; set; }
        public string InfoDiscipline { get; set; } = "";
        public string InfoRoom { get; set; } = "";

        public bool HasTeacherInfo { get; set; } = false;
        public string InfoTeacherName { get; set; } = "";
        public long InfoTeacherId { get; set; } = 0;

        public bool HasGroupInfo { get; set; } = false;
        public List<string> InfoGroupName { get; set; } = new List<string>();
        public List<long> InfoGroupId { get; set; } = new List<long>();


    }
}
