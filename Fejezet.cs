using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    /// <summary>
    /// A történet egy fejezete
    /// </summary>
    public class Fejezet
    {
        /// <summary>
        /// A fejezet sorszáma
        /// </summary>
        public int Sorszam { get; }

        /// <summary>
        /// A fejezet címkéje
        /// </summary>
        public string Cimke { get; }

        /// <summary>
        /// A fejezet teljes szövege
        /// </summary>
        public string Szoveg { get; }

        /// <summary>
        /// Ha a játékos eléri ezt a helyszínt, akkor győz-e?
        /// </summary>
        public bool Gyozelem { get; set; }

        /// <summary>
        /// Merre lehet továbbmenni az adott helyszínről
        /// </summary>
        public List<int> TovabbiLehetosegek { get; }

        public Fejezet(
            int sorszam,
            string cimke,
            string szoveg,
            List<int> tovabbiLehetosegek,
            bool gyozelem = false)
        {
            Sorszam = sorszam;
            Cimke = cimke;
            Szoveg = szoveg;
            TovabbiLehetosegek = tovabbiLehetosegek;
            Gyozelem = gyozelem;
        }

        /// <summary>
        /// A fejezet szövegének kiírása a konzolra
        /// </summary>
        public void Kiir()
        {
            Console.WriteLine($"{this.Sorszam}. fejezet");
            Console.WriteLine(this.Cimke);
            Console.WriteLine(this.Szoveg);
        }
    }
}
