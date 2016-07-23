namespace AutomateGenerateCoverage.Models
{
    using System;
    using System.IO;
    using System.Linq;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Models.Abstract;
    using AutomateGenerateCoverage.Enums;
    using AutomateGenerateCoverage.Utils;

    public class PackageExecutablePathFinder : ValidatorProvider, IExecutablePathFinder
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
                    this.nugetPackageTypeTranslator = new BasicNugetPackageTypeTranslator();
                }

                return this.nugetPackageTypeTranslator;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("PackageExecutablePathFinder.NugetPackageTypeTranslater");
                }

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

            var searchHasBeenSucssessful = this.Search(executableFileName, projectRootDirectory, out pathToExecutableIncludingExecutableName);

            if (!searchHasBeenSucssessful)
            {
                throw new FileNotFoundException(nugetPackageTypeValue.ToString());
            }

            return pathToExecutableIncludingExecutableName;
        }

        /// <summary>
        /// Recursive search through all directories till the file name is found.
        /// </summary>
        /// <param name="executableFileName"></param>
        /// <param name="currentPath"></param>
        /// <param name="pathToExecutableIncludingExecutableName"></param>
        /// <returns>string containing the full path to the file searched for</returns>
        private bool Search(string executableFileName, string currentPath, out string pathToExecutableIncludingExecutableName)
        {
            var fileHasBeenFound = false;

            pathToExecutableIncludingExecutableName = null;
            var allFilesInCurrentDirectory = Directory.GetFiles(currentPath);
            var allFoldersInCurrentDirectory = Directory.GetDirectories(currentPath);

            foreach (var file in allFilesInCurrentDirectory)
            {
                var fileName = file.Split('\\').LastOrDefault();

                if (fileName == null)
                {
                    continue;
                }
                else if (fileName == executableFileName)
                {
                    pathToExecutableIncludingExecutableName = file;
                    fileHasBeenFound = true;
                    return fileHasBeenFound;
                }
            }

            foreach (var folder in allFoldersInCurrentDirectory)
            {
                fileHasBeenFound = this.Search(executableFileName, folder, out pathToExecutableIncludingExecutableName);

                if (fileHasBeenFound)
                {
                    return fileHasBeenFound;
                }
            }

            return fileHasBeenFound;
        }
    }
}
