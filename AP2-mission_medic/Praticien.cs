using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicaments
{
    public class Praticien
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public string mdp { get; set; }
        public TypePraticien unTypePraticien { get; set; }

        public Praticien(string nom, string prenom, string mdp, TypePraticien unTypePraticien)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.mdp = mdp;
            this.unTypePraticien = unTypePraticien; 
        }

        public override string ToString()
        {
            string rtr = "[Nom]: " + this.nom + " [Prenom]: " + this.prenom;
            return rtr;
        }
    }
}
