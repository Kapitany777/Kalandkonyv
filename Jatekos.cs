using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    /// <summary>
    /// A játékos
    /// </summary>
    public class Jatekos
    {
        public const int MAX_ELETERO = 100;
        
        /// <summary>
        /// A játékos neve
        /// </summary>
        public string Nev { get; }

        /// <summary>
        /// A játékos aktuális életereje
        /// </summary>
        public int Eletero { get; private set; }

        public Jatekos(string nev)
        {
            this.Nev = nev;
            this.Eletero = MAX_ELETERO;
        }

        /// <summary>
        /// A játékos gyógyítása
        /// </summary>
        /// <param name="gyogyitas">Ennyi plusz életerőt kap a gyógyítás során</param>
        public void Gyogyit(int gyogyitas)
        {
            this.Eletero += gyogyitas;

            if (this.Eletero > MAX_ELETERO)
            {
                this.Eletero = MAX_ELETERO;
            }
        }

        /// <summary>
        /// A játékos megsebzése
        /// </summary>
        /// <param name="sebzes">Ennyi életerőt veszít a játékos</param>
        public void Sebez(int sebzes)
        {
            this.Eletero -= sebzes;

            if (this.Eletero < 0)
            {
                this.Eletero = 0;
            }
        }
    }
}
