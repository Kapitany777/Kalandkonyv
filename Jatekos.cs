namespace Kalandkonyv
{
    /// <summary>
    /// A játékos
    /// </summary>
    public class Jatekos : Szereplo
    {
        /// <summary>
        /// A játékos maximális életereje
        /// </summary>
        public const int MAX_ELETERO = 100;

        /// <summary>
        /// A játékos maximális sebzése
        /// </summary>
        public const int MAX_SEBZES = 10;

        /// <summary>
        /// A játékosnál lévő gyógyitalok kezdeti száma
        /// </summary>
        public const int KEZDETI_GYOGYITAL = 4;

        /// <summary>
        /// Ennyi HP-t gyógyít egy ital
        /// </summary>
        public const int GYOGYITAS = 5;

        /// <summary>
        /// A játékosnál lévő gyógyitalok száma
        /// </summary>
        public int Gyogyitalok { get; private set; }

        /// <summary>
        /// Lehet-e gyógyítani a játékost?
        /// </summary>
        public bool LehetGyogyitani => Eletero < MAX_ELETERO && Gyogyitalok > 0;

        /// <summary>
        /// A játékos létrehozása
        /// </summary>
        /// <param name="nev">A játékos neve</param>
        public Jatekos(string nev) : base(nev, MAX_ELETERO, MAX_SEBZES)
        {
            this.Gyogyitalok = KEZDETI_GYOGYITAL;
        }

        /// <summary>
        /// A játékos gyógyítása
        /// </summary>
        public void Gyogyit()
        {
            if (!this.LehetGyogyitani)
            {
                return;
            }

            this.Eletero += GYOGYITAS;
            this.Gyogyitalok--;

            if (this.Eletero > MAX_ELETERO)
            {
                this.Eletero = MAX_ELETERO;
            }
        }

        /// <summary>
        /// A játékos teljes felgyógyítása
        /// </summary>
        public void TeljesGyogyitas()
        {
            this.Eletero = MAX_ELETERO;
        }

        /// <summary>
        /// A játékos leírásának összeállítása
        /// </summary>
        /// <returns>A játékos leírása</returns>
        public override string Leiras()
        {
            return $"{this.Nev} | HP: {this.Eletero}";
        }
    }
}
