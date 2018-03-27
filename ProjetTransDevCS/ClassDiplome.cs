using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProjetTransDevCS
{
    public class ClassDiplome
    {
        public int IDDiplome;
        public string DateDiplome;
        public string NomEtablissementDiplome;
        public string CPEtablissementDiplome;
        public string VilleEtablissementDiplome;
        public int IDEmploye;
        public ClassTypeDiplome TypeDiplome;

        public ClassDiplome(int idDiplome, string dateDiplome, string nomEtablissementDiplome, string cpEtablissementDiplome, string villeEtablissementDiplome, int idEmploye, ClassTypeDiplome typeDiplome)
        {
            this.IDDiplome = idDiplome;
            this.DateDiplome = dateDiplome;
            this.NomEtablissementDiplome = nomEtablissementDiplome;
            this.CPEtablissementDiplome = cpEtablissementDiplome;
            this.VilleEtablissementDiplome = villeEtablissementDiplome;
            this.IDEmploye = idEmploye;
            this.TypeDiplome = typeDiplome;
        }

        public override string ToString()
        {            
            return string.Format("{0}, {1}", this.TypeDiplome.LibelleTypDiplome, this.DateDiplome);
        }
    }
}
