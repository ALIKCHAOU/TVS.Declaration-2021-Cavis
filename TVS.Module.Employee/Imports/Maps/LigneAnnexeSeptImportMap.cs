using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace TVS.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeSeptImportMap : CsvClassMap<LigneAnnexe7ImportView>
    {
        public LigneAnnexeSeptImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A707");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A708");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "Nom", "NOM", "A709");

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE", "A710");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A711");

            Map(x => x.TypeMontantPayee)
                .Name("Type Montant Payée", "Type Montant Payee", "Type montant payee", "type montant payee", "A712");

            Map(x => x.MontantPayeeStr)
                .Name("Montant Payée", "Montant Payee", "Montant payee", "montant payee", "A713")
                .Default("0");

            Map(x => x.RetenueSourceStr)
                .Name("Retenue source", "Retenue Source", "Retenue", "RETENUE SOURCE", "A714")
                .Default("0");

            Map(x => x.MontantNetServiStr)
                .Name("Montant net servi", "Montant Net Servi", "MONTANT NET SERVI", "montant net servi", "A715")
                .Default("0");
        }
    }
}