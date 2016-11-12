using DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOperations.UnitTest
{
    [TestClass]
    public class FileOperationsTest
    {
        private IDataOperations _fileOperations;
        private Mock<IDataFile> _dataFileMock;

        [TestInitialize]
        public void Setup()
        {
            _dataFileMock = new Mock<IDataFile>();
            _dataFileMock.Setup(x => x.FullPath).Returns("data.txt");
            _dataFileMock.Setup(x => x.FileName).Returns("data.txt");
            _dataFileMock.Setup(x => x.FileDirectory).Returns(
                Path.GetDirectoryName(_dataFileMock.Object.FullPath) == string.Empty 
                    ? AppDomain.CurrentDomain.BaseDirectory
                    : Path.GetDirectoryName(_dataFileMock.Object.FullPath));
            _dataFileMock.Setup(x => x.Graph).Returns(new List<IGraphItem>());

            _fileOperations = new FileOperations(_dataFileMock.Object);
        }

        [TestMethod]
        public void PopulateValues()
        {
            _fileOperations.PopulateValues();
            Assert.IsTrue(_fileOperations.inputFile.Graph.Count > 0);
        }
    }
}
