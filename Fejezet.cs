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
    public class Fejezet : ILeirhato
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
        /// Az adott helyszínen esetleg található szörny
        /// </summary>
        public Szorny? Szorny { get; set; }

        /// <summary>
        /// Ha a játékos eléri ezt a helyszínt, akkor befejeződik-e a játék?
        /// </summary>
        public bool Befejezes { get; set; }

        /// <summary>
        /// Merre lehet továbbmenni az adott helyszínről
        /// </summary>
        public List<int> TovabbiLehetosegek { get; }

        /// <summary>
        /// A fejezet létrehozása
        /// </summary>
        /// <param name="sorszam">A fejezet sorszáma</param>
        /// <param name="cimke">A fejezet rövid leírása, címkéje</param>
        /// <param name="szoveg">A fejezet teljes szövege</param>
        /// <param name="tovabbiLehetosegek">Merre mehet tovább a játékos</param>
        /// <param name="befejezes">Ez a fejezet a végső befejezést jelenti-e a játékban?</param>
        public Fejezet(
            int sorszam,
            string cimke,
            string szoveg,
            List<int> tovabbiLehetosegek,
            bool befejezes = false)
        {
            Sorszam = sorszam;
            Cimke = cimke;
            Szoveg = szoveg;
            TovabbiLehetosegek = tovabbiLehetosegek;
            Befejezes = befejezes;
            Szorny = null;
        }

        /// <summary>
        /// A fejezet leírásának összeállítása
        /// </summary>
        /// <returns>A fejezet leírása</returns>
        public string Leiras()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Sorszam}. fejezet");
            sb.AppendLine(this.Cimke);
            sb.AppendLine(this.Szoveg);

            return sb.ToString();
        }
    }
}
