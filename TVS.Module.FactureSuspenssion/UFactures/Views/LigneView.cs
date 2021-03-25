using System;
using TVS.Core.Enums;

namespace TVS.Module.FactureSuspenssion.UFactures.Views
{
    public class LigneView
    {
        public int Id { get; set; }

        public int NumeroOrdre { get; set; }

        public int DeclarationNo { get; set; }

        public string NumeroFacture { get; set; }

        public DateTime DateFacture { get; set; }

        public TypeClient TypeClient { get; set; }

        public string IdentifiantClient { get; set; }

        public string NomPrenomClient { get; set; }

        public string AdresseClient { get; set; }

        public string NumeroAutorisation { get; set; }

        public DateTime DateAutorisation { get; set; }

        public decimal PrixVenteHt { get; set; }

        public decimal TauxFodec { get; set; }

        public decimal MontantFodec { get; set; }

        public decimal TauxDroitConsommation { get; set; }

        public decimal MontantDroitConsommation { get; set; }

        public decimal TauxTva { get; set; }

        public decimal MontantTva { get; set; }

        public int SocieteNo { get; set; }
    }
}