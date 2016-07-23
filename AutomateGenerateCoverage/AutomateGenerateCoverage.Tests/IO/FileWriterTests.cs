namespace AutomateGenerateCoverage.Tests.IO
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models;

    [TestFixture]
    public class FileWriterTests
    {
        [Test]
        public void WriteToFile_ShouldThrow_IfFullFileNameWithPathParameterIsNullOrEmpty()
        {
            string fullFileNameWithPath = null;
            var dataToWrite = new List<string>();

            IFileWriter fileWriter;

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }

        [Test]
        public void WriteToFile_ShouldThrow_IfDataToWriteIsNull()
        {
            string fullFileNameWithPath = "something";
            IEnumerable dataToWrite = null;

            IFileWriter fileWriter;

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }

        [Test]
        public void WriteToFile_ShouldThrow_IfFullFileNameWithPathParameterIsNotInAValidDirectory()
        {
            string fullFileNameWithPath = "something";
            var dataToWrite = new List<string>();

            IFileWriter fileWriter;

            Assert.Throws<DirectoryNotFoundException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }
    }
}
