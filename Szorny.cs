using System.Text;

namespace Kalandkonyv
{
    /// <summary>
    /// A szörny szereplők ősosztálya
    /// </summary>
    public abstract class Szorny : Szereplo
    {
        /// <summary>
        /// Az adott szörny agresszív-e?
        /// </summary>
        public bool Agressziv { get; private set; }

        /// <summary>
        /// Az adott szörny lehetséges agresszív viselkedésmódjai
        /// </summary>
        protected List<string> AgresszivViselkedesek = new();

        private readonly Random rnd = new();

        /// <summary>
        /// A szörny létrehozása
        /// </summary>
        /// <param name="nev">A szörny neve</param>
        /// <param name="eletero">A szörny kiinduló életereje</param>
        /// <param name="maxSebzes">A szörny maximális sebzése</param>
        /// <param name="agressziv">Agresszív-e a szörny?</param>
        public Szorny(
            string nev,
            int eletero,
            int maxSebzes,
            bool agressziv) : base(nev, eletero, maxSebzes)
        {
            this.Agressziv = agressziv;
        }

        /// <summary>
        /// Egy véletlenszerű agresszív viselkedés meghatározása
        /// </summary>
        /// <returns>A kiválasztott viselkedés</returns>
        private string AgresszivViselkedes()
        {
            if (AgresszivViselkedesek is null || AgresszivViselkedesek.Count == 0)
            {
                return "Mindjárt megtámad!";
            }

            return AgresszivViselkedesek[rnd.Next(AgresszivViselkedesek.Count)];
        }

        /// <summary>
        /// Az adott szörny leírásának meghatározása
        /// </summary>
        /// <returns>A szörny leírása</returns>
        public override string Leiras()
        {
            var sb = new StringBuilder();

            if (this.Elo)
            {
                sb.AppendLine($"Előtted áll egy {this.Nev}!");

                if (this.Agressziv)
                {
                    sb.AppendLine(AgresszivViselkedes());
                }
                else
                {
                    sb.AppendLine("Szerencsére ma békés hangulatban van, így nem támad rád.");
                }
            }
            else
            {
                sb.AppendLine($"Itt fekszik egy {this.Nev}. Nem mozdul, láthatóan nem jelent már rád veszélyt.");
            }

            return sb.ToString();
        }
    }
}
