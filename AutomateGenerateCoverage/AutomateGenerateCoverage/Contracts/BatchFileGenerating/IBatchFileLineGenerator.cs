namespace AutomateGenerateCoverage.Contracts.BatchFileGenerating
{
    using System.Collections.Generic;

    using AutomateGenerateCoverage.Enums;

    public interface IBatchFileLineGenerator 
    {
        string GenerateBatchFileLine(IList<BatchFileLineParameterType> parameters, IList<string> values);
    }
}
