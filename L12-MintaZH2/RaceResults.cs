using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12_MintaZH2
{
    public class RaceResults
    {
        // adattag
        RunnerWithTime[] adatok;

        // ctor
        public RaceResults(int runnersCount, string[] inputs)
        {
            this.adatok = new RunnerWithTime[runnersCount];

            // feltöltés
            for (int i = 0; i < inputs.Length; i++)
            {
                this.adatok[i] = RunnerWithTime.Parse(inputs[i]);
            }

            // idő szerinti rendezés, ha nem rendezett
            if (!IsSorted()) Sort();
        }

        // rendezettség vizsgálata
        private bool IsSorted()
        {
            // Early Exit-el
            for (int i = 0; i < adatok.Length - 1; i++)
            {
                if (adatok[i].CompareTo(adatok[i + 1]) > 0) return false;
            }
            return true;
        }
        // idő szerinti rendezés
        private void Sort()
        {
            // javított beillesztéses rendezés
            for (int i = 1; i < this.adatok.Length; i++)
            {
                int j = i - 1;
                RunnerWithTime temp = this.adatok[i];

                while (j >= 0 && temp.CompareTo(this.adatok[j]) < 0)
                {
                    this.adatok[j + 1] = adatok[j];
                    j--;
                }
                this.adatok[j + 1] = temp;
            }
        }

        private int LowerBound(Time time)
        {
            return 0;
        }
        private int UpperBound(Time time)
        {
            return 0;
        }
    }
}
