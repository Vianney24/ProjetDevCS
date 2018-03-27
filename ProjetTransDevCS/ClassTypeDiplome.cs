using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransDevCS
{
    public class ClassTypeDiplome
    {
        public int IDTypDiplome;
        public string LibelleTypDiplome;

        public ClassTypeDiplome(int idTypDiplome, string libelleTypDiplome)
        {
            this.IDTypDiplome = idTypDiplome;
            this.LibelleTypDiplome = libelleTypDiplome;
        }

        public override string ToString()
        {
            return string.Format("{0}", this.LibelleTypDiplome);
        }
    }
}
