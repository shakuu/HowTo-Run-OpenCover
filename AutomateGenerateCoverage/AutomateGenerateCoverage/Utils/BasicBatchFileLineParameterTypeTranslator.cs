namespace AutomateGenerateCoverage.Utils
{
    using System;

    using AutomateGenerateCoverage.Contracts;
    using AutomateGenerateCoverage.Enums;

    public class BasicBatchFileLineParameterTypeTranslator : ITypeTranslator
    {
        private const string ParameterPackageExecutableValue = "";
        private const string ParameterTestsLibraryName = "";
        private const string ParameterTargetValue = "-target:";
        private const string ParameterRegisterValue = "-register:";
        private const string ParameterReportsValue = "-reports:";
        private const string ParameterTargetDirValue = "-targetdir:";

        public string GetTranslatedValue(int typeValue)
        {
            string associatedValue;

            switch (typeValue)
            {
                case (int)BatchFileLineParameterType.PackageExecutablePath:
                    associatedValue = BasicBatchFileLineParameterTypeTranslator.ParameterPackageExecutableValue;
                    break;
                case (int)BatchFileLineParameterType.TestsLibraryName:
                    associatedValue = BasicBatchFileLineParameterTypeTranslator.ParameterTestsLibraryName;
                    break;
                case (int)BatchFileLineParameterType.Target:
                    associatedValue = BasicBatchFileLineParameterTypeTranslator.ParameterTargetValue;
                    break;
                case (int)BatchFileLineParameterType.Register:
                    associatedValue = BasicBatchFileLineParameterTypeTranslator.ParameterRegisterValue;
                    break;
                case (int)BatchFileLineParameterType.Reports:
                    associatedValue = BasicBatchFileLineParameterTypeTranslator.ParameterReportsValue;
                    break;
                case (int)BatchFileLineParameterType.TargetDir:
                    associatedValue = BasicBatchFileLineParameterTypeTranslator.ParameterTargetDirValue;
                    break;
                default:
                    throw new ArgumentException();
            }

            return associatedValue;
        }
    }
}
