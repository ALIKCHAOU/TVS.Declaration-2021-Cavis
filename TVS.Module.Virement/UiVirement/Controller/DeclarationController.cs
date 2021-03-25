using Dapper;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using TVS.Config.Helpers;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.Virement.ImportsSql.Views;
using TVS.Module.Virement.Reports;
using TVS.Module.Virement.UiVirement.Views;

namespace TVS.Module.Virement.UiVirement.Controller
{
    public class DeclarationController
    {
        private readonly DeclarationService _service;

        public DeclarationController(DeclarationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
            
        }
        public Societe GetSociete ()
        {
            return _service.Societe;
        }
        public Exercice GetExercice()
        {
            return _service.Exercice;
        }
        public IEnumerable<DeclarationView> GetAll()
        {
            return _service.VirementService.EnteteGetAll().Select(ToView).ToList();
        }

        public DeclarationView GetDeclaration(int no)
        {
            return ToView(_service.VirementService.Get(no));
        }

        private DeclarationView ToView(VirementEntete declaration)
        {
            return new DeclarationView
            {
                ExerciceId = declaration.ExerciceId,
                Id = declaration.Id,
                Banque = declaration.Banque,
                Rib = declaration.Rib,
                Exercice = declaration.Exercice,
                Cloturer = declaration.Cloturer,
                Archiver = declaration.Archiver,
                MotifOperation = declaration.MotifOperation,
                ReferenceEnvoi = declaration.ReferenceEnvoi,
                Total = declaration.Total,
                SocieteId = declaration.SocieteId,
                DateCreation = declaration.DateCreation,
                NombreTotal = declaration.NombreTotal,
                DateEcheance = declaration.DateEcheance,
                BanqueId = declaration.BanqueId,
                RaisonSocial = _service.Societe.RaisonSocial
            };
        }

        public BindingList<LigneView> GetAllLigne(int declarationNo)
        {
            IEnumerable<LigneView> lignes = _service.VirementService.LignesGetAll(declarationNo).Select(ToLigneView);
            return new BindingList<LigneView>(lignes.ToList());
        }

        private LigneView ToLigneView(VirementLigne ligne)
        {
            return new LigneView
            {
                Id = ligne.Id,
                CodeBanque = ligne.CodeBanque,
                Matricule = ligne.Matricule,
                CleRib = ligne.CleRib,
                NetAPaye = ligne.NetAPaye,
                EnteteId = ligne.EnteteId,
                Nom = ligne.Nom,
                Prenom = ligne.Prenom,
                NomBanque = ligne.NomBanque,
                CodeGuichet = ligne.CodeGuichet,
                NumeroCompte = ligne.NumeroCompte,
                Motif = ligne.Motif
            };
        }

        internal void Gerer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.VirementService.DeclarationValider(declaration.Id);
        }

        internal void Archiver(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.VirementService.Archiver(declaration.Id);
        }

        internal void Update(LigneView ligne)
        {
            if (ligne == null) throw new InvalidOperationException("Ligne invalide!");

            _service.VirementService.LigneUpdate(
                ligne.Id,
                ligne.Matricule,
                ligne.Nom,
                ligne.Prenom,
                ligne.NomBanque,
                ligne.CodeBanque,
                ligne.CodeGuichet,
                ligne.NumeroCompte,
                ligne.CleRib,
                ligne.NetAPaye,
                ligne.Motif);
        }

        internal LigneView CreateLigne(LigneView view, DeclarationView declarationView)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (declarationView == null) throw new ArgumentNullException("declarationView");
            // charger la declaration
            var declaration = _service.VirementService.Get(declarationView.Id);
            if (declaration == null) throw new ApplicationException("Déclaratoin invalide!");

            // verifier que la declaration n'est pas archivee
            if (declaration.Archiver)
                throw new InvalidOperationException("Opération invalide! [Déclaration est archivée].");
            // verifier que la declration n'est pas cloturee
            if (declaration.Cloturer)
                throw new InvalidOperationException("Opération invalide! [Déclaration est clôturée].");
          
            var id = _service.VirementService.LigneCreate(declaration.Id,view.Matricule,view.Nom,view.Prenom,view.NomBanque,view.CodeBanque,
                view.CodeGuichet,view.NumeroCompte,view.CleRib,view.NetAPaye,view.Motif
              );
            // charger ligne bon commande suspendue
            var newView = _service.VirementService.LignesGet(id);
            if (newView == null) throw new ApplicationException("Linge bon de commande en suspension invalide!");

            return ToLigneView(newView);
        }

        internal void Delete(LigneView ligne)
        {
            if (ligne == null) throw new ArgumentNullException("ligne");
            _service.VirementService.LigneDelete(ligne.Id);
        }

        internal void Delete(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.VirementService.Delete(declaration.Id);
        }

        internal void Editer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.VirementService.Editer(declaration.Id);
        }

        internal void Exporter(DeclarationView currentDeclaration, string path)
        {
            if (currentDeclaration == null) throw new ArgumentNullException("currentDeclaration");
            _service.VirementService.Exports(currentDeclaration.Id, path);
        }

        internal Societe GetCurrentSociete()
        {
            return _service.Societe;
        }

        internal Exercice GetCurrentExercice()
        {
            return _service.Exercice;
        }

        public DeclarationView InitDeclaration()
        {
            return new DeclarationView
            {
                ExerciceId = _service.Exercice.Id,
                Archiver = false,
                Exercice = _service.Exercice.Annee,
                Cloturer = false,
                DateCreation = DateTime.Now,
                DateEcheance = DateTime.Now,
                NombreTotal = 0,
                SocieteId = _service.Societe.Id,
                RaisonSocial = _service.Societe.RaisonSocial,
            };
        }

        public IEnumerable<SocieteBanque> GetAllBanque()
        {
            return _service.VirementService.GetAllBanque();
        }
        public void CreateDeclaration(DeclarationView view)
        {
            _service.VirementService.Create(view.ReferenceEnvoi, view.MotifOperation , view.Cloturer, view.Archiver, view.Total , view.BanqueId);
        }

        public void UpdateDeclaration(int id, string motif, string reference)
        {
            var declaration = _service.VirementService.Get(id);
            if(declaration == null )return;
            if (declaration.Cloturer) return;
            _service.VirementService.Update(id,reference, motif,declaration.Cloturer, declaration.Archiver, declaration.Total);
        }


        public void ImportSageDeclaration(DeclarationView view)
        {
            if (view == null) return;
            if (view.Id == 0) return;
            var  lignes = new List<LigneSqlView>();
            try {
                lignes =view.CodeEtab==null? GetLignesSql().ToList(): GetLignesSql(view.CodeEtab).ToList();
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Problème sql!");

            }
            //foreach(var ligne in lignes)
            //{
            //    var cle = NumeriqueHelper.GetMatriculeCleRib(string.Format("{0}{1}{2}", ligne.CodeBanque.PadLeft(2, '0'), ligne.CodeGuichet.PadLeft(5, '0'),
            //        ligne.NumeroCompte.PadLeft(11, '0')));
            //    if(cle.PadRight(2,'0') != ligne.CleRib.PadLeft(2,'0'))
            //    {
            //        throw new InvalidOperationException(string.Format("Rib {0} est invalide!",ligne.Matricule));
            //    }
            //}
            try
            {
                ImporterSql(view, lignes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Problème Importation!");

            }
        }

        public IEnumerable<LigneSqlView> GetLignesSql()
        {
            var query = @"
SELECT MatriculeSalarie Matricule,
       Nom,
	   Prenom,
	   T1.NomBanque NomBanque,
	   T1.NomGuichet Agence,
	   RIGHT(T1.CFONB_CodeBanque,2) CodeBanque,
	   T1.CFONB_CodeGuichet CodeGuichet,
	   T1.CFONB_NumeroDeCompte NumeroCompte,
	   T1.CFONB_Cle CleRib,
	   cast(case when T2.ValeurCumIntermediaire is null then 0 else T2.ValeurCumIntermediaire end as decimal(12,3)) NetAPaye,
	   'Virement Salaire mois ' + Cast((Select MoisEnCours From T_Pai) as varchar(2))+ '-'+
	   + Cast((Select AnneeEnCours From T_Pai) as varchar(4)) Motif
FROM T_SAL T0,
     T_INFOBANQUE T1,
	 T_CUMSAL T2

Where 
(T0.ModeDePaiement = 0 or T0.ModeDePaiement IS NULL)
AND
(T0.EtatPaie in (2,3))
AND
(
(T2.OpCstCumul=63 and T1.Numero=1)
Or
(T2.OpCstCumul=64 and T1.Numero=2)
)
AND
(T2.ValeurCumIntermediaire>0)
AND
T0.SA_CompteurNumero=T1.NumSalarie
AND
T0.SA_CompteurNumero=T2.NumSalarie
";
            using (var con = new SqlConnection(_service.Societe.GetConnection()))
            {
                var result = con.Query<LigneSqlView>(query);

                return result;
            }
        }

        public IEnumerable<LigneSqlView> GetLignesSql( string etablissement )
        {
            var query = $@"SELECT        T0.MatriculeSalarie AS Matricule, T0.Nom, T0.Prenom, T1.NomBanque, T1.NomGuichet AS Agence, RIGHT(T1.CFONB_CodeBanque, 2) AS CodeBanque, T1.CFONB_CodeGuichet AS CodeGuichet, 
                         T1.CFONB_NumeroDeCompte AS NumeroCompte, T1.CFONB_Cle AS CleRib, CAST(CASE WHEN T2.ValeurCumIntermediaire IS NULL THEN 0 ELSE T2.ValeurCumIntermediaire END AS decimal(12, 3)) AS NetAPaye, 
                         'Virement Salaire mois ' + CAST
                             ((SELECT        MoisEnCours
                                 FROM            T_PAI) AS varchar(2)) + '-' + + CAST
                             ((SELECT        AnneeEnCours
                                 FROM            T_PAI AS T_PAI_1) AS varchar(4)) AS Motif, T3.CodeEtab, T4.Intitule
FROM            T_SAL AS T0 INNER JOIN
                         T_INFOBANQUE AS T1 ON T0.SA_CompteurNumero = T1.NumSalarie INNER JOIN
                         T_CUMSAL AS T2 ON T0.SA_CompteurNumero = T2.NumSalarie INNER JOIN
                         T_HST_ETABLISSEMENT AS T3 ON T0.SA_CompteurNumero = T3.NumSalarie INNER JOIN
                         T_ETA AS T4 ON T3.CodeEtab = T4.CodeEtab
WHERE        (T0.ModeDePaiement = 0 OR
                         T0.ModeDePaiement IS NULL) AND (T0.EtatPaie IN (2, 3)) AND (T2.OpCstCumul = 63) AND (T1.Numero = 1) AND (T2.ValeurCumIntermediaire > 0) AND (T3.InfoEnCours = 1) AND (T3.CodeEtab = N'{etablissement}') OR
                         (T0.ModeDePaiement = 0 OR
                         T0.ModeDePaiement IS NULL) AND (T0.EtatPaie IN (2, 3)) AND (T2.OpCstCumul = 64) AND (T1.Numero = 2) AND (T2.ValeurCumIntermediaire > 0) AND (T3.CodeEtab = N'{etablissement}')
						 ";
            using (var con = new SqlConnection(_service.Societe.GetConnection()))
            {
                var result = con.Query<LigneSqlView>(query);

                return result;
            }
        }
        public void ImporterSql(DeclarationView entete , IEnumerable<LigneSqlView> lignes)
        {
            foreach (var ligne in lignes)
            {
                _service.VirementService.LigneCreate(entete.Id,
                    ligne.Matricule,
                    ligne.Nom,
                    ligne.Prenom,
                    ligne.NomBanque,
                    ligne.CodeBanque,
                    ligne.CodeGuichet,
                    ligne.NumeroCompte,
                    ligne.CleRib,
                    ligne.NetAPaye,
                    ligne.Motif
                    );
            }
        }

        internal void Imprimer(DeclarationView ligne)
        {
            var reportClass = new VirementReport(GetSociete(), GetExercice());

            var appPath = Path.GetDirectoryName(typeof(Societe).Module.FullyQualifiedName);
            if (appPath == null) return;
            var banque = _service.VirementService.GetAllBanque().FirstOrDefault(x => x.Id == ligne.BanqueId);
            if (banque == null) throw new InvalidOperationException("Banque invalide!");
            var declaration = _service.VirementService.Get(ligne.Id);
            if (declaration == null) throw new InvalidOperationException("Declaration invalide!");
            var lignes = _service.VirementService.LignesGetAll(ligne.Id).ToList();

            var reportFilePath = string.Empty;
            reportFilePath = Path.Combine(appPath,string.Format( @"Virement\{0}.repx", banque.Agence));
            // verify that the report file exists
            if (!File.Exists(reportFilePath))
            {
                reportFilePath = Path.Combine(appPath, @"Virement\Standard.repx");
                // verify that the report file exists
                if (!File.Exists(reportFilePath))
                    throw new InvalidOperationException("Virement n'existe pas![Report]" + reportFilePath);
            }
            var report2 = XtraReport.FromFile(reportFilePath, true);
            // get ligne
           
            var dataSet = reportClass.GetDataSet(banque,declaration, lignes);

            report2.DataSource = dataSet;
            report2.DataMember = reportClass.GetDataMember;
            report2.CreateDocument();
            report2.ShowPreview();
        }
    }
}