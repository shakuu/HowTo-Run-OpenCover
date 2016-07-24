namespace AutomateGenerateCoverage.Contracts.Reports
{
    using System.IO;

    public interface IReport
    {
        FileInfo RunTestsBAT { get; }

        FileInfo ReportHTML { get; }
    }
}
