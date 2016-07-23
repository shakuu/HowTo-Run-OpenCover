namespace AutomateGenerateCoverage.Models.Reports
{
    using System;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Abstract;

    public class Report : ValidatorProvider, IReport
    {
        private FileInfo testingDll;
        private FileInfo reportHTML;

        public Report(string testingDllLocation, string reportHTMLLocation)
        {
            var testingDllLocationFileInfo = this.ConverToFileInfo(testingDllLocation);
            var reportHTMLLocationFileInfo = this.ConverToFileInfo(reportHTMLLocation);

            this.TestingDLL = testingDllLocationFileInfo;
            this.ReportHTML = reportHTMLLocationFileInfo;
        }

        public Report(string testingDllLocation, string reportHTMLLocation, IValidate validator)
            : base(validator)
        {
            var testingDllLocationFileInfo = this.ConverToFileInfo(testingDllLocation);
            var reportHTMLLocationFileInfo = this.ConverToFileInfo(reportHTMLLocation);

            this.TestingDLL = testingDllLocationFileInfo;
            this.ReportHTML = reportHTMLLocationFileInfo;
        }

        public FileInfo TestingDLL
        {
            get
            {
                return this.testingDll;
            }

            private set
            {
                this.testingDll = value;
            }
        }

        public FileInfo ReportHTML
        {
            get
            {
                return reportHTML;
            }

            private set
            {
                this.reportHTML = value;
            }
        }

        private FileInfo ConverToFileInfo(string path)
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
