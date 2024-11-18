using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2021.Jours;

namespace AdventOfCode.Tests.A2021
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

            Assert.AreEqual("7", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour01_Probleme2()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual("5", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour02_Probleme1()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual("150", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour02_Probleme2()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual("900", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour03_Probleme1()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual("198", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour03_Probleme2()
        {
            IJour lJour = new Jour03();

            Assert.AreEqual("230", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour04_Probleme1()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual("4512", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour04_Probleme2()
        {
            IJour lJour = new Jour04();

            Assert.AreEqual("1924", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour05_Probleme1()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual("5", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour05_Probleme2()
        {
            IJour lJour = new Jour05();

            Assert.AreEqual("12", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour06_Probleme1()
        {
            IJour lJour = new Jour06();

            Assert.AreEqual("5934", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour06_Probleme2()
        {
            IJour lJour = new Jour06();

            Assert.AreEqual("26984457539", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour07_Probleme1()
        {
            IJour lJour = new Jour07();

            Assert.AreEqual("37", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour07_Probleme2()
        {
            IJour lJour = new Jour07();

            Assert.AreEqual("168", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour08_Probleme1()
        {
            IJour lJour = new Jour08();

            Assert.AreEqual("26", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour08_Probleme2()
        {
            IJour lJour = new Jour08();

            Assert.AreEqual("61229", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour09_Probleme1()
        {
            IJour lJour = new Jour09();

            Assert.AreEqual("15", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour09_Probleme2()
        {
            IJour lJour = new Jour09();

            Assert.AreEqual("1134", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour10_Probleme1()
        {
            IJour lJour = new Jour10();

            Assert.AreEqual("26397", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour10_Probleme2()
        {
            IJour lJour = new Jour10();

            Assert.AreEqual("288957", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour11_Probleme1()
        {
            IJour lJour = new Jour11();

            Assert.AreEqual("1656", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour11_Probleme2()
        {
            IJour lJour = new Jour11();

            Assert.AreEqual("195", lJour.DonneResultatDeux());
        }
    }
}
