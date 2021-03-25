using System;
using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeCinqImportMap : CsvClassMap<LigneAnnexe5ImportView>
    {
        public LigneAnnexeCinqImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A507");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A508");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "Nom", "NOM", "A509");

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE",
                    "A510");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A511");

            Map(x => x.MontantOpExportStr).Name("A512");
            Map(x => x.RetenueOpExportStr).Name("A513");
            Map(x => x.MontantAutreOpStr).Name("A514");
            Map(x => x.RetenueAutreOpStr).Name("A515");
            Map(x => x.MontantEtabPublicStr).Name("A516");
            Map(x => x.RetenueEtabPublicStr).Name("A517");
            Map(x => x.MontantEtabAlEtrangerStr).Name("A518");
            Map(x => x.RetenueEtabAlEtrangerStr).Name("A519");
            Map(x => x.MontantNetServiStr).Name("A520");
        }
    }
}