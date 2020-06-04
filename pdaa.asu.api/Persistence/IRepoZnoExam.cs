using PDAA_cs.Common.DataModels;
using System.Collections.Generic;
using pdaa.asu.api.Services.ViewModels;

namespace pdaa.asu.api.Persistence
{
    public interface IRepoZno
    {
        List<ZnoExam> GetZnoExams();

        List<ZnoCalculatorResult> GetZnoCalculator(int year, long exam1Id, long exam2Id, long exam3Id, long exam4Id,
            long exam5Id);

        ZnoSpec GetSpec(long specForYearId);
    }
}
