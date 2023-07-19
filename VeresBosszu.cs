using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    public class VeresBosszu : Tortenet
    {
        public VeresBosszu(Jatekos jatekos) : base(jatekos)
        {
            this.Cim = "A véres bosszú";
        }

        public override void Koszonto()
        {
            Console.WriteLine(this.Cim);
            Console.WriteLine();
            Console.WriteLine("Egy isten háta mögötti faluban éldegélsz.");
            Console.WriteLine("Egy napos délelőtt elmész vadászni.");
            Console.WriteLine("Mikor visszaérsz a faluba, azt látod, hogy az orkok földig rombolták a települést.");
            Console.WriteLine("A romokat látva úgy döntesz, hogy bosszút állsz az orkokon.");
            Console.WriteLine();
        }

        public override void FejezetekLetrehozasa()
        {
            fejezetek = new List<Fejezet>
            {
                new Fejezet(1, "Falu", "Ott állsz a lerombolt falu főterén.", new() { 2 }),
                new Fejezet(2, "Erdő", "Az erdőben mész.", new() { 1, 3 }),
                new Fejezet(3, "Erdei tisztás", "Ott állsz az erdei tisztáson.", new() {})
            };
        }
    }
}
