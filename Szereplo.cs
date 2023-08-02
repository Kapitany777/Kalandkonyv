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
    public abstract class Szereplo
    {
        /// <summary>
        /// A szereplő neve
        /// </summary>
        public string Nev { get; }

        /// <summary>
        /// A szereplő aktuális életereje
        /// </summary>
        public int Eletero { get; protected set; }

        public Szereplo(
            string nev,
            int eletero)
        {
            this.Nev = nev;
            this.Eletero = eletero;
        }

        /// <summary>
        /// A szereplő megsebzése
        /// </summary>
        /// <param name="sebzes">Ennyi életerőt veszít a szereplő</param>
        public void Sebez(int sebzes)
        {
            this.Eletero -= sebzes;

            if (this.Eletero < 0)
            {
                this.Eletero = 0;
            }
        }

        /// <summary>
        /// A szereplő adatainak kiírása
        /// </summary>
        public abstract void Kiir();
    }
}
