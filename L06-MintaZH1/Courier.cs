using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // futár osztályunk
    // public, mert tesztelni fogjuk
    public class Courier
    {
        // meg kell nézni, hogy az elkészített osztályokban mi a közös
        // van-e egy közös ősük, vagy van-e egy közös IFace-amit megvalósítanak
        // FragileParcel : Parcel
        // NormalParcel : Parcel
        // Parcel : IDeliverable, IComperable
        // Envelope : IDeliverable

        // FragileParcel, NormalParcel őse a sima Parcel, ami megvalósítja a két IFace-t
        // így ezek is megvalósítják, tehát:
        // FragileParcel : Parcel, IDeliverable, IComperable
        // NormalParcel : Parcel, IDeliverable, IComperable
        // Parcel : IDeliverable, IComperable
        // Envelope : IDeliverable
        // közös mindegyikben az IDeliverable -> ő a tömb

        IDeliverable[] tömb;

        // utoljára beletett elem indexe
        // kezdbetben azért -1, mert üres a tömb
        // 0 nem lehetne kezdetben meg akkor már van a 0. indexen egy elem
        int idx = -1;

        // össztömeget számítunk on the fly
        public int OsszTomeg
        {
            get
            {
                int össz = 0;
                for (int i = 0; i < tömb.Length; i++)
                {
                    // ha az i. tömb elem nem null, akkor van súlya !
                    if (tömb[i] != null) össz += tömb[i].Weight;
                    // rövidebben a ? és ?? operátorokkal
                    // össz += tömb[i]?.Weight ?? 0;
                }

                return össz;
            }
        }

        // ctor
        public Courier(int elemSzam)
        {
            this.tömb = new IDeliverable[elemSzam];
        }

        // metódus
        public void PickUpItem(IDeliverable item)
        {
            // ha a legutoljára betett indexe már az utolsó index, akkor
            // nincs több hely
            // 
            // írj fel egy példát -> legyen egy 3 elemű tömb
            // Length: 3
            // Lehetséges indexek: 0, 1, 2 
            // mikor nem fér bele?
            // ha az idx már 2, azaz Length-1
            
            if (idx == this.tömb.Length - 1)
                throw new DeliveryException("nem fér bele");
            
            // minden más esetben belerakjuk a tömbbe

            this.tömb[++idx] = item;


            // // megoldható az eldöntés programozási tétel felhasználásával
            // // ekkor nem kell idx segéd változó
            // // lásd: https://users.nik.uni-obuda.hu/sergyan/Programozas1Jegyzet.pdf - 25. oldal

            // // első vizsgált index 0
            // int i = 0;
            // // amíg nem értünk a végére és nem null (üres) hely van
            // while ((i <= tömb.Length - 1) && !(tömb[i] == null))
            // {
            //     i++;
            // }
            // // ha az i a tömb hosszával ==, azaz tele volt -> throw
            // if (i == tömb.Length) throw new DeliveryException("nem fér bele");

            // // i -ben megvan az első null indexe -> ide mehet az item
            // this.tömb[i] = item;

        }

        // sorrendezés
        public IDeliverable[] FragilesSorted()
        {
            // megoldható, hogy folyamatosan növeljük a tömb méretét
            // új tömb ami 1-el nagyobb
            // átmásoljuk az összes elemet
            // utolsó helyre az új item
            // de a másolás miatt ez erőforrás igényes -> lassú

            // inkább vállaljuk be azt, hogy 2x járjuk be az összes elemet
            // egyszer az eredménytömb méretéért
            // egyszer pedig a kiválogatás miatt

            // eredmény tömb méretének meghatározása
            int db = 0;
            for (int i = 0; i < tömb.Length; i++)
            {
                if (tömb[i] is FragileParcel) db++;
            }

            // ha nincs, akkor hát nincs :)
            if (db == 0) return null;


            IDeliverable[] result = new IDeliverable[db];
            // melyik indexre kerülhet az új elem?
            int idx = 0;

            for (int i = 0; i < tömb.Length; i++)
            {
                if (tömb[i] is FragileParcel)
                    result[idx++] = tömb[i];
            }

            // rendezzük, CompareTo-t hívogatja
            Array.Sort(result);
            // visszaadjuk
            return result;
        }

    }
}
