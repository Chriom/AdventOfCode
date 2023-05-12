﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Helpers;
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
    }
}
