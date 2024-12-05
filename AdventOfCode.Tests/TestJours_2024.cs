﻿using System;
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

        [TestMethod]
        public void TestJour03()
        {
            Assert.AreEqual("161", new Jour03().DonneResultatUn());
            EntreesHelper.Numero = 2;
            Assert.AreEqual("48", new Jour03().DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour04()
        {
            _Test(new Jour04(), "18", "9");
        }

        [TestMethod]
        public void TestJour05()
        {
            _Test(new Jour05(), "143", "123");
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