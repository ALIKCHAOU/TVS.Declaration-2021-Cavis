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
using TVS.Module.Employee.Reports;
using TVS.Module.Employee;
using TVS.Module.Employee.Imports.Views;
using TVS.Module.Employee.Models.Pieds;

namespace TVS.Module.Employee.Services
{
    public class Annexe1Service : IAnnexeService<LigneAnnexeUn, PiedAnnexeUn>
    {
        private const int No = 1;
        private readonly IAnnexeUnRepository _repository;
        private readonly LigneAnnexeUnValidator _validator;
        private readonly IExportRepostiory _exportRepostiory;
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private readonly ILigneAnnexeUnImportRepository _ligneAnnexeUnImportRepository;

        private string fileName = @"ANXEMP_{0}_{1}{2}_1.txt";

        public Annexe1Service(
            IAnnexeUnRepository repository,
            IExportRepostiory exportRepostiory,
            Societe societe,
            Exercice exercice,
            ILigneAnnexeUnImportRepository ligneAnnexeUnImportRepository)
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            if (exportRepostiory == null)
                throw new ArgumentNullException("exportRepostiory");

            if (societe == null)
                throw new ArgumentNullException("societe");

            if (exercice == null)
                throw new ArgumentNullException("exercice");

            if (ligneAnnexeUnImportRepository == null)
                throw new ArgumentNullException(nameof(ligneAnnexeUnImportRepository));

            _repository = repository;
            _exportRepostiory = exportRepostiory;
            _societe = societe;
            _exercice = exercice;
            _ligneAnnexeUnImportRepository = ligneAnnexeUnImportRepository;
            _validator = new LigneAnnexeUnValidator();
        }

        public bool VerifyLigne(LigneAnnexeUn ligne, IList<ValidationFailure> errors)
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

            // verifier si le beneficiaire a deja une ligne dans l'annexe
            if (_repository.ExistBeneficiaire(ligne.BeneficiaireIdent))
            {
                var failureMessage = string.Format("Le beneficiaire [{0}, {1}] a deja une ligne dans l'annexe 1",
                    ligne.Beneficiaire, ligne.BeneficiaireIdent);
                var failure = new ValidationFailure("BeneficiaireIdent", failureMessage);
                errors.Add(failure);
                return false;
            }

            return true;
        }

        public bool Ajouter(LigneAnnexeUn ligne, IList<ValidationFailure> errors)
        {
            // verifier la ligne
            if (!VerifyLigne(ligne, errors))
                return false;

            ligne.SocieteId = _societe.Id;
            ligne.ExerciceId = _exercice.Id;
            // inserer la ligne dans la base
            _repository.Insert(ligne);
            return true;
        }

        public IAnnexe<LigneAnnexeUn, PiedAnnexeUn> GetAnnexe()
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
                SocieteMatricule = int.Parse(_societe.MatriculFiscal ?? "0"),
                SocieteCle = _societe.MatriculCle,
                SocieteCategorie = _societe.MatriculCategorie,
                SocieteNumeroEtablissement = int.Parse(_societe.MatriculEtablissement ?? "0"),
                Exercice = _exercice.Annee,
                CodeActe = CodeActe.Spontane,
                TotalBeneficiaire = lignes.Count(), // a voire avec Nader (nbre de beneficiare) ??
                SocieteRaisonSocial = _societe.RaisonSocial,
                SocieteActivite = _societe.Activite,
                SocieteVille = _societe.Ville,
                SocieteRue = _societe.Adresse,
                SocieteNumero = 0, // int.Parse(_societe.AdresseNumero),
                SocieteCodePostal = int.Parse(_societe.CodePostal ?? "0")
            };

            var pied = new PiedAnnexeUn
            {
                TypeEnregistrement = string.Format("T{0}", No),
                TotalRevenuImposable = lignes.Sum(x => x.RevenuImposable),
                TotalAventageNature = lignes.Sum(x => x.AvantageEnNature),
                TotalRevenuBrutImposable = lignes.Sum(x => x.RevenuBrutImposable),
                TotalRevenuReinvesti = lignes.Sum(x => x.RevenuReinvesti),
                TotalRetenuRegimeCommun = lignes.Sum(x => x.MontantRetenuesRegimeCommun),
                TotalRetenueTauxVingt = lignes.Sum(x => x.MontantRetenuesTauxVingt),
                TotalNetServi = lignes.Sum(x => x.MontantNetServie)
            };

            return new AnnexeUn
            {
                Entete = entete,
                Pied = pied,
                Lignes = lignes
            };
        }
        public void Exporter2018(IAnnexe<LigneAnnexeUn, PiedAnnexeUn> lst, string directory)
        {
            try
            {
                string result = "";

                //var regexInt = new Regex(@"^\d+$");
                //var banque = _societeBanqueRepository.Get(entet.BanqueId);
                //if (banque == null) throw new InvalidOperationException("Banque invalide!");

                //var count = lignes.Count;
                //var total = lignes.Sum(x => x.NetAPaye);



                result += "E1";
                result += lst.Entete.SocieteMatricule.ToString().PadLeft(7, '0').Substring(0, 7);
                result += lst.Entete.SocieteCle.ToString();
                result += lst.Entete.SocieteCategorie.ToString();
                result += lst.Entete.SocieteNumeroEtablissement.ToString().PadLeft(3, '0').Substring(0, 3);
                result += "2018";
                result += "An1";
                result += ((int)lst.Entete.CodeActe).ToString();
                result += lst.Lignes.Count().ToString().PadLeft(6, '0');
                result += lst.Entete.SocieteRaisonSocial.PadRight(40, ' ').Substring(0, 40); ;
                result += lst.Entete.SocieteActivite.PadRight(40, ' ').Substring(0, 40); 
                result += lst.Entete.SocieteVille.PadRight(40, ' ').Substring(0, 40); ;
                result += lst.Entete.SocieteRue.PadRight(72, ' ').Substring(0, 72); ;
                result += lst.Entete.SocieteNumero.ToString().PadRight(4, '0');
                result += lst.Entete.SocieteCodePostal.ToString().PadRight(4, '0');
                result += string.Empty.PadRight(177, ' ');
                result += Environment.NewLine;
                var i = 1;
                var totalRevImp = lst.Lignes.Sum(x => x.RevenuImposable);
                var totalAvNatur = lst.Lignes.Sum(x => x.AvantageEnNature);
                var totalRevBrutImp = lst.Lignes.Sum(x => x.RevenuBrutImposable);
                var totalRevReinv = lst.Lignes.Sum(x => x.RevenuReinvesti);
                var totalRetOpRC = lst.Lignes.Sum(x => x.MontantRetenuesRegimeCommun);
                var totalRetOp20= lst.Lignes.Sum(x => x.MontantRetenuesTauxVingt);
                var totalContrSolid = lst.Lignes.Sum(x => x.ContributionSocialeSolidarite);
                var totalNetServi = lst.Lignes.Sum(x => x.MontantNetServie);

                foreach (var lig in lst.Lignes)
                {
                    result += "L1";
                    result += lst.Entete.SocieteMatricule.ToString().PadLeft(7, '0').Substring(0, 7);
                    result += lst.Entete.SocieteCle.ToString();
                    result += lst.Entete.SocieteCategorie.ToString();
                    result += lst.Entete.SocieteNumeroEtablissement.ToString().PadLeft(3, '0').Substring(0, 3);
                    result += "2018";
                    result += i.ToString().PadLeft(6, '0');
                    result += (int)lig.BeneficiaireType;
                    result += lig.BeneficiaireIdent.PadRight(13, ' ');
                    result += lig.Beneficiaire.PadRight(40, ' ').Substring(0, 40);
                    result += lig.BeneficiaireActivite.PadRight(40, ' ');
                    result += lig.BeneficiaireAdresse.PadRight(120, ' ');
                    result += (int)lig.SituationFamiliale;
                    result += lig.NombreEnfant.ToString().PadLeft(2, '0').Substring(0, 2);
                    result += lig.DateDebutTravail.ToString("ddMMyyyy");
                    result += lig.DateFinTravail.ToString("ddMMyyyy");
                    result += lig.DureeEnJour.ToString().PadLeft(3, '0').Substring(0, 3);
                    result += string.Format("{0:0}", lig.RevenuImposable * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.AvantageEnNature * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.RevenuBrutImposable * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.RevenuReinvesti * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.MontantRetenuesRegimeCommun * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.MontantRetenuesTauxVingt * 1000).PadLeft(15, '0');

                    result += string.Format("{0:0}", lig.ContributionSocialeSolidarite * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.MontantNetServie * 1000).PadLeft(15, '0');

                    result += string.Empty.PadRight(25, ' ');
                    result += Environment.NewLine;

                    i++;
                }

                //Pied
                result += "T1";                
                result += lst.Entete.SocieteMatricule.ToString().PadLeft(7, '0').Substring(0, 7);
                result += lst.Entete.SocieteCle.ToString();
                result += lst.Entete.SocieteCategorie.ToString();
                result += lst.Entete.SocieteNumeroEtablissement.ToString().PadLeft(3, '0').Substring(0, 3);
                result += "2018";
                result += string.Empty.PadRight(242, ' ');
                result += string.Format("{0:0}", totalRevImp * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalAvNatur * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRevBrutImp * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRevReinv * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRetOpRC * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRetOp20 * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalContrSolid * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalNetServi * 1000).PadLeft(15, '0');
                result += string.Empty.PadRight(25, ' ');


                //result += Environment.NewLine;
                _exportRepostiory.Write(result.ToString(), string.Format(fileName, No, _exercice.Annee[2], _exercice.Annee[3]),
                    directory);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Exporter2019(IAnnexe<LigneAnnexeUn, PiedAnnexeUn> lst, string directory)
        {
            try
            {
                string result = "";

                //var regexInt = new Regex(@"^\d+$");
                //var banque = _societeBanqueRepository.Get(entet.BanqueId);
                //if (banque == null) throw new InvalidOperationException("Banque invalide!");

                //var count = lignes.Count;
                //var total = lignes.Sum(x => x.NetAPaye);



                result += "E1";
                result += lst.Entete.SocieteMatricule.ToString().PadLeft(7, '0').Substring(0, 7);
                result += lst.Entete.SocieteCle.ToString();
                result += lst.Entete.SocieteCategorie.ToString();
                result += lst.Entete.SocieteNumeroEtablissement.ToString().PadLeft(3, '0').Substring(0, 3);
                result += "2019";
                result += "An1";
                result += ((int)lst.Entete.CodeActe).ToString();
                result += lst.Lignes.Count().ToString().PadLeft(6, '0');
                result += lst.Entete.SocieteRaisonSocial.PadRight(40, ' ').Substring(0, 40); ;
                result += lst.Entete.SocieteActivite.PadRight(40, ' ').Substring(0, 40);
                result += lst.Entete.SocieteVille.PadRight(40, ' ').Substring(0, 40); ;
                result += lst.Entete.SocieteRue.PadRight(72, ' ').Substring(0, 72); ;
                result += lst.Entete.SocieteNumero.ToString().PadRight(4, '0');
                result += lst.Entete.SocieteCodePostal.ToString().PadRight(4, '0');
                result += string.Empty.PadRight(177, ' ');
                result += Environment.NewLine;
                var i = 1;
                var totalRevImp = lst.Lignes.Sum(x => x.RevenuImposable);
                var totalAvNatur = lst.Lignes.Sum(x => x.AvantageEnNature);
                var totalRevBrutImp = lst.Lignes.Sum(x => x.RevenuBrutImposable);
                var totalRevReinv = lst.Lignes.Sum(x => x.RevenuReinvesti);
                var totalRetOpRC = lst.Lignes.Sum(x => x.MontantRetenuesRegimeCommun);
                var totalRetOp20 = lst.Lignes.Sum(x => x.MontantRetenuesTauxVingt);
                var totalContrSolid = lst.Lignes.Sum(x => x.ContributionSocialeSolidarite);
                var totalNetServi = lst.Lignes.Sum(x => x.MontantNetServie);

                foreach (var lig in lst.Lignes)
                {
                    result += "L1";
                    result += lst.Entete.SocieteMatricule.ToString().PadLeft(7, '0').Substring(0, 7);
                    result += lst.Entete.SocieteCle.ToString();
                    result += lst.Entete.SocieteCategorie.ToString();
                    result += lst.Entete.SocieteNumeroEtablissement.ToString().PadLeft(3, '0').Substring(0, 3);
                    result += "2019";
                    result += i.ToString().PadLeft(6, '0');
                    result += (int)lig.BeneficiaireType;
                    result += lig.BeneficiaireIdent.PadRight(13, ' ');
                    result += lig.Beneficiaire.PadRight(40, ' ').Substring(0, 40);
                    result += lig.BeneficiaireActivite.PadRight(40, ' ');
                    result += lig.BeneficiaireAdresse.PadRight(120, ' ');
                    result += (int)lig.SituationFamiliale;
                    result += lig.NombreEnfant.ToString().PadLeft(2, '0').Substring(0, 2);
                    result += lig.DateDebutTravail.ToString("ddMMyyyy");
                    result += lig.DateFinTravail.ToString("ddMMyyyy");
                    result += lig.DureeEnJour.ToString().PadLeft(3, '0').Substring(0, 3);
                    result += string.Format("{0:0}", lig.RevenuImposable * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.AvantageEnNature * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.RevenuBrutImposable * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.RevenuReinvesti * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.MontantRetenuesRegimeCommun * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.MontantRetenuesTauxVingt * 1000).PadLeft(15, '0');

                    result += string.Format("{0:0}", lig.ContributionSocialeSolidarite * 1000).PadLeft(15, '0');
                    result += string.Format("{0:0}", lig.MontantNetServie * 1000).PadLeft(15, '0');

                    result += string.Empty.PadRight(25, ' ');
                    result += Environment.NewLine;

                    i++;
                }

                //Pied
                result += "T1";
                result += lst.Entete.SocieteMatricule.ToString().PadLeft(7, '0').Substring(0, 7);
                result += lst.Entete.SocieteCle.ToString();
                result += lst.Entete.SocieteCategorie.ToString();
                result += lst.Entete.SocieteNumeroEtablissement.ToString().PadLeft(3, '0').Substring(0, 3);
                result += "2019";
                result += string.Empty.PadRight(242, ' ');
                result += string.Format("{0:0}", totalRevImp * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalAvNatur * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRevBrutImp * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRevReinv * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRetOpRC * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalRetOp20 * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalContrSolid * 1000).PadLeft(15, '0');
                result += string.Format("{0:0}", totalNetServi * 1000).PadLeft(15, '0');
                result += string.Empty.PadRight(25, ' ');


                //result += Environment.NewLine;
                _exportRepostiory.Write(result.ToString(), string.Format(fileName, No, _exercice.Annee[2], _exercice.Annee[3]),
                    directory);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Exporter(string directory)
        {
            var annexe = GetAnnexe();           

            // charger les lignes
           
            var detailAnnexe = new SharedDetailAnnexe
            {
                Exercice = _exercice.Annee,
                SocieteCle = _societe.MatriculCle,
                SocieteCategorie = _societe.MatriculCategorie,
                SocieteMatricule = int.Parse(_societe.MatriculFiscal),
                SocieteNumeroEtablissement = int.Parse(_societe.MatriculEtablissement)
            };

            if (_exercice.Annee == "2018")
            {
                Exporter2018(annexe , directory);
                return;
            }
            if (_exercice.Annee == "2019")
            {
                Exporter2019(annexe, directory);
                return;
            }


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

        public void Imprimer()
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
            var report = new reportAnnexUn();
            report.Parameters["pRaisonSocial"].Value = _societe.RaisonSocial;
            report.Parameters["pActivite"].Value = _societe.Activite;
            report.Parameters["pAdresse"].Value = _societe.Adresse;
            report.Parameters["pExercice"].Value = _exercice.Annee;
            report.DataSource = annexe.Lignes;
            report.ShowPreview();
        }

        public IList<LigneAnnexeZoneValue> GetZonesValue(LigneAnnexeUn ligne)
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

        public void DeleteLigne(LigneAnnexeUn ligne)
        {
            if (ligne == null)
                throw new ArgumentNullException("ligne");
            // TODO: verifier si la declaration est cloturer
            // supprimer la ligne
            _repository.Delete(ligne);
        }

        public void Update(LigneAnnexeUn ligne)
        {
            try
            {
                if (ligne == null) throw new ArgumentNullException(nameof(ligne));
                _repository.Update(ligne);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<LigneAnnexeUn> GetAll(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            var ligneImportView = _ligneAnnexeUnImportRepository.GetAll(path).ToList();
            foreach (var ligneAnnexe1ImportView in ligneImportView)
            {

                if (ligneAnnexe1ImportView.DateDebutTravail < new DateTime(int.Parse(_exercice.Annee), 1, 1))
                {
                    ligneAnnexe1ImportView.DateDebutTravail = new DateTime(int.Parse(_exercice.Annee), 1, 1);
    
                }
                if (ligneAnnexe1ImportView.DateDebutTravail > new DateTime(int.Parse(_exercice.Annee), 12, 31))
                {
                    ligneAnnexe1ImportView.DateDebutTravail = new DateTime(int.Parse(_exercice.Annee), 12, 31);          
                }
                if (ligneAnnexe1ImportView.DateFinTravail < new DateTime(int.Parse(_exercice.Annee), 1, 1))
                {
                    ligneAnnexe1ImportView.DateFinTravail = new DateTime(int.Parse(_exercice.Annee), 12, 31);
                }
                if (ligneAnnexe1ImportView.DateFinTravail > new DateTime(int.Parse(_exercice.Annee), 12, 31))
                {
                    ligneAnnexe1ImportView.DateFinTravail = new DateTime(int.Parse(_exercice.Annee), 12, 31);
                }
            }
            return ligneImportView
                .Select(ToModel)
                .ToList();
        }

        private LigneAnnexeUn ToModel(LigneAnnexe1ImportView ligneView)
        {
            if (ligneView == null) throw new ArgumentNullException(nameof(ligneView));
            return new LigneAnnexeUn
            {
                SocieteId = _societe.Id,
                ExerciceId = _exercice.Id,
                Beneficiaire = ligneView.Beneficiaire,
                BeneficiaireActivite = ligneView.BeneficiaireActivite,
                BeneficiaireAdresse = ligneView.BeneficiaireAdresse,
                BeneficiaireIdent = ligneView.BeneficiaireIdent,
                BeneficiaireType = ligneView.BeneficiaireType,
                AvantageEnNature = ligneView.AvantageEnNature,
                DateDebutTravail = ligneView.DateDebutTravail,
                DateFinTravail = ligneView.DateFinTravail,
                //  DureeEnJour = ligneView.DureeEnJour,
                MontantNetServie = ligneView.MontantNetServie,
                MontantRetenuesRegimeCommun = ligneView.MontantRetenuesRegimeCommun,
                MontantRetenuesTauxVingt = ligneView.MontantRetenuesTauxVingt,
                NombreEnfant = ligneView.NombreEnfant,
                RevenuBrutImposable = ligneView.RevenuBrutImposable,
                RevenuImposable = ligneView.RevenuImposable,
                RevenuReinvesti = ligneView.RevenuReinvesti,
                SituationFamiliale = ligneView.SituationFamiliale,
                ContributionConjoncturelle = ligneView.ContributionConjoncturelle,
                RetenueUnPrct = ligneView.RetenueUnPrct,
                SalaireNonImposable = ligneView.SalaireNonImposable,
                ContributionSocialeSolidarite = ligneView.ContributionSocialeSol
                ,IntereDetectible=ligneView.InteretDeductibleSol,
                ChefFamille=ligneView.ChefFamille
                
            };
        }

        public LigneAnnexeUn Get(int ligneNo)
        {
            return _repository.Get(ligneNo);
        }

        public LigneAnnexeUn SetLigneEnregistrementValue(IList<LigneAnnexeZoneValue> ligneAnnexeZoneValues)
        {
            if (ligneAnnexeZoneValues == null)
                throw new ArgumentNullException(nameof(ligneAnnexeZoneValues));
            return AnnexeEnregistementHelper
                .SetAnnexeEnregistrementValue<LigneAnnexeUn>(ligneAnnexeZoneValues);
        }
    }
}