﻿namespace Kalandkonyv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleHandler.SzinesSzovegKiirasa("Üdvözöllek a Véres bosszú című játékban!", ConsoleColor.Green);
            Console.WriteLine();

            string nev = ConsoleHandler.NevBekerese();
            var jatekos = new Jatekos(nev);

            Console.WriteLine("Csak a történetre vagy kíváncsi?");
            Console.WriteLine("Vagy inkább szeretnél harcot? (I / N): ");
            string valasz = ConsoleHandler.ValaszBekeres();

            var tortenet = new VeresBosszu(jatekos, valasz == "I");

            Console.Clear();
            tortenet.Futtatas();
            Console.WriteLine("Köszönöm, hogy játszottál a programmal!");
        }
    }
}