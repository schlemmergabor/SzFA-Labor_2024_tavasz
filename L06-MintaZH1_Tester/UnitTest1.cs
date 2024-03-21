using L06_MintaZH1;
namespace L06_MintaZH1_Tester
{
    // Új projekt, Template-nél -> nUnit -> C#-ot válaszd ki
    // Testfixture nélkül is megy, de vizsgán mondd el! :)

    // Add -> Project Reference -> L06-MintaZH1-re pipa !!!

    // Az osztály tesztelési célokat szolgál
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // paraméteres teszteket csinálunk
        [TestCase(true, 200, 400)]
        [TestCase(false, 200, 400)]
        [TestCase(false, 501, 1000)]

        // paraméteres a tesztelõs metódus
        public void ET1(bool csomagAutomata, int gramm, int vart)
        {
            Envelope e = new Envelope("l", gramm, "c");

            // tesztelendõ metódus, várt érték
            Assert.That(e.CalculatePrice(csomagAutomata), Is.EqualTo(vart));
        }

        // dob-e 2000 felett kivételt
        [Test]
        public void ET2()
        {
            Envelope e = new Envelope("l", 2001, "x");

            // try catch is mehetne -> lásd lejebb a példát!
            Assert.Throws<OverweightException>(() => e.CalculatePrice(true));
        }

        // törékenyt nem adhatunk fel automatából -> exception
        [Test]
        public void FPT1()
        {
            FragileParcel fp = new FragileParcel(Mod.Horizontal, 200, "c");

            Assert.Throws<DeliveryException>(() => fp.CalculatePrice(true));
        }

        // törékeny nem mehet tetszõleges mód-al
        [Test]
        public void FPT2()
        {
            // példa try catch-re
            try
            {
                FragileParcel fp = new FragileParcel(Mod.Arbitrary, 200, "c");

            }
            // ilyen kivételt várunk tõle
            catch (IncorrectOrientationException)
            {
                // átmegy a teszten
                Assert.Pass();
            }
            // nem megy át a teszten
            Assert.Fail();
            
            // Assert.Throws-al így nézne ki
            // Assert.Throws<IncorrectOrientationException>(() => new FragileParcel(Mod.Arbitrary, 200, "c"));
        }

        // csomagok össztömege jó-e
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
            int összTömeg = 0;
            for (int i = 0; i < csomagok.Length; i++)
            {
                c.PickUpItem(csomagok[i]);
                összTömeg += csomagok[i].Weight;
            }

            Assert.That(c.OsszTomeg, Is.EqualTo(összTömeg));
        }

        // jók-e a kiválogatott csomagok
        [Test]
        public void CT2()
        {
            Courier c = new Courier(10);
            
            // legyen benne törékeny különbözõ súly-al
            IDeliverable[] csomagok = new IDeliverable[]
            {
                new FragileParcel(Mod.Horizontal, 100, "c"),
                new Envelope("l", 101, "c"),
                new NormalParcel(201, "c"),
                new FragileParcel(Mod.Horizontal, 90, "c")
            };

            // felveszi a csomagokat a futár
            for (int i = 0; i < csomagok.Length; i++)
            {
                c.PickUpItem(csomagok[i]);
            }

            // ezeket a csomagokat várjuk a metódustól, ilyen sorrendben
            IDeliverable[] vart = new IDeliverable[]
            {
                csomagok[3], csomagok[0]
            };
            
            // teszt ellenõrzés
            Assert.That(c.FragilesSorted(), Is.EqualTo(vart));
        }
    }
}