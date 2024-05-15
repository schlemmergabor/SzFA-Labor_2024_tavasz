using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12_MintaZH2
{
    public class RunnerWithTime : IComparable
    {
        // Property-k
        public string Neve { get; private set; }
        public Time Ideje { get; private set; }

        // Metódusok
        static public RunnerWithTime Parse(string input)
        {
            // Jani,01:56:17 és Zsuzsi,57:38
            string[] darabok = input.Split(',');
            
            // csinálhatnánk hozzá ctort-t de így is megoldhatjuk
            RunnerWithTime rwt = new RunnerWithTime();
            rwt.Neve = darabok[0];
            rwt.Ideje = Time.Parse(darabok[1]);
            return rwt;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) throw new ArgumentNullException();
            if (!(obj is RunnerWithTime)) throw new ArgumentException();

            RunnerWithTime other = obj as RunnerWithTime;

            // idők megegyeznek
            if (this.Ideje.Equals(other.Ideje))
            {
                // név szerint hasonlítjuk össze őket
                return this.Neve.CompareTo(other.Neve);
            }
            // ha nem egyeztek meg, akkor az idők szerint
            return this.Ideje.CompareTo(other.Ideje);
        }

        public override string? ToString()
        {   // Jani (01:56:17)
            return $"{this.Neve} ({this.Ideje})";
        }
        public override bool Equals(object? obj)
        {
            return obj is RunnerWithTime time &&
                   Neve == time.Neve &&
                   EqualityComparer<Time>.Default.Equals(Ideje, time.Ideje);
        }

    }
}
