using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphExercise.UnitTest
{
    /// <summary>
    /// Full scale test without mocks
    /// </summary>
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void RunMain()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("data.txt"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    Console.SetIn(sr);
                    // Act
                    GraphExercise.Program.Main(null);

                    // Assert
                    var result = sw.ToString();
                    Assert.IsTrue(result.Contains("Press any key and enter to quit..."));

                }
            }
        }

        [TestMethod]
        public void RunMainInvalidFile()
        {
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(""))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    GraphExercise.Program.Main(null);

                    var result = sw.ToString();
                    Assert.IsTrue(result.Contains("You reached maximum try count"));
                }
            }
        }
    }
}
