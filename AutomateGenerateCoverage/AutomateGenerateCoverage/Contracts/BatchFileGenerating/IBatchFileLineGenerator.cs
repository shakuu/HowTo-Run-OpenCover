namespace AutomateGenerateCoverage.Contracts.BatchFileGenerating
{
    using System.Collections.Generic;

    using AutomateGenerateCoverage.Enums;

    public interface IBatchFileLineGenerator 
    {
        string GenerateBatchFileLine(ICollection<BatchFileLineParameterType> parameters, ICollection<string> values);
    }
}
