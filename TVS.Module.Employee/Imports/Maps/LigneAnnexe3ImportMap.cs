using System;
using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeTroisImportMap : CsvClassMap<LigneAnnexe3ImportView>
    {
        public LigneAnnexeTroisImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A307");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A308");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "Nom", "NOM", "A309");

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE",
                    "A310");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A311");

            Map(x => x.CompteSpeciauxStr)
                .Name("Comptes spéciaux", "COMPTES SPECIAUX", "A312");

            Map(x => x.AutreCapitauxMobilierStr)
                .Name("Autre capitaux mobiliers", "AUTRE CAPITAUX MOBILIERS", "A313");

            Map(x => x.PretEtabBancaireStr)
                .Name("A314");

            Map(x => x.MontantRetenueOpereeStr)
                .Name("Montant retenue operée", "MONTANT RETENUE OPEREE", "A315");

            Map(x => x.MontantNetServiStr)
                .Name("Montant net servi", "MONTANT NET SERVI", "A316");
        }
    }
}