using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traffic.Genetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic.Genetic.Tests
{
    [TestClass()]
    public class GeneTests
    {
        [TestMethod()]
        public void GeneTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GeneTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ConvertToNumberTest()
        {
            int[] tab = { 1, 0, 1 };
            Gene gen = new Gene(tab);
            Assert.AreEqual(5, gen.ConvertToNumber());
        }
    }
}

namespace TrafficTests.Genetic
{
    class GeneTests
    {
    }
}
