namespace AutomateGenerateCoverage.Contracts
{
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts.Reports;

    public interface IReportManager
    {
        ICollection<FileInfo> GenerateReport(string testingDllDirectory);

        ICollection<IReport> GetAllReports();
    }
}
