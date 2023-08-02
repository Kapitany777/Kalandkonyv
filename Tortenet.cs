﻿using System;
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
                    int kovetkezoSorszam = ConsoleHandler.SorszamBekeres();

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
    }
}
