using System;
using TVS.Core.Models;
using TVS.Module.Employee.Models;
using DsCertificatRetenue = TVS.Module.Employee.Reports.Datasets.DsCertificatRetenue;

namespace TVS.Module.Employee.Reports
{
    public class CertificatRetenueReport
    {
        private readonly Societe _societe;
        private readonly Exercice _exercice;

        public CertificatRetenueReport(
            Societe societe,
            Exercice exercice)
        {
            if (societe == null) throw new ArgumentNullException(nameof(societe));
            if (exercice == null) throw new ArgumentNullException(nameof(exercice));

            _societe = societe;
            _exercice = exercice;
        }

        public string GetDataMember
        {
            get { return "LigneAnnexeUn"; }
        }

        public System.Data.DataSet GetDataSet(LigneAnnexeUn ligne)
        {
            if (ligne == null)
                throw new ArgumentNullException(nameof(ligne));

            var dataSet = new DsCertificatRetenue();
            // ajout de la ligne societe
            var tableSociete = dataSet.Societe;
            tableSociete.AddSocieteRow(
                _societe.Id,
                _societe.MatriculFiscal,
                _societe.MatriculCle,
                _societe.MatriculCategorie,
                int.Parse(_societe.MatriculEtablissement),
                _exercice.Annee,
                _societe.RaisonSocial,
                _societe.Activite,
                _societe.Ville,
                _societe.Adresse,
                0,
                int.Parse(_societe.CodePostal), _societe.MatriculCodeTva);
            // ajout de la ligne annexe un
            var tableAnnexeUn = dataSet.LigneAnnexeUn;
            if (ligne.ChefFamille == "1")
            {
                ligne.ChefFamille = "Oui";

            }
            else { ligne.ChefFamille = "Non"; }
            tableAnnexeUn.AddLigneAnnexeUnRow(
                ligne.Id,
                ligne.Ordre,
                (int)ligne.BeneficiaireType,
                ligne.BeneficiaireIdent,
                ligne.Beneficiaire,
                ligne.BeneficiaireActivite,
                ligne.BeneficiaireAdresse,
                (int)ligne.SituationFamiliale,
                ligne.NombreEnfant,
                ligne.DateDebutTravail,
                ligne.DateFinTravail,
                ligne.DureeEnJour,
                ligne.RevenuImposable,
                ligne.AvantageEnNature,
                ligne.RevenuBrutImposable,
                ligne.RevenuReinvesti,
                ligne.MontantRetenuesRegimeCommun,
                ligne.MontantRetenuesTauxVingt,
                ligne.MontantNetServie,
                ligne.RetenueUnPrct,
                ligne.ContributionConjoncturelle,
                ligne.SalaireNonImposable, ligne.ContributionSocialeSolidarite, ligne.ChefFamille, ligne.IntereDetectible);
          
            return dataSet;
        }
    }
}