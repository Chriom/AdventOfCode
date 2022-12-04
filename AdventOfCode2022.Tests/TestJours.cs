using AdventOfCode2022.Interfaces;
using AdventOfCode2022.Metier.Jours;

namespace AdventOfCode2022.Tests
{
    [TestClass]
    public class TestJours
    {
        [TestMethod]
        public void TestJour01_Probleme1()
        {
            IJour lJour = new Jour01(true);

            Assert.AreEqual(lJour.DonneResultatUn(), "24000");
        }

        [TestMethod]
        public void TestJour01_Probleme2()
        {
            IJour lJour = new Jour01(true);

            Assert.AreEqual(lJour.DonneResultatDeux(), "45000");
        }

        [TestMethod]
        public void TestJour02_Probleme1()
        {
            IJour lJour = new Jour02(true);

            Assert.AreEqual(lJour.DonneResultatUn(), "15");
        }

        [TestMethod]
        public void TestJour02_Probleme2()
        {
            IJour lJour = new Jour02(true);

            Assert.AreEqual(lJour.DonneResultatDeux(), "12");
        }

        [TestMethod]
        public void TestJour03_Probleme1()
        {
            IJour lJour = new Jour03(true);

            Assert.AreEqual(lJour.DonneResultatUn(), "157");
        }

        [TestMethod]
        public void TestJour03_Probleme2()
        {
            IJour lJour = new Jour03(true);

            Assert.AreEqual(lJour.DonneResultatDeux(), "70");
        }

        [TestMethod]
        public void TestJour04_Probleme1()
        {
            IJour lJour = new Jour04(true);

            Assert.AreEqual(lJour.DonneResultatUn(), "2");
        }

        [TestMethod]
        public void TestJour04_Probleme2()
        {
            IJour lJour = new Jour04(true);

            Assert.AreEqual(lJour.DonneResultatDeux(), "4");
        }
    }
}