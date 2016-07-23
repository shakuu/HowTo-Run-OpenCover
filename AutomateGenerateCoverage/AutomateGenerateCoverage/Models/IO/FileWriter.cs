namespace AutomateGenerateCoverage.Models.IO
{
    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Text;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models.Abstract;

    public class FileWriter : ValidatorProvider, IFileWriter
    {
        public FileWriter()
        {
        }

        public FileWriter(IValidate validator)
            : base(validator)
        {
        }

        public bool WriteToFile(string fullFileNameWithPath, IEnumerable dataToWrite)
        {
            this.ValidateInputParameters(fullFileNameWithPath, dataToWrite);

            try
            {
                using (var writer = new StreamWriter(fullFileNameWithPath))
                {
                    foreach (var item in dataToWrite)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void ValidateInputParameters(string fullFileNameWithPath, IEnumerable dataToWrite)
        {
            if (base.Validator.CheckIfStringIsNullOrEmpty(fullFileNameWithPath))
            {
                throw new ArgumentNullException(nameof(fullFileNameWithPath));
            }

            if (base.Validator.CheckIfObjectIsNull(dataToWrite))
            {
                throw new ArgumentNullException(nameof(dataToWrite));
            }

            var fileNameAsArray = fullFileNameWithPath.Split('\\');
            var directoryPath = string.Join("\\", fileNameAsArray.Take(fileNameAsArray.Length - 1));

            if (!base.Validator.CheckIfFolderExistsAtInputPath(directoryPath))
            {
                throw new DirectoryNotFoundException(fullFileNameWithPath);
            }

            foreach (var item in dataToWrite)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(item));
                }
            }
        }
    }
}
