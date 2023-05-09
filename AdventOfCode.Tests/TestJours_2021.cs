using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2021.Jours;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class TestJours_2021
    {
        public TestJours_2021()
        {
            EntreesHelper.EstEnmodeTest = true;
            EntreesHelper.Numero = 1;
        }

        [TestMethod]
        public void TestJour01_Probleme1()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual(lJour.DonneResultatUn(), "7");
        }

        [TestMethod]
        public void TestJour01_Probleme2()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual(lJour.DonneResultatDeux(), "5");
        }

        [TestMethod]
        public void TestJour02_Probleme1()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual(lJour.DonneResultatUn(), "150");
        }

        [TestMethod]
        public void TestJour02_Probleme2()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual(lJour.DonneResultatDeux(), "900");
        }
    }
}
