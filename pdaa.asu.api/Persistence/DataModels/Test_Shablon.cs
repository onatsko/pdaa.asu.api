namespace pdaa.asu.api.Persistence.DataModels
{
    public class Test_Shablon
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class Test_ShablonDetail
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int VidSysOcen { get; set; }
    }

    public class Test_StartedTestQuestion
    {
        public long QuestionId { get; set; }
        public long RowNumber { get; set; }
        public string QuestionHtml { get; set; }
    }

    public class Test_StartedTestAnswer
    {
        public long RowNumber { get; set; }
        public long IdTestAnswer { get; set; }
        public long IdAnswer { get; set; }
        public bool AnswerFl_fakt { get; set; }
        public string AnswerHtml { get; set; }
    }



}
