using System.Collections.Generic;

namespace TVS.Module.Employee.Models
{
    public interface IAnnexe<TL, TP>
        where TL : ILigneAnnexe
        where TP : IPiedAnnexe
    {
        IList<TL> Lignes { get; set; }

        EnteteAnnexe Entete { get; set; }

        TP Pied { get; set; }
    }
}