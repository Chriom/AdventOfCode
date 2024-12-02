using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier;
using AdventOfCode.Metier.A2024.Jours;

namespace AdventOfCode.Tests.A2024
{
    [TestClass]
    public class TestJours_2024
    {
        public TestJours_2024()
        {
            EntreesHelper.EstEnmodeTest = true;
            EntreesHelper.Numero = 1;
        }

        [TestMethod]
        public void TestJour01()
        {
            _Test(new Jour01(), "11", "31");
        }

        [TestMethod]
        public void TestJour02()
        {
            _Test(new Jour02(), "2", "4");
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
