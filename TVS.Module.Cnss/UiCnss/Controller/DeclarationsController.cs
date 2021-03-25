using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.Parameters;
using TVS.Core;
using TVS.Core.Data;
using TVS.Core.Models;
using TVS.Core.Reports;
using TVS.Module.Cnss.UiCnss.Views;

namespace TVS.Module.Cnss.UiCnss.Controller
{
    public class DeclarationsController
    {
        private readonly DeclarationService _service;

        public DeclarationsController(DeclarationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
        }

        public IEnumerable<DeclarationView> GetAll()
        {
            return _service.CnssService.DeclarationAll().Select(ToView).OrderBy(x => x.Trimestre).ToList();
        }

        internal IEnumerable<Exercice> GetAllExercice()
        {
            return _service.ExerciceGetAll().OrderBy(x => x.Annee);
        }

        internal Exercice GetExercice(int no)
        {
            return _service.GetExercice(no);
        }
        internal IEnumerable<Societe> GetAllSoc()
        {
            return _service.GetAllSoc();
        }
        //public IEnumerable<Societe> GetAllSociete()
        //{
        //   var societes = _service.SocieteGetAll();
        //    // if (Program.IsMultiSociete) return societes;
        //    return  societes;
        //}

        public DeclarationView GetDeclaration(int no)
        {
            return ToView(_service.CnssService.DeclarationGet(no));
        }
        public DeclarationCnss GetDeclarationCnss(int no)
        {
            return _service.CnssService.DeclarationGet(no);
        }

        public IEnumerable<DeclarationCnss> GetDeclarationByTrimestre(int trimestre, int exerciceNo,int trimestreF, int exerciceNoF)
        {
            return _service.CnssService.GetDeclarationByTrimestre(trimestre, exerciceNo, trimestreF, exerciceNoF);
        }

        private DeclarationView ToView(DeclarationCnss declaration)
        {
            return new DeclarationView
            {
                Complementaire = declaration.Complementaire,
                Date = declaration.Date,
                IsArchive = declaration.IsArchive,
                IsCloture = declaration.IsCloture,
                Trimestre = declaration.Trimestre,
                ExerciceId = declaration.ExerciceId,
                Id = declaration.Id,
            };
        }

        public BindingList<LigneView> GetAllLigne(int declarationNo)
        {
            IEnumerable<LigneView> lignes =
                _service.CnssService.GetLigneDeclarationCnss(declarationNo).Select(ToLigneView);
            return new BindingList<LigneView>(lignes.OrderBy(x => x.NumeroCnss).ToList());
        }

        public IEnumerable<LigneCnss> GetLigne(int  
            employeNo, int trim1, int ex1, int trim2, int ex2)
        {
            IEnumerable<LigneCnss> lignes =
                _service.CnssService.GetLigne( employeNo, trim1, ex1, trim2, ex2);
            return lignes.ToList();
        }


        private LigneView ToLigneView(LigneCnss ligne)
        {
            return new LigneView
            {
                No = ligne.Id,
                Cin = ligne.Cin,
                AutresNom = ligne.AutresNom,
                Brut1 = ligne.Brut1,
                Brut2 = ligne.Brut2,
                Brut3 = ligne.Brut3,
                Civilite = ligne.Civilite,
                CleCnss = ligne.CleCnss,
                Nom = ligne.Nom,
                NomJeuneFille = ligne.NomJeuneFille,
                NumeroCnss = ligne.NumeroCnss,
                Prenom = ligne.Prenom,
                CategorieNo = ligne.CategorieNo,
                CodeExploitation = ligne.CodeExploitation,
                DeclarationNo = ligne.DeclarationNo,
                EmployeeNo = ligne.EmployeeNo,
                NumeroInterne = ligne.NumeroInterne,
                Ligne = ligne.Ligne,
                Page = ligne.Page
            };
        }

        public List<CategorieCnss> GetAllCategories()
        {
            return _service.CnssService.GetAllCategories().ToList();
        }


        internal void Gerer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.CnssService.DeclarationValiderCnss(declaration.Id);
        }

        internal void Archiver(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.CnssService.Archiver(declaration.Id);
        }

        internal void Update(LigneView ligne)
        {
            if (ligne == null) throw new InvalidOperationException("Ligne invalide!");

            _service.CnssService.UpdateLigneDeclarationCnss(ligne.No,
                ligne.Nom,
                ligne.Prenom,
                ligne.Civilite,
                ligne.NumeroCnss,
                ligne.CleCnss,
                ligne.NomJeuneFille,
                ligne.AutresNom,
                ligne.NumeroInterne,
                ligne.CategorieNo,
                ligne.Brut1,
                ligne.Brut2,
                ligne.Brut3);
        }

        internal void Delete(LigneView ligne)
        {
            if (ligne == null) throw new ArgumentNullException("ligne");
            _service.CnssService.LigneCnssDelete(ligne.No);
        }

        internal void Delete(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.CnssService.DeclarationDeleteCnss(declaration.Id);
        }

        internal void Editer(DeclarationView declaration)
        {
            if (declaration == null) throw new ArgumentNullException("declaration");
            _service.CnssService.Editer(declaration.Id);
        }

        internal void Exporter(DeclarationView currentDeclaration, string path)
        {
            if (currentDeclaration == null) throw new ArgumentNullException("currentDeclaration");
            _service.CnssService.ExportsCnss(currentDeclaration.Id, path);
        }

        internal Societe GetCurrentSociete()
        {
            return _service.Societe;
        }

        internal Exercice GetCurrentExercice()
        {
            return _service.Exercice;
        }

        internal DeclarationReport Imprimer(DeclarationView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            var declaration = _service.CnssService.DeclarationGet(view.Id);
            if (declaration == null) throw new ArgumentNullException("Déclaration invalide!");
            var ds = new DeclarationDs(_service, declaration);
            var etat = new DeclarationReport
            {
                DataSource = ds
            };
            foreach (Parameter param in etat.Parameters)
            {
                var lookUpSetting = param.LookUpSettings as DynamicListLookUpSettings;
                if (lookUpSetting == null) continue;
                lookUpSetting.DataSource = ds;
            }
            return etat;
        }

        internal RecapCnssReportI3 ImprimerRecap(DeclarationView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            var declaration = _service.CnssService.DeclarationGet(view.Id);
            if (declaration == null) throw new ArgumentNullException("Déclaration invalide!");
            var ds = new DeclarationDs(_service, declaration);
            var etat = new RecapCnssReportI3
            {
                DataSource = ds
            };
            foreach (Parameter param in etat.Parameters)
            {
                var lookUpSetting = param.LookUpSettings as DynamicListLookUpSettings;
                if (lookUpSetting == null) continue;
                lookUpSetting.DataSource = ds;
            }
            return etat;
        }

        public DeclarationView InitDeclaration()
        {
            return new DeclarationView
            {
                Complementaire = false,
                ExerciceId = _service.Exercice.Id,
                Trimestre = 1,
                Date = DateTime.Now,
                IsArchive = false,
                IsCloture = false,
                Societe = _service.Societe.RaisonSocial,
                Annee = _service.Exercice.Annee
            };
        }

        public void CreateDeclaration(DeclarationView view)
        {
            _service.CnssService.DeclarationCreate(view.Trimestre, view.Complementaire);
        }
    }
}