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
        /// <summary>
        /// A történet címe
        /// </summary>
        public string Cim { get; protected set; }

        /// <summary>
        /// A játékos
        /// </summary>
        public Jatekos Jatekos { get; }

        /// <summary>
        /// Legyen-e harc a játékban, vagy csak a történetet szeretnénk megismerni
        /// </summary>
        public bool Harc { get; }

        /// <summary>
        /// A történet fejezetei
        /// </summary>
        protected List<Fejezet> fejezetek;

        public Tortenet(Jatekos jatekos, bool harc)
        {
            this.Cim = string.Empty;
            this.Jatekos = jatekos;

            this.Harc = harc;

            fejezetek = new List<Fejezet>();
            FejezetekLetrehozasa();
        }

        /// <summary>
        /// A köszöntő szöveg kiírása
        /// </summary>
        public abstract void Koszonto();

        /// <summary>
        /// A fejezetek létrehozása
        /// </summary>
        public abstract void FejezetekLetrehozasa();

        /// <summary>
        /// A játék futtatása
        /// </summary>
        public void Futtatas()
        {
            Koszonto();

            var aktualisFejezet = fejezetek[0];

            while (true)
            {
                Console.WriteLine(this.Jatekos.Leiras());

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

                if (aktualisFejezet.Szorny != null)
                {
                    Console.WriteLine(aktualisFejezet.Szorny.Leiras());

                    if (aktualisFejezet.Szorny.Agressziv)
                    {
                        Csata(aktualisFejezet.Szorny);
                    }
                }

                // TODO: ha a játékos veszít, azt is kezelni kell

                LehetosegekKiirasa(aktualisFejezet);

                Fejezet? kovetkezoFejezet = null;

                do
                {
                    int kovetkezoSorszam = ConsoleHandler.SorszamBekeres();

                    // Ha gyógyítani szeretne
                    if (kovetkezoSorszam == 100)
                    {
                        if (Jatekos.LehetGyogyitani)
                        {
                            Jatekos.Gyogyit();

                            Console.WriteLine("Glutty, ez jól esett!");
                            Console.WriteLine($"Még {Jatekos.Gyogyitalok} db italod maradt.");
                        }
                        else
                        {
                            Console.WriteLine("Most nincs erre szükség.");
                        }

                        continue;
                    }

                    // Egyébként egy újabb fejezetre szeretne lépni
                    try
                    {
                        kovetkezoFejezet = fejezetek
                            .Where(f => f.Sorszam == kovetkezoSorszam && aktualisFejezet.TovabbiLehetosegek.Contains(kovetkezoSorszam))
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

        /// <summary>
        /// Egy adott fejezet lehetőségeinek kiírása
        /// </summary>
        /// <param name="fejezet">A kiírandó fejezet</param>
        private void LehetosegekKiirasa(Fejezet fejezet)
        {
            Console.WriteLine("Merre mész tovább?");

            foreach (int lehetoseg in fejezet.TovabbiLehetosegek)
            {
                var cimke = fejezetek
                   .Where(f => f.Sorszam == lehetoseg)
                   .First()
                   .Cimke;

                Console.WriteLine($"{lehetoseg} - {cimke}");
            }

            if (Jatekos.LehetGyogyitani)
            {
                Console.WriteLine("100 - Gyógyítás");
            }
        }

        public Szereplo Csata(Szorny szorny)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Rettenetes csata kezdődik!");
            Console.ForegroundColor = ConsoleColor.Gray;

            var rnd = new Random();

            while (Jatekos.Elo && szorny.Elo)
            {
                int dobas1 = rnd.Next(20);
                int dobas2 = rnd.Next(20);
                Console.WriteLine($"{dobas1} {dobas2}");

                if (dobas1 < dobas2)
                {
                    int sebzes = rnd.Next(szorny.MaxSebzes) + 1;
                    Jatekos.Sebez(sebzes);
                }
                else
                {
                    int sebzes = rnd.Next(Jatekos.MaxSebzes) + 1;
                    szorny.Sebez(sebzes);
                }

                Console.WriteLine($"{Jatekos.Nev} {Jatekos.Eletero} | {szorny.Nev} {szorny.Eletero}");
                Thread.Sleep(100);
            }

            return Jatekos.Elo ? Jatekos : szorny;

        }
    }
}
