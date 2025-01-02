using static System.ConsoleColor;

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

        /// <summary>
        /// A történet létrehozása
        /// </summary>
        /// <param name="jatekos">A játékos</param>
        /// <param name="harc">Legyen-e harc a játékban?</param>
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
            bool kilepes = false;

            while (!kilepes)
            {
                ConsoleHandler.SzinesSzovegKiirasa(this.Jatekos.Leiras(), Yellow);

                Console.WriteLine(aktualisFejezet.Leiras());

                if (aktualisFejezet.Befejezes)
                {
                    ConsoleHandler.SzinesSzovegKiirasa("Gratulálok, megnyerted a játékot!", Green);
                    break;
                }

                if (aktualisFejezet.TovabbiLehetosegek.Count == 0)
                {
                    ConsoleHandler.SzinesSzovegKiirasa("Kalandod itt véget ér...", Red);
                    break;
                }

                if (aktualisFejezet.Szorny != null)
                {
                    Console.WriteLine(aktualisFejezet.Szorny.Leiras());

                    if (aktualisFejezet.Szorny.Agressziv && aktualisFejezet.Szorny.Elo)
                    {
                        if (Csata(aktualisFejezet.Szorny) == this.Jatekos)
                        {
                            ConsoleHandler.SzinesSzovegKiirasa("Legyőzted a szörnyet!", Blue);
                            Console.WriteLine();
                        }
                        else
                        {
                            ConsoleHandler.SzinesSzovegKiirasa("Legyőzött a szörny!", Red);
                            ConsoleHandler.SzinesSzovegKiirasa("Kalandod itt véget ér...", Red);
                            Console.WriteLine();

                            kilepes = true;
                            continue;
                        }
                    }
                }

                LehetosegekKiirasa(aktualisFejezet);

                Fejezet? kovetkezoFejezet = null;

                do
                {
                    int kovetkezoSorszam = ConsoleHandler.SorszamBekeres();
                    Console.WriteLine();

                    // Ha ki szeretne lépni a programból
                    if (kovetkezoSorszam == 0)
                    {
                        kilepes = true;
                        break;
                    }

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

                        Console.WriteLine();

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

                if (kovetkezoFejezet != null)
                {
                    aktualisFejezet = kovetkezoFejezet;
                }
            }
        }

        /// <summary>
        /// Egy adott fejezet lehetőségeinek kiírása
        /// </summary>
        /// <param name="fejezet">A kiírandó fejezet</param>
        private void LehetosegekKiirasa(Fejezet fejezet)
        {
            Console.WriteLine("Merre mész tovább, vagy mit teszel?");

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

            Console.WriteLine("0 - Kilépés a játékból");

            Console.WriteLine();
        }

        /// <summary>
        /// Csata a játékos és egy szörny között
        /// </summary>
        /// <param name="szorny">A szörny, akivel meg kell küzdeni</param>
        /// <returns>A csata győztese</returns>
        public Szereplo Csata(Szorny szorny)
        {
            ConsoleHandler.SzinesSzovegKiirasa("Rettenetes csata kezdődik!", Red);

            var rnd = new Random();

            while (Jatekos.Elo && szorny.Elo)
            {
                int dobas1 = rnd.Next(20);
                int dobas2 = rnd.Next(20);
                // Console.WriteLine($"{dobas1} {dobas2}");

                string nyil;

                if (dobas1 < dobas2)
                {
                    int sebzes = rnd.Next(szorny.MaxSebzes) + 1;
                    Jatekos.Megsebez(sebzes);
                    nyil = "<-";
                }
                else
                {
                    int sebzes = rnd.Next(Jatekos.MaxSebzes) + 1;
                    szorny.Megsebez(sebzes);
                    nyil = "->";
                }

                Console.WriteLine($"{Jatekos.Nev} HP: {Jatekos.Eletero} {nyil} {szorny.Nev} HP: {szorny.Eletero}");
                Console.WriteLine();
                Thread.Sleep(100);
            }

            return Jatekos.Elo ? Jatekos : szorny;
        }
    }
}
