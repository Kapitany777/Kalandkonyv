using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ConsoleColor;

namespace Kalandkonyv
{
    /// <summary>
    /// A teljes történet
    /// </summary>
    public class VeresBosszu : Tortenet
    {
        /// <summary>
        /// A konkrét történet létrehozása
        /// </summary>
        /// <param name="jatekos">A játékos</param>
        /// <param name="harc">Legyen-e harc a játékban?</param>
        public VeresBosszu(Jatekos jatekos, bool harc) : base(jatekos, harc)
        {
            this.Cim = "A véres bosszú";
        }

        /// <summary>
        /// A köszöntő szöveg kiírása
        /// </summary>
        public override void Koszonto()
        {
            ConsoleHandler.SzinesSzovegKiirasa(this.Cim, Green);
            Console.WriteLine();
            Console.WriteLine("Egy isten háta mögötti faluban éldegélsz, te vagy a falu köztiszteletben álló varázslója.");
            Console.WriteLine("Egy napos délelőttön elmész gyógynövényeket gyűjtögetni az erdőbe.");
            Console.WriteLine("Mikor dolgod végeztével visszaérsz a faluba, azt látod, hogy az orkok földig rombolták a települést, a lakosokat pedig elüldözték vagy megölték.");
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
                new Fejezet(2, "Erdő", "A sűrű, sötét erdőben gyalogolsz. Még a madarak sem csicseregnek.", new() { 1, 4 }) { Szorny = new Goblin(this.Harc) },
                new Fejezet(3, "Templom", $"A templomban állsz. Itt imádkozik Tizsamik, a falu papja.{Environment.NewLine}- Állj bosszút a faluért! - kiáltja az atya.", new() { 1 }),
                new Fejezet(4, "Erdei tisztás", "Ott állsz egy erdei tisztáson. Egy ösvény vezet tovább az orkok faluja felé. Egy barlangot is látsz a közelben, amelyből messziről érezhető rettenetes bűz árad. Nem tűnik túl jó ötletnek, hogy bemenj ide...", new() { 2, 5, 6 }),
                new Fejezet(5, "Barlang", "Irgalmatlan büdös van a barlangban, a padlón szétszórt csontok hevernek.", new() { 4 }) { Szorny = new Troll(this.Harc) },
                new Fejezet(6, "Erdei ösvény", "Egy keskeny erdei ösvényen gyalogolsz, már nincs messze az ork falu.", new() { 4, 7 }),
                new Fejezet(7, "Ork falu", "Meglátod az orkok szánalmas, düledező viskóit. Elérkezett a bosszú ideje!", new() { 8, 9 }),
                new Fejezet(8, "Egy tűzgolyóval lerombolom a falut", "Egy rettenetes tűzgolyó varázslattal porrá égeted az orkok faluját. Bosszúd beteljesedett!", new(), true),
                new Fejezet(9, "Elmenekülök a környékről", "Nem tudtad magad rászánni, hogy lerombold a falut. Megkímélted az orkok nyomorult életét, de nem bosszultad meg a falu pusztulását.", new(), true)
            };
        }
    }
}
