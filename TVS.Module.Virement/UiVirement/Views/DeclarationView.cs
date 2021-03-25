using System;
using TVS.Core.Enums;

namespace TVS.Module.Virement.UiVirement.Views
{
    public class DeclarationView
    {
        public int Id { get; set; }
        public DateTime DateEcheance { get; set; }
        public DateTime DateCreation { get; set; }
        public string ReferenceEnvoi { get; set; }
        public string MotifOperation { get; set; }
        public bool Cloturer { get; set; }
        public bool Archiver { get; set; }
        public decimal Total { get; set; }
        public int NombreTotal { get; set; }
        public int BanqueId { get; set; }
        public Banque Banque { get; set; }
        public string Rib { get; set; }
        public int SocieteId { get; set; }
        public int ExerciceId { get; set; }
        public string Exercice { get; set; }
        public string RaisonSocial { get; set; }
        public string CodeEtab { get; set; }
    }
}