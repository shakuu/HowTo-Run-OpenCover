namespace AutomateGenerateCoverage.Models.Reports
{
    using System;
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
            var testingDllLocationFileInfo = this.ConvertToFileInfo(testingDllLocation);
            var reportHTMLLocationFileInfo = this.ConvertToFileInfo(reportHTMLLocation);

            this.TestingDLL = testingDllLocationFileInfo;
            this.ReportHTML = reportHTMLLocationFileInfo;
        }

        public Report(string testingDllLocation, string reportHTMLLocation, IValidate validator)
            : base(validator)
        {
            var testingDllLocationFileInfo = this.ConvertToFileInfo(testingDllLocation);
            var reportHTMLLocationFileInfo = this.ConvertToFileInfo(reportHTMLLocation);

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

        /// <summary>
        /// Validation causes errors
        /// .dll has been validated before
        /// .htm is not created yet
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected override FileInfo ConvertToFileInfo(string path)
        {
            //if (base.Validator.CheckIfStringIsNullOrEmpty(path))
            //{
            //    throw new ArgumentNullException();
            //}

            //if (!base.Validator.CheckIfFileExistsAtInputPath(path))
            //{
            //    throw new FileNotFoundException(path);
            //}

            var result = new FileInfo(path);
            return result;
        }
    }
}
