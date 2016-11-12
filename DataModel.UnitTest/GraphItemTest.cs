using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.UnitTest
{
    [TestClass]
    public class GraphItemTest
    {
        private const string COLOR = "Blue";
        private const string NAME = "#A";
        private const string VALUE1 = "5";
        private const string VALUE2 = "ASDQWE";

        private IGraphItem _graphItem1;
        private IGraphItem _graphItem2;

        [TestInitialize]
        public void Setup()
        {
            _graphItem1= new GraphItem(NAME, COLOR, VALUE1);
            _graphItem2 = new GraphItem(NAME, COLOR, VALUE2);
        }

        [TestMethod]
        public void GraphItemNameIsCorrect()
        {
            Assert.IsTrue(_graphItem1.Name == "#A");
        }

        [TestMethod]
        public void GraphItemColorIsCorrect()
        {
            Assert.IsTrue(_graphItem1.Color == "Blue");
        }

        [TestMethod]
        public void GraphItemValueIsCorrect()
        {
            Assert.IsTrue(_graphItem1.Value == Convert.ToInt32(VALUE1));
        }

        [TestMethod]
        public void GraphItemValueIsNotConvertibleAndWePutZero()
        {
            Assert.IsTrue(_graphItem2.Value == 0);
        }
    }
}
