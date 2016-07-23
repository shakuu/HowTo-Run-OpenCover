namespace AutomateGenerateCoverage.Tests.Data
{
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Enums;

    public class BatchFileLineGeneratorTestsData
    {
        public static IEnumerable GenerateBatchFileLineTestCases
        {
            get
            {
                yield return new TestCaseData(
                    new List<BatchFileLineParameterType>()
                    {
                        BatchFileLineParameterType.PackageExecutablePath,
                        BatchFileLineParameterType.Reports,
                        BatchFileLineParameterType.TargetDir
                    },
                    new List<string>()
                    {
                        "..\\..\\..\\packages\\ReportGenerator.2.4.5.0\\tools\\ReportGenerator.exe",
                        "results.xml",
                        "..\\..\\..\\coverage"
                    })
                    .Returns("..\\..\\..\\packages\\ReportGenerator.2.4.5.0\\tools\\ReportGenerator.exe -reports:results.xml -targetdir:..\\..\\..\\coverage");

                yield return new TestCaseData(
                    new List<BatchFileLineParameterType>()
                    {
                        BatchFileLineParameterType.PackageExecutablePath,
                    },
                    new List<string>()
                    {
                        "..\\test-path"
                    })
                    .Returns("..\\test-path");
            }
        }
    }
}
