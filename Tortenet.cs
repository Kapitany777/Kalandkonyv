﻿using System;
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

        protected List<Fejezet> fejezetek;

        public Tortenet(Jatekos jatekos)
        {
            this.Cim = string.Empty;
            this.Jatekos = jatekos;

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

                foreach (int sorszam in aktualisFejezet.TovabbiLehetosegek)
                {
                    Console.WriteLine(sorszam);
                }

                break;
            }
        }
    }
}
