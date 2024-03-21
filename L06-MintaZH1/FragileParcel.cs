using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // public a tesztelés miatt
    // : Parcel -> ebből származik
    public class FragileParcel : Parcel
    {
        // ctor, meghívja az őse ctor-ját
        public FragileParcel(Mod elhelyezesiMod, int weight, string address) 
            : base(elhelyezesiMod, weight, address)
        {
            // ha az elhelyezési mód tetszőleges, akkor exception-t dobunk
            // amiben bele tesszük a csomagra (this)-re a ref-et.
            if (elhelyezesiMod == Mod.Arbitrary)
                throw new IncorrectOrientationException(this);
        }

        // új árat kalkulálunk
        public override double CalculatePrice(bool fromLocker)
        {
            int dij = 1000 + this.Weight * 2;

            // csomagautomatás feladat esetén -> Exception
            if (fromLocker)
                throw new DeliveryException("Nem adható fel törékeny csomag automatából");

            return dij;
        }
    }

}
