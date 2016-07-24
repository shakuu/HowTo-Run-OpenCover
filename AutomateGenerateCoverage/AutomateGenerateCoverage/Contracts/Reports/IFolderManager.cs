namespace AutomateGenerateCoverage.Contracts.Reports
{
    public interface IFolderManager
    {
        string GetNextReportFolder();

        string GetNextBatFilesFolder();
    }
}
