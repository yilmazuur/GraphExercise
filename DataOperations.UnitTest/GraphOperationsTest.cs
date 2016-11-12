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
    public class GraphOperationsTest
    {
        private IGraphOperations _graphOperations;
        private Mock<IDataFile> _dataFileMock;
        private Mock<IGraphItem> _graphItemA;
        private Mock<IGraphItem> _graphItemB;
        private Mock<IGraphItem> _graphItemC;

        [TestInitialize]
        public void Setup()
        {
            _graphItemA = new Mock<IGraphItem>();
            _graphItemA.Setup(x => x.Color).Returns("Blue");
            _graphItemA.Setup(x => x.Name).Returns("#A");
            _graphItemA.Setup(x => x.Value).Returns(5);
            _graphItemB = new Mock<IGraphItem>();
            _graphItemB.Setup(x => x.Color).Returns("Red");
            _graphItemB.Setup(x => x.Name).Returns("#B");
            _graphItemB.Setup(x => x.Value).Returns(10);
            _graphItemC = new Mock<IGraphItem>();
            _graphItemC.Setup(x => x.Color).Returns("Green");
            _graphItemC.Setup(x => x.Name).Returns("#C");
            _graphItemC.Setup(x => x.Value).Returns(15);


            _dataFileMock = new Mock<IDataFile>();
            _dataFileMock.Setup(x => x.FullPath).Returns("data.txt");
            _dataFileMock.Setup(x => x.FileName).Returns("data.txt");
            _dataFileMock.Setup(x => x.FileDirectory).Returns(
                Path.GetDirectoryName(_dataFileMock.Object.FullPath) == string.Empty
                    ? AppDomain.CurrentDomain.BaseDirectory
                    : Path.GetDirectoryName(_dataFileMock.Object.FullPath));
            _dataFileMock.Setup(x => x.Graph).Returns(new List<IGraphItem>());

            _graphOperations = new GraphOperations(_dataFileMock.Object);
        }

        [TestMethod]
        public void DrawGraphAsImageIsWorking()
        {
            string res = _graphOperations.DrawGraphAsImage();
            Assert.IsTrue(res.Contains("barChart.png"));
        }

        [TestMethod]
        public void VisualizeChartIsWorking()
        {
            _graphOperations.VisualizeChart(_graphOperations.DrawGraphAsImage());
        }
    }
}
