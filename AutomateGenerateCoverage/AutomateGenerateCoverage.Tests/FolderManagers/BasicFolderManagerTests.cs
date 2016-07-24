namespace AutomateGenerateCoverage.Tests.FolderManagers
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Models.Reports.FolderManagers;

    [TestFixture]
    public class BasicFolderManagerTests
    {
        [Test]
        public void Constructor_ShouldThrow_IfReportsRootFolderIsNullOrEmpty()
        {
            string reportsRootFolder = null;

            Assert.Throws<ArgumentNullException>(() => new BasicFolderManager(reportsRootFolder));
        }

        [Test]
        public void Constructor_ShouldThrow_IfReportsRootFolderCannotBeFound()
        {
            string reportsRootFolder = "random\\folder";

            Assert.Throws<DirectoryNotFoundException>(() => new BasicFolderManager(reportsRootFolder));
        }

        [Test]
        public void Constructor_ShouldInstantiateCorrectly_IfPassedValidArguments()
        {
            string reportsRootFolder = "D:\\Homeworks";

            var actualResult = new BasicFolderManager(reportsRootFolder);

            Assert.NotNull(actualResult);
        }

        [Test]
        public void GetNextFolder_ShouldReturnAValidString()
        {
            var expectedNextFolder = "D:\\Homeworks\\reports";

            var reportsRootFolder = "D:\\Homeworks";
            var folderManager = new BasicFolderManager(reportsRootFolder);

            var actualNextFolder = folderManager.GetNextReportFolder();

            Assert.AreEqual(expectedNextFolder, actualNextFolder);
        }
    }
}
