using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    public abstract class Tortenet
    {
        public string Cim { get; protected set; }
        public Jatekos Jatekos { get; }
        public bool Harc { get; }

        protected List<Fejezet> fejezetek;

        public Tortenet(Jatekos jatekos, bool harc)
        {
            this.Cim = string.Empty;
            this.Jatekos = jatekos;

            this.Harc = harc;

            fejezetek = new List<Fejezet>();
            FejezetekLetrehozasa();
        }

        public abstract void FejezetekLetrehozasa();

        public abstract void Koszonto();

        public void Futtatas()
        {
            Koszonto();

            var aktualisFejezet = fejezetek[0];

            while (true)
            {
                Console.WriteLine(this.Jatekos);
                Console.WriteLine();

                aktualisFejezet.Kiir();
                Console.WriteLine();

                Console.WriteLine("Merre mész tovább?");

                foreach (int lehetoseg in aktualisFejezet.TovabbiLehetosegek)
                {
                    Console.WriteLine(lehetoseg);
                }

                int sorszam = ConsoleHandler.SorszamBekeres();

                break;
            }
        }
    }
}
