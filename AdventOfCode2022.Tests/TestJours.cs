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
            EntreesHelper.Numero = 1;
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

            Assert.AreEqual("12", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour03_Probleme1()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual("157", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour03_Probleme2()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual("70", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour04_Probleme1()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual("2", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour04_Probleme2()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual("4", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour05_Probleme1()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual("CMZ", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour05_Probleme2()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual("MCD", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour06_Probleme1()
        {
            IJour lJour = new Jour06();
            Assert.AreEqual("7", lJour.DonneResultatUn());

            EntreesHelper.Numero = 2;
            lJour = new Jour06();
            Assert.AreEqual("5", lJour.DonneResultatUn());

            EntreesHelper.Numero = 3;
            lJour = new Jour06();
            Assert.AreEqual("6", lJour.DonneResultatUn());

            EntreesHelper.Numero = 4;
            lJour = new Jour06();
            Assert.AreEqual("10", lJour.DonneResultatUn());

            EntreesHelper.Numero = 5;
            lJour = new Jour06();
            Assert.AreEqual("11", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour06_Probleme2()
        {
            IJour lJour = new Jour06();
            Assert.AreEqual("19", lJour.DonneResultatDeux());

            EntreesHelper.Numero = 2;
            lJour = new Jour06();
            Assert.AreEqual("23", lJour.DonneResultatDeux());

            EntreesHelper.Numero = 3;
            lJour = new Jour06();
            Assert.AreEqual("23", lJour.DonneResultatDeux());

            EntreesHelper.Numero = 4;
            lJour = new Jour06();
            Assert.AreEqual("29", lJour.DonneResultatDeux());

            EntreesHelper.Numero = 5;
            lJour = new Jour06();
            Assert.AreEqual("26", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour07_Probleme1()
        {
            IJour lJour = new Jour07();
            Assert.AreEqual("95437", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour07_Probleme2()
        {
            IJour lJour = new Jour07();
            Assert.AreEqual("24933642", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour08_Probleme1()
        {
            IJour lJour = new Jour08();
            Assert.AreEqual("21", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour08_Probleme2()
        {
            IJour lJour = new Jour08();
            Assert.AreEqual("8", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour09_Probleme1()
        {
            IJour lJour = new Jour09();
            Assert.AreEqual("13", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour09_Probleme2()
        {
            EntreesHelper.Numero = 2;
            IJour lJour = new Jour09();
            Assert.AreEqual("36", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour10_Probleme1()
        {
            IJour lJour = new Jour10();
            Assert.AreEqual("13140", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour10_Probleme2()
        {
            IJour lJour = new Jour10();
            string lResultat =
@"##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....";

            Assert.AreEqual(lResultat, lJour.DonneResultatDeux());
        }
    }
}