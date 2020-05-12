using Microsoft.VisualStudio.TestTools.UnitTesting;
using sec_video_rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sec_video_rental.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            Movie obj = new Movie();
            int cost = obj.getCost(2020);
            int ActCost = 5;
            if (ActCost == cost)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.IsTrue(false);
            }
        }


    }
}