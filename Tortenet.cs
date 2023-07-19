using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    public abstract class Tortenet
    {
        public Jatekos Jatekos { get; }

        public Tortenet(Jatekos jatekos)
        {
            this.Jatekos = jatekos;
        }

        public abstract void Koszonto();

        public void Futtatas()
        {
            Koszonto();


        }
    }
}
