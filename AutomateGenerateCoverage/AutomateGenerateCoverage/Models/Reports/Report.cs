namespace AutomateGenerateCoverage.Models.Reports
{
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports.Abstract;

    // TODO: Overload GetHash()
    public class Report : ReportValidatorProvider, IReport
    {
        private FileInfo testingDll;
        private FileInfo reportHTML;

        public Report(string testingDllLocation, string reportHTMLLocation)
        {
            var testingDllLocationFileInfo = base.ConverToFileInfo(testingDllLocation);
            var reportHTMLLocationFileInfo = base.ConverToFileInfo(reportHTMLLocation);

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
    }
}
