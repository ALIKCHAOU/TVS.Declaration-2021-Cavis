using System;
using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeQuatreImportMap : CsvClassMap<LigneAnnexe4ImportView>
    {
        public LigneAnnexeQuatreImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A407");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A408");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "Nom", "NOM", "A409");

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE",
                    "A410");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A411");

            Map(x => x.TypeMontantServiActNonCommercial)
                .Name("Type Servis non commercial", "Type montant servi non commercial", "type servis non commercial",
                    "TYPE SERVI NON COMMERCIAL", "A412");

            Map(x => x.TauxMontantServiStr)
                .Name("Taux montant servi", "Toux Montant Servi", "toux montant servi", "A413")
                .Default("0");

            Map(x => x.MontantServiStr)
                .Name("Montant Servi", "Montant brut servi", "Montant Brut Servi", "montant brut servi", "A414")
                .Default("0");

            Map(x => x.TauxHonoraireNonResidenteStr)
                .Name("Taux honoraire non residente", "Taux honoraire non residente", "taux honoraire", "A415")
                .Default("0");

            Map(x => x.MontantHonoraireNonResidenteStr)
                .Name("Montant honoraire non residente", "Montant honoraire", "A416")
                .Default("0");

            Map(x => x.TauxPlusValueImmobiliereStr)
                .Name("Taux immobiliere", "Taux plus-value immobiliere", "A417")
                .Default("0");

            Map(x => x.MontantPlusValueImmobiliereStr)
                .Name("Montant immobiliere", "Montant plus-value immobiliere", "montant immobiliere", "A418")
                .Default("0");

            Map(x => x.TauxTauxCessionStr)
                .Name("A419")
                .Default("0");

            Map(x => x.MontantCessionStr).Name("A420").Default("0");

            Map(x => x.TauxRevenuValueMobiliereStr).Name("A421").Default("0");

            //   Map(x => x.MontantRevenuValueMobiliereStr).Name("A422").Default("0");

            Map(x => x.MontantValeurMobiliereStr).Name("A4221").Default("0");

            Map(x => x.MontantJetonsPresenceStr).Name("A4222").Default("0");

            Map(x => x.MontantActionsPartSocialeStr).Name("A4223").Default("0");


            Map(x => x.TypeMontantServiExport)
                .Name("Type Servis export", "Type montant export", "type servis export", "TYPE SERVI EXPORT", "A423");

            Map(x => x.MontantBrutExportStr)
                .Name("Montant Export", "Montant brut export", "MONTANT BRUT EXPORT",
                    "montant brut export", "A424")
                .Default("0");

            Map(x => x.MontantParadisFiscauxStr)
                .Name("Montant paradis fiscaux", "Montant fiscaux", "MONTANT Fiscaux",
                    "montant fiscaux", "A425")
                .Default("0");
            Map(x => x.MontantRetenueOpereeStr)
                .Name("A426")
                .Default("0");

            Map(x => x.MontantNetServiStr)
                .Name("Montant net servi", "Montant Net Servi", "MONTANT NET SERVI", "montant net servi", "A427")
                .Default("0");
        }
    }
}