﻿using System;
using System.Collections.Generic;
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
    }
}
