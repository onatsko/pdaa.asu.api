using System.Collections.Generic;
using pdaa.asu.api.Persistence;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Services
{
    public class ServiceTests
    {
        private IUnitOfWork _uow;

        public ServiceTests(IUnitOfWork uow)
        {
            _uow = uow;
        }

        //private string GetHtmlFromRtf(string rtf)
        //{
        //      //using RtfPipe;
        //    return Rtf.ToHtml(rtf);
        //}

        //private string GetHtmlFromRtf(string rtf)
        //{
        //    SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();

        //    // Let's store all images inside the HTML document.
        //    r.ImageStyle.IncludeImageInHtml = true;

        //    string htmlString = r.ConvertString(rtf);

        //    var toDel = "<div style=\"text-align:center;\">The trial version of &laquo;RTF to HTML .Net&raquo; can convert up to 10000 symbols.<br><a href=\"https://www.sautinsoft.com/products/rtf-to-html/order.php\">Get the full featured version!</a></div>";
        //    return htmlString.Replace(toDel, "");
        //}



        public string GetQuestion(long id)
        {
            var html = _uow.repoTests.GetQuestion(id);
            if (html == null)
                return string.Empty;

            //2020-05-19 уже заранее сделана конвертация в базе в поле [QuestionPicHtml] из поля [QuestionPicRtf]


            //#if NETCORE
            //  // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
            //  Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //#endif

            //var html = GetHtmlFromRtf(rtf);

            return html;
        }

        public List<string> GetAnswers(long questionId)
        {
            var answerIds = _uow.repoTests.GetAnswerIdsForQuestion(questionId);
            if (answerIds == null)
                return new List<string>();

#if NETCORE
              // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
              Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
#endif

            var result = new List<string>();
            foreach(var a in answerIds)
            {
                var answerHtml = _uow.repoTests.GetAnswer(a);
                if (!string.IsNullOrWhiteSpace(answerHtml))
                    result.Add(answerHtml);
            }

            return result;
        }

        public List<Test_Shablon> GetShablons(long kadrId, long kadrDivisionId, long kadrPosadaId)
        {
            return _uow.repoTests.GetShablons(kadrId, kadrDivisionId, kadrPosadaId);
        }

        public Test_ShablonDetail GetShablonDetail(long id)
        {
            return _uow.repoTests.GetShablonDetail(id);
        }

        public long StartTest(Test_ShablonDetail shablon, long currentUserId, long currentUserDivisionId, long currentUserPosadaId)
        {
            return _uow.repoTests.StartTestJrnl(shablon, currentUserId, currentUserDivisionId, currentUserPosadaId);
        }

        public List<Test_StartedTestQuestion> GetStartTestQuestions(long startTestShablonId, long shablonId, long currentUserId)
        {
            var questions = _uow.repoTests.GetQuestionsForTest(startTestShablonId, shablonId);

            foreach (var q in questions)
            {
                q.QuestionHtml = _uow.repoTests.GetQuestion(q.QuestionId);
            }

            return questions;
        }

        public List<Test_StartedTestAnswer> GetStartedTestQuestionAnswers(long startTestShablonId, long questionId)
        {
            var answers = _uow.repoTests.GetStartedTestQestionAnswers(startTestShablonId, questionId);
            foreach (var a in answers)
            {
               a.AnswerHtml = _uow.repoTests.GetAnswer(a.IdAnswer);
            }

            return answers;
        }

        public void SetStartedTestQuestionAnswer(long testAnswerId, int answerFlFakt, long currentUserId)
        {
            _uow.repoTests.SetStartedTestQuestionAnswer(testAnswerId, answerFlFakt, currentUserId);
        }

        public void CheckTest(long startTestShablonId, long shablonId)
        {
            _uow.repoTests.CheckTest(startTestShablonId, shablonId);
        }

        public string GetTestResult(long startTestShablonId)
        {
            return _uow.repoTests.GetTestResult(startTestShablonId);
        }
    }
}
