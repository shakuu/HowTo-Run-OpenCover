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

        public ICollection<FileInfo> GenerateReport(string testingDllDirectory)
        {
            var testingDllDirectoryFileInfo = ConverToFileInfo(testingDllDirectory);

            throw new NotImplementedException();
        }
    }
}
