using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    public static class ConsoleHandler
    {
        /// <summary>
        /// A hős nevének bekérése
        /// </summary>
        /// <returns>A hős neve</returns>
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

        /// <summary>
        /// Igen / Nem válasz bekérése
        /// </summary>
        /// <returns>A megadott válasz nagybetűsre konvertálva</returns>
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

        /// <summary>
        /// A következő fejezet sorszámának bekérése
        /// </summary>
        /// <returns>A beírt sorszám</returns>
        public static int SorszamBekeres()
        {
            string? valasz = string.Empty;
            int sorszam;

            while (string.IsNullOrEmpty(valasz) || !int.TryParse(valasz, out sorszam))
            {
                Console.Write("Sorszám: ");
                valasz = Console.ReadLine();
            }

            return sorszam;
        }

        /// <summary>
        /// Színes szöveg kiírása
        /// </summary>
        /// <param name="szoveg">A kiírandó szöveg</param>
        /// <param name="color">A kiírás színe</param>
        public static void SzinesSzovegKiirasa(string szoveg, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(szoveg);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
