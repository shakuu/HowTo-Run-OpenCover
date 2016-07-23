namespace AutomateGenerateCoverage.Utils
{
    using System;
    using System.IO;

    using AutomateGenerateCoverage.Contracts;

    public class Validator : IValidate
    {
        public bool CheckIfFileExistsAtInputPath(string inputPath)
        {
            return File.Exists(inputPath);
        }

        public bool CheckIfFolderExistsAtInputPath(string inputPath)
        {
            return Directory.Exists(inputPath);
        }

        public bool CheckIfObjectIsNull(object obj)
        {
            return obj == null;
        }

        public bool CheckIfStringIsNullOrEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
