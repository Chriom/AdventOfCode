using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2023.Jours;

namespace AdventOfCode.Tests.A2023
{
    [TestClass]
    public class TestJours_2023
    {
        public TestJours_2023()
        {
            EntreesHelper.EstEnmodeTest = true;
            EntreesHelper.Numero = 1;
        }

        [TestMethod]
        public void TestJour01_Probleme1()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual("142", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour01_Probleme2()
        {
            EntreesHelper.Numero = 2;
            IJour lJour = new Jour01();
            

            Assert.AreEqual("281", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour02_Probleme1()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual("8", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour02_Probleme2() 
        {
            IJour lJour = new Jour02();

            Assert.AreEqual("2286", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour03_Probleme1()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual("4361", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour03_Probleme2()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual("467835", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour04_Probleme1()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual("13", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour04_Probleme2()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual("30", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour05_Probleme1()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual("35", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour05_Probleme2()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual("46", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour07_Probleme1()
        {
            IJour lJour = new Jour07();

            Assert.AreEqual("6440", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour07_Probleme2()
        {
            IJour lJour = new Jour07();

            Assert.AreEqual("5905", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour08_Probleme1()
        {
            IJour lJour = new Jour08();

            Assert.AreEqual("2", lJour.DonneResultatUn());

            EntreesHelper.Numero = 2;
            IJour lJour2 = new Jour08();

            Assert.AreEqual("6", lJour2.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour08_Probleme2()
        {
            EntreesHelper.Numero = 3;
            IJour lJour = new Jour08();

            Assert.AreEqual("6", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour09_Probleme1()
        {
            IJour lJour = new Jour09();

            Assert.AreEqual("114", lJour.DonneResultatUn());

        }

        [TestMethod]
        public void TestJour09_Probleme2()
        {
            IJour lJour = new Jour09();

            Assert.AreEqual("2", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour10_Probleme1()
        {
            IJour lJour = new Jour10();

            Assert.AreEqual("4", lJour.DonneResultatUn());

            EntreesHelper.Numero = 2;

            IJour lJour2 = new Jour10();

            Assert.AreEqual("8", lJour2.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour10_Probleme2()
        {
            EntreesHelper.Numero = 3;
            IJour lJour = new Jour10();

            Assert.AreEqual("4", lJour.DonneResultatDeux());

            EntreesHelper.Numero = 4;
            IJour lJour2 = new Jour10();

            Assert.AreEqual("8", lJour2.DonneResultatDeux());

            EntreesHelper.Numero = 5;
            IJour lJour3 = new Jour10();

            Assert.AreEqual("10", lJour3.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour11_Probleme1()
        {
            IJour lJour = new Jour11();

            Assert.AreEqual("374", lJour.DonneResultatUn());

        }

        [TestMethod]
        public void TestJour11_Probleme2()
        {
            Jour11 lJour = new Jour11();

            Assert.AreEqual("1030", lJour.DonneResultatDeux(9));

            Jour11 lJour2 = new Jour11();

            Assert.AreEqual("8410", lJour2.DonneResultatDeux(99));
        }

        [TestMethod]
        public void TestJour12_Probleme1()
        {
            IJour lJour = new Jour12();

            Assert.AreEqual("21", lJour.DonneResultatUn());

        }

        [TestMethod]
        public void TestJour12_Probleme2()
        {
            IJour lJour = new Jour12();

            Assert.AreEqual("525152", lJour.DonneResultatDeux());

        }

        [TestMethod]
        public void TestJour13_Probleme1()
        {
            IJour lJour = new Jour13();

            Assert.AreEqual("405", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour13_Probleme2()
        {
            IJour lJour = new Jour13();

            Assert.AreEqual("400", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour14_Probleme1()
        {
            IJour lJour = new Jour14();

            Assert.AreEqual("136", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour14_Probleme2()
        {
            IJour lJour = new Jour14();

            Assert.AreEqual("64", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour15_Probleme1()
        {
            IJour lJour = new Jour15();

            Assert.AreEqual("1320", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour15_Probleme2()
        {
            IJour lJour = new Jour15();

            Assert.AreEqual("145", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour16_Probleme1()
        {
            IJour lJour = new Jour16();

            Assert.AreEqual("46", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour16_Probleme2()
        {
            IJour lJour = new Jour16();

            Assert.AreEqual("51", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour17_Probleme1()
        {
            IJour lJour = new Jour17();

            Assert.AreEqual("102", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour17_Probleme2()
        {
            IJour lJour = new Jour17();

            Assert.AreEqual("94", lJour.DonneResultatDeux());

            EntreesHelper.Numero = 2;
            IJour lJour2 = new Jour17();

            Assert.AreEqual("71", lJour2.DonneResultatDeux());
        }
    }
}
