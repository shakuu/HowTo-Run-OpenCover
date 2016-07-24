﻿namespace AutomateGenerateCoverage.Tests.Reports
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts.Reports;
    using AutomateGenerateCoverage.Models.Reports;
    using AutomateGenerateCoverage.Models.Reports.FolderManagers;

    [TestFixture]
    public class ReportManagerTests
    {
        [Test]
        public void Constructor_ShouldThrow_IfReportsRootDirctoryIsNullOrEmpty()
        {
            IFolderManager folderManager = null;

            Assert.Throws<ArgumentNullException>(() => new ReportManager(folderManager));
        }

        [Test]
        public void Constructor_ShouldInitializeCorrectly_IfPassedAValidPath()
        {
            var reportsRootDirectory = "D:\\Homeworks";
            var folderManger = new BasicFolderManager(reportsRootDirectory);

            var actualResult = new ReportManager(folderManger);

            Assert.NotNull(actualResult);
        }

        [Test]
        public void GenerateReport_ShouldThrow_IfTestingDllDirectoryIsNull()
        {
            string testingDllDirectory = null;

            var reportsRootDirectory = "D:\\Homeworks";
            var folderManger = new BasicFolderManager(reportsRootDirectory);
            var reportManager = new ReportManager(folderManger);

            Assert.Throws<ArgumentNullException>(() => reportManager.GenerateReport(testingDllDirectory));
        }

        [Test]
        public void GenerateReport_ShouldThrow_IfTestingDllDirectoryCannotBeFound()
        {
            var testingDllDirectory = "random\\folder";

            var reportsRootDirectory = "D:\\Homeworks";
            var folderManger = new BasicFolderManager(reportsRootDirectory);
            var reportManager = new ReportManager(folderManger);

            Assert.Throws<DirectoryNotFoundException>(() => reportManager.GenerateReport(testingDllDirectory));
        }
    }
}
