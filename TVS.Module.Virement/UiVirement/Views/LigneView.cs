using System;

namespace TVS.Module.Virement.UiVirement.Views
{
    public class LigneView
    {
        public int Id { get; set; }

        public int EnteteId { get; set; }

        public string Matricule { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NomBanque { get; set; }

        public string CodeBanque { get; set; }

        public string CodeGuichet { get; set; }

        public string NumeroCompte { get; set; }

        public string CleRib { get; set; }

        public decimal NetAPaye { get; set; }

        public string Motif { get; set; }
    }
}