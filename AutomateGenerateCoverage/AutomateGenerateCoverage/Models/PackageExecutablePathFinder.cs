namespace AutomateGenerateCoverage.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models.Abstract;
    using AutomateGenerateCoverage.Enums;

    public class PackageExecutablePathFinder : PathFinder, IExecutablePathFinder
    {
        ITypeTranslator nugetPackageTypeTranslator;

        public PackageExecutablePathFinder(ITypeTranslator translator)
        {
            this.NugetPackageTypeTranslator = translator;
        }

        public PackageExecutablePathFinder(ITypeTranslator translator, IValidate validator)
            : base(validator)
        {
            this.NugetPackageTypeTranslator = translator;
        }

        private ITypeTranslator NugetPackageTypeTranslator
        {
            get
            {
                if (this.nugetPackageTypeTranslator == null)
                {
                    //this.nugetPackageTypeTranslator = new ? 
                }

                return this.nugetPackageTypeTranslator;
            }

            set
            {
                this.nugetPackageTypeTranslator = value;
            }
        }

        public string FindPathToExecutable(NugetPackageType nugetPackageTypeValue, string projectRootDirectory)
        {
            string pathToExecutableIncludingExecutableName = null;

            if (base.Validator.CheckIfStringIsNullOrEmpty(projectRootDirectory))
            {
                throw new ArgumentNullException(nameof(projectRootDirectory));
            }

            if (!base.Validator.CheckIfFolderExistsAtInputPath(projectRootDirectory))
            {
                throw new DirectoryNotFoundException(projectRootDirectory);
            }

            var executableFileName = this.NugetPackageTypeTranslator.GetTranslatedValue((int)nugetPackageTypeValue);

            throw new NotImplementedException();
        }

        private bool Search(string executableFileName, string currentPath, out string pathToExecutablepathToExecutableIncludingExecutableName)
        {
            var allFilesInCurrentDirectory = Directory.GetFiles(currentPath);
            var allFoldersInCurrentDirectory = Directory.GetDirectories(currentPath);

            foreach (var file in allFilesInCurrentDirectory)
            {
                var fileName = file.Split('\\').LastOrDefault();

                if (fileName == null)
                {
                    continue;
                }
                else if (fileName.Contains(executableFileName))
                {

                }
            }

            throw new NotImplementedException();
        }
    }
}
