using DevExpress.XtraPrinting.Native;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraReports.UI;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Interfaces;
using TVS.Core.Models;
using Tvs.Module.Employee.Imports.Interfaces;
using Tvs.Module.Employee.DalExport;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Imports.Views;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Services
{
    public class Annexe5Service : IAnnexeService<LigneAnnexeCinq, PiedAnnexeCinq>
    {
        private const int No = 5;
        private readonly IAnnexeCinqRepository _repository;
        private readonly IExportRepostiory _exportRepostiory;
        private readonly LigneAnnexeCinqValidator _validator;
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private string fileName = @"ANXEMP_{0}_{1}{2}_1.txt";
        private readonly ILigneAnnexeCinqImportRepository _ligneAnnexeCinqImportRepository;

        public Annexe5Service(
            IAnnexeCinqRepository repository,
            IExportRepostiory exportRepostiory,
            Societe societe,
            Exercice exercice,
            ILigneAnnexeCinqImportRepository ligneAnnexeCinqImportRepository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            if (exportRepostiory == null)
                throw new ArgumentNullException("exportRepostiory");

            if (societe == null)
                throw new ArgumentNullException("societe");

            if (exercice == null)
                throw new ArgumentNullException("exercice");

            if (ligneAnnexeCinqImportRepository == null)
                throw new ArgumentNullException(nameof(ligneAnnexeCinqImportRepository));

            _repository = repository;
            _exportRepostiory = exportRepostiory;
            _societe = societe;
            _exercice = exercice;
            _ligneAnnexeCinqImportRepository = ligneAnnexeCinqImportRepository;

            _validator = new LigneAnnexeCinqValidator();
        }

        public bool VerifyLigne(LigneAnnexeCinq ligne, IList<ValidationFailure> errors)
        {
            if (ligne == null)
                throw new ArgumentNullException("ligne");

            if (errors == null)
                throw new ArgumentNullException("errors");

            // vider la collection d'erreurs
            errors.Clear();
            // verifier si les donnees de la ligne sont valides
            var result = _validator.Validate(ligne);
            if (!result.IsValid)
            {
                result.Errors.ForEach(errors.Add);
                return false;
            }
            return true;
        }

        public bool Ajouter(LigneAnnexeCinq ligne, IList<ValidationFailure> errors)
        {
            // verify ligne
            if (!VerifyLigne(ligne, errors))
                return false;

            ligne.SocieteId = _societe.Id;
            ligne.ExerciceId = _exercice.Id;
            // insert ligne
            _repository.Insert(ligne);
            return true;
        }

        public IAnnexe<LigneAnnexeCinq, PiedAnnexeCinq> GetAnnexe()
        {
            var lignes = _repository.GetAll(_societe.Id, _exercice.Id).Select(x =>
            {
                x.TypeEnregistrement = string.Format("L{0}", No);
                return x;
            }).ToList();

            var entete = new EnteteAnnexe
            {
                TypeEnregistrement = string.Format("E{0}", No),
                TypeDocument = string.Format("An{0}", No),
                SocieteMatricule = int.Parse(_societe.MatriculFiscal),
                SocieteCle = _societe.MatriculCle,
                SocieteCategorie = _societe.MatriculCategorie,
                SocieteNumeroEtablissement = int.Parse(_societe.MatriculEtablissement),
                Exercice = _exercice.Annee,
                CodeActe = CodeActe.Spontane,
                TotalBeneficiaire = lignes.Count(), // a voire avec Nader (nbre de beneficiare) ??
                SocieteRaisonSocial = _societe.RaisonSocial,
                SocieteActivite = _societe.Activite,
                SocieteVille = _societe.Ville,
                SocieteRue = _societe.Adresse,
                SocieteNumero = 0, //int.Parse(_societe.AdresseNumero),
                SocieteCodePostal = int.Parse(_societe.CodePostal)
            };

            var pied = new PiedAnnexeCinq
            {
                TypeEnregistrement = string.Format("T{0}", No),
                MontantAutreOperation = lignes.Sum(x => x.MontantAutreOp),
                MontantEtabEtrangere = lignes.Sum(x => x.MontantEtabAlEtranger),
                MontantEtabPublic = lignes.Sum(x => x.MontantEtabPublic),
                MontantTauxDix = lignes.Sum(x => x.MontantOpExport),
                RetenueEtabEtangere = lignes.Sum(x => x.RetenueEtabAlEtranger),
                RetenueEtabPublic = lignes.Sum(x => x.RetenueEtabPublic),
                RetenueTauxDix = lignes.Sum(x => x.RetenueOpExport),
                RetenusAutreOperation = lignes.Sum(x => x.RetenueAutreOp),
                TotalNetServis = lignes.Sum(x => x.MontantNetServi)
            };

            return new AnnexeCinq
            {
                Entete = entete,
                Pied = pied,
                Lignes = lignes
            };
        }

        public void Exporter(string directory)
        {
            // construire l'entee
            // charger les lignes
            var annexe = GetAnnexe();
            var detailAnnexe = new SharedDetailAnnexe
            {
                Exercice = _exercice.Annee,
                SocieteCle = _societe.MatriculCle,
                SocieteCategorie = _societe.MatriculCategorie,
                SocieteMatricule = int.Parse(_societe.MatriculFiscal),
                SocieteNumeroEtablissement = int.Parse(_societe.MatriculEtablissement)
            };

            var str = new StringBuilder();
            str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementText(annexe.Entete, detailAnnexe));

            var compteur = 0;
            foreach (var ligne in annexe.Lignes)
            {
                compteur++;
                ligne.Ordre = compteur;
                str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementText(ligne, detailAnnexe));
            }

            str.Append(AnnexeEnregistementHelper.GetEnregistrementText(annexe.Pied, detailAnnexe));
            _exportRepostiory.Write(str.ToString(), string.Format(fileName, No, _exercice.Annee[2], _exercice.Annee[3]),
                directory);
        }

        public void ValiderAnnexeCinq()
        {
            // get all lignes
            var lignes = _repository.GetAll(_societe.Id, _exercice.Id);
            var numeroOrdre = 0;
            foreach (var ligne in lignes)
            {
                // mettre a jour le numero d'ordre du ligne du declaration
                numeroOrdre++;
                ligne.Ordre = numeroOrdre;
                _repository.Update(ligne);
            }
        }

        public void DeleteLigne(LigneAnnexeCinq ligne)
        {
            if (ligne == null)
                throw new ArgumentNullException("ligne");
            // TODO: verifier si la declaration est cloturer
            // supprimer la ligne
            _repository.Delete(ligne);
        }

        public IList<LigneAnnexeZoneValue> GetZonesValue(LigneAnnexeCinq ligne)
        {
            return AnnexeEnregistementHelper.GetZonesValue(ligne)
                .Where(x => x.EditingInGrid)
                .Select(x =>
                {
                    if (x.Code.Length == 2)
                        x.Code = string.Format("A{0}{1}", No, x.Code);
                    return x;
                }).ToList();
        }

        public void Update(LigneAnnexeCinq ligne)
        {
            if (ligne == null) throw new ArgumentNullException(nameof(ligne));
            _repository.Update(ligne);
        }

        public List<LigneAnnexeCinq> GetAll(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            var lignesImportView = _ligneAnnexeCinqImportRepository.GetAll(path).ToList();
            return lignesImportView
                .Select(ToModel)
                .ToList();
        }

        private LigneAnnexeCinq ToModel(LigneAnnexe5ImportView ligneView)
        {
            if (ligneView == null)
                throw new ArgumentNullException(nameof(ligneView));
            return new LigneAnnexeCinq
            {
                SocieteId = _societe.Id,
                ExerciceId = _exercice.Id,
                Beneficiaire = ligneView.Beneficiaire,
                BeneficiaireActivite = ligneView.BeneficiaireActivite,
                BeneficiaireAdresse = ligneView.BeneficiaireAdresse,
                BeneficiaireIdent = ligneView.BeneficiaireIdent,
                BeneficiaireType = ligneView.BeneficiaireType,
                MontantAutreOp = ligneView.MontantAutreOp,
                MontantEtabAlEtranger = ligneView.MontantEtabAlEtranger,
                MontantEtabPublic = ligneView.MontantEtabPublic,
                MontantNetServi = ligneView.MontantNetServi,
                MontantOpExport = ligneView.MontantOpExport,
                RetenueAutreOp = ligneView.RetenueAutreOp,
                RetenueEtabAlEtranger = ligneView.RetenueEtabAlEtranger,
                RetenueEtabPublic = ligneView.RetenueEtabPublic,
                RetenueOpExport = ligneView.RetenueOpExport
            };
        }

        public LigneAnnexeCinq Get(int ligneNo)
        {
            return _repository.Get(ligneNo);
        }

        public LigneAnnexeCinq SetLigneEnregistrementValue(IList<LigneAnnexeZoneValue> ligneAnnexeZoneValues)
        {
            if (ligneAnnexeZoneValues == null)
                throw new ArgumentNullException(nameof(ligneAnnexeZoneValues));
            return AnnexeEnregistementHelper
                .SetAnnexeEnregistrementValue<LigneAnnexeCinq>(ligneAnnexeZoneValues);
        }

        public void Imprimer()
        {
        }
    }
}