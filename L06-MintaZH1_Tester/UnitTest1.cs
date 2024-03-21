using L06_MintaZH1;
namespace L06_MintaZH1_Tester
{
    // �j projekt, Template-n�l -> nUnit -> C#-ot v�laszd ki
    // Testfixture n�lk�l is megy, de vizsg�n mondd el! :)

    // Add -> Project Reference -> L06-MintaZH1-re pipa !!!

    // Az oszt�ly tesztel�si c�lokat szolg�l
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // param�teres teszteket csin�lunk
        [TestCase(true, 200, 400)]
        [TestCase(false, 200, 400)]
        [TestCase(false, 501, 1000)]

        // param�teres a tesztel�s met�dus
        public void ET1(bool csomagAutomata, int gramm, int vart)
        {
            Envelope e = new Envelope("l", gramm, "c");

            // tesztelend� met�dus, v�rt �rt�k
            Assert.That(e.CalculatePrice(csomagAutomata), Is.EqualTo(vart));
        }

        // dob-e 2000 felett kiv�telt
        [Test]
        public void ET2()
        {
            Envelope e = new Envelope("l", 2001, "x");

            // try catch is mehetne -> l�sd lejebb a p�ld�t!
            Assert.Throws<OverweightException>(() => e.CalculatePrice(true));
        }

        // t�r�kenyt nem adhatunk fel automat�b�l -> exception
        [Test]
        public void FPT1()
        {
            FragileParcel fp = new FragileParcel(Mod.Horizontal, 200, "c");

            Assert.Throws<DeliveryException>(() => fp.CalculatePrice(true));
        }

        // t�r�keny nem mehet tetsz�leges m�d-al
        [Test]
        public void FPT2()
        {
            // p�lda try catch-re
            try
            {
                FragileParcel fp = new FragileParcel(Mod.Arbitrary, 200, "c");

            }
            // ilyen kiv�telt v�runk t�le
            catch (IncorrectOrientationException)
            {
                // �tmegy a teszten
                Assert.Pass();
            }
            // nem megy �t a teszten
            Assert.Fail();
            
            // Assert.Throws-al �gy n�zne ki
            // Assert.Throws<IncorrectOrientationException>(() => new FragileParcel(Mod.Arbitrary, 200, "c"));
        }

        // csomagok �sszt�mege j�-e
        [Test]
        public void CT1()
        {
            Courier c = new Courier(10);
            IDeliverable[] csomagok = new IDeliverable[]
            {
                new FragileParcel(Mod.Horizontal, 100, "c"),
                new Envelope("l", 101, "c"),
                new NormalParcel(201, "c"),
                new FragileParcel(Mod.Horizontal, 90, "c")
            };
            int �sszT�meg = 0;
            for (int i = 0; i < csomagok.Length; i++)
            {
                c.PickUpItem(csomagok[i]);
                �sszT�meg += csomagok[i].Weight;
            }

            Assert.That(c.OsszTomeg, Is.EqualTo(�sszT�meg));
        }

        // j�k-e a kiv�logatott csomagok
        [Test]
        public void CT2()
        {
            Courier c = new Courier(10);
            
            // legyen benne t�r�keny k�l�nb�z� s�ly-al
            IDeliverable[] csomagok = new IDeliverable[]
            {
                new FragileParcel(Mod.Horizontal, 100, "c"),
                new Envelope("l", 101, "c"),
                new NormalParcel(201, "c"),
                new FragileParcel(Mod.Horizontal, 90, "c")
            };

            // felveszi a csomagokat a fut�r
            for (int i = 0; i < csomagok.Length; i++)
            {
                c.PickUpItem(csomagok[i]);
            }

            // ezeket a csomagokat v�rjuk a met�dust�l, ilyen sorrendben
            IDeliverable[] vart = new IDeliverable[]
            {
                csomagok[3], csomagok[0]
            };
            
            // teszt ellen�rz�s
            Assert.That(c.FragilesSorted(), Is.EqualTo(vart));
        }
    }
}