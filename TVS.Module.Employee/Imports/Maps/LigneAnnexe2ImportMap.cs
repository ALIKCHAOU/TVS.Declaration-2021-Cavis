using System;
using CsvHelper.Configuration;
using TVS.Module.Employee.Imports.Views;

namespace Tvs.Module.Employee.Imports.Maps
{
    public sealed class LigneAnnexeDeuxImportMap : CsvClassMap<LigneAnnexe2ImportView>
    {
        public LigneAnnexeDeuxImportMap()
        {
            Map(x => x.BeneficiaireType)
                .Name("Type identifiant", "TYPE IDENTIFIANT", "TYPE",
                    "type identifiant", "Type Identifiant", "A207");

            Map(x => x.BeneficiaireIdent)
                .Name("Identifiant", "IDENTIFIANT", "Cin", "CIN",
                    "Matricule fiscal", "Matricule Fiscal", "A208");

            Map(x => x.Beneficiaire)
                .Name("Nom et prenom", "Nom et prénom", "Bénéficiaire", " Beneficiaire", "Nom", "NOM", "A209");

            Map(x => x.BeneficiaireActivite)
                .Name("Activite", "Activité", "Fonction", "fonction", "activite", "activité", "FONCTION", "ACTIVITE",
                    "A210");

            Map(x => x.BeneficiaireAdresse)
                .Name("Adresse", "ADRESSE", "adresse", "A211");

            Map(x => x.TypeMontantServiPersonne)
                .Name("Type montant servi personne", "Type Montant Servi Personne", "type montant servi personne",
                    "A212").Default(0);

            Map(x => x.MontantBurtOperateurTelephoniqueStr)
                .Name("Montant brut honoraire non commercial", " Montant Brut Honoraire non commercial",
                    "montant brut honoraire non commercial", "A213")
                .Default("0");

            Map(x => x.HonorairesSocieteStr)
                .Name("Honoraire societe", "Honoraire servis societe", "honoraire societe", "Honoraire Societe", "A214")
                .Default("0");

            Map(x => x.ActionsPartSocialeStr)
                .Name("Jetons de presence", "Jetons Presence", "jetons de presence", "A215")
                .Default("0");

            Map(x => x.RemunerationsSalariesStr)
                .Name("Remuneration salaries", "Remuneration Salaries", "remuneration salaries", "A216")
                .Default("0");

            Map(x => x.PrixImmeubleStr)
                .Name("Prix immeuble", "Prix Immeubles", "prix immeuble", "A217")
                .Default("0");

            Map(x => x.LoyersHotelsStr)
                .Name("Loyers Hotels", "Loyers hotels", "LOYERS HOTELS", "loyers hotels", "A218")
                .Default("0");

            Map(x => x.RemunerationsArtistesStr)
                .Name("Remuneration artistes", "Remuneration Artistes", "remuneration artistes", "A219")
                .Default("0");

            Map(x => x.HonorairesBureauEtudeStr)
                .Name("Honoraire bureau d'étude", "Honoraire bureau etude", "honoraire bureau etude",
                    "Honoraire Bureau Etude", "A220")
                .Default("0");

            Map(x => x.TypeMontantServiOperationExport)
                .Name("Type montant servi export", "Type Montant Servi Export", "type montant servi export", "A221").Default(0);

            Map(x => x.MontantBrutHonorairesOperationExportationStr)
                .Name("Montant brut honoraires", "Montant Brut Honoraires", "MONTANT BRUT HONORAIRES", "A222")
                .Default("0");

            Map(x => x.MontantRetenueOpereeStr)
                .Name("Montant retenue operee", "Montant Retenue Operee", "montant retenue operee", "A223")
                .Default("0");

            Map(x => x.MontantNetServiStr)
                .Name("Montant net servi", "Montant Net Servi", "MONTANT NET SERVI", "montant net servi", "A224")
                .Default("0");
        }
    }
}