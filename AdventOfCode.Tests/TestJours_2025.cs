using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier;
using AdventOfCode.Metier.A2025;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.A2025
{
    [TestClass]
    public class TestJours_2025
    {

        public TestJours_2025()
        {
            EntreesHelper.EstEnmodeTest = true;
            EntreesHelper.Numero = 1;
        }

        [TestMethod]
        public void Test_Jour01()
        {
            _Test(new Jour01(), "3", "6");
        }

        [TestMethod]
        public void Test_Jour02()
        {
            _Test(new Jour02(), "1227775554", "4174379265");
        }

        [TestMethod]
        public void Test_Jour03()
        {
            _Test(new Jour03(), "357", "3121910778619");
        }

        [TestMethod]
        public void Test_Jour04()
        {
            _Test(new Jour04(), "13", "43");
        }

        [TestMethod]
        public void Test_Jour05()
        {
            _Test(new Jour05(), "3", "14");
        }

        [TestMethod]
        public void Test_Jour06()
        {
            _Test(new Jour06(), "4277556", "3263827");
        }

        [TestMethod]
        public void Test_Jour07()
        {
            _Test(new Jour07(), "21", "40");
        }

        [TestMethod]
        public void Test_Jour08()
        {
            Assert.AreEqual("40", new Jour08().DonneResultatUn());
            Assert.AreEqual("25272", new Jour08().DonneResultatDeux());
        }


        private void _Test(IJour pJour, string pResultat1, string pResultat2)
        {
            Assert.AreEqual(pResultat1, pJour.DonneResultatUn());

            if (string.IsNullOrEmpty(pResultat2) == false)
            {
                Assert.AreEqual(pResultat2, pJour.DonneResultatDeux());
            }
        }


    }
}
