using DevExpress.XtraPrinting.Native;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Interfaces;
using TVS.Core.Models;
using Tvs.Module.Employee.Imports.Interfaces;
using Tvs.Module.Employee.DalExport;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Imports.Views;
using TVS.Module.Employee.Models.Pieds;
using TVS.Module.Employee.Services;

namespace TVS.Module.Employee.Services
{
    public class Annexe4Service : IAnnexeService<LigneAnnexeQuatre, PiedAnnexeQuatre>
    {
        private const int No = 4;
        private readonly IAnnexeQuatreRepository _repository;
        private readonly LigneAnnexeQuatreValidator _validator;
        private readonly IExportRepostiory _exportRepostiory;
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private string fileName = @"ANXEMP_{0}_{1}{2}_1.txt";
        private readonly ILigneAnnexeQuatreImportRepository _ligneAnnexeQuatreImportRepository;

        public Annexe4Service(
            IAnnexeQuatreRepository repository,
            IExportRepostiory exportRepostiory,
            Societe societe,
            Exercice exercice,
            ILigneAnnexeQuatreImportRepository ligneAnnexeQuatreImportRepository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            if (exportRepostiory == null)
                throw new ArgumentNullException("exportRepostiory");

            if (societe == null)
                throw new ArgumentNullException("societe");

            if (exercice == null)
                throw new ArgumentNullException("exercice");

            if (ligneAnnexeQuatreImportRepository == null)
                throw new ArgumentNullException(nameof(ligneAnnexeQuatreImportRepository));

            _repository = repository;
            _exportRepostiory = exportRepostiory;
            _societe = societe;
            _exercice = exercice;
            _ligneAnnexeQuatreImportRepository = ligneAnnexeQuatreImportRepository;
            _validator = new LigneAnnexeQuatreValidator();
        }

        public bool VerifyLigne(LigneAnnexeQuatre ligne, IList<ValidationFailure> errors)
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

        public bool Ajouter(LigneAnnexeQuatre ligne, IList<ValidationFailure> errors)
        {
            //verify ligne
            if (!VerifyLigne(ligne, errors))
                return false;
            ligne.SocieteId = _societe.Id;
            ligne.ExerciceId = _exercice.Id;

            // insert ligne
            _repository.Insert(ligne);
            return true;
        }

        public IAnnexe<LigneAnnexeQuatre, PiedAnnexeQuatre> GetAnnexe()
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
                SocieteNumero = 0, // int.Parse(_societe.AdresseNumero),
                SocieteCodePostal = int.Parse(_societe.CodePostal)
            };

            var pied = new PiedAnnexeQuatre
            {
                TypeEnregistrement = string.Format("T{0}", No),
                TotalHonoraireNonResidente = lignes.Sum(x => x.MontantHonoraireNonResidente),
                TotalPlusValueImmobiliere = lignes.Sum(x => x.MontantPlusValueImmobiliere),
                TotalMontantHonoraireExportation = lignes.Sum(x => x.MontantBrutExport),
                TotalMontantParadisFiscaux = lignes.Sum(x => x.MontantParadisFiscaux),
                TotalNetServis = lignes.Sum(x => x.MontantNetServi),
                TotalHonoraireNonDepotExistence = lignes.Sum(x => x.MontantServi),
                TotalPlusValeurFondPrevuesLegislation = lignes.Sum(x => x.MontantCession),
                TotalRetenueOperee = lignes.Sum(x => x.MontantRetenueOperee),
                TotalRevenueMobiliere = lignes.Sum(x => x.MontantRevenuValueMobiliere),
            };

            return new AnnexeQuatre
            {
                Entete = entete,
                Pied = pied,
                Lignes = lignes
            };
        }

        public void Exporter(string directory)
        {
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
            try
            {
                str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementText(annexe.Entete, detailAnnexe));
            }
            catch (Exception e)
            {
                MessageBox.Show("Entete");
                throw;
            }
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

        public void ValiderAnnexeQuatre()
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

        public void DeleteLigne(LigneAnnexeQuatre ligne)
        {
            if (ligne == null) throw new ArgumentNullException("ligne");
            // TODO: verifier si la declaration est cloturer
            // supprimer la ligne
            _repository.Delete(ligne);
        }

        public IList<LigneAnnexeZoneValue> GetZonesValue(LigneAnnexeQuatre ligne)
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

        public void Update(LigneAnnexeQuatre ligne)
        {
            if (ligne == null) throw new ArgumentNullException(nameof(ligne));
            _repository.Update(ligne);
        }

        public List<LigneAnnexeQuatre> GetAll(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            var ligneImportView = _ligneAnnexeQuatreImportRepository.GetAll(path).ToList();

            return ligneImportView
                .Select(ToModel)
                .ToList();
        }

        private LigneAnnexeQuatre ToModel(LigneAnnexe4ImportView ligneView)
        {
            if (ligneView == null) throw new ArgumentNullException(nameof(ligneView));
            return new LigneAnnexeQuatre
            {
                Beneficiaire = ligneView.Beneficiaire,
                BeneficiaireActivite = ligneView.BeneficiaireActivite,
                BeneficiaireAdresse = ligneView.BeneficiaireAdresse,
                BeneficiaireIdent = ligneView.BeneficiaireIdent,
                BeneficiaireType = ligneView.BeneficiaireType,
                MontantNetServi = ligneView.MontantNetServi,
                MontantRetenueOperee = ligneView.MontantRetenueOperee,
                MontantBrutExport = ligneView.MontantBrutExport,
                MontantHonoraireNonResidente = ligneView.MontantHonoraireNonResidente,
                MontantParadisFiscaux = ligneView.MontantParadisFiscaux,
                MontantPlusValueImmobiliere = ligneView.MontantPlusValueImmobiliere,
                MontantServi = ligneView.MontantServi,
                TauxHonoraireNonResidente = ligneView.TauxHonoraireNonResidente,
                TauxMontantServi = ligneView.TauxMontantServi,
                TauxPlusValueImmobiliere = ligneView.TauxPlusValueImmobiliere,
                TypeMontantServiActNonCommercial = ligneView.TypeMontantServiActNonCommercial,
                TypeMontantServiExport = ligneView.TypeMontantServiExport,
                MontantCession = ligneView.MontantCession,
                //  MontantRevenuValueMobiliere = ligneView.MontantRevenuValueMobiliere,
                MontantJetonsPresence = ligneView.MontantJetonsPresence,
                MontantActionsPartsSociales = ligneView.MontantActionsPartSociale,
                MontantValeurMobiliere = ligneView.MontantRevenuValeurMobiliere,
                TauxCession = ligneView.TauxCession,
                TauxRevenuValueMobiliere = ligneView.TauxRevenuValueMobiliere,
                SocieteId = _societe.Id,
                ExerciceId = _exercice.Id,
            };
        }

        public LigneAnnexeQuatre Get(int ligneNo)
        {
            return _repository.Get(ligneNo);
        }

        public LigneAnnexeQuatre SetLigneEnregistrementValue(IList<LigneAnnexeZoneValue> ligneAnnexeZoneValues)
        {
            if (ligneAnnexeZoneValues == null)
                throw new ArgumentNullException(nameof(ligneAnnexeZoneValues));
            return AnnexeEnregistementHelper
                .SetAnnexeEnregistrementValue<LigneAnnexeQuatre>(ligneAnnexeZoneValues);
        }

        public void Imprimer()
        {
        }
    }
}