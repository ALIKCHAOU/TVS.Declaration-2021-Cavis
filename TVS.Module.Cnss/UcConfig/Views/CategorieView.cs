using TVS.Core.Enums;

namespace TVS.Module.Cnss.UcConfig.Views
{
    public class CategorieView
    {
        public int Id { get; set; }

        public int No { get; set; }

        public string Intitule { get; set; }

        public string CodeExploitation { get; set; }

        public decimal TauxSalarial { get; set; }

        public decimal TauxPatronal { get; set; }

        public decimal AccidentTravail { get; set; }

        public TypeVariablePaie TypeVariablePaie { get; set; }

        public string CodePaie { get; set; }
    }
}