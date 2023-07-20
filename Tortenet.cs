using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    /// <summary>
    /// A történeteket kezelő absztrakt osztály
    /// </summary>
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

                if (aktualisFejezet.Gyozelem)
                {
                    Console.WriteLine("Gratulálok, megnyerted a játékot!");
                    break;
                }

                if (aktualisFejezet.TovabbiLehetosegek.Count == 0)
                {
                    Console.WriteLine("Kalandod itt véget ér...");
                    break;
                }

                Console.WriteLine("Merre mész tovább?");

                foreach (int lehetoseg in aktualisFejezet.TovabbiLehetosegek)
                {
                    var cimke = fejezetek
                       .Where(f => f.Sorszam == lehetoseg)
                       .First()
                       .Cimke;

                    Console.WriteLine($"{lehetoseg} - {cimke}");
                }

                Fejezet? kovetkezoFejezet = null;

                do
                {
                    int sorszam = ConsoleHandler.SorszamBekeres();

                    try
                    {
                        kovetkezoFejezet = fejezetek
                            .Where(f => f.Sorszam == sorszam && aktualisFejezet.TovabbiLehetosegek.Contains(sorszam))
                            .First();
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Erre sajnos nem mehetsz tovább...");
                    }
                } while (kovetkezoFejezet == null);

                aktualisFejezet = kovetkezoFejezet;
            }
        }
    }
}
