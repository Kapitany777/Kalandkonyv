using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    public class Szorny : Szereplo
    {
        public bool Agressziv { get; private set; }

        public Szorny(
            string nev,
            int eletero,
            bool agressziv) : base(nev, eletero)
        {
            Agressziv = agressziv;
        }

        public override void Kiir()
        {
            Console.WriteLine($"Itt áll előtted egy rettenetes {this.Nev}!");
            Console.WriteLine(this.Agressziv ? "Mindjárt rád ront!" : "Szerencsére ma békés hangulatban van, nem fog megtámadni.");
            Console.WriteLine();
        }
    }
}
