using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public class VirementEntete
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
    }
}
