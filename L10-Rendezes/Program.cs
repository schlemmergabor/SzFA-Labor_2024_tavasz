namespace L10_Rendezes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IComparable[] telefonkönyv =
                new PhoneBookItem[]
                {
                    
                    new PhoneBookItem(){ Név="Pisti",Telefonszám=11 },
                    new PhoneBookItem(){ Név="Jani", Telefonszám=12 },
                    new PhoneBookItem(){ Név="Bazsi", Telefonszám=13 }
                };

            Console.WriteLine(telefonkönyv[1].CompareTo(telefonkönyv[2]));
            // Console.WriteLine("Alma".CompareTo(telefonkönyv[0]));
        }
    }
}
