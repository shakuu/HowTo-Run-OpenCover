namespace AutomateGenerateCoverage.Tests.Reports
{
    using System;
    using System.IO;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Models.Reports;

    [TestFixture]
    public class ReportTests
    {
        [Test]
        public void Constructor_ShouldThrow_If_TestingDllIsNull()
        {
            string testingDll = null;
            var reportHtml = @"D:\Homeworks\results\index.htm";

            Assert.Throws<ArgumentNullException>(() => new Report(testingDll, reportHtml));
        }

        [Test]
        public void Constructor_ShouldThrow_If_TestingDllIsInvalidPath()
        {
            var testingDll = "random\\path";
            var reportHtml = @"D:\Homeworks\results\index.htm";

            Assert.Throws<FileNotFoundException>(() => new Report(testingDll, reportHtml));
        }

        [Test]
        public void Constructor_ShouldThrow_If_ReportHTMLIsNull()
        {
            var testingDll = @"D:\Homeworks\results\index.htm";
            string reportHtml = null;

            Assert.Throws<ArgumentNullException>(() => new Report(testingDll, reportHtml));
        }

        [Test]
        public void Constructor_ShouldThrow_If_ReportHTMLIsInvalidPath()
        {
            var testingDll = @"D:\Homeworks\results\index.htm";
            var reportHtml = "random\\Path";

            Assert.Throws<FileNotFoundException>(() => new Report(testingDll, reportHtml));
        }
    }
}
