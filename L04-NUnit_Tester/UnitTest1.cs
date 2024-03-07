using L04_NUnit;

namespace L04_NUnit_Tester
{
    // Ez a Class Library szolg�l az L04-NUnit projektben megval�s�tott k�dok tesztel�s�re

    // a VS nyit�lapj�n fent a keres�be be�rod, hogy NUnit �s ki fogja adni
    // NUnit Test Projekt

    // Ne felejtsd el hozz�adni ehhez a ref-et a tesztelend� projektr�l!
    // Add -> Projekt Reference -> L04-NUnit
    public class Tests
    {
        // ide ker�lnek a "be�ll�t�sos" r�szek
        // mindenk�pp lefut a tesztel�sek el�tt

        [SetUp]
        public void Setup()
        {
        }

        // egy test met�dus
        [Test]
        public void Test1()
        {
            // azt jelzi, hogy sikeres
            // Assert.Fail -> jelzi, hogy nem sikeres
            // Assert.That -> elv�rt �rt�ket megn�zi -> ezt fogjuk haszn�lni
            Assert.Pass();

        }

        // Teszt met�dusokat tudunk param�terezni
        // Erre haszn�ljuk a TestCase-t
        // paramt�rezni kell a Test met�dust!

        [TestCase(true, 2)]
        [TestCase(true, 3)]
        [TestCase(false, 4)]
        [TestCase(true, 5)]
        [TestCase(false, 6)]
        public void IsPrimeTest(bool vartErtek, int szam)
        {
            // p�ld�nyos�tjuk
            PrimeTool pt = new PrimeTool(szam);

            // megn�zz�k, hogy
            // vartErtek == pt.IsPrime()
            // Test men�pont -> Test Explorer-ben tudod futtatni a teszteket
            Assert.That(pt.IsPrime(), Is.EqualTo(vartErtek));
        }

        [TestCase(35, new int[] { 4, 3, 2, 1, 10, 15 })]
        [TestCase(31, new int[] { 4, 3, -2, 1, 10, 15 })]
        [TestCase(1, new int[] { -4, -3, 2, 1, -10, 15 })]
        public void TotalTest(int vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);

            Assert.That(A.Total(), Is.EqualTo(vartErtek));
        }

        [TestCase(true, new int[] { 1, 2, 3 }, 3)]
        [TestCase(false, new int[] { 7, 8, 3 }, 9)]
        [TestCase(true, new int[] { 1, 2, 3 }, 2)]
        public void ContainsTest(bool vartErtek, int[] t�mb, int szam)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.Contains(szam), Is.EqualTo(vartErtek));
        }

        [TestCase(true, new int[] { 1, 2, 3 })]
        [TestCase(true, new int[] { 1, 1, 3 })]
        [TestCase(false, new int[] { 1, 2, -3 })]
        public void SortedTest(bool vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.Sorted(), Is.EqualTo(vartErtek));
        }

        [TestCase(8, new int[] { 1, 10, 3 }, 1)]
        [TestCase(8, new int[] { 1, 7, 3 }, -1)]
        [TestCase(-11, new int[] { 3, -10, -3 }, 0)]
        public void FirstGreaterTest(int szam, int[] t�mb, int vartErtek)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.FirstGreater(szam), Is.EqualTo(vartErtek));
        }

        [TestCase(1, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 1, 3 })]
        [TestCase(3, new int[] { 10, 2, -30 })]
        public void CountEvensTest(int vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.CountEvens(), Is.EqualTo(vartErtek));
        }

        [TestCase(2, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 10, 1, 3 })]
        [TestCase(0, new int[] { 10, 2, -30 })]
        public void MaxIndexTest(int vartErtek, int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            Assert.That(A.MaxIndex(), Is.EqualTo(vartErtek));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, -3 })]
        [TestCase(new int[] { -1, -10, 0 })]

        public void SortTest(int[] t�mb)
        {
            ArrayStatistics A = new ArrayStatistics(t�mb);
            // Rendezz�k
            A.Sort();
            // Megn�zz�k, hogy rendezett-e
            Assert.That(A.Sorted(), Is.EqualTo(true));

        }

    }


}

