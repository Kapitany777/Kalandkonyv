using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalandkonyv
{
    /// <summary>
    /// Egy leírható dolog
    /// </summary>
    public interface ILeirhato
    {
        /// <summary>
        /// Ez a metódus adja vissza a dolog leírását
        /// </summary>
        /// <returns>A dolog leírása</returns>
        string Leiras();
    }
}
