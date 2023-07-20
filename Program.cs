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

        static string ValaszBekeres()
        {
            string? valasz = string.Empty;

            while (string.IsNullOrEmpty(valasz) || !"iInN".Contains(valasz))
            {
                Console.Write("Válasz (I/N): ");
                valasz = Console.ReadLine();
            }

            return valasz.ToUpper();
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Üdvözöllek a Véres bosszú című játékban!");
            Console.WriteLine();

            string nev = NevBekerese();
            var jatekos = new Jatekos(nev);

            Console.WriteLine("Csak a történetre vagy kíváncsi?");
            Console.WriteLine("Vagy inkább szeretnél harcot? (I / N): ");
            string valasz = ValaszBekeres();

            var tortenet = new VeresBosszu(jatekos, valasz == "I");

            Console.Clear();
            tortenet.Futtatas();
        }
    }
}