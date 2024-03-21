using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // DeliveryException az őse
    public class IncorrectOrientationException
        : DeliveryException
    {
        // eltároljuk a csomagot
        // kívülről lekérdezhető lesz
        // viszont csak private set, hogy csak mi tudjuk állítani
        public FragileParcel Csomag
        {
            get;
            private set;
        }

        // base(...) -el meghívjuk az ősének a ctorját, amiben
        // belekódoljuk a hibaüzenetet
        public IncorrectOrientationException(FragileParcel csomag)
            : base("Nem jó a csomag elhelyezési módja")
        {
            Csomag = csomag;
        }
    }

}
