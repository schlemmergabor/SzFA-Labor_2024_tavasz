using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using L09_TrainingCosts;

namespace L09_TrainingCostsTests
{
    [TestFixture]
    internal class MonthlyCostsTests
    {
        [Test]
        public void LoadFromNonExisting()
        {
            Assert.Throws<FileNotFoundException>(() => MonthlyCosts.LoadFrom("non_existing.csv"));
        }

        [Test]
        public void LoadFromEmpty()
        {
            MonthlyCosts februaryCosts = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_02.csv");
            Assert.That(februaryCosts.TrainingCosts.Length, Is.EqualTo(0));
        }

        [Test]
        public void LoadFromSuccessful()
        {
            MonthlyCosts januaryCosts = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");
            Assert.That(januaryCosts.TrainingCosts.Length, Is.EqualTo(6));
        }
        ////////////////////////////////////////////////////////////////////////////////
        //                                    //
        // Innen kezdődik a feladat megoldása //
        //  
        //
        [TestCase("01", 65900)]
        [TestCase("02", 0)]
        public void TeljesKöltésTeszt(string honap, int vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");

            Assert.That(c.TeljesKöltés(), Is.EqualTo(vart));
        }

        [TestCase("01", 10000, 42100)]

        public void TeljesKöltésFeltétellelTeszt2(string honap, int nagyobb, int vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");

            Assert.That(c.TeljesKöltés(p => p.Cost > nagyobb), Is.EqualTo(vart));
        }

        [TestCase(TrainingType.Cycling, 14500, true)]
        [TestCase(TrainingType.Cycling, 9500, false)]
        public void VoltETeszt(TrainingType tr, int ertek, bool vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");

            Assert.That(c.VoltE(p => p.Cost == ertek && p.Type == tr), Is.EqualTo(vart));
        }

        [TestCase(1000, true)]
        [TestCase(100000, false)]
        public void MindenETeszT(int ertek, bool vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");

            Assert.That(c.MindenE(a => a.Cost > ertek), Is.EqualTo(vart));

        }

        [TestCase(3, "2024.01.11", true)]
        [TestCase(4, "2024.01.11", false)]
        public void VoltEkDbKöltésTeszt(int ertek, string datum, bool vart)
        {


            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");
            Assert.That(c.VoltE(ertek, a => a.Date > DateOnly.Parse(datum)), Is.EqualTo(vart));
        }

        [TestCase(3, "2024.01.11", 5)]
        [TestCase(4, "2024.01.11", -1)]
        public void MelyikTeszt(int ertek, string datum, int index)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");
            // null ref returnját akarjuk ellenőrizni
            if (index == -1)
            {
                Assert.That(c.Melyik(ertek, a => a.Date > DateOnly.Parse(datum)), Is.Null);
            }
            else
            {
                Assert.That(c.Melyik(ertek, a => a.Date > DateOnly.Parse(datum)), Is.EqualTo(c.TrainingCosts[index]));
            }
        }

        [TestCase(6, 1000)]
        [TestCase(3, 10000)]
        [TestCase(0, 100000000)]
        public void DbTeszt(int vart, int ertek)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_01.csv");
            Assert.That(c.DB(a => a.Cost > ertek), Is.EqualTo(vart));
        }
        [TestCase("01", 5)]
        [TestCase("02", -1)]
        public void LegnagyobbTeszt(string honap, int index)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");
            if (index == -1)
            {
                Assert.Throws<ZeroLengthArrayException>(() => c.Legnagyobb());
            }
            else
            {
                Assert.That(c.Legnagyobb(), Is.EqualTo(c.TrainingCosts[index]));
            }
        }


        [TestCase("01", new int[] { 5 })]
        [TestCase("03", new int[] { 0, 1, 5 })]
        public void MaxokTeszt(string honap, int[] vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");
            int[] v = c.Maxok();
            ;
            Assert.That(c.Maxok(), Is.EqualTo(vart));
        }

        [TestCase("01", TrainingType.Swimming, 5)]
        [TestCase("02", TrainingType.Running, -1)]
        [TestCase("01", TrainingType.Cycling, 0)]
        public void LegnagyobbFeltétellelTeszt(string honap, TrainingType t, int vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");
            if (vart == -1)
            {
                Assert.IsNull(c.LegnagyobbFeltétellel(b => b.Cost > 0));
            }
            else
            {
                Assert.That(c.LegnagyobbFeltétellel(b => b.Type == t), Is.EqualTo(c.TrainingCosts[vart]));
            }
        }

        [TestCase("01", 5)]
        [TestCase("02", -1)]
        [TestCase("03", 5)]
        public void LegnagyobbSulyozassalTeszt(string honap, int vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");
            if (vart == -1)
            {
                Assert.IsNull(c.LegnagyobbSulyozassal());
            }
            else
            {
                Assert.That(c.LegnagyobbSulyozassal(), Is.EqualTo(c.TrainingCosts[vart]));
            }
        }

        [TestCase("01", new int[] { 0,2,5 })]
        [TestCase("02", new int[] {  })]
        public void FeltételesIndexekTeszt(string honap, int[] vart)
        {
            MonthlyCosts c = MonthlyCosts.LoadFrom(@"..\..\..\csv_files\2024_" + honap + ".csv");

            Assert.That(c.FeltételesIndexek(p => p.Cost > 10000), Is.EqualTo(vart));
        }

        



    }
}

