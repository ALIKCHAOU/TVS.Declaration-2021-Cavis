using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraPrinting.Native;
using FluentValidation.Results;
using Tvs.Module.Employee.DalExport;
using Tvs.Module.Employee.Imports.Interfaces;
using TVS.Core.Models;
using TVS.Module.Employee.Imports.Views;
using TVS.Module.Employee.Interfaces;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Services
{
    public class Annexe7Service : IAnnexeService<LigneAnnexeSept, PiedAnnexeSept>
    {
        private const int No = 7;
        private readonly IAnnexeSeptRepository _repository;
        private readonly LigneAnnexeSeptValidator _validator;
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private readonly ILigneAnnexeSeptImportRepository _ligneAnnexeSeptImportRepository;
        private readonly IExportRepostiory _exportRepostiory;
        private string fileName = @"ANXEMP_{0}_{1}{2}_1.txt";
        //private readonly IAnnexeUnRepository _annexeUnRepo;
        //private readonly IAnnexeDeuxRepository _annexeDeuxRepo;
        //private readonly IAnnexeTroisRepository _annexeTroisRepo;
        //private readonly IAnnexeQuatreRepository _annexeQuatreRepo;
        //private readonly IAnnexeCinqRepository _annexeCinqRepo;
        private readonly IAnnexeSeptRepository _annexeSeptRepo;

        public Annexe7Service(
            IAnnexeSeptRepository repository,
            IExportRepostiory exportRepostiory,
            Societe societe,
            Exercice exercice,
            ILigneAnnexeSeptImportRepository ligneAnnexeSeptImportRepository,

            //IAnnexeUnRepository annexeUnRepo,
            //IAnnexeDeuxRepository annexeDeuxRepo,
            //IAnnexeTroisRepository annexeTroisRepo,
            //IAnnexeQuatreRepository annexeQuatreRepo,
            //IAnnexeCinqRepository annexeCinqRepo,
            IAnnexeSeptRepository annexeSeptRepo)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            if (exportRepostiory == null)
                throw new ArgumentNullException("exportRepostiory");

            if (societe == null)
                throw new ArgumentNullException("societe");

            if (exercice == null)
                throw new ArgumentNullException("exercice");

            _repository = repository;
            _exportRepostiory = exportRepostiory;
            _societe = societe;
            _exercice = exercice;
            _ligneAnnexeSeptImportRepository = ligneAnnexeSeptImportRepository;
            _validator = new LigneAnnexeSeptValidator();
            //_annexeCinqRepo = annexeCinqRepo;
            //_annexeSixRepo = annexeSixRepo;
            //_annexeDeuxRepo = annexeDeuxRepo;
            //_annexeTroisRepo = annexeTroisRepo;
            //_annexeUnRepo = annexeUnRepo;
            //_annexeQuatreRepo = annexeQuatreRepo;
            _annexeSeptRepo = annexeSeptRepo;
        }

        public bool VerifyLigne(LigneAnnexeSept ligne, IList<ValidationFailure> errors)
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

        public bool Ajouter(LigneAnnexeSept ligne, IList<ValidationFailure> errors)
        {
            // verify ligne
            if (!VerifyLigne(ligne, errors))
                return false;
            // insert ligne
            ligne.ExerciceId = _exercice.Id;
            ligne.SocieteId = _societe.Id;
            _repository.Insert(ligne);
            return true;
        }

        public IAnnexe<LigneAnnexeSept, PiedAnnexeSept> GetAnnexe()
        {
            var lignes = _annexeSeptRepo.GetAll(_societe.Id, _exercice.Id).Select(x =>
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
                TotalBeneficiaire = lignes.Count(),
                SocieteRaisonSocial = _societe.RaisonSocial,
                SocieteActivite = _societe.Activite,
                SocieteVille = _societe.Ville,
                SocieteRue = _societe.Adresse,
                SocieteNumero = 0, //int.Parse(_societe.AdresseNumero),
                SocieteCodePostal = int.Parse(_societe.CodePostal)
            };

            var pied = new PiedAnnexeSept
            {
                TypeEnregistrement = string.Format("T{0}", No),
                TotalMontantPayee = lignes.Sum(x => x.MontantPayee),
                TotalRetenuSource = lignes.Sum(x => x.RetenueSource),
                TotalMontantNetServi = lignes.Sum(x => x.MontantNetServi)
            };

            return new AnnexeSept
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
            str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementText(annexe.Entete, detailAnnexe));

            var compteur = 0;
            foreach (var ligne in annexe.Lignes)
            {
                compteur++;
                ligne.Ordre = compteur;
                _repository.Update(ligne);
                str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementText(ligne, detailAnnexe));
            }

            str.Append(AnnexeEnregistementHelper.GetEnregistrementText(annexe.Pied, detailAnnexe));
            _exportRepostiory.Write(str.ToString(), string.Format(fileName, No, _exercice.Annee[2], _exercice.Annee[3]),
                directory);
        }

        public void ValiderAnnexeSept()
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

        public void DeleteLigne(LigneAnnexeSept ligne)
        {
            if (ligne == null) throw new ArgumentNullException("ligne");
            // TODO: verifier si la declaration est cloturer
            // supprimer la ligne
            _repository.Delete(ligne);
        }

        public IList<LigneAnnexeZoneValue> GetZonesValue(LigneAnnexeSept ligne)
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

        public void Update(LigneAnnexeSept ligne)
        {
            if (ligne == null) throw new ArgumentNullException(nameof(ligne));
            _repository.Update(ligne);
        }

        public List<LigneAnnexeSept> GetAll(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
          //  return GenereRecapAnnexe7();
            var ligneImportView = _ligneAnnexeSeptImportRepository.GetAll(path).ToList();

            return ligneImportView
                .Select(ToModel)
                .ToList();
        }

        //List<LigneAnnexeSept> GenereRecapAnnexe7()
        //{
        //    var lignesAnx1 = _annexeUnRepo.GetAll(_societe.Id).ToList();
        //    var lignesAnx2 = _annexeDeuxRepo.GetAll(_societe.Id).ToList();
        //    var lignesAnx3 = _annexeTroisRepo.GetAll(_societe.Id).ToList();
        //    var lignesAnx4 = _annexeQuatreRepo.GetAll(_societe.Id).ToList();
        //    var lignesAnx5 = _annexeCinqRepo.GetAll(_societe.Id).ToList();
        //    // var lignesAnx6 = _annexeSixRepo.GetAll(_societe.Id).ToList();

        //    var lignesAnx7 = new List<LigneAnnexeSept>();
        //    for (var i = 1; i <= 25; i++)
        //    {
        //        switch (i)
        //        {
        //            case 1:
        //            {
        //                var lignes1 = lignesAnx1.ToList();
        //                foreach (var lig in lignes1)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.Traitement,
        //                        MontantPayee = lig.RevenuBrutImposable - lig.RevenuReinvesti,
        //                        RetenueSource = lig.MontantRetenuesRegimeCommun + lig.MontantRetenuesTauxVingt,
        //                        MontantNetServi = lig.MontantNetServie,
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 2:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Honoraires)
        //                        .ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.Honoraires,
        //                        MontantPayee = lig.MontantBurtHonoraires,
        //                        RetenueSource = lig.MontantRetenueOperee,
        //                        MontantNetServi = lig.MontantNetServi,
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 3:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Commissions)
        //                        .ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.Commissions,
        //                        MontantPayee = lig.MontantBurtHonoraires,
        //                        RetenueSource = lig.MontantRetenueOperee,
        //                        MontantNetServi = lig.MontantNetServi,
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 4:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Courtages)
        //                        .ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.Courtages,
        //                        MontantPayee = lig.MontantBurtHonoraires,
        //                        RetenueSource = lig.MontantRetenueOperee,
        //                        MontantNetServi = lig.MontantNetServi,
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 5:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Loyers).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.Loyers,
        //                        MontantPayee = lig.MontantBurtHonoraires,
        //                        RetenueSource = lig.MontantRetenueOperee,
        //                        MontantNetServi = lig.MontantNetServi,
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 6:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Remuneration)
        //                        .ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RemunerationsActivite,
        //                        MontantPayee = lig.MontantBurtHonoraires, //A213
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 7:
        //            {
        //                var lignes2 = lignesAnx2.Where(x => x.HonorairesSociete > 0).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.HonorairesPersonnePhysiqueMoraleSoumiseRegimeReel,
        //                        MontantPayee = lig.HonorairesSociete, //A214
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 8:
        //            {
        //                var lignes2 = lignesAnx2.Where(x => x.RemunerationsArtistes > 0).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RemunerationsAriste,
        //                        MontantPayee = lig.RemunerationsArtistes, //A219
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 9:
        //            {
        //                var lignes2 = lignesAnx2.Where(x => x.HonorairesBureauEtude > 0).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.HonorairesBureau,
        //                        MontantPayee = lig.HonorairesBureauEtude, //A220
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 10:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(
        //                        x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Honoraires).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.HonorairesOperationExport,
        //                        MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 Where A221 = 1
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 11:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(
        //                        x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Commissions).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.CommissionOperationExport,
        //                        MontantPayee = lig.MontantBrutHonorairesOperationExportation, // A222 where A221 = 2
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 12:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Courtages)
        //                        .ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.CourtagesOpeationExport,
        //                        MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 where A221 = 3
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 13:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Loyers)
        //                        .ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.LoyersOperationExport,
        //                        MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 where A221 = 4
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 14:
        //            {
        //                var lignes2 =
        //                    lignesAnx2.Where(
        //                        x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Remuneration).ToList();
        //                foreach (var lig in lignes2)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RemunerationOperationExport,
        //                        MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 where A221 = 5
        //                        RetenueSource = lig.MontantRetenueOperee, //A223
        //                        MontantNetServi = lig.MontantNetServi, //A225
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 15:
        //            {
        //                var lignes3 = lignesAnx3.Where(x => x.CompteSpeciaux > 0).ToList();
        //                foreach (var lig in lignes3)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.InteretCompteEpargne,
        //                        MontantPayee = lig.CompteSpeciaux, //A312 where A312 >0 
        //                        RetenueSource = lig.MontantRetenueOperee, //A315
        //                        MontantNetServi = lig.MontantNetServi, //A317
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 16:
        //            {
        //                var lignes3 = lignesAnx3.Where(x => x.PretEtabBancaire > 0).ToList();
        //                foreach (var lig in lignes3)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.InteretPretEtablissementBancaires,
        //                        MontantPayee = lig.PretEtabBancaire, //A314 where A314 > 0
        //                        RetenueSource = lig.MontantRetenueOperee, //A315
        //                        MontantNetServi = lig.MontantNetServi, //A317
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 17:
        //            {
        //                var lignes3 = lignesAnx3.Where(x => x.AutreCapitauxMobilier > 0).ToList();
        //                foreach (var lig in lignes3)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RevenusValeursMobilier,
        //                        MontantPayee = lig.AutreCapitauxMobilier, //A314 where A314 > 0
        //                        RetenueSource = lig.MontantRetenueOperee, //A315
        //                        MontantNetServi = lig.MontantNetServi, //A317
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 18:
        //            {
        //                var lignes4 = lignesAnx4.Where(x => x.MontantHonoraireNonResidente > 0).ToList();
        //                foreach (var lig in lignes4)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.HonorairesPersonneNonResident,
        //                        MontantPayee = lig.MontantHonoraireNonResidente, //A416 where A416 > 0
        //                        RetenueSource = lig.MontantRetenueOperee, //A426
        //                        MontantNetServi = lig.MontantNetServi, //A427
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 19:
        //            {
        //                var lignes4 = lignesAnx4.Where(x => x.MontantRevenuValueMobiliere > 0).ToList();
        //                foreach (var lig in lignes4)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RevenusMobilierNonResident,
        //                        MontantPayee = lig.MontantRevenuValueMobiliere, //A4222 where A422 > 0
        //                        RetenueSource = lig.MontantRetenueOperee, //A426
        //                        MontantNetServi = lig.MontantNetServi, //A427
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 20:
        //            {
        //                var lignes4 = lignesAnx4.Where(x => x.MontantParadisFiscaux > 0).ToList();
        //                foreach (var lig in lignes4)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RemunerationsPersonneResidentEtabliesParadisFiscaux,
        //                        MontantPayee = lig.MontantParadisFiscaux, //A425 where A425 > 0
        //                        RetenueSource = lig.MontantRetenueOperee, //A423
        //                        MontantNetServi = lig.MontantNetServi, //A427
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 21:
        //            {
        //                var lignes5 = lignesAnx5.Where(x => x.MontantOpExport > 0).ToList();
        //                foreach (var lig in lignes5)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RetenueSourcesMontantOperationExport,
        //                        MontantPayee = lig.MontantOpExport, //A512 WHERE A512 >0
        //                        RetenueSource = lig.RetenueOpExport, //A513
        //                        MontantNetServi = lig.MontantNetServi, //A521
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 22:
        //            {
        //                var lignes5 = lignesAnx5.Where(x => x.MontantAutreOp > 0).ToList();
        //                foreach (var lig in lignes5)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RetenueSourcesMontantAutresOperation,
        //                        MontantPayee = lig.MontantAutreOp, //A514 WHERE A514 > 0
        //                        RetenueSource = lig.RetenueAutreOp, //A515
        //                        MontantNetServi = lig.MontantNetServi, //A521
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 23:
        //            {
        //                var lignes5 = lignesAnx5.Where(x => x.MontantEtabPublic > 0).ToList();
        //                foreach (var lig in lignes5)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee = TypeMontantPayee.RetenueSourcesEtablissementPublic,
        //                        MontantPayee = lig.MontantEtabPublic, //A516 WHERE A516 > A516
        //                        RetenueSource = lig.RetenueEtabPublic, //A517
        //                        MontantNetServi = lig.MontantNetServi, //A521
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 24:
        //            {
        //                var lignes5 = lignesAnx5.Where(x => x.MontantEtabAlEtranger > 0).ToList();
        //                foreach (var lig in lignes5)
        //                {
        //                    var lig7 = new LigneAnnexeSept
        //                    {
        //                        SocieteId = _societe.Id,
        //                        ExerciceId = _exercice.Id,
        //                        Beneficiaire = lig.Beneficiaire,
        //                        BeneficiaireActivite = lig.BeneficiaireActivite,
        //                        BeneficiaireAdresse = lig.BeneficiaireAdresse,
        //                        BeneficiaireIdent = lig.BeneficiaireIdent,
        //                        BeneficiaireType = lig.BeneficiaireType,
        //                        TypeMontantPayee =
        //                            TypeMontantPayee.RetenueSourcesOperationPersonneNAyantPasEtablissement,
        //                        MontantPayee = lig.MontantEtabAlEtranger, //A518 WHERE A519
        //                        RetenueSource = lig.RetenueEtabAlEtranger, //A519
        //                        MontantNetServi = lig.MontantNetServi, //A521
        //                    };
        //                    lignesAnx7.Add(lig7);
        //                }
        //            }
        //                break;
        //            case 25:
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    return lignesAnx7;
        //}

        private LigneAnnexeSept ToModel(LigneAnnexe7ImportView ligneView)
        {
            if (ligneView == null) throw new ArgumentNullException(nameof(ligneView));
            return new LigneAnnexeSept
            {
                Beneficiaire = ligneView.Beneficiaire,
                BeneficiaireActivite = ligneView.BeneficiaireActivite,
                BeneficiaireAdresse = ligneView.BeneficiaireAdresse,
                BeneficiaireIdent = ligneView.BeneficiaireIdent,
                BeneficiaireType = ligneView.BeneficiaireType,
                MontantNetServi = ligneView.MontantNetServi,
                MontantPayee = ligneView.MontantPayee,
                RetenueSource = ligneView.RetenueSource,
                TypeMontantPayee = ligneView.TypeMontantPayee,
                SocieteId = _societe.Id,
                ExerciceId = _exercice.Id,
            };
        }

        public LigneAnnexeSept Get(int ligneNo)
        {
            return _repository.Get(ligneNo);
        }

        public LigneAnnexeSept SetLigneEnregistrementValue(IList<LigneAnnexeZoneValue> ligneAnnexeZoneValues)
        {
            if (ligneAnnexeZoneValues == null)
                throw new ArgumentNullException(nameof(ligneAnnexeZoneValues));
            return AnnexeEnregistementHelper
                .SetAnnexeEnregistrementValue<LigneAnnexeSept>(ligneAnnexeZoneValues);
        }

        public void Imprimer()
        {
        }
    }
}