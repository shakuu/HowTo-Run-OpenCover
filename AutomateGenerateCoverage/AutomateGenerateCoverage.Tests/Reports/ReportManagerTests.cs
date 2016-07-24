namespace AutomateGenerateCoverage.Tests.Reports
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Models.Reports;

    [TestFixture]
    public class ReportManagerTests
    {
        [Test]
        public void Constructor_ShouldThrow_IfReportsRootDirctoryIsNullOrEmpty()
        {
            string reportsRootDirectory = null;

            Assert.Throws<ArgumentNullException>(() => new ReportManager(reportsRootDirectory));
        }

        [Test]
        public void Constructor_ShouldThrow_IfReportsRootDirctoryCannotBeFound()
        {
            var reportsRootDirectory = "random\\folder";

            Assert.Throws<DirectoryNotFoundException>(() => new ReportManager(reportsRootDirectory));
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly_IfPassedAValidPath()
        {
            var reportsRootDirectory = "D:\\Homeworks";

            var actualResult = new ReportManager(reportsRootDirectory);

            Assert.NotNull(actualResult);
        }

        [Test]
        public void GenerateReport_ShouldThrow_IfTestingDllDirectoryIsNull()
        {
            string testingDllDirectory = null;

            var reportsRootDirectory = "D:\\Homeworks";
            var reportManager = new ReportManager(reportsRootDirectory);

            Assert.Throws<ArgumentNullException>(() => reportManager.GenerateReport(testingDllDirectory));
        }

        [Test]
        public void GenerateReport_ShouldThrow_IfTestingDllDirectoryCannotBeFound()
        {
            var testingDllDirectory = "random\\folder";

            var reportsRootDirectory = "D:\\Homeworks";
            var reportManager = new ReportManager(reportsRootDirectory);

            Assert.Throws<DirectoryNotFoundException>(() => reportManager.GenerateReport(testingDllDirectory));
        }
    }
}
