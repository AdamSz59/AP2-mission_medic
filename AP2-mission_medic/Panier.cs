using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicaments
{
    public class Panier
    {
        List<Medicaments> listMedic { get; set; }

        public Panier()
        {
            listMedic = new List<Medicaments>();
        }

        public void AddMedic(Medicaments medic)
        {
            listMedic.Add(medic);
        }

        public void DeleteMedic(Medicaments medic)
        {
            listMedic.Remove(medic);
        }

        public double CalculerPrixTotal()
        {
            double total = 0;
            
            foreach (Medicaments medic in listMedic)
            {
                total += medic.prix;
            }
            return total;

        }

        public List<Medicaments> ConsulterPanier()
        {
            return this.listMedic;
        }
    }
}
