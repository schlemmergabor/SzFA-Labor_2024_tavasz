using L04_NUnit;

namespace L04_NUnit_Tester
{
    // Ez a Class Library szolgál az L04-NUnit projektben megvalósított kódok tesztelésére

    // a VS nyitólapján fent a keresõbe beírod, hogy NUnit és ki fogja adni
    // NUnit Test Projekt

    // Ne felejtsd el hozzáadni ehhez a ref-et a tesztelendõ projektrõl!
    // Add -> Projekt Reference -> L04-NUnit
    public class Tests
    {
        // ide kerülnek a "beállításos" részek
        // mindenképp lefut a tesztelések elõtt

        [SetUp]
        public void Setup()
        {
        }

        // egy test metódus
        [Test]
        public void Test1()
        {
            // azt jelzi, hogy sikeres
            // Assert.Fail -> jelzi, hogy nem sikeres
            // Assert.That -> elvárt értéket megnézi -> ezt fogjuk használni
            Assert.Pass();

        }

        // Teszt metódusokat tudunk paraméterezni
        // Erre használjuk a TestCase-t
        // paramtérezni kell a Test metódust!

        [TestCase(true, 2)]
        [TestCase(true, 3)]
        [TestCase(false, 4)]
        [TestCase(true, 5)]
        [TestCase(false, 6)]
        public void IsPrimeTest(bool vartErtek, int szam)
        {
            // példányosítjuk
            PrimeTool pt = new PrimeTool(szam);

            // megnézzük, hogy
            // vartErtek == pt.IsPrime()
            // Test menüpont -> Test Explorer-ben tudod futtatni a teszteket
            Assert.That(pt.IsPrime(), Is.EqualTo(vartErtek));
        }

        [TestCase(35, new int[] { 4, 3, 2, 1, 10, 15 })]
        [TestCase(31, new int[] { 4, 3, -2, 1, 10, 15 })]
        [TestCase(1, new int[] { -4, -3, 2, 1, -10, 15 })]
        public void TotalTest(int vartErtek, int[] tömb)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);

            Assert.That(A.Total(), Is.EqualTo(vartErtek));
        }

        [TestCase(true, new int[] { 1, 2, 3 }, 3)]
        [TestCase(false, new int[] { 7, 8, 3 }, 9)]
        [TestCase(true, new int[] { 1, 2, 3 }, 2)]
        public void ContainsTest(bool vartErtek, int[] tömb, int szam)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);
            Assert.That(A.Contains(szam), Is.EqualTo(vartErtek));
        }

        [TestCase(true, new int[] { 1, 2, 3 })]
        [TestCase(true, new int[] { 1, 1, 3 })]
        [TestCase(false, new int[] { 1, 2, -3 })]
        public void SortedTest(bool vartErtek, int[] tömb)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);
            Assert.That(A.Sorted(), Is.EqualTo(vartErtek));
        }

        [TestCase(8, new int[] { 1, 10, 3 }, 1)]
        [TestCase(8, new int[] { 1, 7, 3 }, -1)]
        [TestCase(-11, new int[] { 3, -10, -3 }, 0)]
        public void FirstGreaterTest(int szam, int[] tömb, int vartErtek)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);
            Assert.That(A.FirstGreater(szam), Is.EqualTo(vartErtek));
        }

        [TestCase(1, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 1, 1, 3 })]
        [TestCase(3, new int[] { 10, 2, -30 })]
        public void CountEvensTest(int vartErtek, int[] tömb)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);
            Assert.That(A.CountEvens(), Is.EqualTo(vartErtek));
        }

        [TestCase(2, new int[] { 1, 2, 3 })]
        [TestCase(0, new int[] { 10, 1, 3 })]
        [TestCase(0, new int[] { 10, 2, -30 })]
        public void MaxIndexTest(int vartErtek, int[] tömb)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);
            Assert.That(A.MaxIndex(), Is.EqualTo(vartErtek));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, -3 })]
        [TestCase(new int[] { -1, -10, 0 })]

        public void SortTest(int[] tömb)
        {
            ArrayStatistics A = new ArrayStatistics(tömb);
            // Rendezzük
            A.Sort();
            // Megnézzük, hogy rendezett-e
            Assert.That(A.Sorted(), Is.EqualTo(true));

        }

    }


}

