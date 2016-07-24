namespace AutomateGenerateCoverage.Contracts
{
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts.Reports;

    public interface IReportManager
    {
        ICollection<IReport> AllReports { get; }

        IReport GenerateReport(string testingDllDirectory);
    }
}
