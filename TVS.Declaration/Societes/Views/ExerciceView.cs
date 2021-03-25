using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Declaration.Societes.Views
{
    public class ExerciceView
    {
        public int Id { get; set; }
        public string Annee { get; set; }
        public bool IsArchive { get; set; }
        public bool IsCloturer { get; set; }
    }
}