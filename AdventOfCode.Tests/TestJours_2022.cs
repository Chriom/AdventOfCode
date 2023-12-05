using AdventOfCode.Commun.Helpers;
using AdventOfCode.Interfaces;
using AdventOfCode.Metier.A2022.Jours;
using AdventOfCode.ObjetsMetier.A2022.Jour13;

namespace AdventOfCode.Tests.A2022
{
    [TestClass]
    public class TestJours_2022
    {
        public TestJours_2022()
        {
            EntreesHelper.EstEnmodeTest = true;
            EntreesHelper.Numero = 1;
        }

        [TestMethod]
        public void TestJour01_Probleme1()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual("24000", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour01_Probleme2()
        {
            IJour lJour = new Jour01();

            Assert.AreEqual("45000", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour02_Probleme1()
        {
            IJour lJour = new Jour02();

            Assert.AreEqual("15", lJour.DonneResultatUn());
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

        [TestMethod]
        public void TestJour11_Probleme1()
        {
            IJour lJour = new Jour11();
            Assert.AreEqual("10605", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour11_Probleme2()
        {
            IJour lJour = new Jour11();
            Assert.AreEqual("2713310158", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour12_Probleme1()
        {
            IJour lJour = new Jour12();
            Assert.AreEqual("31", lJour.DonneResultatUn());
        }


        [TestMethod]
        public void TestJour12_Probleme2()
        {
            IJour lJour = new Jour12();
            Assert.AreEqual("29", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour13_CasTest()
        {
            Assert.IsTrue(new PairePaquets(1, new Paquet("[1,1,3,1,1]"), new Paquet("[1,1,5,1,1]")).EstDansLeBonOrdre, "Cas 1");
            Assert.IsTrue(new PairePaquets(1, new Paquet("[[1],[2,3,4]]"), new Paquet("[[1],4]")).EstDansLeBonOrdre, "Cas 2");
            Assert.IsFalse(new PairePaquets(1, new Paquet("[9]"), new Paquet("[[8,7,6]]")).EstDansLeBonOrdre, "Cas 3");
            Assert.IsTrue(new PairePaquets(1, new Paquet("[[4,4],4,4]"), new Paquet("[[4,4],4,4,4]")).EstDansLeBonOrdre, "Cas 4");
            Assert.IsFalse(new PairePaquets(1, new Paquet("[7,7,7,7]"), new Paquet("[7,7,7]")).EstDansLeBonOrdre, "Cas 5");
            Assert.IsTrue(new PairePaquets(1, new Paquet("[]"), new Paquet("[3]")).EstDansLeBonOrdre, "Cas 6");
            Assert.IsFalse(new PairePaquets(1, new Paquet("[[[]]]"), new Paquet("[[]]")).EstDansLeBonOrdre, "Cas 7");
            Assert.IsFalse(new PairePaquets(1, new Paquet("[1,[2,[3,[4,[5,6,7]]]],8,9]"), new Paquet("[1,[2,[3,[4,[5,6,0]]]],8,9]")).EstDansLeBonOrdre, "Cas 8");
        }

       [TestMethod]
        public void TestJour13_Probleme1()
        {
            IJour lJour = new Jour13();
            Assert.AreEqual("13", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour13_Probleme2()
        {
            IJour lJour = new Jour13();
            Assert.AreEqual("140", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour14_Probleme1()
        {
            IJour lJour = new Jour14();
            Assert.AreEqual("24", lJour.DonneResultatUn());
        }


        [TestMethod]
        public void TestJour14_Probleme2()
        {
            IJour lJour = new Jour14();
            Assert.AreEqual("93", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour15_Probleme1()
        {
            Jour15 lJour = new Jour15();
            Assert.AreEqual("26", lJour.DonneResultatUn(10));
        }

        [TestMethod]
        public void TestJour15_Probleme2()
        {
            Jour15 lJour = new Jour15();
            Assert.AreEqual("56000011", lJour.DonneResultatDeux(20));
        }

        [TestMethod]
        public void TestJour16_Probleme1()
        {
            IJour lJour = new Jour16();
            Assert.AreEqual("1651", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour16_Probleme2()
        {
            IJour lJour = new Jour16();
            Assert.AreEqual("1707", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour20_Probleme1()
        {
            IJour lJour = new Jour20();
            Assert.AreEqual("3", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour20_Probleme2()
        {
            IJour lJour = new Jour20();
            Assert.AreEqual("1623178306", lJour.DonneResultatDeux());
        }

        [TestMethod]
        public void TestJour21_Probleme1()
        {
            IJour lJour = new Jour21();
            Assert.AreEqual("152", lJour.DonneResultatUn());
        }

        [TestMethod]
        public void TestJour21_Probleme2()
        {
            IJour lJour = new Jour21();
            Assert.AreEqual("301", lJour.DonneResultatDeux());
        }
    }
}