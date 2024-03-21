using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L06_MintaZH1
{
    // Enum, ahogy a feladat kérte
    // ide tedd a namespace alá, hogy mindenhonnan elérhető legyen !
    public enum Mod
    {
        Arbitrary, Horizontal, Vertical
    }
    // public a tesztelés miatt
    // abstract mert a feladat azt kérte
    // plusz mert van legalább 1 abstract metódusa -> előírás a gyerek osztályokra
    // két IFace-t valósít meg ezeket : után felsorolod
    // IComparable -> beépített rendezéshez (Array.Sort()) kell
    public abstract class Parcel: IDeliverable, IComparable
    {
        // elhelyezési módhoz Prop
        // kezdetben private set volt -> azaz csak ebből az osztályból állítani
        // de a NormalParcel (ennek a leszármazottja amúgy) osztályból is kell állítani
        // így került oda a protected a set elé
        public Mod ElhelyezesiMod
        {
            get;
            protected set;
        }

        public Parcel(Mod elhelyezesiMod, int weight, string address)
        {
            ElhelyezesiMod = elhelyezesiMod;
            Weight = weight;
            Address = address;
        }
        
        // ez egy olyan konstruktor ami meghívja a háromparaméteres ctor-t
        public Parcel(int weight, string address) : this(Mod.Arbitrary, weight, address)
        {
        }

        // IFace által előírt Prop-ok, Metódusok
        public int Weight
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }

        public abstract double CalculatePrice(bool fromLocker);

        // IComparable által előírt metódus
        // Array.Sort(...) ezt fogja használni
        public int CompareTo(object? obj)
        {
            // két ugyanolyan osztályú objektumot kell összehasonlítani
            // this osztálya Parcel
            // a paraméter obj, viszont object? típusú
            // -> át kell castolni Parcel-é és akkor tudjuk összehasonlítani

            Parcel temp = (Parcel)obj;
            // ha nem megoldható a castolás pl az obj "kiskutya" lenne,
            // akkor null ref kerül a temp-be
            // dobahatnánk egy ilyen kivételt
            // if (temp == null) throw new ArgumentException();
            // de most a feladatban is végig "jó" osztályokkal fogunk dolgozni.

            // nézd meg a < jel állását
            // a sorrend most az lenne, hogy
            // this, < temp -> tehát a this előrébb van, így a -1 megy vissza

            if (temp.Weight > this.Weight) return -1;
            
            // itt a sorrend: temp, < this, tehát a temp hátrébb van 1 megy vissza
            if (temp.Weight < this.Weight) return 1;
            // megegyező értékek esetén 0
            return 0;
        }

        public override string? ToString()
        {
            return $"Címzett: {this.Address} " +
                $"/ Elhelyzési Mód: {this.ElhelyezesiMod}  " +
                $"/ Tömeg:{this.Weight} g";
        }
    }

}
