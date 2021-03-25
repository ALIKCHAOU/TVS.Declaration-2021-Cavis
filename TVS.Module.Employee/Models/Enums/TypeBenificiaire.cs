using System.ComponentModel;

namespace TVS.Module.Employee.Models.Enums
{
    public enum TypeBeneficiaire : int
    {
        // matricule fiscale
        [Description("Matricule fiscal")] MatriculeFiscal = 1,

        // Numéro carte d'identité nationale
        [Description("CIN")] CarteIdentidiantNationale = 2,

        // Numéro de la carte sejour
        [Description("Carte séjour")] CarteSejour = 3,

        // Identifiant personne non domiciliée
        [Description("Ident. personne non domiciliée")] IdentNonDomiciliee = 4
    }
}