using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
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
