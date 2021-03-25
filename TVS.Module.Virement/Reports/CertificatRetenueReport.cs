using System;
using System.Collections.Generic;
using TVS.Core.Models;
using TVS.Module.Virement.Reports.Datasets;

namespace TVS.Module.Virement.Reports
{
    public class VirementReport
    {
        private readonly Societe _societe;
        private readonly Exercice _exercice;

        public VirementReport(
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
            get { return "TLignes"; }
        }

        public System.Data.DataSet GetDataSet(SocieteBanque banque, VirementEntete entete , List<VirementLigne> lignes)
        {
            if (entete == null)
                throw new ArgumentNullException(nameof(entete));

            var dataSet = new DsVirement();
            // ajout de la ligne societe
            var tableSociete = dataSet.TSociete;
            tableSociete.AddTSocieteRow(
                _societe.Id,
                int.Parse(_societe.MatriculFiscal),
                _societe.MatriculCle,
                _societe.MatriculCategorie,
                _societe.MatriculEtablissement,
                _exercice.Annee,
                _societe.RaisonSocial,
                _societe.Activite,
                _societe.Ville,
                _societe.Adresse,
                0,
                int.Parse(_societe.CodePostal));
           

            var tableEntete =  dataSet.TEntete;
            var row =tableEntete.AddTEnteteRow(entete.Id,
                entete.DateEcheance,
                entete.DateCreation,
                entete.ReferenceEnvoi,
                entete.MotifOperation,
                entete.Total,
                entete.NombreTotal,
                entete.Rib,
                banque.Agence.ToUpper(),
                banque.Adresse
                );
            foreach(var ligne in lignes)
            {
                var tableLigne = dataSet.TLignes;
                tableLigne.AddTLignesRow(ligne.Id,
                    row,
                    ligne.Nom,
                    ligne.Prenom,
                    ligne.Rib,
                    ligne.NomBanque,
                    ligne.NetAPaye
                    );
            }
            return dataSet;
        }
    }
}