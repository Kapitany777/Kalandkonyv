using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
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

        public Szorny(
            string nev,
            int eletero,
            int maxSebzes,
            bool agressziv) : base(nev, eletero, maxSebzes)
        {
            Agressziv = agressziv;
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
        /// <returns>A leírás</returns>
        public override string Leiras()
        {
            var sb = new StringBuilder();

            if (this.Elo)
            {
                sb.AppendLine($"Itt áll egy {this.Nev}.");

                if (this.Agressziv)
                {
                    sb.AppendLine(AgresszivViselkedes());
                }
                else
                {
                    sb.AppendLine("Szerencsére ma békés hangulatban van, nem támad rád.");
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
