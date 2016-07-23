namespace AutomateGenerateCoverage.Contracts.Reports
{
    using System.IO;

    public interface IReport
    {
        FileInfo TestingDLL { get; }

        FileInfo ReportHTML { get; }
    }
}
