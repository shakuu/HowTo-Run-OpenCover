namespace AutomateGenerateCoverage.Models.Reports.FolderManagers
{
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports.Abstract;

    public class BasicFolderManager : ReportValidatorProvider, IFolderManager
    {
        private const string BatFilesSubfolder = "\\reports";
        private const string ReportSubfolder = "\\reports\\report";


        private FileInfo rootFolder;

        public BasicFolderManager(string reportsRootFolder)
        {
            var reportsRootFolderFileInfo = this.ConvertToFileInfo(reportsRootFolder);
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
            var nextReportFolder = this.RootFolder + BasicFolderManager.ReportSubfolder;

            if (Directory.Exists(nextReportFolder))
            {
                Directory.Delete(nextReportFolder, true);
            }

            Directory.CreateDirectory(nextReportFolder);

            return nextReportFolder;
        }

        public string GetNextBatFilesFolder()
        {
            var nextBatFilesFolder = this.RootFolder + BasicFolderManager.BatFilesSubfolder;

            if (Directory.Exists(nextBatFilesFolder))
            {
                Directory.Delete(nextBatFilesFolder, true);
            }

            Directory.CreateDirectory(nextBatFilesFolder);

            return nextBatFilesFolder;
        }
    }
}
