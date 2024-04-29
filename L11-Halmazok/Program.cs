namespace L11_Halmazok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //
            int[] x = new int[] { 1, 2, 3, };
            int[] y = new int[] { 3, 5, 7, 70 };

            int[] vart = new int[] { 1, 2, 3, 5, 7, 70 };
            SetOfInts A = new SetOfInts(x);
            SetOfInts B = new SetOfInts(y);
            SetOfInts Vart = A.Union(B);

            ;

            

        }
    }
}
