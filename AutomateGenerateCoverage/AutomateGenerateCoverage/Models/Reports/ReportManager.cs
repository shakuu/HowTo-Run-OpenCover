namespace AutomateGenerateCoverage.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Contracts.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.Reports.Abstract;
    using AutomateGenerateCoverage.Models.BatchFileGenerating;
    using AutomateGenerateCoverage.Models.IO;
    using AutomateGenerateCoverage.Utils;

    public class ReportManager : ReportValidatorProvider, IReportManager
    {
        private const string RunTestsFileName = "\\RunTests.bat";
        private const string GetReportFileName = "\\GetReport.bat";
        private const string IndexHtmFileName = "\\index.htm";

        private HashSet<IReport> reports = new HashSet<IReport>();

        private IFolderManager folderManager;

        public ReportManager(IFolderManager folderManager)
        {
            this.FolderManger = folderManager;
        }

        public ReportManager(IFolderManager folderManager, IValidate validator)
            : base(validator)
        {
            this.FolderManger = folderManager;
        }

        private IFolderManager FolderManger
        {
            get
            {
                return this.folderManager;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(this.FolderManger));
                }

                this.folderManager = value;
            }
        }

        public ICollection<IReport> AllReports
        {
            get
            {
                if (this.reports == null)
                {
                    this.reports = new HashSet<IReport>();
                }

                return this.reports;
            }
        }

        public IReport GenerateReport(string testingDllDirectory)
        {
            var testingDllDirectoryFileInfo = ConvertToFileInfo(testingDllDirectory);
            var targetDirectory = this.FolderManger.GetNextReportFolder();
            var batFilesDirectory = this.FolderManger.GetNextBatFilesFolder();
            var outputFileNames = this.GetFileNames(batFilesDirectory);

            var batchFileGenerator = this.InitializeBatchFileGenerator();

            var outputFiles = batchFileGenerator.GenereteBatchFiles(
                testingDllDirectoryFileInfo.FullName,
                targetDirectory,
                outputFileNames);
            
            var currentReport = this.GenerateReport(batFilesDirectory + ReportManager.GetReportFileName, targetDirectory);

            this.reports.Add(currentReport);
            return currentReport;
        }

        private IReport GenerateReport(string testingDllDirectory, string targetDirectory)
        {
            var newReport = new Report(testingDllDirectory, targetDirectory + ReportManager.IndexHtmFileName);
            return newReport;
        }

        private IList<string> GetFileNames(string targetDirectory)
        {
            var outputFileNames = new List<string>();

            outputFileNames.Add(targetDirectory + ReportManager.RunTestsFileName);
            outputFileNames.Add(targetDirectory + ReportManager.GetReportFileName);

            return outputFileNames;
        }

        private IBatchFileGenerator InitializeBatchFileGenerator()
        {
            var packageTypeTranslator = new BasicNugetPackageTypeTranslator();
            var batchFileLineParameterTypeTranslator = new BasicBatchFileLineParameterTypeTranslator();

            var fileWriter = new FileWriter();
            var rootPathFinder = new RootPathFinder();
            var executablePathFinder = new PackageExecutablePathFinder(packageTypeTranslator);
            var batchFileLineGenerator = new BatchFileLineGenerator(batchFileLineParameterTypeTranslator);

            var batchFileGenerator = new BatchFileGenerator(
                fileWriter,
                rootPathFinder,
                executablePathFinder,
                batchFileLineGenerator);

            return batchFileGenerator;
        }

        protected override FileInfo ConvertToFileInfo(string path)
        {
            if (base.Validator.CheckIfStringIsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            if (!base.Validator.CheckIfFileExistsAtInputPath(path))
            {
                throw new FileNotFoundException(path);
            }

            var result = new FileInfo(path);
            return result;
        }
    }
}
