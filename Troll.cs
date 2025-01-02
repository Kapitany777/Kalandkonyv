namespace Kalandkonyv
{
    /// <summary>
    /// Troll
    /// </summary>
    public class Troll : Szorny
    {
        public Troll(bool agressziv) : base("Troll", 100, 25, agressziv)
        {
            AgresszivViselkedesek = new List<string>
            {
                "Mindjárt rád ront!",
                "Fenyegetően rázza hatalmas ökleit!",
                "Sötéten néz rád gonosz szemeivel!",
                "Rettenetes hangon hörög!"
            };
        }
    }
}
