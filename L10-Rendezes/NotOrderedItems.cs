using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_Rendezes
{
    internal class NotOrderedItems : Exception
    {
        IComparable[] tömb;

        public NotOrderedItems(IComparable[] tömb)
        {
            this.tömb = tömb;
        }
    }
}
