using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_Rendezes
{
    public class PhoneBookItem : IComparable
    {
        // Propertyk
        public string Név { get; set; }
        public int Telefonszám { get; set; }

        public int CompareTo(object? obj)
        {
            // Early Exittel
            // ha nem PBI, nem string -> Exit.
            if (!(obj is PhoneBookItem) && !(obj is string))
            {
                throw new ArgumentException();
            }

            // PBI-e az obj paraméter?
            if (obj is PhoneBookItem)
            {
                return this.Név.CompareTo((obj as PhoneBookItem).Név);
            }

            // string
            // innentől már biztos, hogy string az obj
            return this.Név.CompareTo(obj as string);
        }
    }
}
