using AdventOfCode2022.Helpers;
using AdventOfCode2022.Interfaces;
using AdventOfCode2022.Metier.Jours;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestJours
    {
        public TestJours()
        {
            EntreesHelper.EstEnmodeTest = true;
        }

        [TestMethod]
        public void TestJour01_Probleme1()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual(lJour.DonneResultatUn(), "24000");
        }

        [TestMethod]
        public void TestJour01_Probleme2()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual(lJour.DonneResultatDeux(), "45000");
        }

        [TestMethod]
        public void TestJour02_Probleme1()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual(lJour.DonneResultatUn(), "15");
        }

        [TestMethod]
        public void TestJour02_Probleme2()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual(lJour.DonneResultatDeux(), "12");
        }

        [TestMethod]
        public void TestJour03_Probleme1()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual(lJour.DonneResultatUn(), "157");
        }

        [TestMethod]
        public void TestJour03_Probleme2()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual(lJour.DonneResultatDeux(), "70");
        }

        [TestMethod]
        public void TestJour04_Probleme1()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual(lJour.DonneResultatUn(), "2");
        }

        [TestMethod]
        public void TestJour04_Probleme2()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual(lJour.DonneResultatDeux(), "4");
        }

        [TestMethod]
        public void TestJour05_Probleme1()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual(lJour.DonneResultatUn(), "CMZ");
        }

        [TestMethod]
        public void TestJour05_Probleme2()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual(lJour.DonneResultatDeux(), "MCD");
        }
    }
}