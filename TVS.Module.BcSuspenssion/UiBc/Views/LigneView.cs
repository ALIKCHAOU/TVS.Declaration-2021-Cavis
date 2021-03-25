using System;

namespace TVS.Module.BcSuspenssion.UiBc.Views
{
    public class LigneView
    {
        public int Id { get; set; }

        public int NumeroOrdre { get; set; }

        public int DeclarationNo { get; set; }

        public string NumeroAutorisation { get; set; }

        public string NumeroBonCommande { get; set; }

        public DateTime DateBonCommande { get; set; }

        public string NumeroFacture { get; set; }

        public DateTime DateFacture { get; set; }

        public string Identifiant { get; set; }

        public string RaisonSocialFournisseur { get; set; }

        public decimal PrixAchatHorsTaxe { get; set; }

        public decimal MontantTva { get; set; }

        public string ObjetFacture { get; set; }

        public int SocieteNo { get; set; }
    }
}