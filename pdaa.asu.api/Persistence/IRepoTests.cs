using System.Collections.Generic;
using pdaa.asu.api.Persistence.DataModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoTests
    {
        //void Create(Kadr kadr);
        //void Delete(int id);
        //void Update(Kadr kadr);

        string GetQuestion(long id);
        List<long> GetAnswerIdsForQuestion(long questionId);
        string GetAnswer(long id);
        List<Test_Shablon> GetShablons(long kadrId, long kadrDivisionId, long kadrPosadaId);
        Test_ShablonDetail GetShablonDetail(long id);
        long StartTestJrnl(Test_ShablonDetail shablon, long currentUserId, long kadrDivisionId, long kadrPosadaId);
        List<Test_StartedTestQuestion> GetQuestionsForTest(long startTestShablonId, long shablonId);
        List<Test_StartedTestAnswer> GetStartedTestQestionAnswers(long startTestShablonId, long questionId);
        void SetStartedTestQuestionAnswer(long testAnswerId, int answerFlFakt, long currentUserId);
        void CheckTest(long startTestShablonId, long shablonId);
        string GetTestResult(long startTestShablonId);
    }
}
