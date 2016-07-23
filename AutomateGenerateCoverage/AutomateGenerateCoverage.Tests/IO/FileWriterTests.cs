namespace AutomateGenerateCoverage.Tests.IO
{
    using System;
    using System.IO;
    using System.Collections;
    using System.Collections.Generic;

    using NUnit.Framework;

    using AutomateGenerateCoverage.Contracts.IO;
    using AutomateGenerateCoverage.Models.IO;

    [TestFixture]
    public class FileWriterTests
    {
        [Test]
        public void WriteToFile_ShouldThrow_IfFullFileNameWithPathParameterIsNullOrEmpty()
        {
            string fullFileNameWithPath = null;
            var dataToWrite = new List<string>();

            IFileWriter fileWriter = new FileWriter();

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }

        [Test]
        public void WriteToFile_ShouldThrow_IfDataToWriteIsNull()
        {
            string fullFileNameWithPath = "something";
            IEnumerable dataToWrite = null;

            IFileWriter fileWriter = new FileWriter();

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }

        [Test]
        public void WriteToFile_ShouldThrow_IfFullFileNameWithPathParameterIsNotInAValidDirectory()
        {
            string fullFileNameWithPath = "something";
            var dataToWrite = new List<string>();

            IFileWriter fileWriter = new FileWriter();

            Assert.Throws<DirectoryNotFoundException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }

        [Test]
        public void WriteToFile_ShouldThrow_IfAnyOfTheObjectsPassedInDataToWriteAreNull()
        {
            string fullFileNameWithPath = "D:\\Homeworks\\test.txt";

            var dataToWrite = new List<string>()
            {
                "string",
                null
            };

            IFileWriter fileWriter = new FileWriter();

            Assert.Throws<ArgumentNullException>(() => fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite));
        }

        [Test]
        public void WriteToFile_ShouldWriteDataToFile_IfAnyOfTheObjectsPassedInDataToWriteAreNull()
        {
            string fullFileNameWithPath = "D:\\Homeworks\\test.txt";

            var dataToWrite = new List<string>()
            {
                "string",
                string.Empty
            };

            IFileWriter fileWriter = new FileWriter();

            var actual = fileWriter.WriteToFile(fullFileNameWithPath, dataToWrite);

            Assert.IsTrue(actual);
        }
    }
}
