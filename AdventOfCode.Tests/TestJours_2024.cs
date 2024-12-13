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

        [TestMethod]
        public void TestJour06()
        {
            _Test(new Jour06(), "41", "6");
        }

        [TestMethod]
        public void TestJour07()
        {
            _Test(new Jour07(), "3749", "11387");
        }

        [TestMethod]
        public void TestJour08()
        {
            _Test(new Jour08(), "14", "34");
        }

        [TestMethod]
        public void TestJour08_Part2()
        {
            EntreesHelper.Numero = 2;
            Assert.AreEqual("9", new Jour08().DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour09()
        {
            _Test(new Jour09(), "1928", "2858");
        }

        [TestMethod]
        public void TestJour10()
        {
            _Test(new Jour10(), "36", "81");
        }

        [TestMethod]
        public void TestJour10_Simple()
        {
            EntreesHelper.Numero = 2;
            Assert.AreEqual("2", new Jour10().DonneResultatUn());

            EntreesHelper.Numero = 3;
            Assert.AreEqual("3", new Jour10().DonneResultatUn());
        }

        [TestMethod]
        public void TestJour11()
        {
            _Test(new Jour11(), "55312", null);
        }

        [TestMethod]
        public void TestJour12()
        {
            _Test(new Jour12(), "1930", "1206");
        }

        [TestMethod]
        public void TestJour12_Exemple()
        {
            EntreesHelper.Numero = 2;
            Assert.AreEqual("80", new Jour12().DonneResultatDeux());

            EntreesHelper.Numero = 3;
            Assert.AreEqual("236", new Jour12().DonneResultatDeux());

            EntreesHelper.Numero = 4;
            Assert.AreEqual("368", new Jour12().DonneResultatDeux());

            EntreesHelper.Numero = 5;
            Assert.AreEqual("436", new Jour12().DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour13()
        {
            _Test(new Jour13(), "480", null);
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
