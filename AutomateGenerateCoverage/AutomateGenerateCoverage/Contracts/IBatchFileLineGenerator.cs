namespace AutomateGenerateCoverage.Contracts
{
    using System.Collections.Generic;

    using AutomateGenerateCoverage.Enums;

    public interface IBatchFileLineGenerator
    {
        string GenerateBatchFileLine(IEnumerable<BatchFileLineParameterType> parameters, IEnumerable<string> values);
    }
}
