namespace Kalandkonyv
{
    /// <summary>
    /// Goblin
    /// </summary>
    public class Goblin : Szorny
    {
        public Goblin(bool agressziv) : base("Goblin", 10, 5, agressziv)
        {
            AgresszivViselkedesek = new List<string>
            {
                "Mindjárt rád ront!",
                "Fenyegetően rázza a bunkóját!",
                "Sötéten néz rád gonosz szemeivel!"
            };
        }
    }
}
