using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // interfész
    // előírásokat tartalmaz Property-re és Metódus-ra
    // mező nem lehet benne,
    // kitöltött/megvalósított metódus nem lehet benne

    // public a láthatósága a tesztelések miatt
    public interface IDeliverable
    {
        // súly előírás, get, set
        int Weight { get; set; }

        // cím előírás, get, set
        string Address { get; set; }

        // metódus előírás
        double CalculatePrice(bool fromLocker);

    }

}
