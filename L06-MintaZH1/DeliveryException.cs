using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // Exception az őse
    public class DeliveryException : Exception
    {
        // üzenetet kap a ctor
        // ős osztály Exception ctorjának tovább adjuk
        // így lesz benne a kivételben a Message Prop
        public DeliveryException(string uzenet) : base(uzenet)
        {

        }
    }

}
