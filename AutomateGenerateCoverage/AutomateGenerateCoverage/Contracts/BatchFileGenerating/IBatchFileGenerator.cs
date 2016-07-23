namespace AutomateGenerateCoverage.Contracts.BatchFileGenerating
{
    using System.Collections.Generic;
    using System.IO;

    public interface IBatchFileGenerator
    {
        IEnumerable<FileInfo> GenereteBatchFiles(string inputPathToTestingLibrary);
    }
}
