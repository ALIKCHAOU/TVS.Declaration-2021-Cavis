using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.Virement.Imports.Repository;
using TVS.Module.Virement.Imports.Views;

namespace TVS.Module.Virement.Imports.Controller
{
    public class ImportController
    {
        private readonly DeclarationService _service;
        private readonly ILigneImportRepository _serviceImport;

        public ImportController(DeclarationService service, ILigneImportRepository serviceImport)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
            _serviceImport = serviceImport;
        }

        public DeclarationImportView InitDeclaration()
        {
            return new DeclarationImportView
            {
                RaisonSocial = _service.Societe.RaisonSocial,
                Exercice = _service.Exercice.Annee,
                ExerciceId = _service.Exercice.Id,
                SocieteId = _service.Societe.Id,
                Path = string.Empty,
                
            };
        }

        public List<LigneImportView> GetLigne(string path)
        {
            var listImport = _serviceImport.GetAll(path).ToList();

            return listImport;
        }

        internal void Importer(DeclarationImportView declarationView)
        {
            var lignes = declarationView.Lignes.Select(x=>ToLigneImport(x,declarationView));
          

            _service.VirementService.ImporterLignes(declarationView.Id, lignes);
        }

        private VirementLigne ToLigneImport(LigneImportView l , DeclarationImportView declartion)
        {
            return new VirementLigne
            {
                Matricule = l.Matricule,
                Nom = l.Nom,
                Prenom = l.Prenom,
                NomBanque = l.NomBanque,
                CodeBanque = l.CodeBanque,
                CodeGuichet = l.CodeGuichet,
                NumeroCompte = l.NumeroCompte,
                CleRib = l.CleRib,
                NetAPaye = l.NetAPaye,
                Motif = l.Motif,
            };
        }

        public DeclarationImportView GetDeclaration(int no)
        {
            var declaration = _service.VirementService.Get(no);
            var exercice = _service.Exercice;
            return new DeclarationImportView
            {
                Id = declaration.Id,
                RaisonSocial = _service.Societe.RaisonSocial,
                Exercice = exercice.Annee,
                ExerciceId = declaration.ExerciceId,
                SocieteId = declaration.SocieteId,
                Path = string.Empty,
                Rib = declaration.Rib,
                Banque = declaration.Banque,
                Cloturer = declaration.Cloturer,
                Archiver = declaration.Archiver,
                MotifOperation = declaration.MotifOperation,
                ReferenceEnvoi = declaration.ReferenceEnvoi,
                Total = declaration.Total,
                DateCreation = declaration.DateCreation,
                NombreTotal = declaration.NombreTotal,
                DateEcheance = declaration.DateEcheance,
                BanqueId = declaration.BanqueId
            };
        }
    }
}