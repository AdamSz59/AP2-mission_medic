using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicaments
{
    public class TypePraticien
    {
        public string codePraticien { get; set; }
        public string libelle { get; set; }
        public int majoration { get; set; }
        
        public TypePraticien(string codePraticien, string libelle, int majoration)
        {
            this.codePraticien = codePraticien;
            this.libelle = libelle;
            this.majoration = majoration;
        }

        public override string ToString()
        {
            string rtr = "[CodePraticien]: " + this.codePraticien + " [Libelle]: " + this.libelle + " [Majoration]: " + this.majoration;
            return rtr;
        }
    }
}
