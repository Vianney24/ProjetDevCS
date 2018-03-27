using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransDevCS
{
    public class ClassEmploye
    {
        public int IDEmploye;
        public string NomEmploye;
        public string PrenomEmploye;
        public DateTime DateNaissanceEmploye;
        public string AdresseL1Employe;
        public string AdresseL2Employe;
        public string CPEmploye;
        public string VilleEmploye;
        public string TelephoneEmploye;
        public int IDContrat;
        public int IDService;

        public ClassEmploye(int idEmploye, string nomEmploye, string prenomEmploye, DateTime dateNaissanceEmploye, string adresseL1Employe, string adresseL2Employe, string cPEmploye, string villeEmploye, string telephoneEmploye, int idContrat, int idService)
        {
            this.IDEmploye = idEmploye;
            this.NomEmploye = nomEmploye;
            this.PrenomEmploye = prenomEmploye;
            this.DateNaissanceEmploye = dateNaissanceEmploye;
            this.AdresseL1Employe = adresseL1Employe;
            this.AdresseL2Employe = adresseL2Employe;
            this.CPEmploye = cPEmploye;
            this.VilleEmploye = villeEmploye;
            this.TelephoneEmploye = telephoneEmploye;
            this.IDContrat = idContrat;
            this.IDService = idService;

            
        }

        public override string ToString()
        {
            string annee = this.DateNaissanceEmploye.Year.ToString();
            string mois = this.DateNaissanceEmploye.Month.ToString();
            string jour = this.DateNaissanceEmploye.Day.ToString();

            string DateDeNaissance = jour + "-" + mois + "-" + annee;

            return string.Format("{0} {1}, Date de Naissance: {2}", this.NomEmploye.ToUpper(), this.PrenomEmploye.ToLower(), DateDeNaissance);
        }
    }
}
