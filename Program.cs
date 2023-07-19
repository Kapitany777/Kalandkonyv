namespace Kalandkonyv
{
    internal class Program
    {
        static string NevBekerese()
        {
            string? nev = string.Empty;

            while (string.IsNullOrEmpty(nev))
            {
                Console.Write("Add meg a hős nevét: ");
                nev = Console.ReadLine();
            }

            return nev;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Üdvözöllek a Véres bosszú című játékban!");
            Console.WriteLine();

            string nev = NevBekerese();
            var jatekos = new Jatekos(nev);
            var tortenet = new VeresBosszu(jatekos);

            Console.Clear();
            tortenet.Futtatas();
        }
    }
}