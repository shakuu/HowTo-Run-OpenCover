namespace AutomateGenerateCoverage.Models.Reports.Abstract
{
    using System;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models.Abstract;

    public abstract class ReportValidatorProvider : ValidatorProvider
    {
        public ReportValidatorProvider()
        {

        }

        public ReportValidatorProvider(IValidate validator)
            : base(validator)
        {
        }

        protected virtual FileInfo ConverToFileInfo(string path)
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
