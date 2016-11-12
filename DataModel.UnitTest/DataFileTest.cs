using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitTest
{
    [TestClass]
    public class DataFileTest
    {
        private const string FILEPATH = "data.txt";

        private IDataFile _dataFile;

        [TestInitialize]
        public void Setup()
        {
            _dataFile = new DataFile(FILEPATH);
        }

        [TestMethod]
        public void DataFileFullPathIsCorrect()
        {
            Assert.IsTrue(_dataFile.FullPath == FILEPATH);
        }

        [TestMethod]
        public void DataFileNameIsCorrect()
        {
            Assert.IsTrue(FILEPATH.Contains(_dataFile.FileName));
        }

        [TestMethod]
        public void DataFileDirectoryIsCorrect()
        {
            Assert.IsTrue(_dataFile.FileDirectory ==
                (Path.GetDirectoryName(FILEPATH) == string.Empty ? AppDomain.CurrentDomain.BaseDirectory : Path.GetDirectoryName(FILEPATH)));
        }

        [TestMethod]
        public void GraphIsNullAtTheMoment()
        {
            Assert.IsTrue(_dataFile.Graph == null);
        }
    }
}
