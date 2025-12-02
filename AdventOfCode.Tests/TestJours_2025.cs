using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Metier.A2025;

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
        public void TestJour01()
        {
            _Test(new Jour01(), "3", "6");
        }

        [TestMethod]
        public void TestJour02()
        {
            _Test(new Jour02(), "1227775554", "4174379265");
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
