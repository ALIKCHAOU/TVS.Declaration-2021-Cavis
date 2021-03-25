using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class DeclarationCnss
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public int SocieteId { get; set; }

        public bool IsCloture { get; set; }

        public bool IsArchive { get; set; }

        public int Trimestre { get; set; }

        public bool Complementaire { get; set; }

        public DateTime Date { get; set; }
    }
}