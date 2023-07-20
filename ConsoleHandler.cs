using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    public static class ConsoleHandler
    {
        public static string NevBekerese()
        {
            string? nev = string.Empty;

            while (string.IsNullOrEmpty(nev))
            {
                Console.Write("Add meg a hős nevét: ");
                nev = Console.ReadLine();
            }

            return nev;
        }

        public static string ValaszBekeres()
        {
            string? valasz = string.Empty;

            while (string.IsNullOrEmpty(valasz) || !"iInN".Contains(valasz))
            {
                Console.Write("Válasz (I/N): ");
                valasz = Console.ReadLine();
            }

            return valasz.ToUpper();
        }

        public static int SorszamBekeres()
        {
            string? valasz = string.Empty;
            int sorszam = 0;

            while (string.IsNullOrEmpty(valasz) || !int.TryParse(valasz, out sorszam))
            {
                Console.Write("Sorszám: ");
                valasz = Console.ReadLine();
            }

            return sorszam;
        }
    }
}
