namespace AutomateGenerateCoverage.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports.Abstract;

    public class ReportManager : ReportValidatorProvider, IReportManager
    {
        private const string RunTestsFileName = "RunTests.bat";
        private const string GetReportFileName = "GetReport.bat";
        private const string IndexHtmFileName = "index.htm";

        private HashSet<IReport> reports = new HashSet<IReport>();
        private FileInfo rootDirectory;

        public ReportManager(string reportsRootDirectory)
        {
            var reportsRootDirectoryFileInfo = base.ConverToFileInfo(reportsRootDirectory);

            this.RootDirectory = reportsRootDirectoryFileInfo;
        }

        public ReportManager(string reportsRootDirectory, IValidate validator)
            : base(validator)
        {
            var reportsRootDirectoryFileInfo = base.ConverToFileInfo(reportsRootDirectory);

            this.RootDirectory = reportsRootDirectoryFileInfo;
        }

        private FileInfo RootDirectory
        {
            get
            {
                return this.rootDirectory;
            }

            set
            {
                this.rootDirectory = value;
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

        public ICollection<FileInfo> GenerateReport(string testingDllDirectory)
        {
            var testingDllDirectoryFileInfo = ConverToFileInfo(testingDllDirectory);

            throw new NotImplementedException();
        }

        protected override FileInfo ConverToFileInfo(string path)
        {
            if (base.Validator.CheckIfStringIsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }

            if (!base.Validator.CheckIfFolderExistsAtInputPath(path))
            {
                throw new DirectoryNotFoundException(path);
            }

            var result = new FileInfo(path);
            return result;
        }
    }
}
