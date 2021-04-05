using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tvs.Module.Employee.DalExport;
using TVS.Core.Models;
using TVS.Module.Employee.Models.Enums;
using TVS.Module.Employee.Models.Recap;

namespace TVS.Module.Employee.Services
{
    public interface IRecapService
    {
        AnnexeRecap GetAnnexeRecap(
            bool isDecAnnexeUn,
            bool isDecAnnexeDeux,
            bool isDecAnnexeTrois,
            bool isDecAnnexeQuatre,
            bool isDecAnnexeCinq,
            bool isDecAnnexeSix,
            bool isDecAnnexeSept);

        void Exporter(bool isDecAnnexeUn,
            bool isDecAnnexeDeux,
            bool isDecAnnexeTrois,
            bool isDecAnnexeQuatre,
            bool isDecAnnexeCinq,
            bool isDecannexeSix,
            bool isDecAnnexeSept,
            string directory);
    }

    public class RecapService : IRecapService
    {
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private readonly Annexe1Service _annexeUnService;
        private readonly Annexe2Service _annexeDeuxService;
        private readonly Annexe3Service _annexeTroisService;
        private readonly Annexe4Service _annexeQuatreService;
        private readonly Annexe5Service _annexeCinqService;
        private readonly Annexe6Service _annexeSixService;
        private readonly Annexe7Service _annexeSeptService;
        private readonly IExportRepostiory _exportRepostiory;
        private string FileName = @"DECEMP_{0}{1}.txt";

        public RecapService(
            Societe societe,
            Exercice exercice,
            Annexe1Service annexeUnService,
            Annexe2Service annexeDeuxService,
            Annexe3Service annexeTroisService,
            Annexe4Service annexeQuatreService,
            Annexe5Service annexeCinqService,
            Annexe6Service annexeSixService,
            //  AnnexeSeptService annexeSeptService,
            IExportRepostiory exportRepostiory)
        {
            if (societe == null)
                throw new ArgumentNullException(nameof(societe));

            if (exercice == null)
                throw new ArgumentNullException(nameof(exercice));

            if (annexeUnService == null)
                throw new ArgumentNullException(nameof(annexeUnService));

            if (annexeDeuxService == null)
                throw new ArgumentNullException(nameof(annexeDeuxService));

            if (annexeTroisService == null)
                throw new ArgumentNullException(nameof(annexeTroisService));

            if (annexeQuatreService == null)
                throw new ArgumentNullException(nameof(annexeQuatreService));

            if (annexeCinqService == null)
                throw new ArgumentNullException(nameof(annexeCinqService));

            if (annexeSixService == null)
                throw new ArgumentNullException(nameof(annexeSixService));

            //if (annexeSeptService == null)
            //    throw new ArgumentNullException(nameof(annexeSeptService));

            if (exportRepostiory == null)
                throw new ArgumentNullException(nameof(exportRepostiory));

            _societe = societe;
            _exercice = exercice;
            _annexeUnService = annexeUnService;
            _annexeDeuxService = annexeDeuxService;
            _annexeTroisService = annexeTroisService;
            _annexeQuatreService = annexeQuatreService;
            _annexeCinqService = annexeCinqService;
            _annexeSixService = annexeSixService;
            //  _annexeSeptService = annexeSeptService;
            _exportRepostiory = exportRepostiory;
        }

        public AnnexeRecap GetAnnexeRecap(
            bool isDecAnnexeUn,
            bool isDecAnnexeDeux,
            bool isDecAnnexeTrois,
            bool isDecAnnexeQuatre,
            bool isDecAnnexeCinq,
            bool isDecAnnexeSix,
            bool isDecAnnexeSept)
        {
            // get annexe 1
            var annexeUn = _annexeUnService.GetAnnexe();
            if (annexeUn == null) throw new ArgumentNullException(nameof(annexeUn));
            // get annexe 2
            var annexeDeux = _annexeDeuxService.GetAnnexe();
            if (annexeDeux == null) throw new ArgumentNullException(nameof(annexeDeux));
            // get annexe 3
            var annexeTrois = _annexeTroisService.GetAnnexe();
            if (annexeTrois == null) throw new ArgumentNullException(nameof(annexeTrois));
            // get annexe 4
            var annexeQuatre = _annexeQuatreService.GetAnnexe();
            if (annexeQuatre == null) throw new ArgumentNullException(nameof(annexeQuatre));
            // get annexe 5
            var annexeCinq = _annexeCinqService.GetAnnexe();
            if (annexeCinq == null) throw new ArgumentNullException(nameof(annexeCinq));
            // get annexe 6
            var annexeSix = _annexeSixService.GetAnnexe();
            if (annexeSix == null) throw new ArgumentNullException(nameof(annexeSix));
            //// get annexe 7
            //var annexeSept = _annexeSeptService.GetAnnexe();
            //if (annexeSept == null) throw new ArgumentNullException(nameof(annexeSept));

            var lignesRecap = new List<LigneRecap>();

            // total general ligne recap
            var piedRecapTotalGeneral = 0M;
            // recap entete
            var recapEntete = new EnteteRecap
            {
                TypeEnregistrement = "000",
                Exercice = _exercice.Annee,
                SocieteMatricule = int.Parse(_societe.MatriculFiscal),
                SocieteCle = _societe.MatriculCle,
                SocieteCategorie = _societe.MatriculCategorie,
                SocieteEtablissement = int.Parse(_societe.MatriculEtablissement),
                IsDecAnnexe1 = isDecAnnexeUn,
                IsDecAnnexe2 = isDecAnnexeDeux,
                IsDecAnnexe3 = isDecAnnexeTrois,
                IsDecAnnexe4 = isDecAnnexeQuatre,
                IsDecAnnexe5 = isDecAnnexeCinq,
                IsDecAnnexe6 = isDecAnnexeSix,
                IsDecAnnexe7 = isDecAnnexeSept
            };

            if (_exercice.Annee == "2018")
            {

                /****/


             

                ///

                // ligne recap 1 DECEMP01	010	D011	A117	0	D013	A121
                var d013 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesRegimeCommun) : 0;
                // 121 Where A121 > 0 
                var d011 = !isDecAnnexeUn
                    ? 0
                    : annexeUn.Lignes//.Where(x => x.MontantRetenuesRegimeCommun > 0)
                        .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 Where A121 > 0 
                var recap1 = new LigneRecap
                {
                    Name = "DECEMP01",
                    Annexe = Annexe.Annexe1,
                    TypeEnregistrement = "010",
                    TotalAssiette = d011,
                    Taux = 0,
                    TotalRetenue = d013
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap1.TotalRetenue : 0;
                lignesRecap.Add(recap1);

                // ligne recap 2 DECEMP02	170	D021	A117	0	D023	A122
                var d023 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesTauxVingt) : 0; //A122
                var d021 = d023 == 0
                    ? 0
                    : annexeUn.Lignes.Where(y => y.MontantRetenuesTauxVingt > 0)
                        .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 (A122 > 0)
                var recap2 = new LigneRecap
                {
                    Name = "DECEMP02",
                    Annexe = Annexe.Annexe1,
                    TypeEnregistrement = "170",
                    TotalAssiette = d021,
                    Taux = 0,
                    TotalRetenue = d023
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap2.TotalRetenue : 0;
                lignesRecap.Add(recap2);

                // ligne recap 3 DECEMP03	
                var d032 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.ContributionSocialeSolidarite) : 0;

                var recap3 = new LigneRecap
                {
                    Name = "DECEMP03",
                    Annexe = Annexe.Annexe1,
                    TypeEnregistrement = "300",
                    // TotalAssiette = d021,
                    Taux2018A1 = "",
                    TotalRetenue = d032
                };                               

                piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap3.TotalRetenue : 0;
                lignesRecap.Add(recap3);
                 

                //ligne recap 4 DECEMP04                
                var d043 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x =>
                                x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                                (int)x.TypeMontantServiPersonne <= 5)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A213 > 0)
                var d041 = d043 == 0
                    ? 0
                    : annexeDeux.Lignes.Where(
                            x =>
                                x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                                (int)x.TypeMontantServiPersonne <= 5)
                        .Sum(x => x.MontantBurtHonoraires); //A213

                var recap4 = new LigneRecap
                {
                    Name = "DECEMP04",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "021",
                    TotalAssiette = d041,
                    Taux = 1500,
                    TotalRetenue = d043
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap4.TotalRetenue : 0;
                lignesRecap.Add(recap4);

                // ligne recap 5 DECEMP05	
                var d053 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                                (int)x.TypeMontantServiActNonCommercial <= 1)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d051 = d053 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                                (int)x.TypeMontantServiActNonCommercial <= 1)
                        .Sum(x => x.MontantServi);

                var recap5 = new LigneRecap
                {
                    Name = "DECEMP05",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "023",
                    TotalAssiette = d051,
                    Taux = 1500,
                    TotalRetenue = d053
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap5.TotalRetenue : 0;
                lignesRecap.Add(recap5);

                // ligne recap 6 DECEMP06
                var d063 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x =>
                                (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                 x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                                && x.MontantBrutHonorairesOperationExportation > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d061 = d063 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Where(
                            x =>
                                x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                        .Sum(x => x.MontantBrutHonorairesOperationExportation); //A222 (PP)

                var recap6 = new LigneRecap
                {
                    Name = "DECEMP06",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "025",
                    TotalAssiette = d061,
                    Taux = 250,
                    TotalRetenue = d063
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap6.TotalRetenue : 0;
                lignesRecap.Add(recap6);


                // ligne recap 7 DECEMP07
                var d073 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.HonorairesSociete > 0 || x.RemunerationsArtistes > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A219 > 0 & A214 > 0)

                var d071 = d073 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.RemunerationsArtistes + x.HonorairesSociete);
                // A214 + A219
                var recap7 = new LigneRecap
                {
                    Name = "DECEMP07",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "030",
                    TotalAssiette = d071,
                    Taux = 500,
                    TotalRetenue = d073
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap7.TotalRetenue : 0;
                lignesRecap.Add(recap7);

                // ligne recap 8 DECEMP08
                var d083 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.HonorairesBureauEtude > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A220 > 0)

                var d081 = d083 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.HonorairesBureauEtude); //A220
                var recap8 = new LigneRecap
                {
                    Name = "DECEMP08",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "180",
                    TotalAssiette = d081,
                    Taux = 250,
                    TotalRetenue = d083
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap8.TotalRetenue : 0;
                lignesRecap.Add(recap8);

                // ligne recap 9 DECEMP09
                var d093 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.LoyersHotels > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A218 > 0)

                var d091 = d093 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Sum(x => x.LoyersHotels); // 218

                var recap9 = new LigneRecap
                {
                    Name = "DECEMP09",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "040",
                    TotalAssiette = d091,
                    Taux = 500,
                    TotalRetenue = d093
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap9.TotalRetenue : 0;
                lignesRecap.Add(recap9);


                // ligne recap 10 DECEMP10	
                var d0103 = isDecAnnexeDeux
                    ? annexeDeux.Lignes.Where(
                            y =>
                                y.MontantBurtHonoraires > 0 &&
                                y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; // A213 > 0 et A212 = 6
                var d0101 = d0103 == 0
                    ? 0
                    : annexeDeux.Lignes.Where(
                            y =>
                                y.MontantBurtHonoraires > 0 &&
                                y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                        .Sum(x => x.MontantBurtHonoraires);
                var recap10 = new LigneRecap
                {
                    Name = "DECEMP10",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "260",
                    TotalAssiette = d0101,
                    Taux = 1500,
                    TotalRetenue = d0103
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap10.TotalRetenue : 0;
                lignesRecap.Add(recap10);


                // ligne recap 11 DECEMP11
                var d113 = isDecAnnexeTrois
                    ? annexeTrois.Lignes.Where(y => y.CompteSpeciaux > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (A312 > 0)
                var d111 = d113 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.CompteSpeciaux);
                var recap11 = new LigneRecap
                {
                    Name = "DECEMP11",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "060",
                    TotalAssiette = d111,
                    Taux = 2000,
                    TotalRetenue = d113
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap11.TotalRetenue : 0;
                lignesRecap.Add(recap11);
                // ligne recap 12 DECEMP12	
                var d123 = isDecAnnexeTrois
                    ? annexeTrois.Lignes
                        .Where(x => (x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                     x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                                    && x.AutreCapitauxMobilier > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (Résident & A313 >0)
                var d121 = d123 == 0
                    ? 0
                    : annexeTrois.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                    x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                        .Sum(x => x.AutreCapitauxMobilier); //A313(Résident)
                var recap12 = new LigneRecap
                {
                    Name = "DECEMP12",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "071",
                    TotalAssiette = d121,
                    Taux = 2000,
                    TotalRetenue = d123
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap12.TotalRetenue : 0;
                lignesRecap.Add(recap12);


                // ligne recap 13 DECEMP13
                var d133 = isDecAnnexeTrois
                    ? annexeTrois.Lignes
                        .Where(x => (x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                     x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                                    && x.AutreCapitauxMobilier > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (Non Résident & A313 >0)

                var d131 = d133 == 0
                    ? 0
                    : annexeTrois.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                    x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.AutreCapitauxMobilier); // A313 (Non Résident)

                var recap13 = new LigneRecap
                {
                    Name = "DECEMP13",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "073",
                    TotalAssiette = d131,
                    Taux = 2000,
                    TotalRetenue = d133
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap13.TotalRetenue : 0;
                lignesRecap.Add(recap13);


                // ligne recap 14 DECEMP14	
                var d143 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantValeurMobiliere > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A4201 > 0)

                var d141 = d143 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantValeurMobiliere); //A4201

                var recap14 = new LigneRecap
                {
                    Name = "DECEMP14",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "080",
                    TotalAssiette = d141,
                    Taux = 1500,
                    TotalRetenue = d143
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap14.TotalRetenue : 0;
                lignesRecap.Add(recap14);



                // ligne recap 15 DECEMP15
                var d153 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x =>
                                x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale &&
                                x.ActionsPartSociale > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A2152 > 0 & PP)

                var d151 = d153 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                        .Sum(x => x.ActionsPartSociale); //A2152 (PP)

                var recap15 = new LigneRecap
                {
                    Name = "DECEMP15",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "241",
                    TotalAssiette = d151,
                    Taux = 1000,
                    TotalRetenue = d153
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap15.TotalRetenue : 0;
                lignesRecap.Add(recap15);

                // ligne recap 16 DECEMP16	
                var d163 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes.Where(x => x.MontantActionsPartsSociales > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A4203 > 0)
                var d161 = d163 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantActionsPartsSociales); //A4203
                var recap16 = new LigneRecap
                {
                    Name = "DECEMP16",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "242",
                    TotalAssiette = d161,
                    Taux = 1000,
                    TotalRetenue = d163
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap16.TotalRetenue : 0;
                lignesRecap.Add(recap16);


                // ligne recap 17 DECEMP17	
                var d173 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A2151 >0)

                var d171 = d173 == 0 ? 0 : annexeDeux.Lignes.Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0).Sum(x => x.ActionsPartSociale); //A2151

                var recap17 = new LigneRecap
                {
                    Name = "DECEMP17",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "091",
                    TotalAssiette = 0,
                    Taux = 2000,
                    TotalRetenue = 0
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap17.TotalRetenue : 0;
                lignesRecap.Add(recap17);

                //
                // ligne recap 18 DECEMP18
                var d183 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantJetonsPresence > 0).Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A4202 > 0)

                var d181 = d183 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantJetonsPresence); //  A4202
                var recap18 = new LigneRecap
                {
                    Name = "DECEMP18",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "093",
                    TotalAssiette = d181,
                    Taux = 2000,
                    TotalRetenue = d183
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap18.TotalRetenue : 0;
                lignesRecap.Add(recap18);

                // ligne recap 19 DECEMP19
                var d193 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.RemunerationsSalaries > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A216 > 0)

                var d191 = d193 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Sum(x => x.RemunerationsSalaries); //A216
                var recap19 = new LigneRecap
                {
                    Name = "DECEMP19",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "100",
                    TotalAssiette = d191,
                    Taux = 1500,
                    TotalRetenue = d193
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap19.TotalRetenue : 0;
                lignesRecap.Add(recap19);

                // ligne recap 20 : DECEMP20	
                var d203 = isDecAnnexeTrois
                    ? annexeTrois.Lignes
                        .Where(x => x.PretEtabBancaire > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (A314 > 0)

                var d201 = d203 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.PretEtabBancaire); // A314
                var recap20 = new LigneRecap
                {
                    Name = "DECEMP20",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "110",
                    TotalAssiette = d201,
                    Taux = 1000,
                    TotalRetenue = d203
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap20.TotalRetenue : 0;
                lignesRecap.Add(recap20);

                // ligne recap 21 DECEMP21
                var A213 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x => x.PrixImmeuble > 0 && (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                                        x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal))
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223(A217 > 0 & Résident)

                var A211 = A213 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                    x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                        .Sum(x => x.PrixImmeuble); //A223 (Résident)

                var recap21 = new LigneRecap
                {
                    Name = "DECEMP21",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "121",
                    TotalAssiette = A211,
                    Taux = 250,
                    TotalRetenue = A213
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap21.TotalRetenue : 0;
                lignesRecap.Add(recap21);

                // ligne recap 22 DECEMP22	
                var d223 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantPlusValueImmobiliere > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d221 = d223 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantPlusValueImmobiliere > 0)
                        .Sum(x => x.MontantPlusValueImmobiliere);

                var recap22 = new LigneRecap
                {
                    Name = "DECEMP22",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "122",
                    TotalAssiette = d221,
                    Taux = 250,
                    TotalRetenue = d223
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap22.TotalRetenue : 0;
                lignesRecap.Add(recap22);

                // ligne recap 23 DECEMP23
                var d233 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantPlusValueImmobiliere > 0 &&
                                x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; // A423 (A418 > 0 & PM)

                var d231 = d233 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantPlusValueImmobiliere > 0 &&
                                x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantPlusValueImmobiliere); //A418(PM)

                var recap23 = new LigneRecap
                {
                    Name = "DECEMP23",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "123",
                    TotalAssiette = d231,
                    Taux = 1500,
                    TotalRetenue = d233
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap23.TotalRetenue : 0;
                lignesRecap.Add(recap23);

                // ligne recap 24 DECEMP24
                var d243 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.RetenueOpExport)
                    : 0;
                var d241 = d243 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.MontantOpExport);
                var recap24 = new LigneRecap
                {
                    Name = "DECEMP24",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "131",
                    TotalAssiette = d241,
                    Taux = 50,
                    TotalRetenue = d243
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap24.TotalRetenue : 0;
                lignesRecap.Add(recap24);

                // ligne recap 25 : DECEMP25
                var d253 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.RetenueAutreOp)
                    : 0;
                var d251 = d253 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.MontantAutreOp);
                var recap25 = new LigneRecap
                {
                    Name = "DECEMP25",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "132",
                    TotalAssiette = d251,
                    Taux = 150,
                    TotalRetenue = d253
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap25.TotalRetenue : 0;
                lignesRecap.Add(recap25);

                // ligne recap 26 DECEMP26
                var d263 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.RetenueEtabPublic)
                    : 0;
                var d261 = d263 == 0
                    ? 0
                    : annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.MontantEtabPublic);
                var recap26 = new LigneRecap
                {
                    Name = "DECEMP26",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "140",
                    TotalAssiette = d261,
                    Taux = 2500,
                    TotalRetenue = d263
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap26.TotalRetenue : 0;
                lignesRecap.Add(recap26);

                // ligne recap 27 DECEMP27
                var d273 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.RetenueEtabAlEtranger)
                    : 0;
                var d271 = d273 == 0
                    ? 0
                    : annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.MontantEtabAlEtranger);
                var recap27 = new LigneRecap
                {
                    Name = "DECEMP27",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "150",
                    TotalAssiette = d271,
                    Taux = 10000,
                    TotalRetenue = d273
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap27.TotalRetenue : 0;
                lignesRecap.Add(recap27);

                // ligne recap 28 DECEMP28
                var d283 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantHonoraireNonResidente > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A416 > 0)

                var d281 = d283 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantHonoraireNonResidente > 0)
                        .Sum(x => x.MontantHonoraireNonResidente); //A416 

                var recap28 = new LigneRecap
                {
                    Name = "DECEMP28",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "160",
                    TotalAssiette = d281,
                    Taux = 0,
                    TotalRetenue = d283
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap28.TotalRetenue : 0;
                lignesRecap.Add(recap28);


                // ligne recap 29 DECEMP29
                var d293 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 &&
                                (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1|| x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A416 > 0)

                var d291 = d293 == 0
                    ? 0
                    : annexeQuatre.Lignes
                         .Where(
                            x =>
                                x.MontantServi > 0 &&
                                (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1 || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                        .Sum(x => x.MontantServi); //A416 

                var recap29 = new LigneRecap
                {
                    Name = "DECEMP29",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "270",
                    TotalAssiette = d291,
                    Taux = 1500,
                    TotalRetenue = d293
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap29.TotalRetenue : 0;
                lignesRecap.Add(recap29);


                // ligne recap 30 DECEMP30	
                var d303 = isDecAnnexeSix
                    ? annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                        .Sum(x => x.MontantAvances)
                    : 0;
                var d301 = d303 == 0
                    ? 0
                    : annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                        .Sum(x => x.MontantVentes);
                var recap30 = new LigneRecap
                {
                    Name = "DECEMP30",
                    Annexe = Annexe.Annexe6,
                    TypeEnregistrement = "200",
                    TotalAssiette = d301,
                    Taux = 100,
                    TotalRetenue = d303
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap30.TotalRetenue : 0;
                lignesRecap.Add(recap30);

                // ligne recap 31 DECEMP31
                var d313 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d311 = d313 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                        .Sum(x => x.MontantCession);
                var recap31 = new LigneRecap
                {
                    Name = "DECEMP31",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "191",
                    TotalAssiette = d311,
                    Taux = 1000,
                    TotalRetenue = d313
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap31.TotalRetenue : 0;
                lignesRecap.Add(recap31);

                // ligne recap 32 DECEMP32
                var d323 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d321 = d323 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantCession);
                var recap32 = new LigneRecap
                {
                    Name = "DECEMP32",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "192",
                    TotalAssiette = d321,
                    Taux = 2500,
                    TotalRetenue = d323
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap32.TotalRetenue : 0;
                lignesRecap.Add(recap32);

                // ligne recap 33 DECEMP33
                var d333 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 &&
                                x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A425 >0)
                var d331 = d333 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 &&
                                x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                        .Sum(x => x.MontantServi);
                var recap33 = new LigneRecap
                {
                    Name = "DECEMP33",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "051",
                    TotalAssiette = d331,
                    Taux = 1500,
                    TotalRetenue = d333
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap33.TotalRetenue : 0;
                lignesRecap.Add(recap33);


                // ligne recap 34 DECEMP34
                var d343 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantParadisFiscaux > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A426 > 0)

                var d341 = d343 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantParadisFiscaux > 0)
                        .Sum(x => x.MontantParadisFiscaux);
                var recap34 = new LigneRecap
                {
                    Name = "DECEMP34",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "220",
                    TotalAssiette = d341,
                    Taux = 2500,
                    TotalRetenue = d343
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap34.TotalRetenue : 0;
                lignesRecap.Add(recap34);


                //// ligne recap 35 DECEMP35
                //var d343 = isDecAnnexeDeux
                //    ? annexeDeux.Lignes
                //        .Where(x => x.MontantBurtOperateurTelephonique > 0)
                //        .Sum(x => x.MontantRetenueOperee)
                //    : 0;//A223 (A2132 > 0)

                //var d341 = d343 == 0 ? 0 : annexeDeux.Lignes
                //            .Where(x => x.TypeMontantServiPersonne == TypeMontantServi.Commissions)
                //            .Sum(x => x.MontantBurtOperateurTelephonique);
                var recap35 = new LigneRecap
                {
                    Name = "DECEMP35",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "250",
                    TotalAssiette = 0,
                    Taux = 150,
                    TotalRetenue = 0
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap35.TotalRetenue : 0;
                lignesRecap.Add(recap35);

                // ligne recap 36 DECEMP36
                var d363 = isDecAnnexeSix
                    ? annexeSix.Lignes
                        .Where(x => x.MontantRevenusJeuPari > 0)
                        .Sum(x => x.MontantRetenuJeuPari)
                    : 0; //A223 (A2132 > 0)

                var d361 = d363 == 0
                    ? 0
                    : annexeSix.Lignes
                        .Where(x => x.MontantRevenusJeuPari > 0)
                        .Sum(x => x.MontantRevenusJeuPari);
                var recap36 = new LigneRecap
                {
                    Name = "DECEMP36",
                    Annexe = Annexe.Annexe6,
                    TypeEnregistrement = "280",
                    TotalAssiette = d361,
                    Taux = 2500,
                    TotalRetenue = d363
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap36.TotalRetenue : 0;
                lignesRecap.Add(recap36);

                // ligne recap 37 DECEMP37
                var d373 = isDecAnnexeSix
                    ? annexeSix.Lignes
                        .Where(x => x.MontantVenteNeDepassantVingt > 0)
                        .Sum(x => x.MontantRetenuNeDepassantVingt)
                    : 0; //A223 (A2132 > 0)

                var d371 = d373 == 0
                    ? 0
                    : annexeSix.Lignes
                        .Where(x => x.MontantVenteNeDepassantVingt > 0)
                        .Sum(x => x.MontantVenteNeDepassantVingt);
                var recap37 = new LigneRecap
                {
                    Name = "DECEMP37",
                    Annexe = Annexe.Annexe6,
                    TypeEnregistrement = "290",
                    TotalAssiette = d371,
                    Taux = 300,
                    TotalRetenue = d373
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap37.TotalRetenue : 0;
                lignesRecap.Add(recap37);



                // ligne 38 recap fin
                var piedRecap = new PiedRecap
                {
                    TypeEnregistrement = "999",
                    TotalGeneral = piedRecapTotalGeneral,
                };
                //////////////
                var annexeRecap = new AnnexeRecap
                {
                    Entete = recapEntete,
                    Lignes = lignesRecap,
                    Pied = piedRecap,
                    // Verification = lignesVerificator
                };
                return annexeRecap;
            }
            else if (_exercice.Annee == "2019" || _exercice.Annee == "2020")
            {
                /************2019********************/
          

                    // ligne recap 1 DECEMP01	010	D011	A117	0	D013	A121
                    var d013 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesRegimeCommun) : 0;
                    // 121 Where A121 > 0 
                    var d011 = !isDecAnnexeUn
                        ? 0
                        : annexeUn.Lignes//.Where(x => x.MontantRetenuesRegimeCommun > 0)
                            .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 Where A121 > 0 
                    var recap1 = new LigneRecap
                    {
                        Name = "DECEMP01",
                        Annexe = Annexe.Annexe1,
                        TypeEnregistrement = "010",
                        TotalAssiette = d011,
                        Taux = 0,
                        TotalRetenue = d013
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap1.TotalRetenue : 0;
                    lignesRecap.Add(recap1);

                    // ligne recap 2 DECEMP02	170	D021	A117	0	D023	A122
                    var d023 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesTauxVingt) : 0; //A122
                    var d021 = d023 == 0
                        ? 0
                        : annexeUn.Lignes.Where(y => y.MontantRetenuesTauxVingt > 0)
                            .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 (A122 > 0)
                    var recap2 = new LigneRecap
                    {
                        Name = "DECEMP02",
                        Annexe = Annexe.Annexe1,
                        TypeEnregistrement = "170",
                        TotalAssiette = d021,
                        Taux = 0,
                        TotalRetenue = d023
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap2.TotalRetenue : 0;
                    lignesRecap.Add(recap2);

                    // ligne recap 3 DECEMP03	
                    var d032 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.ContributionSocialeSolidarite) : 0;

                    var recap3 = new LigneRecap
                    {
                        Name = "DECEMP03",
                        Annexe = Annexe.Annexe1,
                        TypeEnregistrement = "300",
                        // TotalAssiette = d021,
                        Taux2018A1 = "",
                        TotalRetenue = d032
                    };

                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap3.TotalRetenue : 0;
                    lignesRecap.Add(recap3);


                    //ligne recap 4 DECEMP04                
                    var d043 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(
                                x =>
                                    x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                                    (int)x.TypeMontantServiPersonne <= 5)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A213 > 0)
                    var d041 = d043 == 0
                        ? 0
                        : annexeDeux.Lignes.Where(
                                x =>
                                    x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                                    (int)x.TypeMontantServiPersonne <= 5)
                            .Sum(x => x.MontantBurtHonoraires); //A213

                    var recap4 = new LigneRecap
                    {
                        Name = "DECEMP04",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "021",
                        TotalAssiette = d041,
                        Taux = 1500,
                        TotalRetenue = d043
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap4.TotalRetenue : 0;
                    lignesRecap.Add(recap4);

                    // ligne recap 5 DECEMP05	
                    var d053 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(
                                x =>
                                    x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                                    (int)x.TypeMontantServiActNonCommercial <= 1)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0;
                    var d051 = d053 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(
                                x =>
                                    x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                                    (int)x.TypeMontantServiActNonCommercial <= 1)
                            .Sum(x => x.MontantServi);

                    var recap5 = new LigneRecap
                    {
                        Name = "DECEMP05",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "023",
                        TotalAssiette = d051,
                        Taux = 1500,
                        TotalRetenue = d053
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap5.TotalRetenue : 0;
                    lignesRecap.Add(recap5);

                    // ligne recap 6 DECEMP06
                    var d063 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(
                                x =>
                                    (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                     x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                                    && x.MontantBrutHonorairesOperationExportation > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0;
                    var d061 = d063 == 0
                        ? 0
                        : annexeDeux.Lignes
                            .Where(
                                x =>
                                    x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                    x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                            .Sum(x => x.MontantBrutHonorairesOperationExportation); //A222 (PP)

                    var recap6 = new LigneRecap
                    {
                        Name = "DECEMP06",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "025",
                        TotalAssiette = d061,
                        Taux = 250,
                        TotalRetenue = d063
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap6.TotalRetenue : 0;
                    lignesRecap.Add(recap6);


                    // ligne recap 7 DECEMP07
                    var d073 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(x => x.HonorairesSociete > 0 || x.RemunerationsArtistes > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A219 > 0 & A214 > 0)

                    var d071 = d073 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.RemunerationsArtistes + x.HonorairesSociete);
                    // A214 + A219
                    var recap7 = new LigneRecap
                    {
                        Name = "DECEMP07",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "030",
                        TotalAssiette = d071,
                        Taux = 500,
                        TotalRetenue = d073
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap7.TotalRetenue : 0;
                    lignesRecap.Add(recap7);

                    // ligne recap 8 DECEMP08
                    var d083 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(x => x.HonorairesBureauEtude > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A220 > 0)

                    var d081 = d083 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.HonorairesBureauEtude); //A220
                    var recap8 = new LigneRecap
                    {
                        Name = "DECEMP08",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "180",
                        TotalAssiette = d081,
                        Taux = 250,
                        TotalRetenue = d083
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap8.TotalRetenue : 0;
                    lignesRecap.Add(recap8);

                    // ligne recap 9 DECEMP09
                    var d093 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(x => x.LoyersHotels > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A218 > 0)

                    var d091 = d093 == 0
                        ? 0
                        : annexeDeux.Lignes
                            .Sum(x => x.LoyersHotels); // 218

                    var recap9 = new LigneRecap
                    {
                        Name = "DECEMP09",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "040",
                        TotalAssiette = d091,
                        Taux = 500,
                        TotalRetenue = d093
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap9.TotalRetenue : 0;
                    lignesRecap.Add(recap9);


                    // ligne recap 10 DECEMP10	
                    var d0103 = isDecAnnexeDeux
                        ? annexeDeux.Lignes.Where(
                                y =>
                                    y.MontantBurtHonoraires > 0 &&
                                    y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; // A213 > 0 et A212 = 6
                    var d0101 = d0103 == 0
                        ? 0
                        : annexeDeux.Lignes.Where(
                                y =>
                                    y.MontantBurtHonoraires > 0 &&
                                    y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                            .Sum(x => x.MontantBurtHonoraires);
                    var recap10 = new LigneRecap
                    {
                        Name = "DECEMP10",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "260",
                        TotalAssiette = d0101,
                        Taux = 1500,
                        TotalRetenue = d0103
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap10.TotalRetenue : 0;
                    lignesRecap.Add(recap10);


                    // ligne recap 11 DECEMP11
                    var d113 = isDecAnnexeTrois
                        ? annexeTrois.Lignes.Where(y => y.CompteSpeciaux > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A315 (A312 > 0)
                    var d111 = d113 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.CompteSpeciaux);
                    var recap11 = new LigneRecap
                    {
                        Name = "DECEMP11",
                        Annexe = Annexe.Annexe3,
                        TypeEnregistrement = "060",
                        TotalAssiette = d111,
                        Taux = 2000,
                        TotalRetenue = d113
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap11.TotalRetenue : 0;
                    lignesRecap.Add(recap11);
                    // ligne recap 12 DECEMP12	
                    var d123 = isDecAnnexeTrois
                        ? annexeTrois.Lignes
                            .Where(x => (x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                         x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                                        && x.AutreCapitauxMobilier > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A315 (Résident & A313 >0)
                    var d121 = d123 == 0
                        ? 0
                        : annexeTrois.Lignes
                            .Where(x => x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                        x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                            .Sum(x => x.AutreCapitauxMobilier); //A313(Résident)
                    var recap12 = new LigneRecap
                    {
                        Name = "DECEMP12",
                        Annexe = Annexe.Annexe3,
                        TypeEnregistrement = "071",
                        TotalAssiette = d121,
                        Taux = 2000,
                        TotalRetenue = d123
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap12.TotalRetenue : 0;
                    lignesRecap.Add(recap12);


                    // ligne recap 13 DECEMP13
                    var d133 = isDecAnnexeTrois
                        ? annexeTrois.Lignes
                            .Where(x => (x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                         x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                                        && x.AutreCapitauxMobilier > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A315 (Non Résident & A313 >0)

                    var d131 = d133 == 0
                        ? 0
                        : annexeTrois.Lignes
                            .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                        x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                            .Sum(x => x.AutreCapitauxMobilier); // A313 (Non Résident)

                    var recap13 = new LigneRecap
                    {
                        Name = "DECEMP13",
                        Annexe = Annexe.Annexe3,
                        TypeEnregistrement = "073",
                        TotalAssiette = d131,
                        Taux = 2000,
                        TotalRetenue = d133
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap13.TotalRetenue : 0;
                    lignesRecap.Add(recap13);


                    // ligne recap 14 DECEMP14	
                    var d143 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantValeurMobiliere > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A4201 > 0)

                    var d141 = d143 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantValeurMobiliere); //A4201

                    var recap14 = new LigneRecap
                    {
                        Name = "DECEMP14",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "080",
                        TotalAssiette = d141,
                        Taux = 1500,
                        TotalRetenue = d143
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap14.TotalRetenue : 0;
                    lignesRecap.Add(recap14);



                    // ligne recap 15 DECEMP15
                    var d153 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(
                                x =>
                                    x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale &&
                                    x.ActionsPartSociale > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A2152 > 0 & PP)

                    var d151 = d153 == 0
                        ? 0
                        : annexeDeux.Lignes
                            .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                            .Sum(x => x.ActionsPartSociale); //A2152 (PP)

                    var recap15 = new LigneRecap
                    {
                        Name = "DECEMP15",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "241",
                        TotalAssiette = d151,
                        Taux = 1000,
                        TotalRetenue = d153
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap15.TotalRetenue : 0;
                    lignesRecap.Add(recap15);

                    // ligne recap 16 DECEMP16	
                    var d163 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes.Where(x => x.MontantActionsPartsSociales > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A4203 > 0)
                    var d161 = d163 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantActionsPartsSociales); //A4203
                    var recap16 = new LigneRecap
                    {
                        Name = "DECEMP16",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "242",
                        TotalAssiette = d161,
                        Taux = 1000,
                        TotalRetenue = d163
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap16.TotalRetenue : 0;
                    lignesRecap.Add(recap16);


                    // ligne recap 17 DECEMP17	
                    var d173 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A2151 >0)

                    var d171 = d173 == 0 ? 0 : annexeDeux.Lignes.Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0).Sum(x => x.ActionsPartSociale); //A2151

                    var recap17 = new LigneRecap
                    {
                        Name = "DECEMP17",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "091",
                        TotalAssiette = 0,
                        Taux = 2000,
                        TotalRetenue = 0
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap17.TotalRetenue : 0;
                    lignesRecap.Add(recap17);

                    //
                    // ligne recap 18 DECEMP18
                    var d183 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantJetonsPresence > 0).Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A4202 > 0)

                    var d181 = d183 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantJetonsPresence); //  A4202
                    var recap18 = new LigneRecap
                    {
                        Name = "DECEMP18",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "093",
                        TotalAssiette = d181,
                        Taux = 2000,
                        TotalRetenue = d183
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap18.TotalRetenue : 0;
                    lignesRecap.Add(recap18);

                    // ligne recap 19 DECEMP19
                    var d193 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(x => x.RemunerationsSalaries > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223 (A216 > 0)

                    var d191 = d193 == 0
                        ? 0
                        : annexeDeux.Lignes
                            .Sum(x => x.RemunerationsSalaries); //A216
                    var recap19 = new LigneRecap
                    {
                        Name = "DECEMP19",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "100",
                        TotalAssiette = d191,
                        Taux = 1500,
                        TotalRetenue = d193
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap19.TotalRetenue : 0;
                    lignesRecap.Add(recap19);

                    // ligne recap 20 : DECEMP20	
                    var d203 = isDecAnnexeTrois
                        ? annexeTrois.Lignes
                            .Where(x => x.PretEtabBancaire > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A315 (A314 > 0)

                    var d201 = d203 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.PretEtabBancaire); // A314
                    var recap20 = new LigneRecap
                    {
                        Name = "DECEMP20",
                        Annexe = Annexe.Annexe3,
                        TypeEnregistrement = "110",
                        TotalAssiette = d201,
                        Taux = 1000,
                        TotalRetenue = d203
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap20.TotalRetenue : 0;
                    lignesRecap.Add(recap20);

                    // ligne recap 21 DECEMP21
                    var A213 = isDecAnnexeDeux
                        ? annexeDeux.Lignes
                            .Where(
                                x => x.PrixImmeuble > 0 && (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                                            x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal))
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A223(A217 > 0 & Résident)

                    var A211 = A213 == 0
                        ? 0
                        : annexeDeux.Lignes
                            .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                        x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                            .Sum(x => x.PrixImmeuble); //A223 (Résident)

                    var recap21 = new LigneRecap
                    {
                        Name = "DECEMP21",
                        Annexe = Annexe.Annexe2,
                        TypeEnregistrement = "121",
                        TotalAssiette = A211,
                        Taux = 250,
                        TotalRetenue = A213
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap21.TotalRetenue : 0;
                    lignesRecap.Add(recap21);

                    // ligne recap 22 DECEMP22	
                    var d223 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantPlusValueImmobiliere > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0;
                    var d221 = d223 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(x => x.MontantPlusValueImmobiliere > 0)
                            .Sum(x => x.MontantPlusValueImmobiliere);

                    var recap22 = new LigneRecap
                    {
                        Name = "DECEMP22",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "122",
                        TotalAssiette = d221,
                        Taux = 250,
                        TotalRetenue = d223
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap22.TotalRetenue : 0;
                    lignesRecap.Add(recap22);

                    // ligne recap 23 DECEMP23
                    var d233 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(
                                x =>
                                    x.MontantPlusValueImmobiliere > 0 &&
                                    x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; // A423 (A418 > 0 & PM)

                    var d231 = d233 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(
                                x =>
                                    x.MontantPlusValueImmobiliere > 0 &&
                                    x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                            .Sum(x => x.MontantPlusValueImmobiliere); //A418(PM)

                    var recap23 = new LigneRecap
                    {
                        Name = "DECEMP23",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "123",
                        TotalAssiette = d231,
                        Taux = 1500,
                        TotalRetenue = d233
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap23.TotalRetenue : 0;
                    lignesRecap.Add(recap23);

                    // ligne recap 24 DECEMP24
                    var d243 = isDecAnnexeCinq
                        ? annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.RetenueOpExport)
                        : 0;
                    var d241 = d243 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.MontantOpExport);
                    var recap24 = new LigneRecap
                    {
                        Name = "DECEMP24",
                        Annexe = Annexe.Annexe5,
                        TypeEnregistrement = "131",
                        TotalAssiette = d241,
                        Taux = 50,
                        TotalRetenue = d243
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap24.TotalRetenue : 0;
                    lignesRecap.Add(recap24);

                    // ligne recap 25 : DECEMP25
                    var d253 = isDecAnnexeCinq
                        ? annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.RetenueAutreOp)
                        : 0;
                    var d251 = d253 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.MontantAutreOp);
                    var recap25 = new LigneRecap
                    {
                        Name = "DECEMP25",
                        Annexe = Annexe.Annexe5,
                        TypeEnregistrement = "132",
                        TotalAssiette = d251,
                        Taux = 150,
                        TotalRetenue = d253
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap25.TotalRetenue : 0;
                    lignesRecap.Add(recap25);

                    // ligne recap 26 DECEMP26
                    var d263 = isDecAnnexeCinq
                        ? annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.RetenueEtabPublic)
                        : 0;
                    var d261 = d263 == 0
                        ? 0
                        : annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.MontantEtabPublic);
                    var recap26 = new LigneRecap
                    {
                        Name = "DECEMP26",
                        Annexe = Annexe.Annexe5,
                        TypeEnregistrement = "140",
                        TotalAssiette = d261,
                        Taux = 2500,
                        TotalRetenue = d263
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap26.TotalRetenue : 0;
                    lignesRecap.Add(recap26);

                    // ligne recap 27 DECEMP27
                    var d273 = isDecAnnexeCinq
                        ? annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.RetenueEtabAlEtranger)
                        : 0;
                    var d271 = d273 == 0
                        ? 0
                        : annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.MontantEtabAlEtranger);
                    var recap27 = new LigneRecap
                    {
                        Name = "DECEMP27",
                        Annexe = Annexe.Annexe5,
                        TypeEnregistrement = "150",
                        TotalAssiette = d271,
                        Taux = 10000,
                        TotalRetenue = d273
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap27.TotalRetenue : 0;
                    lignesRecap.Add(recap27);

                    // ligne recap 28 DECEMP28
                    var d283 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantHonoraireNonResidente > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A416 > 0)

                    var d281 = d283 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(x => x.MontantHonoraireNonResidente > 0)
                            .Sum(x => x.MontantHonoraireNonResidente); //A416 

                    var recap28 = new LigneRecap
                    {
                        Name = "DECEMP28",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "160",
                        TotalAssiette = d281,
                        Taux = 0,
                        TotalRetenue = d283
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap28.TotalRetenue : 0;
                    lignesRecap.Add(recap28);


                    // ligne recap 29 DECEMP29
                    var d293 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where( x =>
                                x.MontantServi > 0 &&
                                (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1 || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A416 > 0)

                    var d291 = d293 == 0
                        ? 0
                        : annexeQuatre.Lignes
                             .Where(   x => x.MontantServi > 0 &&
                                (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1 || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                            .Sum(x => x.MontantServi); //A416 

                    var recap29 = new LigneRecap
                    {
                        Name = "DECEMP29",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "270",
                        TotalAssiette = d291,
                        Taux = 00000,
                        TotalRetenue = d293
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap29.TotalRetenue : 0;
                    lignesRecap.Add(recap29);


                    // ligne recap 30 DECEMP30	
                    var d303 = isDecAnnexeSix
                        ? annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                            .Sum(x => x.MontantAvances)
                        : 0;
                    var d301 = d303 == 0
                        ? 0
                        : annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                            .Sum(x => x.MontantVentes);
                    var recap30 = new LigneRecap
                    {
                        Name = "DECEMP30",
                        Annexe = Annexe.Annexe6,
                        TypeEnregistrement = "200",
                        TotalAssiette = d301,
                        Taux = 100,
                        TotalRetenue = d303
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap30.TotalRetenue : 0;
                    lignesRecap.Add(recap30);

                    // ligne recap 31 DECEMP31
                    var d313 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0;
                    var d311 = d313 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                            .Sum(x => x.MontantCession);
                    var recap31 = new LigneRecap
                    {
                        Name = "DECEMP31",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "191",
                        TotalAssiette = d311,
                        Taux = 1000,
                        TotalRetenue = d313
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap31.TotalRetenue : 0;
                    lignesRecap.Add(recap31);

                    // ligne recap 32 DECEMP32
                    var d323 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0;
                    var d321 = d323 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                            .Sum(x => x.MontantCession);
                    var recap32 = new LigneRecap
                    {
                        Name = "DECEMP32",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "192",
                        TotalAssiette = d321,
                        Taux = 2500,
                        TotalRetenue = d323
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap32.TotalRetenue : 0;
                    lignesRecap.Add(recap32);

                    // ligne recap 33 DECEMP33
                    var d333 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(
                                x =>
                                    x.MontantServi > 0 &&
                                    x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A425 >0)
                    var d331 = d333 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(
                                x =>
                                    x.MontantServi > 0 &&
                                    x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                            .Sum(x => x.MontantServi);
                    var recap33 = new LigneRecap
                    {
                        Name = "DECEMP33",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "051",
                        TotalAssiette = d331,
                        Taux = 1500,
                        TotalRetenue = d333
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap33.TotalRetenue : 0;
                    lignesRecap.Add(recap33);


                    // ligne recap 34 DECEMP34
                    var d343 = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes
                            .Where(x => x.MontantParadisFiscaux > 0)
                            .Sum(x => x.MontantRetenueOperee)
                        : 0; //A423 (A426 > 0)

                    var d341 = d343 == 0
                        ? 0
                        : annexeQuatre.Lignes
                            .Where(x => x.MontantParadisFiscaux > 0)
                            .Sum(x => x.MontantParadisFiscaux);
                    var recap34 = new LigneRecap
                    {
                        Name = "DECEMP34",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "220",
                        TotalAssiette = d341,
                        Taux = 2500,
                        TotalRetenue = d343
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap34.TotalRetenue : 0;
                    lignesRecap.Add(recap34);


                    //// ligne recap 35 DECEMP35
                    //var d343 = isDecAnnexeDeux
                    //    ? annexeDeux.Lignes
                    //        .Where(x => x.MontantBurtOperateurTelephonique > 0)
                    //        .Sum(x => x.MontantRetenueOperee)
                    //    : 0;//A223 (A2132 > 0)

                    //var d341 = d343 == 0 ? 0 : annexeDeux.Lignes
                    //            .Where(x => x.TypeMontantServiPersonne == TypeMontantServi.Commissions)
                    //            .Sum(x => x.MontantBurtOperateurTelephonique);
                    var recap35 = new LigneRecap
                    {
                        Name = "DECEMP35",
                        Annexe = Annexe.Annexe4,
                        TypeEnregistrement = "250",
                        TotalAssiette = 0,
                        Taux = 150,
                        TotalRetenue = 0
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap35.TotalRetenue : 0;
                    lignesRecap.Add(recap35);

                    // ligne recap 36 DECEMP36
                    var d363 = isDecAnnexeSix
                        ? annexeSix.Lignes
                            .Where(x => x.MontantRevenusJeuPari > 0)
                            .Sum(x => x.MontantRetenuJeuPari)
                        : 0; //A223 (A2132 > 0)

                    var d361 = d363 == 0
                        ? 0
                        : annexeSix.Lignes
                            .Where(x => x.MontantRevenusJeuPari > 0)
                            .Sum(x => x.MontantRevenusJeuPari);
                    var recap36 = new LigneRecap
                    {
                        Name = "DECEMP36",
                        Annexe = Annexe.Annexe6,
                        TypeEnregistrement = "280",
                        TotalAssiette = d361,
                        Taux = 2500,
                        TotalRetenue = d363
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap36.TotalRetenue : 0;
                    lignesRecap.Add(recap36);

                    // ligne recap 37 DECEMP37
                    var d373 = isDecAnnexeSix
                        ? annexeSix.Lignes
                            .Where(x => x.MontantVenteNeDepassantVingt > 0)
                            .Sum(x => x.MontantRetenuNeDepassantVingt)
                        : 0; //A223 (A2132 > 0)

                    var d371 = d373 == 0
                        ? 0
                        : annexeSix.Lignes
                            .Where(x => x.MontantVenteNeDepassantVingt > 0)
                            .Sum(x => x.MontantVenteNeDepassantVingt);
                    var recap37 = new LigneRecap
                    {
                        Name = "DECEMP37",
                        Annexe = Annexe.Annexe6,
                        TypeEnregistrement = "290",
                        TotalAssiette = d371,
                        Taux = 300,
                        TotalRetenue = d373
                    };
                    piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap37.TotalRetenue : 0;
                    lignesRecap.Add(recap37);



                    // ligne 38 recap fin
                    var piedRecap = new PiedRecap
                    {
                        TypeEnregistrement = "999",
                        TotalGeneral = piedRecapTotalGeneral,
                    };
                    //////////////
                    var annexeRecap = new AnnexeRecap
                    {
                        Entete = recapEntete,
                        Lignes = lignesRecap,
                        Pied = piedRecap,
                        // Verification = lignesVerificator
                    };
                    return annexeRecap;
                

                /************2019*********************/
            }
            else
            {

                // ligne recap 1 DECEMP01	010	D011	A117	0	D013	A121
                var d013 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesRegimeCommun) : 0;
                // 121 Where A121 > 0 
                var d011 = !isDecAnnexeUn
                    ? 0
                    : annexeUn.Lignes//.Where(x => x.MontantRetenuesRegimeCommun > 0)
                        .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 Where A121 > 0 
                var recap1 = new LigneRecap
                {
                    Name = "DECEMP01",
                    Annexe = Annexe.Annexe1,
                    TypeEnregistrement = "010",
                    TotalAssiette = d011,
                    Taux = 0,
                    TotalRetenue = d013
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap1.TotalRetenue : 0;
                lignesRecap.Add(recap1);

                // ligne recap 2 DECEMP02	170	D021	A117	0	D023	A122
                var d023 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesTauxVingt) : 0; //A122
                var d021 = d023 == 0
                    ? 0
                    : annexeUn.Lignes.Where(y => y.MontantRetenuesTauxVingt > 0)
                        .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 (A122 > 0)

                var recap2 = new LigneRecap
                {
                    Name = "DECEMP02",
                    Annexe = Annexe.Annexe1,
                    TypeEnregistrement = "170",
                    TotalAssiette = d021,
                    Taux = 0,
                    TotalRetenue = d023
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap2.TotalRetenue : 0;
                lignesRecap.Add(recap2);

                // ligne recap 3 DECEMP03	021	D031	A213	1500	D033	A223
                var d033 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x =>
                                x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                                (int)x.TypeMontantServiPersonne <= 5)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A213 > 0)
                var d031 = d033 == 0
                    ? 0
                    : annexeDeux.Lignes.Where(
                            x =>
                                x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                                (int)x.TypeMontantServiPersonne <= 5)
                        .Sum(x => x.MontantBurtHonoraires); //A213

                var recap3 = new LigneRecap
                {
                    Name = "DECEMP03",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "021",
                    TotalAssiette = d031,
                    Taux = 1500,
                    TotalRetenue = d033
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap3.TotalRetenue : 0;
                lignesRecap.Add(recap3);

                // ligne recap 4 DECEMP04	023	D041	A414	1500	D043	A423
                var d043 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                                (int)x.TypeMontantServiActNonCommercial <= 1)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d041 = d043 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                                (int)x.TypeMontantServiActNonCommercial <= 1)
                        .Sum(x => x.MontantServi);

                var recap4 = new LigneRecap
                {
                    Name = "DECEMP04",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "023",
                    TotalAssiette = d041,
                    Taux = 1500,
                    TotalRetenue = d043
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap4.TotalRetenue : 0;
                lignesRecap.Add(recap4);

                // ligne recap 5 DECEMP05	025	D051	A222	250	D053	A223
                var d053 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x =>
                                (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                 x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                                && x.MontantBrutHonorairesOperationExportation > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d051 = d053 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Where(
                            x =>
                                x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                        .Sum(x => x.MontantBrutHonorairesOperationExportation); //A222 (PP)

                var recap5 = new LigneRecap
                {
                    Name = "DECEMP05",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "025",
                    TotalAssiette = d051,
                    Taux = 250,
                    TotalRetenue = d053
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap5.TotalRetenue : 0;
                lignesRecap.Add(recap5);

                // ligne recap 6 DECEMP06	030	D061	A219+A214	500	D063	A223
                var d063 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.HonorairesSociete > 0 || x.RemunerationsArtistes > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A219 > 0 & A214 > 0)

                var d061 = d063 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.RemunerationsArtistes + x.HonorairesSociete);
                // A214 + A219
                var recap6 = new LigneRecap
                {
                    Name = "DECEMP06",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "030",
                    TotalAssiette = d061,
                    Taux = 500,
                    TotalRetenue = d063
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap6.TotalRetenue : 0;
                lignesRecap.Add(recap6);

                // ligne recap 7 DECEMP07	180	D071	A220	250	D073	A223
                var d073 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.HonorairesBureauEtude > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A220 > 0)

                var d071 = d073 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.HonorairesBureauEtude); //A220
                var recap7 = new LigneRecap
                {
                    Name = "DECEMP07",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "180",
                    TotalAssiette = d071,
                    Taux = 250,
                    TotalRetenue = d073
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap7.TotalRetenue : 0;
                lignesRecap.Add(recap7);

                // ligne recap 8 DECEMP08	040	D081	A218	500	D083	A223
                var d083 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.LoyersHotels > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A218 > 0)

                var d081 = d083 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Sum(x => x.LoyersHotels); // 218

                var recap8 = new LigneRecap
                {
                    Name = "DECEMP08",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "040",
                    TotalAssiette = d081,
                    Taux = 500,
                    TotalRetenue = d083
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap8.TotalRetenue : 0;
                lignesRecap.Add(recap8);


                // ligne recap 9 DECEMP10	060	D091	A312	2000	D093	A315
                var d093 = isDecAnnexeDeux
                    ? annexeDeux.Lignes.Where(
                            y =>
                                y.MontantBurtHonoraires > 0 &&
                                y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; // A213 > 0 et A212 = 6
                var d091 = d093 == 0
                    ? 0
                    : annexeDeux.Lignes.Where(
                            y =>
                                y.MontantBurtHonoraires > 0 &&
                                y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                        .Sum(x => x.MontantBurtHonoraires);
                var recap9 = new LigneRecap
                {
                    Name = "DECEMP09",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "260",
                    TotalAssiette = d091,
                    Taux = 1500,
                    TotalRetenue = d093
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap9.TotalRetenue : 0;
                lignesRecap.Add(recap9);


                // ligne recap 10 DECEMP10	060	D091	A312	2000	D093	A315
                var d103 = isDecAnnexeTrois
                    ? annexeTrois.Lignes.Where(y => y.CompteSpeciaux > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (A312 > 0)
                var d101 = d103 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.CompteSpeciaux);
                var recap10 = new LigneRecap
                {
                    Name = "DECEMP10",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "060",
                    TotalAssiette = d101,
                    Taux = 2000,
                    TotalRetenue = d103
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap10.TotalRetenue : 0;
                lignesRecap.Add(recap10);

                // ligne recap 11 DECEMP11	071	D111	A313	2000	D113	A315
                var d113 = isDecAnnexeTrois
                    ? annexeTrois.Lignes
                        .Where(x => (x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                     x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                                    && x.AutreCapitauxMobilier > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (Résident & A313 >0)
                var d111 = d113 == 0
                    ? 0
                    : annexeTrois.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                    x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                        .Sum(x => x.AutreCapitauxMobilier); //A313(Résident)
                var recap11 = new LigneRecap
                {
                    Name = "DECEMP11",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "071",
                    TotalAssiette = d111,
                    Taux = 2000,
                    TotalRetenue = d113
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap11.TotalRetenue : 0;
                lignesRecap.Add(recap11);

                // ligne recap 12 DECEMP12	073	D121	A414	2000	D123	A423
                var d123 = isDecAnnexeTrois
                    ? annexeTrois.Lignes
                        .Where(x => (x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                     x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                                    && x.AutreCapitauxMobilier > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (Non Résident & A313 >0)

                var d121 = d123 == 0
                    ? 0
                    : annexeTrois.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                    x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.AutreCapitauxMobilier); // A313 (Non Résident)

                var recap12 = new LigneRecap
                {
                    Name = "DECEMP12",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "073",
                    TotalAssiette = d121,
                    Taux = 2000,
                    TotalRetenue = d123
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap12.TotalRetenue : 0;
                lignesRecap.Add(recap12);
                // ligne recap 12 DECEMP13	080	D131	A420	1500	D133	A423
                var d133 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantValeurMobiliere > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A4201 > 0)

                var d131 = d133 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantValeurMobiliere); //A4201

                var recap13 = new LigneRecap
                {
                    Name = "DECEMP13",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "080",
                    TotalAssiette = d131,
                    Taux = 1500,
                    TotalRetenue = d133
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap13.TotalRetenue : 0;
                lignesRecap.Add(recap13);


                // ligne recap 14 DECEMP13	241	D131	A215	500	D133	A223
                var d143 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x =>
                                x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale &&
                                x.ActionsPartSociale > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A2152 > 0 & PP)

                var d141 = d143 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                        .Sum(x => x.ActionsPartSociale); //A2152 (PP)

                var recap14 = new LigneRecap
                {
                    Name = "DECEMP14",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "241",
                    TotalAssiette = d141,
                    Taux = 500,
                    TotalRetenue = d143
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap14.TotalRetenue : 0;
                lignesRecap.Add(recap14);

                // ligne recap 15 DECEMP15	242	D151	A420	500	D153	A423
                var d153 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes.Where(x => x.MontantActionsPartsSociales > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A4203 > 0)
                var d151 = d153 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantActionsPartsSociales); //A4203
                var recap15 = new LigneRecap
                {
                    Name = "DECEMP15",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "242",
                    TotalAssiette = d151,
                    Taux = 500,
                    TotalRetenue = d153
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap15.TotalRetenue : 0;
                lignesRecap.Add(recap15);

                // ligne recap 16 DECEMP16	091	D151	A215	2000	D153	A223
                var d163 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A2151 >0)

                var d161 = d163 == 0 ? 0 : annexeDeux.Lignes.Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0).Sum(x => x.ActionsPartSociale); //A2151

                var recap16 = new LigneRecap
                {
                    Name = "DECEMP16",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "091",
                    TotalAssiette = 0,
                    Taux = 2000,
                    TotalRetenue = 0
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap16.TotalRetenue : 0;
                lignesRecap.Add(recap16);

                // ligne recap 17 DECEMP17	093	D171	A420	2000	D173	A423
                var d173 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantJetonsPresence > 0).Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A4202 > 0)

                var d171 = d173 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantJetonsPresence); //  A4202
                var recap17 = new LigneRecap
                {
                    Name = "DECEMP17",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "093",
                    TotalAssiette = d171,
                    Taux = 2000,
                    TotalRetenue = d173
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap17.TotalRetenue : 0;
                lignesRecap.Add(recap17);

                // ligne recap 18 DECEMP18	100	D181	A216	1500	D183	A232
                var d183 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(x => x.RemunerationsSalaries > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223 (A216 > 0)

                var d181 = d183 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Sum(x => x.RemunerationsSalaries); //A216
                var recap18 = new LigneRecap
                {
                    Name = "DECEMP18",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "100",
                    TotalAssiette = d181,
                    Taux = 1500,
                    TotalRetenue = d183
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap18.TotalRetenue : 0;
                lignesRecap.Add(recap18);

                // ligne recap 19 : DECEMP19	110	D191	A314	500	D193	A315
                var d193 = isDecAnnexeTrois
                    ? annexeTrois.Lignes
                        .Where(x => x.PretEtabBancaire > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A315 (A314 > 0)

                var d191 = d193 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.PretEtabBancaire); // A314
                var recap19 = new LigneRecap
                {
                    Name = "DECEMP19",
                    Annexe = Annexe.Annexe3,
                    TypeEnregistrement = "110",
                    TotalAssiette = d191,
                    Taux = 500,
                    TotalRetenue = d193
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap19.TotalRetenue : 0;
                lignesRecap.Add(recap19);

                // ligne recap 20 DECEMP20	121	D201	A217	250	D203	A223
                var A203 = isDecAnnexeDeux
                    ? annexeDeux.Lignes
                        .Where(
                            x => x.PrixImmeuble > 0 && (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                                        x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal))
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A223(A217 > 0 & Résident)

                var A201 = A203 == 0
                    ? 0
                    : annexeDeux.Lignes
                        .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                    x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                        .Sum(x => x.PrixImmeuble); //A223 (Résident)

                var recap20 = new LigneRecap
                {
                    Name = "DECEMP20",
                    Annexe = Annexe.Annexe2,
                    TypeEnregistrement = "121",
                    TotalAssiette = A201,
                    Taux = 250,
                    TotalRetenue = A203
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap20.TotalRetenue : 0;
                lignesRecap.Add(recap20);

                // ligne recap 21 DECEMP21	122	D211	A418	250	D213	A423
                var d213 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantPlusValueImmobiliere > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d211 = d213 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantPlusValueImmobiliere > 0)
                        .Sum(x => x.MontantPlusValueImmobiliere);

                var recap21 = new LigneRecap
                {
                    Name = "DECEMP21",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "122",
                    TotalAssiette = d211,
                    Taux = 250,
                    TotalRetenue = d213
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap21.TotalRetenue : 0;
                lignesRecap.Add(recap21);

                // ligne recap 22 DECEMP22	123	D221	A418	1500	D223	A423
                var d223 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantPlusValueImmobiliere > 0 &&
                                x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; // A423 (A418 > 0 & PM)

                var d221 = d223 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantPlusValueImmobiliere > 0 &&
                                x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantPlusValueImmobiliere); //A418(PM)

                var recap22 = new LigneRecap
                {
                    Name = "DECEMP22",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "123",
                    TotalAssiette = d221,
                    Taux = 1500,
                    TotalRetenue = d223
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap22.TotalRetenue : 0;
                lignesRecap.Add(recap22);

                // ligne recap 23 DECEMP23	131	D221	A512	50	D223	A513
                var d233 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.RetenueOpExport)
                    : 0;
                var d231 = d233 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.MontantOpExport);
                var recap23 = new LigneRecap
                {
                    Name = "DECEMP23",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "131",
                    TotalAssiette = d231,
                    Taux = 50,
                    TotalRetenue = d233
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap23.TotalRetenue : 0;
                lignesRecap.Add(recap23);

                // ligne recap 24 : DECEMP24	132	D241	A514	150	D243	A515
                var d243 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.RetenueAutreOp)
                    : 0;
                var d241 = d243 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.MontantAutreOp);
                var recap24 = new LigneRecap
                {
                    Name = "DECEMP24",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "132",
                    TotalAssiette = d241,
                    Taux = 150,
                    TotalRetenue = d243
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap24.TotalRetenue : 0;
                lignesRecap.Add(recap24);

                // ligne recap 25 DECEMP25	140	D251	A516	5000	D253	A517
                var d253 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.RetenueEtabPublic)
                    : 0;
                var d251 = d253 == 0
                    ? 0
                    : annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.MontantEtabPublic);
                var recap25 = new LigneRecap
                {
                    Name = "DECEMP25",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "140",
                    TotalAssiette = d251,
                    Taux = 5000,
                    TotalRetenue = d253
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap25.TotalRetenue : 0;
                lignesRecap.Add(recap25);

                // ligne recap 26 DECEMP26	150	D261	A518	10000	D263	A519
                var d263 = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.RetenueEtabAlEtranger)
                    : 0;
                var d261 = d263 == 0
                    ? 0
                    : annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.MontantEtabAlEtranger);
                var recap26 = new LigneRecap
                {
                    Name = "DECEMP26",
                    Annexe = Annexe.Annexe5,
                    TypeEnregistrement = "150",
                    TotalAssiette = d261,
                    Taux = 10000,
                    TotalRetenue = d263
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap26.TotalRetenue : 0;
                lignesRecap.Add(recap26);

                // ligne recap 27 DECEMP27	160	D271	A416	0	D273	A423
                var d273 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantHonoraireNonResidente > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A416 > 0)

                var d271 = d273 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantHonoraireNonResidente > 0)
                        .Sum(x => x.MontantHonoraireNonResidente); //A416 

                var recap27 = new LigneRecap
                {
                    Name = "DECEMP27",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "160",
                    TotalAssiette = d271,
                    Taux = 0,
                    TotalRetenue = d273
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap27.TotalRetenue : 0;
                lignesRecap.Add(recap27);


                // ligne recap 28 DECEMP28	270	D281	A416	0	D273	A423
                var d283 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                         .Where( x =>
                                x.MontantServi > 0 &&
                                (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1 || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A416 > 0)

                var d281 = d283 == 0
                    ? 0
                    : annexeQuatre.Lignes
                         .Where(    x =>      x.MontantServi > 0 &&
                                (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1 || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                        .Sum(x => x.MontantServi); //A416 

                var recap28 = new LigneRecap
                {
                    Name = "DECEMP28",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "270",
                    TotalAssiette = d281,
                    Taux = 1500,
                    TotalRetenue = d283
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap28.TotalRetenue : 0;
                lignesRecap.Add(recap28);


                // ligne recap 29 DECEMP29	200	D291	A613	100	D293	A614
                var d293 = isDecAnnexeSix
                    ? annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                        .Sum(x => x.MontantAvances)
                    : 0;
                var d291 = d293 == 0
                    ? 0
                    : annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                        .Sum(x => x.MontantVentes);
                var recap29 = new LigneRecap
                {
                    Name = "DECEMP29",
                    Annexe = Annexe.Annexe6,
                    TypeEnregistrement = "200",
                    TotalAssiette = d291,
                    Taux = 100,
                    TotalRetenue = d293
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap29.TotalRetenue : 0;
                lignesRecap.Add(recap29);

                // ligne recap 30 DECEMP30	191	D301	A422	1000	D303	A423
                var d303 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d301 = d303 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                        .Sum(x => x.MontantCession);
                var recap30 = new LigneRecap
                {
                    Name = "DECEMP30",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "191",
                    TotalAssiette = d301,
                    Taux = 1000,
                    TotalRetenue = d303
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap30.TotalRetenue : 0;
                lignesRecap.Add(recap30);

                // ligne recap 31 DECEMP31	192	D311	A422	2500	D313	A423
                var d313 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0;
                var d311 = d313 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                        .Sum(x => x.MontantCession);
                var recap31 = new LigneRecap
                {
                    Name = "DECEMP31",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "192",
                    TotalAssiette = d311,
                    Taux = 2500,
                    TotalRetenue = d313
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap31.TotalRetenue : 0;
                lignesRecap.Add(recap31);

                // ligne recap 32 DECEMP32	051	D321	A425	1500	D323	A423
                var d323 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 &&
                                x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A425 >0)
                var d321 = d323 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(
                            x =>
                                x.MontantServi > 0 &&
                                x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                        .Sum(x => x.MontantServi);
                var recap32 = new LigneRecap
                {
                    Name = "DECEMP32",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "051",
                    TotalAssiette = d321,
                    Taux = 1500,
                    TotalRetenue = d323
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap32.TotalRetenue : 0;
                lignesRecap.Add(recap32);


                // ligne recap 32 DECEMP32	220	D321	A426	2500	D323	A423
                var d333 = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes
                        .Where(x => x.MontantParadisFiscaux > 0)
                        .Sum(x => x.MontantRetenueOperee)
                    : 0; //A423 (A426 > 0)

                var d331 = d333 == 0
                    ? 0
                    : annexeQuatre.Lignes
                        .Where(x => x.MontantParadisFiscaux > 0)
                        .Sum(x => x.MontantParadisFiscaux);
                var recap33 = new LigneRecap
                {
                    Name = "DECEMP33",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "220",
                    TotalAssiette = d331,
                    Taux = 2500,
                    TotalRetenue = d333
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap33.TotalRetenue : 0;
                lignesRecap.Add(recap33);


                //// ligne recap 34 DECEMP34	250	D341	A2132	1500	D343	A223
                //var d343 = isDecAnnexeDeux
                //    ? annexeDeux.Lignes
                //        .Where(x => x.MontantBurtOperateurTelephonique > 0)
                //        .Sum(x => x.MontantRetenueOperee)
                //    : 0;//A223 (A2132 > 0)

                //var d341 = d343 == 0 ? 0 : annexeDeux.Lignes
                //            .Where(x => x.TypeMontantServiPersonne == TypeMontantServi.Commissions)
                //            .Sum(x => x.MontantBurtOperateurTelephonique);
                var recap34 = new LigneRecap
                {
                    Name = "DECEMP34",
                    Annexe = Annexe.Annexe4,
                    TypeEnregistrement = "250",
                    TotalAssiette = 0,
                    Taux = 150,
                    TotalRetenue = 0
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap34.TotalRetenue : 0;
                lignesRecap.Add(recap34);

                // ligne recap 35 DECEMP35	250	D351	A2132	1500	D353	A223
                var d353 = isDecAnnexeSix
                    ? annexeSix.Lignes
                        .Where(x => x.MontantRevenusJeuPari > 0)
                        .Sum(x => x.MontantRetenuJeuPari)
                    : 0; //A223 (A2132 > 0)

                var d351 = d353 == 0
                    ? 0
                    : annexeSix.Lignes
                        .Where(x => x.MontantRevenusJeuPari > 0)
                        .Sum(x => x.MontantRevenusJeuPari);
                var recap35 = new LigneRecap
                {
                    Name = "DECEMP35",
                    Annexe = Annexe.Annexe6,
                    TypeEnregistrement = "280",
                    TotalAssiette = d351,
                    Taux = 2500,
                    TotalRetenue = d353
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap35.TotalRetenue : 0;
                lignesRecap.Add(recap35);

                // ligne recap 36 DECEMP36	250	D361	A2132	1500	D363	A223
                var d363 = isDecAnnexeSix
                    ? annexeSix.Lignes
                        .Where(x => x.MontantVenteNeDepassantVingt > 0)
                        .Sum(x => x.MontantRetenuNeDepassantVingt)
                    : 0; //A223 (A2132 > 0)

                var d361 = d363 == 0
                    ? 0
                    : annexeSix.Lignes
                        .Where(x => x.MontantVenteNeDepassantVingt > 0)
                        .Sum(x => x.MontantVenteNeDepassantVingt);
                var recap36 = new LigneRecap
                {
                    Name = "DECEMP36",
                    Annexe = Annexe.Annexe6,
                    TypeEnregistrement = "290",
                    TotalAssiette = d361,
                    Taux = 300,
                    TotalRetenue = d363
                };
                piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap36.TotalRetenue : 0;
                lignesRecap.Add(recap36);

                // ligne 37 recap fin
                var piedRecap = new PiedRecap
                {
                    TypeEnregistrement = "999",
                    TotalGeneral = piedRecapTotalGeneral,
                };


                /*                                                                                                  

                //###### Verification #######//
                // ligne 1 verificator
                var ligneAnnexeUnVerification = new AnnexeVerfication
                {
                    Annexe = Annexe.Annexe1,
                    IsDepose = isDecAnnexeUn,
                    SumAnnexe = isDecAnnexeUn
                        ? annexeUn.Lignes.Sum(x => x.MontantRetenuesRegimeCommun + x.MontantRetenuesTauxVingt)
                        : 0, // TODO
                    SumAnnexeRecap = isDecAnnexeUn
                        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe1).Sum(x => x.TotalRetenue) + d313A1
                        : 0
                };

                // ligne 2 verificator
                var ligneAnnexeDeuxVerification = new AnnexeVerfication
                {
                    Annexe = Annexe.Annexe2,
                    IsDepose = isDecAnnexeDeux,
                    SumAnnexe = isDecAnnexeDeux
                        ? annexeDeux.Lignes.Sum(x => x.MontantRetenueOperee + x.MontantBurtHonoraireOperateurTelephonique)
                        : 0,
                    SumAnnexeRecap = isDecAnnexeDeux
                        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe2).Sum(x => x.TotalRetenue) + d313A2
                        : 0
                };

                // ligne 3 verificator
                var ligneAnnexeTroisVerification = new AnnexeVerfication
                {
                    Annexe = Annexe.Annexe3,
                    IsDepose = isDecAnnexeTrois,
                    SumAnnexe = isDecAnnexeTrois
                        ? annexeTrois.Lignes.Sum(x => x.MontantRetenueOperee)
                        : 0,
                    SumAnnexeRecap = isDecAnnexeTrois
                        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe3).Sum(x => x.TotalRetenue) + d313A3
                        : 0
                };

                // ligne 4 verificator
                var ligneAnnexeQuatreVerification = new AnnexeVerfication
                {
                    Annexe = Annexe.Annexe4,
                    IsDepose = isDecAnnexeQuatre,
                    SumAnnexe = isDecAnnexeQuatre
                        ? annexeQuatre.Lignes.Sum(x => x.MontantRetenueOperee)
                        : 0,
                    SumAnnexeRecap = isDecAnnexeQuatre
                        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe4).Sum(x => x.TotalRetenue)
                        : 0
                };

                // ligne 5 verificator
                var ligneAnnexeCinqVerification = new AnnexeVerfication
                {
                    Annexe = Annexe.Annexe5,
                    IsDepose = isDecAnnexeCinq,
                    SumAnnexe = isDecAnnexeCinq
                        ? annexeCinq.Lignes.Sum(x =>
                            x.RetenueOpExport +
                            x.RetenueAutreOp +
                            x.RetenueEtabPublic +
                            x.RetenueEtabAlEtranger)
                        : 0,
                    SumAnnexeRecap = isDecAnnexeCinq
                        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe5 && x.Name != "DECEMP31").Sum(x => x.TotalRetenue) + d313A5
                        : 0
                };

                // ligne 6 verificator
                var ligneAnnexeSixVerification = new AnnexeVerfication
                {
                    Annexe = Annexe.Annexe6,
                    IsDepose = isDecAnnexeSix,
                    SumAnnexe = isDecAnnexeSix
                        ? annexeSix.Lignes.Sum(x => x.MontantAvances)
                        : 0,
                    SumAnnexeRecap = isDecAnnexeSix
                        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe6).Sum(x => x.TotalRetenue)
                        : 0
                };

                //// ligne 7 verificator
                //var ligneAnnexeSeptVerification = new AnnexeVerfication
                //{
                //    Annexe = Annexe.Annexe7,
                //    IsDepose = isDecAnnexeSept,
                //    SumAnnexe = isDecAnnexeSept
                //        ? annexeSept.Lignes.Sum(x => x.RetenueSource)
                //        : 0,
                //    SumAnnexeRecap = isDecAnnexeSept
                //        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe7).Sum(x => x.TotalRetenue)
                //        : 0
                //};

                var lignesVerificator = new List<AnnexeVerfication>();
                lignesVerificator.AddRange(new[]
                {
                    ligneAnnexeUnVerification,
                    ligneAnnexeDeuxVerification,
                    ligneAnnexeTroisVerification,
                    ligneAnnexeQuatreVerification,
                    ligneAnnexeCinqVerification,
                    ligneAnnexeSixVerification,
                    // ligneAnnexeSeptVerification
                });*/


                var annexeRecap = new AnnexeRecap
                {
                    Entete = recapEntete,
                    Lignes = lignesRecap,
                    Pied = piedRecap,
                    // Verification = lignesVerificator
                };
                return annexeRecap;
            }

            
        }

        public AnnexeRecap GetAnnexeRecap2018(
            bool isDecAnnexeUn,
            bool isDecAnnexeDeux,
            bool isDecAnnexeTrois,
            bool isDecAnnexeQuatre,
            bool isDecAnnexeCinq,
            bool isDecAnnexeSix,
            bool isDecAnnexeSept)
        {
            // get annexe 1
            var annexeUn = _annexeUnService.GetAnnexe();
            if (annexeUn == null) throw new ArgumentNullException(nameof(annexeUn));
            // get annexe 2
            var annexeDeux = _annexeDeuxService.GetAnnexe();
            if (annexeDeux == null) throw new ArgumentNullException(nameof(annexeDeux));
            // get annexe 3
            var annexeTrois = _annexeTroisService.GetAnnexe();
            if (annexeTrois == null) throw new ArgumentNullException(nameof(annexeTrois));
            // get annexe 4
            var annexeQuatre = _annexeQuatreService.GetAnnexe();
            if (annexeQuatre == null) throw new ArgumentNullException(nameof(annexeQuatre));
            // get annexe 5
            var annexeCinq = _annexeCinqService.GetAnnexe();
            if (annexeCinq == null) throw new ArgumentNullException(nameof(annexeCinq));
            // get annexe 6
            var annexeSix = _annexeSixService.GetAnnexe();
            if (annexeSix == null) throw new ArgumentNullException(nameof(annexeSix));
            //// get annexe 7
            //var annexeSept = _annexeSeptService.GetAnnexe();
            //if (annexeSept == null) throw new ArgumentNullException(nameof(annexeSept));

            var lignesRecap = new List<LigneRecap>();

            // total general ligne recap
            var piedRecapTotalGeneral = 0M;
            // recap entete
            var recapEntete = new EnteteRecap
            {
                TypeEnregistrement = "000",
                Exercice = _exercice.Annee,
                SocieteMatricule = int.Parse(_societe.MatriculFiscal),
                SocieteCle = _societe.MatriculCle,
                SocieteCategorie = _societe.MatriculCategorie,
                SocieteEtablissement = int.Parse(_societe.MatriculEtablissement),
                IsDecAnnexe1 = isDecAnnexeUn,
                IsDecAnnexe2 = isDecAnnexeDeux,
                IsDecAnnexe3 = isDecAnnexeTrois,
                IsDecAnnexe4 = isDecAnnexeQuatre,
                IsDecAnnexe5 = isDecAnnexeCinq,
                IsDecAnnexe6 = isDecAnnexeSix,
                IsDecAnnexe7 = isDecAnnexeSept
            };
            // ligne recap 1 DECEMP01	010	D011	A117	0	D013	A121
            var d013 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesRegimeCommun) : 0;
            // 121 Where A121 > 0 
            var d011 = !isDecAnnexeUn
                ? 0
                : annexeUn.Lignes//.Where(x => x.MontantRetenuesRegimeCommun > 0)
                    .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 Where A121 > 0 
            var recap1 = new LigneRecap
            {
                Name = "DECEMP01",
                Annexe = Annexe.Annexe1,
                TypeEnregistrement = "010",
                TotalAssiette = d011,
                Taux = 0,
                TotalRetenue = d013
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap1.TotalRetenue : 0;
            lignesRecap.Add(recap1);

            // ligne recap 2 DECEMP02	170	D021	A117	0	D023	A122
            var d023 = isDecAnnexeUn ? annexeUn.Lignes.Sum(x => x.MontantRetenuesTauxVingt) : 0; //A122
            var d021 = d023 == 0
                ? 0
                : annexeUn.Lignes.Where(y => y.MontantRetenuesTauxVingt > 0)
                    .Sum(x => x.RevenuBrutImposable);// d'apres karim A119 //A119-A120 (A122 > 0)

            var recap2 = new LigneRecap
            {
                Name = "DECEMP02",
                Annexe = Annexe.Annexe1,
                TypeEnregistrement = "170",
                TotalAssiette = d021,
                Taux = 0,
                TotalRetenue = d023
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe1 ? recap2.TotalRetenue : 0;
            lignesRecap.Add(recap2);

            // ligne recap 3 DECEMP03	021	D031	A213	1500	D033	A223
            var d033 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(
                        x =>
                            x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                            (int)x.TypeMontantServiPersonne <= 5)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A213 > 0)
            var d031 = d033 == 0
                ? 0
                : annexeDeux.Lignes.Where(
                        x =>
                            x.MontantBurtHonoraires > 0 && (int)x.TypeMontantServiPersonne >= 1 &&
                            (int)x.TypeMontantServiPersonne <= 5)
                    .Sum(x => x.MontantBurtHonoraires); //A213

            var recap3 = new LigneRecap
            {
                Name = "DECEMP03",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "021",
                TotalAssiette = d031,
                Taux = 1500,
                TotalRetenue = d033
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap3.TotalRetenue : 0;
            lignesRecap.Add(recap3);

            // ligne recap 4 DECEMP04	023	D041	A414	1500	D043	A423
            var d043 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                            (int)x.TypeMontantServiActNonCommercial <= 1)
                    .Sum(x => x.MontantRetenueOperee)
                : 0;
            var d041 = d043 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantServi > 0 && (int)x.TypeMontantServiActNonCommercial >= 1 &&
                            (int)x.TypeMontantServiActNonCommercial <= 1)
                    .Sum(x => x.MontantServi);

            var recap4 = new LigneRecap
            {
                Name = "DECEMP04",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "023",
                TotalAssiette = d041,
                Taux = 1500,
                TotalRetenue = d043
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap4.TotalRetenue : 0;
            lignesRecap.Add(recap4);

            // ligne recap 5 DECEMP05	025	D051	A222	250	D053	A223
            var d053 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(
                        x =>
                            (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                             x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                            && x.MontantBrutHonorairesOperationExportation > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0;
            var d051 = d053 == 0
                ? 0
                : annexeDeux.Lignes
                    .Where(
                        x =>
                            x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                            x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                    .Sum(x => x.MontantBrutHonorairesOperationExportation); //A222 (PP)

            var recap5 = new LigneRecap
            {
                Name = "DECEMP05",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "025",
                TotalAssiette = d051,
                Taux = 250,
                TotalRetenue = d053
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap5.TotalRetenue : 0;
            lignesRecap.Add(recap5);

            // ligne recap 6 DECEMP06	030	D061	A219+A214	500	D063	A223
            var d063 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(x => x.HonorairesSociete > 0 || x.RemunerationsArtistes > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A219 > 0 & A214 > 0)

            var d061 = d063 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.RemunerationsArtistes + x.HonorairesSociete);
            // A214 + A219
            var recap6 = new LigneRecap
            {
                Name = "DECEMP06",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "030",
                TotalAssiette = d061,
                Taux = 500,
                TotalRetenue = d063
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap6.TotalRetenue : 0;
            lignesRecap.Add(recap6);

            // ligne recap 7 DECEMP07	180	D071	A220	250	D073	A223
            var d073 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(x => x.HonorairesBureauEtude > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A220 > 0)

            var d071 = d073 == 0 ? 0 : annexeDeux.Lignes.Sum(x => x.HonorairesBureauEtude); //A220
            var recap7 = new LigneRecap
            {
                Name = "DECEMP07",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "180",
                TotalAssiette = d071,
                Taux = 250,
                TotalRetenue = d073
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap7.TotalRetenue : 0;
            lignesRecap.Add(recap7);

            // ligne recap 8 DECEMP08	040	D081	A218	500	D083	A223
            var d083 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(x => x.LoyersHotels > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A218 > 0)

            var d081 = d083 == 0
                ? 0
                : annexeDeux.Lignes
                    .Sum(x => x.LoyersHotels); // 218

            var recap8 = new LigneRecap
            {
                Name = "DECEMP08",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "040",
                TotalAssiette = d081,
                Taux = 500,
                TotalRetenue = d083
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap8.TotalRetenue : 0;
            lignesRecap.Add(recap8);


            // ligne recap 9 DECEMP10	060	D091	A312	2000	D093	A315
            var d093 = isDecAnnexeDeux
                ? annexeDeux.Lignes.Where(
                        y =>
                            y.MontantBurtHonoraires > 0 &&
                            y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; // A213 > 0 et A212 = 6
            var d091 = d093 == 0
                ? 0
                : annexeDeux.Lignes.Where(
                        y =>
                            y.MontantBurtHonoraires > 0 &&
                            y.TypeMontantServiPersonne == TypeMontantServiAnnexe2.PerformancePrestation)
                    .Sum(x => x.MontantBurtHonoraires);
            var recap9 = new LigneRecap
            {
                Name = "DECEMP09",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "260",
                TotalAssiette = d091,
                Taux = 1500,
                TotalRetenue = d093
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap9.TotalRetenue : 0;
            lignesRecap.Add(recap9);


            // ligne recap 10 DECEMP10	060	D091	A312	2000	D093	A315
            var d103 = isDecAnnexeTrois
                ? annexeTrois.Lignes.Where(y => y.CompteSpeciaux > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A315 (A312 > 0)
            var d101 = d103 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.CompteSpeciaux);
            var recap10 = new LigneRecap
            {
                Name = "DECEMP10",
                Annexe = Annexe.Annexe3,
                TypeEnregistrement = "060",
                TotalAssiette = d101,
                Taux = 2000,
                TotalRetenue = d103
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap10.TotalRetenue : 0;
            lignesRecap.Add(recap10);

            // ligne recap 11 DECEMP11	071	D111	A313	2000	D113	A315
            var d113 = isDecAnnexeTrois
                ? annexeTrois.Lignes
                    .Where(x => (x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                 x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                                && x.AutreCapitauxMobilier > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A315 (Résident & A313 >0)
            var d111 = d113 == 0
                ? 0
                : annexeTrois.Lignes
                    .Where(x => x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal ||
                                x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                    .Sum(x => x.AutreCapitauxMobilier); //A313(Résident)
            var recap11 = new LigneRecap
            {
                Name = "DECEMP11",
                Annexe = Annexe.Annexe3,
                TypeEnregistrement = "071",
                TotalAssiette = d111,
                Taux = 2000,
                TotalRetenue = d113
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap11.TotalRetenue : 0;
            lignesRecap.Add(recap11);

            // ligne recap 12 DECEMP12	073	D121	A414	2000	D123	A423
            var d123 = isDecAnnexeTrois
                ? annexeTrois.Lignes
                    .Where(x => (x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                 x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                                && x.AutreCapitauxMobilier > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A315 (Non Résident & A313 >0)

            var d121 = d123 == 0
                ? 0
                : annexeTrois.Lignes
                    .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteSejour ||
                                x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                    .Sum(x => x.AutreCapitauxMobilier); // A313 (Non Résident)

            var recap12 = new LigneRecap
            {
                Name = "DECEMP12",
                Annexe = Annexe.Annexe3,
                TypeEnregistrement = "073",
                TotalAssiette = d121,
                Taux = 2000,
                TotalRetenue = d123
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap12.TotalRetenue : 0;
            lignesRecap.Add(recap12);
            // ligne recap 12 DECEMP13	080	D131	A420	1500	D133	A423
            var d133 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantValeurMobiliere > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A4201 > 0)

            var d131 = d133 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantValeurMobiliere); //A4201

            var recap13 = new LigneRecap
            {
                Name = "DECEMP13",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "080",
                TotalAssiette = d131,
                Taux = 1500,
                TotalRetenue = d133
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap13.TotalRetenue : 0;
            lignesRecap.Add(recap13);


            // ligne recap 14 DECEMP13	241	D131	A215	500	D133	A223
            var d143 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(
                        x =>
                            x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale &&
                            x.ActionsPartSociale > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A2152 > 0 & PP)

            var d141 = d143 == 0
                ? 0
                : annexeDeux.Lignes
                    .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale)
                    .Sum(x => x.ActionsPartSociale); //A2152 (PP)

            var recap14 = new LigneRecap
            {
                Name = "DECEMP14",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "241",
                TotalAssiette = d141,
                Taux = 500,
                TotalRetenue = d143
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap14.TotalRetenue : 0;
            lignesRecap.Add(recap14);

            // ligne recap 15 DECEMP15	242	D151	A420	500	D153	A423
            var d153 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes.Where(x => x.MontantActionsPartsSociales > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A4203 > 0)
            var d151 = d153 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantActionsPartsSociales); //A4203
            var recap15 = new LigneRecap
            {
                Name = "DECEMP15",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "242",
                TotalAssiette = d151,
                Taux = 500,
                TotalRetenue = d153
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap15.TotalRetenue : 0;
            lignesRecap.Add(recap15);

            // ligne recap 16 DECEMP16	091	D151	A215	2000	D153	A223
            var d163 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A2151 >0)

            var d161 = d163 == 0 ? 0 : annexeDeux.Lignes.Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale && x.ActionsPartSociale > 0).Sum(x => x.ActionsPartSociale); //A2151

            var recap16 = new LigneRecap
            {
                Name = "DECEMP16",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "091",
                TotalAssiette = 0,
                Taux = 2000,
                TotalRetenue = 0
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap16.TotalRetenue : 0;
            lignesRecap.Add(recap16);

            // ligne recap 17 DECEMP17	093	D171	A420	2000	D173	A423
            var d173 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantJetonsPresence > 0).Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A4202 > 0)

            var d171 = d173 == 0 ? 0 : annexeQuatre.Lignes.Sum(x => x.MontantJetonsPresence); //  A4202
            var recap17 = new LigneRecap
            {
                Name = "DECEMP17",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "093",
                TotalAssiette = d171,
                Taux = 2000,
                TotalRetenue = d173
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap17.TotalRetenue : 0;
            lignesRecap.Add(recap17);

            // ligne recap 18 DECEMP18	100	D181	A216	1500	D183	A232
            var d183 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(x => x.RemunerationsSalaries > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223 (A216 > 0)

            var d181 = d183 == 0
                ? 0
                : annexeDeux.Lignes
                    .Sum(x => x.RemunerationsSalaries); //A216
            var recap18 = new LigneRecap
            {
                Name = "DECEMP18",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "100",
                TotalAssiette = d181,
                Taux = 1500,
                TotalRetenue = d183
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap18.TotalRetenue : 0;
            lignesRecap.Add(recap18);

            // ligne recap 19 : DECEMP19	110	D191	A314	500	D193	A315
            var d193 = isDecAnnexeTrois
                ? annexeTrois.Lignes
                    .Where(x => x.PretEtabBancaire > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A315 (A314 > 0)

            var d191 = d193 == 0 ? 0 : annexeTrois.Lignes.Sum(x => x.PretEtabBancaire); // A314
            var recap19 = new LigneRecap
            {
                Name = "DECEMP19",
                Annexe = Annexe.Annexe3,
                TypeEnregistrement = "110",
                TotalAssiette = d191,
                Taux = 500,
                TotalRetenue = d193
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe3 ? recap19.TotalRetenue : 0;
            lignesRecap.Add(recap19);

            // ligne recap 20 DECEMP20	121	D201	A217	250	D203	A223
            var A203 = isDecAnnexeDeux
                ? annexeDeux.Lignes
                    .Where(
                        x => x.PrixImmeuble > 0 && (x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                                    x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal))
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A223(A217 > 0 & Résident)

            var A201 = A203 == 0
                ? 0
                : annexeDeux.Lignes
                    .Where(x => x.BeneficiaireType == TypeBeneficiaire.CarteIdentidiantNationale ||
                                x.BeneficiaireType == TypeBeneficiaire.MatriculeFiscal)
                    .Sum(x => x.PrixImmeuble); //A223 (Résident)

            var recap20 = new LigneRecap
            {
                Name = "DECEMP20",
                Annexe = Annexe.Annexe2,
                TypeEnregistrement = "121",
                TotalAssiette = A201,
                Taux = 250,
                TotalRetenue = A203
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap20.TotalRetenue : 0;
            lignesRecap.Add(recap20);

            // ligne recap 21 DECEMP21	122	D211	A418	250	D213	A423
            var d213 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantPlusValueImmobiliere > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0;
            var d211 = d213 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(x => x.MontantPlusValueImmobiliere > 0)
                    .Sum(x => x.MontantPlusValueImmobiliere);

            var recap21 = new LigneRecap
            {
                Name = "DECEMP21",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "122",
                TotalAssiette = d211,
                Taux = 250,
                TotalRetenue = d213
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap21.TotalRetenue : 0;
            lignesRecap.Add(recap21);

            // ligne recap 22 DECEMP22	123	D221	A418	1500	D223	A423
            var d223 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantPlusValueImmobiliere > 0 &&
                            x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; // A423 (A418 > 0 & PM)

            var d221 = d223 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantPlusValueImmobiliere > 0 &&
                            x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                    .Sum(x => x.MontantPlusValueImmobiliere); //A418(PM)

            var recap22 = new LigneRecap
            {
                Name = "DECEMP22",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "123",
                TotalAssiette = d221,
                Taux = 1500,
                TotalRetenue = d223
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap22.TotalRetenue : 0;
            lignesRecap.Add(recap22);

            // ligne recap 23 DECEMP23	131	D221	A512	50	D223	A513
            var d233 = isDecAnnexeCinq
                ? annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.RetenueOpExport)
                : 0;
            var d231 = d233 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantOpExport > 0).Sum(x => x.MontantOpExport);
            var recap23 = new LigneRecap
            {
                Name = "DECEMP23",
                Annexe = Annexe.Annexe5,
                TypeEnregistrement = "131",
                TotalAssiette = d231,
                Taux = 50,
                TotalRetenue = d233
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap23.TotalRetenue : 0;
            lignesRecap.Add(recap23);

            // ligne recap 24 : DECEMP24	132	D241	A514	150	D243	A515
            var d243 = isDecAnnexeCinq
                ? annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.RetenueAutreOp)
                : 0;
            var d241 = d243 == 0 ? 0 : annexeCinq.Lignes.Where(x => x.MontantAutreOp > 0).Sum(x => x.MontantAutreOp);
            var recap24 = new LigneRecap
            {
                Name = "DECEMP24",
                Annexe = Annexe.Annexe5,
                TypeEnregistrement = "132",
                TotalAssiette = d241,
                Taux = 150,
                TotalRetenue = d243
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap24.TotalRetenue : 0;
            lignesRecap.Add(recap24);

            // ligne recap 25 DECEMP25	140	D251	A516	5000	D253	A517
            var d253 = isDecAnnexeCinq
                ? annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.RetenueEtabPublic)
                : 0;
            var d251 = d253 == 0
                ? 0
                : annexeCinq.Lignes.Where(x => x.MontantEtabPublic > 0).Sum(x => x.MontantEtabPublic);
            var recap25 = new LigneRecap
            {
                Name = "DECEMP25",
                Annexe = Annexe.Annexe5,
                TypeEnregistrement = "140",
                TotalAssiette = d251,
                Taux = 5000,
                TotalRetenue = d253
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap25.TotalRetenue : 0;
            lignesRecap.Add(recap25);

            // ligne recap 26 DECEMP26	150	D261	A518	10000	D263	A519
            var d263 = isDecAnnexeCinq
                ? annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.RetenueEtabAlEtranger)
                : 0;
            var d261 = d263 == 0
                ? 0
                : annexeCinq.Lignes.Where(x => x.MontantEtabAlEtranger > 0).Sum(x => x.MontantEtabAlEtranger);
            var recap26 = new LigneRecap
            {
                Name = "DECEMP26",
                Annexe = Annexe.Annexe5,
                TypeEnregistrement = "150",
                TotalAssiette = d261,
                Taux = 10000,
                TotalRetenue = d263
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe5 ? recap26.TotalRetenue : 0;
            lignesRecap.Add(recap26);

            // ligne recap 27 DECEMP27	160	D271	A416	0	D273	A423
            var d273 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantHonoraireNonResidente > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A416 > 0)

            var d271 = d273 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(x => x.MontantHonoraireNonResidente > 0)
                    .Sum(x => x.MontantHonoraireNonResidente); //A416 

            var recap27 = new LigneRecap
            {
                Name = "DECEMP27",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "160",
                TotalAssiette = d271,
                Taux = 0,
                TotalRetenue = d273
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap27.TotalRetenue : 0;
            lignesRecap.Add(recap27);


            // ligne recap 28 DECEMP28	270	D281	A416	0	D273	A423
            var d283 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantServi > 0 &&
                            (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1))
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A416 > 0)

            var d281 = d283 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantServi > 0 &&
                            (x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidents1 || x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.NonResidentsterritoireregime))
                    .Sum(x => x.MontantServi); //A416 

            var recap28 = new LigneRecap
            {
                Name = "DECEMP28",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "270",
                TotalAssiette = d281,
                Taux = 1500,
                TotalRetenue = d283
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap28.TotalRetenue : 0;
            lignesRecap.Add(recap28);


            // ligne recap 29 DECEMP29	200	D291	A613	100	D293	A614
            var d293 = isDecAnnexeSix
                ? annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                    .Sum(x => x.MontantAvances)
                : 0;
            var d291 = d293 == 0
                ? 0
                : annexeSix.Lignes.Where(x => x.MontantVentes > 0)
                    .Sum(x => x.MontantVentes);
            var recap29 = new LigneRecap
            {
                Name = "DECEMP29",
                Annexe = Annexe.Annexe6,
                TypeEnregistrement = "200",
                TotalAssiette = d291,
                Taux = 100,
                TotalRetenue = d293
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap29.TotalRetenue : 0;
            lignesRecap.Add(recap29);

            // ligne recap 30 DECEMP30	191	D301	A422	1000	D303	A423
            var d303 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                    .Sum(x => x.MontantRetenueOperee)
                : 0;
            var d301 = d303 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.CarteSejour)
                    .Sum(x => x.MontantCession);
            var recap30 = new LigneRecap
            {
                Name = "DECEMP30",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "191",
                TotalAssiette = d301,
                Taux = 1000,
                TotalRetenue = d303
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap30.TotalRetenue : 0;
            lignesRecap.Add(recap30);

            // ligne recap 31 DECEMP31	192	D311	A422	2500	D313	A423
            var d313 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                    .Sum(x => x.MontantRetenueOperee)
                : 0;
            var d311 = d313 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(x => x.MontantCession > 0 && x.BeneficiaireType == TypeBeneficiaire.IdentNonDomiciliee)
                    .Sum(x => x.MontantCession);
            var recap31 = new LigneRecap
            {
                Name = "DECEMP31",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "192",
                TotalAssiette = d311,
                Taux = 2500,
                TotalRetenue = d313
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap31.TotalRetenue : 0;
            lignesRecap.Add(recap31);

            // ligne recap 32 DECEMP32	051	D321	A425	1500	D323	A423
            var d323 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantServi > 0 &&
                            x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A425 >0)
            var d321 = d323 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(
                        x =>
                            x.MontantServi > 0 &&
                            x.TypeMontantServiActNonCommercial == TypeMontantServiAnnexe4.AutresRevenus)
                    .Sum(x => x.MontantServi);
            var recap32 = new LigneRecap
            {
                Name = "DECEMP32",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "051",
                TotalAssiette = d321,
                Taux = 1500,
                TotalRetenue = d323
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap32.TotalRetenue : 0;
            lignesRecap.Add(recap32);


            // ligne recap 32 DECEMP32	220	D321	A426	2500	D323	A423
            var d333 = isDecAnnexeQuatre
                ? annexeQuatre.Lignes
                    .Where(x => x.MontantParadisFiscaux > 0)
                    .Sum(x => x.MontantRetenueOperee)
                : 0; //A423 (A426 > 0)

            var d331 = d333 == 0
                ? 0
                : annexeQuatre.Lignes
                    .Where(x => x.MontantParadisFiscaux > 0)
                    .Sum(x => x.MontantParadisFiscaux);
            var recap33 = new LigneRecap
            {
                Name = "DECEMP33",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "220",
                TotalAssiette = d331,
                Taux = 2500,
                TotalRetenue = d333
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe4 ? recap33.TotalRetenue : 0;
            lignesRecap.Add(recap33);


            //// ligne recap 34 DECEMP34	250	D341	A2132	1500	D343	A223
            //var d343 = isDecAnnexeDeux
            //    ? annexeDeux.Lignes
            //        .Where(x => x.MontantBurtOperateurTelephonique > 0)
            //        .Sum(x => x.MontantRetenueOperee)
            //    : 0;//A223 (A2132 > 0)

            //var d341 = d343 == 0 ? 0 : annexeDeux.Lignes
            //            .Where(x => x.TypeMontantServiPersonne == TypeMontantServi.Commissions)
            //            .Sum(x => x.MontantBurtOperateurTelephonique);
            var recap34 = new LigneRecap
            {
                Name = "DECEMP34",
                Annexe = Annexe.Annexe4,
                TypeEnregistrement = "250",
                TotalAssiette = 0,
                Taux = 150,
                TotalRetenue = 0
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe2 ? recap34.TotalRetenue : 0;
            lignesRecap.Add(recap34);

            // ligne recap 35 DECEMP35	250	D351	A2132	1500	D353	A223
            var d353 = isDecAnnexeSix
                ? annexeSix.Lignes
                    .Where(x => x.MontantRevenusJeuPari > 0)
                    .Sum(x => x.MontantRetenuJeuPari)
                : 0; //A223 (A2132 > 0)

            var d351 = d353 == 0
                ? 0
                : annexeSix.Lignes
                    .Where(x => x.MontantRevenusJeuPari > 0)
                    .Sum(x => x.MontantRevenusJeuPari);
            var recap35 = new LigneRecap
            {
                Name = "DECEMP35",
                Annexe = Annexe.Annexe6,
                TypeEnregistrement = "280",
                TotalAssiette = d351,
                Taux = 2500,
                TotalRetenue = d353
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap35.TotalRetenue : 0;
            lignesRecap.Add(recap35);

            // ligne recap 36 DECEMP36	250	D361	A2132	1500	D363	A223
            var d363 = isDecAnnexeSix
                ? annexeSix.Lignes
                    .Where(x => x.MontantVenteNeDepassantVingt > 0)
                    .Sum(x => x.MontantRetenuNeDepassantVingt)
                : 0; //A223 (A2132 > 0)

            var d361 = d363 == 0
                ? 0
                : annexeSix.Lignes
                    .Where(x => x.MontantVenteNeDepassantVingt > 0)
                    .Sum(x => x.MontantVenteNeDepassantVingt);
            var recap36 = new LigneRecap
            {
                Name = "DECEMP36",
                Annexe = Annexe.Annexe6,
                TypeEnregistrement = "290",
                TotalAssiette = d361,
                Taux = 300,
                TotalRetenue = d363
            };
            piedRecapTotalGeneral += recapEntete.IsDecAnnexe6 ? recap36.TotalRetenue : 0;
            lignesRecap.Add(recap36);

            // ligne 37 recap fin
            var piedRecap = new PiedRecap
            {
                TypeEnregistrement = "999",
                TotalGeneral = piedRecapTotalGeneral,
            };


            /*                                                                                                  

            //###### Verification #######//
            // ligne 1 verificator
            var ligneAnnexeUnVerification = new AnnexeVerfication
            {
                Annexe = Annexe.Annexe1,
                IsDepose = isDecAnnexeUn,
                SumAnnexe = isDecAnnexeUn
                    ? annexeUn.Lignes.Sum(x => x.MontantRetenuesRegimeCommun + x.MontantRetenuesTauxVingt)
                    : 0, // TODO
                SumAnnexeRecap = isDecAnnexeUn
                    ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe1).Sum(x => x.TotalRetenue) + d313A1
                    : 0
            };

            // ligne 2 verificator
            var ligneAnnexeDeuxVerification = new AnnexeVerfication
            {
                Annexe = Annexe.Annexe2,
                IsDepose = isDecAnnexeDeux,
                SumAnnexe = isDecAnnexeDeux
                    ? annexeDeux.Lignes.Sum(x => x.MontantRetenueOperee + x.MontantBurtHonoraireOperateurTelephonique)
                    : 0,
                SumAnnexeRecap = isDecAnnexeDeux
                    ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe2).Sum(x => x.TotalRetenue) + d313A2
                    : 0
            };

            // ligne 3 verificator
            var ligneAnnexeTroisVerification = new AnnexeVerfication
            {
                Annexe = Annexe.Annexe3,
                IsDepose = isDecAnnexeTrois,
                SumAnnexe = isDecAnnexeTrois
                    ? annexeTrois.Lignes.Sum(x => x.MontantRetenueOperee)
                    : 0,
                SumAnnexeRecap = isDecAnnexeTrois
                    ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe3).Sum(x => x.TotalRetenue) + d313A3
                    : 0
            };

            // ligne 4 verificator
            var ligneAnnexeQuatreVerification = new AnnexeVerfication
            {
                Annexe = Annexe.Annexe4,
                IsDepose = isDecAnnexeQuatre,
                SumAnnexe = isDecAnnexeQuatre
                    ? annexeQuatre.Lignes.Sum(x => x.MontantRetenueOperee)
                    : 0,
                SumAnnexeRecap = isDecAnnexeQuatre
                    ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe4).Sum(x => x.TotalRetenue)
                    : 0
            };

            // ligne 5 verificator
            var ligneAnnexeCinqVerification = new AnnexeVerfication
            {
                Annexe = Annexe.Annexe5,
                IsDepose = isDecAnnexeCinq,
                SumAnnexe = isDecAnnexeCinq
                    ? annexeCinq.Lignes.Sum(x =>
                        x.RetenueOpExport +
                        x.RetenueAutreOp +
                        x.RetenueEtabPublic +
                        x.RetenueEtabAlEtranger)
                    : 0,
                SumAnnexeRecap = isDecAnnexeCinq
                    ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe5 && x.Name != "DECEMP31").Sum(x => x.TotalRetenue) + d313A5
                    : 0
            };

            // ligne 6 verificator
            var ligneAnnexeSixVerification = new AnnexeVerfication
            {
                Annexe = Annexe.Annexe6,
                IsDepose = isDecAnnexeSix,
                SumAnnexe = isDecAnnexeSix
                    ? annexeSix.Lignes.Sum(x => x.MontantAvances)
                    : 0,
                SumAnnexeRecap = isDecAnnexeSix
                    ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe6).Sum(x => x.TotalRetenue)
                    : 0
            };

            //// ligne 7 verificator
            //var ligneAnnexeSeptVerification = new AnnexeVerfication
            //{
            //    Annexe = Annexe.Annexe7,
            //    IsDepose = isDecAnnexeSept,
            //    SumAnnexe = isDecAnnexeSept
            //        ? annexeSept.Lignes.Sum(x => x.RetenueSource)
            //        : 0,
            //    SumAnnexeRecap = isDecAnnexeSept
            //        ? lignesRecap.Where(x => x.Annexe == Annexe.Annexe7).Sum(x => x.TotalRetenue)
            //        : 0
            //};

            var lignesVerificator = new List<AnnexeVerfication>();
            lignesVerificator.AddRange(new[]
            {
                ligneAnnexeUnVerification,
                ligneAnnexeDeuxVerification,
                ligneAnnexeTroisVerification,
                ligneAnnexeQuatreVerification,
                ligneAnnexeCinqVerification,
                ligneAnnexeSixVerification,
                // ligneAnnexeSeptVerification
            });*/
            var annexeRecap = new AnnexeRecap
            {
                Entete = recapEntete,
                Lignes = lignesRecap,
                Pied = piedRecap,
                // Verification = lignesVerificator
            };

            return annexeRecap;
        }

        public void Exporter(
            bool isDecAnnexeUn,
            bool isDecAnnexeDeux,
            bool isDecAnnexeTrois,
            bool isDecAnnexeQuatre,
            bool isDecAnnexeCinq,
            bool isDecannexeSix,
            bool isDecAnnexeSept,
            string directory)
        {
            // get annexe recap


            var annexe = GetAnnexeRecap(
                isDecAnnexeUn,
                isDecAnnexeDeux,
                isDecAnnexeTrois,
                isDecAnnexeQuatre,
                isDecAnnexeCinq,
                isDecannexeSix,
                isDecAnnexeSept);
            // entete
            var str = new StringBuilder();
            str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementRecapText(annexe.Entete));
            // lignes
            foreach (var ligne in annexe.Lignes)
            {
                if(_exercice.Annee=="2018" && ligne.Name=="DECEMP03")
                {
                    string lig = AnnexeEnregistementHelper.GetEnregistrementRecapText(ligne);
                    string total = lig.Substring(23, 15);
                    string newline = lig.Substring(0, 3) + string.Empty.PadRight(20, ' ') +total;
                    str.AppendLine(newline);
                    continue;
                }
                if ((_exercice.Annee == "2019" && ligne.Name == "DECEMP03") || (_exercice.Annee == "2020" && ligne.Name == "DECEMP03"))
                {
                    string lig = AnnexeEnregistementHelper.GetEnregistrementRecapText(ligne);
                    string total = lig.Substring(23, 15);
                    string newline = lig.Substring(0, 3) + string.Empty.PadRight(20, ' ') + total;
                    str.AppendLine(newline);
                    continue;
                }
                str.AppendLine(AnnexeEnregistementHelper.GetEnregistrementRecapText(ligne));
                
            }
            // pied
            str.Append(AnnexeEnregistementHelper.GetEnregistrementRecapText(annexe.Pied));
            // exporter fichier
            _exportRepostiory.Write(str.ToString(), string.Format(FileName, _exercice.Annee[2], _exercice.Annee[3]),
                directory);
        }
    }
}