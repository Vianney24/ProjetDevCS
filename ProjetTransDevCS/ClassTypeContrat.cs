using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransDevCS
{
    public class ClassTypeContrat
    {
        public int IDTypContrat;
        public string LibelleTypContrat;

        public ClassTypeContrat(int idTypContrat, string libelleTypContrat)
        {
            this.IDTypContrat = idTypContrat;
            this.LibelleTypContrat = libelleTypContrat;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.LibelleTypContrat);
        }
    }
}
