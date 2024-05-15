using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12_MintaZH2
{
    public class Time : IComparable
    {
        // mezők
        int ora, perc, masodperc;

        // Propertyk, setterek, getterek
        public int Ora
        {
            get => this.ora;
            set
            {
                if (value < 0) throw new TimeException("Nem lehet 0-nál kisebb az értéke!");
                if (value > 3) throw new TimeException("Nem lehet 3-nál nagyobb az értéke!");

                this.ora = value;
            }
        }

        public int Perc
        {
            get => this.perc;
            set
            {
                if (value < 0) throw new TimeException("Nem lehet 0-nál kisebb az értéke!");
                if (value > 59) throw new TimeException("Nem lehet 59-nél nagyobb az értéke!");
                this.perc = value;
            }
        }

        public int Masodperc
        {
            get => masodperc;
            set
            {
                if (value < 0) throw new TimeException("Nem lehet 0-nál kisebb az értéke!");
                if (value > 59) throw new TimeException("Nem lehet 59-nél nagyobb az értéke!");
                this.masodperc = value;
            }

        }

        // ctor settereken (Propertyn) keresztül
        // három paraméteres
        public Time(int ora, int perc, int masodperc)
        {
            Ora = ora;
            Perc = perc;
            Masodperc = masodperc;
        }

        // két paraméteres -> ekkor óra = 0
        public Time(int perc, int masodperc) : this(0, perc, masodperc)
        {
        }

        public override string? ToString()
        {
            if (this.ora > 0) return $"{this.ora:00}:{this.perc:00}:{this.masodperc:00}";
            return $"{this.perc:00}:{this.masodperc:00}";
        }

        static public Time Parse(string input)
        {
            // vezető nullák ha hiányoznak
            if (input.Length != 5 && input.Length != 8) throw new TimeException("Nem jó az input formátuma!");

            string[] darabok = input.Split(':');
            if (darabok.Length == 2)
            {
                return new Time(int.Parse(input.Split(":")[0]), int.Parse(input.Split(":")[1]));
            }
            if (darabok.Length == 3)
            {
                return new Time(int.Parse(input.Split(":")[0]), int.Parse(input.Split(":")[1]), int.Parse(input.Split(":")[2]));
            }

            // ha rossz a formátum
            throw new TimeException("Nem jó az input formátuma!");
        }

        // Akkor egyeznek meg, ha minden adattag megegyezik
        public override bool Equals(object? obj)
        {
            return obj is Time time &&
                   Ora == time.Ora &&
                   Perc == time.Perc &&
                   Masodperc == time.Masodperc;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) throw new ArgumentNullException();
            if (!(obj is Time)) throw new ArgumentException();

            Time other = obj as Time;

            // this össz mp kiszámolása
            int aMp = this.Ora * 60 * 60 + this.Perc * 60 + this.Masodperc * 60;

            // other össz mp kiszámolása
            int bMp = other.Ora * 60 * 60 + other.Perc * 60 + other.Masodperc * 60;

            // két össz mp összehasonlítása -> int.CompareTo-val
            return aMp.CompareTo(bMp);
        }
    }
}
