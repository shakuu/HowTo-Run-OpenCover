namespace AutomateGenerateCoverage.Models.Reports.FolderManagers
{
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports.Abstract;

    public class BasicFolderManager : ReportValidatorProvider, IFolderManager
    {
        private const string ReportsSubfolder = "\\reports";

        private FileInfo rootFolder;

        public BasicFolderManager(string reportsRootFolder)
        {
            var reportsRootFolderFileInfo = this.ConverToFileInfo(reportsRootFolder);
            this.RootFolder = reportsRootFolderFileInfo;
        }

        public BasicFolderManager(IValidate validator)
            : base(validator)
        {
        }

        private FileInfo RootFolder
        {
            get
            {
                return this.rootFolder;
            }

            set
            {
                this.rootFolder = value;
            }
        }

        public string GetNextReportFolder()
        {
            var nextReportFolder = this.RootFolder + BasicFolderManager.ReportsSubfolder;

            if (Directory.Exists(nextReportFolder))
            {
                Directory.Delete(nextReportFolder, true);
            }

            Directory.CreateDirectory(nextReportFolder);

            return nextReportFolder;
        }
    }
}
