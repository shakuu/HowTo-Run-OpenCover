namespace AutomateGenerateCoverage.Utils
{
    using System;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Enums;

    public class BasicNugetPackageTypeTranslator : ITypeTranslator
    {
        private const string NUnitFileName = "nunit3-console.exe";
        private const string OpenCoverFileName = "OpenCover.Console.exe";
        private const string ReportGeneratorFileName = "ReportGenerator.exe";

        public string GetTranslatedValue(int typeValue)
        {
            string associatedFileName;

            switch (typeValue)
            {
                case (int)NugetPackageType.NUnit:
                    associatedFileName = BasicNugetPackageTypeTranslator.NUnitFileName;
                    break;
                case (int)NugetPackageType.OpenCover:
                    associatedFileName = BasicNugetPackageTypeTranslator.OpenCoverFileName;
                    break;
                case (int)NugetPackageType.ReportGenerator:
                    associatedFileName = BasicNugetPackageTypeTranslator.ReportGeneratorFileName;
                    break;
                default:
                    throw new ArgumentException();
            }

            return associatedFileName;
        }
    }
}
