using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Core.Models
{
    public class Exercice
    {
        public int Id { get; set; }
        public string Annee { get; set; }
        public bool IsArchive { get; set; }
        public bool IsCloturer { get; set; }
    }
}