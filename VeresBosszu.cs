using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    /// <summary>
    /// A teljes történet
    /// </summary>
    public class VeresBosszu : Tortenet
    {
        public VeresBosszu(Jatekos jatekos, bool harc) : base(jatekos, harc)
        {
            this.Cim = "A véres bosszú";
        }

        /// <summary>
        /// A köszöntő szöveg kiírása
        /// </summary>
        public override void Koszonto()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this.Cim);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Egy isten háta mögötti faluban éldegélsz, te vagy a falu varázslója.");
            Console.WriteLine("Egy napos délelőtt elmész gyógynövényeket gyűjtögetni az erdőbe.");
            Console.WriteLine("Mikor visszaérsz a faluba, azt látod, hogy az orkok földig rombolták a települést, a lakosokat pedig elüldözték vagy megölték.");
            Console.WriteLine("A romokat látva úgy döntesz, hogy szörnyű bosszút állsz az orkokon.");
            Console.WriteLine();
        }

        /// <summary>
        /// A fejezetek létrehozása
        /// </summary>
        public override void FejezetekLetrehozasa()
        {
            fejezetek = new List<Fejezet>
            {
                new Fejezet(1, "Falu", "Ott állsz a lerombolt falu főterén. Egyedül Nessamesle templomát kímélték meg az orkok, talán féltek az istenek bosszújától.", new() { 2, 3 }),
                new Fejezet(2, "Erdő", "Az erdőben mászkálsz ide-oda.", new() { 1, 4 }) { Szorny = new Goblin(this.Harc) },
                new Fejezet(3, "Templom", $"A templomban állsz. Itt áll Tizsamik, a falu papja.{Environment.NewLine}- Állj bosszút a faluért! - kiáltja az atya.", new() { 1 }),
                new Fejezet(4, "Erdei tisztás", "Ott állsz az erdei tisztáson. Egy barlangot látsz a közelben, amelyből messziről érezhető rettenetes bűz árad.", new() { 5 }),
                new Fejezet(5, "Barlang", "Irgalmatlan büdös van a barlangban, a padlón csontok hevernek.", new() { 6 }) { Szorny = new Troll(this.Harc) },
                new Fejezet(6, "Ork falu", "Felrobbantod az ork falut egy kazettás bombával!", new(), true)
            };
        }
    }
}
