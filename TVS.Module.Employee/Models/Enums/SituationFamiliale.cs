using System.ComponentModel;

namespace TVS.Module.Employee.Models.Enums
{
    public enum SituationFamiliale : int
    {
        // célibataire
        [Description("Célibataire")] Celebataire = 1,

        //marié
        [Description("Marié")] Mariee = 2,

        // divorcé
        [Description("Divorcé")] Divorse = 3,

        //veuf
        [Description("Veuf")] Veuf = 4
    }
}