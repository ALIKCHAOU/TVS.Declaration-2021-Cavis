using System;
using TVS.Core.Models;
using TVS.Module.Cnss.UiCnss.Views;
using DsAttestation = TVS.Module.Cnss.Report.Datasets.DsAttestation;

namespace TVS.Module.Cnss.Report
{
    public class AttestationCNSS
    {
        private readonly Societe _societe;
        //private readonly Exercice _exercice;
       // private readonly string _exercice;
        public AttestationCNSS(
            Societe societe 
            )
        {
            if (societe == null) throw new ArgumentNullException(nameof(societe));
            //if (exercice == null) throw new ArgumentNullException(nameof(exercice));

            _societe = societe;
           // _exercice = exercice;
        }

        public string GetDataMember
        {
            get { return "LigneCNSS"; }
        }

        public System.Data.DataSet GetDataSet(LigneCnss ligne, DeclarationCnss dec, Exercice ex, int tr)
        {
            if (ligne == null)
                throw new ArgumentNullException(nameof(ligne));

            var dataSet = new DsAttestation();
            // ajout de la ligne societe
            var tableSociete = dataSet.Societe;
            tableSociete.AddSocieteRow(
                _societe.Id,
                _societe.MatriculFiscal,
                _societe.MatriculCle,
                _societe.MatriculCategorie,
                int.Parse(_societe.MatriculEtablissement),
                _societe.RaisonSocial,
                _societe.Activite,
                _societe.Ville,
                _societe.Adresse,
                0,
                int.Parse(_societe.CodePostal), _societe.MatriculCodeTva);
            // ajout de la ligne annexe un
            DateTime t1 = new DateTime();
            DateTime t2 = new DateTime();
            if (tr == 1)
            {
                t1 = new DateTime(Convert.ToInt32(ex.Annee), 01, 01);
                t2 = new DateTime(Convert.ToInt32(ex.Annee), 03, 31);

            }
            else if (tr == 2)
            {
                t1 = new DateTime(Convert.ToInt32(ex.Annee), 04, 01);
                t2 = new DateTime(Convert.ToInt32(ex.Annee), 06, 30);

            }
            else if (tr == 3)
            {
                t1 = new DateTime(Convert.ToInt32(ex.Annee), 07, 01);
                t2 = new DateTime(Convert.ToInt32(ex.Annee), 09, 30);

            }
            else if (tr == 4)
            {
                t1 = new DateTime(Convert.ToInt32(ex.Annee), 10, 01);
                t2 = new DateTime(Convert.ToInt32(ex.Annee), 12, 31);

            }
            var tableAnnexeUn = dataSet.LigneCNSS;
            tableAnnexeUn.AddLigneCNSSRow(
                ligne.Id,
                ligne.Nom,
                ligne.Brut1 + ligne.Brut2 + ligne.Brut3,
                ligne.Page.GetValueOrDefault(),
                ligne.Ligne.GetValueOrDefault(),
                ligne.Prenom,
                ligne.NumeroCnss,
                 t1,
                 t2, ex.Annee.ToString(), tr.ToString());

            return dataSet;
        }

        
    }
}