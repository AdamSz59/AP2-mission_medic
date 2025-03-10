using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicaments
{
    public class Medicaments
    {
        public string designation { get; set; }
        public string marque { get; set; }
        public string concentration { get; set; }
        public string type { get; set; }
        public double prix { get; set; }

        public Medicaments(string designation, string marque, string concentration, string type, double prix)
        {
            this.designation = designation;
            this.marque = marque;
            this.concentration = concentration;
            this.type = type;
            this.prix = prix;
        }

        public override string ToString()
        {
            string rtr = "[Designation]: " + this.designation + " ; " + " [Marque]: " + this.marque + " ; " + " [Concentration]: " + this.concentration + " ; " + " [Type]: " + this.type + " ; " + " [Prix]: " + this.prix;
            return rtr; 
        }
    }
}
