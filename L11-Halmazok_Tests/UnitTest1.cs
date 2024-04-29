using L11_Halmazok;
namespace L11_Halmazok_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CTorTest()
        {
            int[] a = new int[] { 1, 2, 3 };

            try
            {
                SetOfInts sei = new SetOfInts(a);
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void CTorTest2()
        {
            int[] a = new int[] { 1, 2, 1 };

            try
            {
                SetOfInts sei = new SetOfInts(a);
            }
            catch (Exception)
            {
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void EgyenlosegTest()
        {
            int[] a = new int[] { 1, 2, 3 };
            int[] b = new int[] { 1, 2, 3 };

            SetOfInts X = new SetOfInts(a);
            SetOfInts Y = new SetOfInts(b);

            Assert.That(X.Equals(Y), Is.True);
        }

        [Test]
        public void BinKerOkTest()
        {
            int[] v = new int[] { 3, 10, 30 };
            SetOfInts sei = new SetOfInts(v);

            Assert.That(sei.BinKeresés(10), Is.EqualTo(1));
        }

        [Test]
        public void BinKerNOkTest()
        {
            int[] v = new int[] { 3, 10, 30 };
            SetOfInts sei = new SetOfInts(v);

            Assert.That(sei.BinKeresés(11), Is.EqualTo(-1));
        }

        [Test]
        // Részhalmaz-E Teszt
        public void SubsetOk()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] b = new int[] { 3, 6, 9 };
            SetOfInts A = new SetOfInts(a);
            SetOfInts B = new SetOfInts(b);

            Assert.That(B.Subset(A), Is.True);
        }

        [Test]
        // Részhalmaz-E Teszt2
        public void SubsetNOk()
        {
            int[] a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] b = new int[] { -1, 40, 90 };
            SetOfInts A = new SetOfInts(a);
            SetOfInts B = new SetOfInts(b);

            Assert.That(A.Subset(B), Is.False);
        }

        [Test]
        // Metszet teszt
        public void MetszetTest()
        {
            int[] x = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] y = new int[] { 3, 5, 7, 70 };

            int[] vart = new int[] { 3, 5, 7 };
            SetOfInts A = new SetOfInts(x);
            SetOfInts B = new SetOfInts(y);
            SetOfInts Vart = new SetOfInts(vart);

            Assert.That(A.Intersection(B), Is.EqualTo(Vart));
        }

        [Test]
        // Unio teszt
        public void UnioTest()
        {
            int[] x = new int[] { 1, 2, 3, };
            int[] y = new int[] { 3, 5, 7, 70 };

            int[] vart = new int[] { 1, 2, 3, 5, 7, 70 };
            SetOfInts A = new SetOfInts(x);
            SetOfInts B = new SetOfInts(y);
            SetOfInts Vart = new SetOfInts(vart);

            Assert.That(A.Union(B), Is.EqualTo(Vart));
        }

    }
}