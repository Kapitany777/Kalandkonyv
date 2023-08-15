using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    /// <summary>
    /// A játék egy szereplője
    /// </summary>
    public abstract class Szereplo : ILeirhato
    {
        /// <summary>
        /// A szereplő neve
        /// </summary>
        public string Nev { get; }

        /// <summary>
        /// A szereplő aktuális életereje
        /// </summary>
        public int Eletero { get; protected set; }

        /// <summary>
        /// Az adott szereplő él-e még
        /// </summary>
        public bool Elo => this.Eletero > 0;

        /// <summary>
        /// Az adott szereplő maximális sebzése
        /// </summary>
        public int MaxSebzes { get; set; }

        /// <summary>
        /// A szereplő létrehozása
        /// </summary>
        /// <param name="nev">A szereplő neve</param>
        /// <param name="eletero">A szereplő kiinduló életereje</param>
        /// <param name="maxSebzes">A szereplő maximális sebzése</param>
        public Szereplo(
            string nev,
            int eletero,
            int maxSebzes)
        {
            this.Nev = nev;
            this.Eletero = eletero;
            this.MaxSebzes = maxSebzes;
        }

        /// <summary>
        /// A szereplő megsebzése
        /// </summary>
        /// <param name="sebzes">Ennyi életerőt veszít a szereplő</param>
        public void Megsebez(int sebzes)
        {
            this.Eletero -= sebzes;

            if (this.Eletero < 0)
            {
                this.Eletero = 0;
            }
        }

        /// <summary>
        /// A szereplő leírásának összeállítása
        /// </summary>
        /// <returns>A szereplő leírása</returns>
        public abstract string Leiras();
    }
}
