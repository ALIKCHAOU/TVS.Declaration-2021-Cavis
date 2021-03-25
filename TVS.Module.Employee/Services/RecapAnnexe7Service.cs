using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core.Models;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Enums;

namespace TVS.Module.Employee.Services
{
    public class RecapAnnexe7Service
    {
        private readonly Societe _societe;
        private readonly Exercice _exercice;
        private readonly Annexe1Service _annexeUnService;
        private readonly Annexe2Service _annexeDeuxService;
        private readonly Annexe3Service _annexeTroisService;
        private readonly Annexe4Service _annexeQuatreService;
        private readonly Annexe5Service _annexeCinqService;
        private readonly Annexe6Service _annexeSixService;


        public RecapAnnexe7Service(
            Societe societe,
            Exercice exercice,
            Annexe1Service annexeUnService,
            Annexe2Service annexeDeuxService,
            Annexe3Service annexeTroisService,
            Annexe4Service annexeQuatreService,
            Annexe5Service annexeCinqService,
            Annexe6Service annexeSixService)
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

            _societe = societe;
            _exercice = exercice;
            _annexeUnService = annexeUnService;
            _annexeDeuxService = annexeDeuxService;
            _annexeTroisService = annexeTroisService;
            _annexeQuatreService = annexeQuatreService;
            _annexeCinqService = annexeCinqService;
            _annexeSixService = annexeSixService;
        }

        void GenereRecapAnnexe7()
        {
            var anx1 = _annexeUnService.GetAnnexe();
            var lignesAnx1 = anx1.Lignes.ToList();
            var anx2 = _annexeDeuxService.GetAnnexe();
            var lignesAnx2 = anx2.Lignes;
            var anx3 = _annexeTroisService.GetAnnexe();
            var lignesAnx3 = anx3.Lignes;
            var anx4 = _annexeQuatreService.GetAnnexe();
            var lignesAnx4 = anx4.Lignes;
            var anx5 = _annexeCinqService.GetAnnexe();
            var lignesAnx5 = anx5.Lignes;
            var anx6 = _annexeSixService.GetAnnexe();
            var lignesAnx6 = anx6.Lignes;
            var lignesAnx7 = new List<LigneAnnexeSept>();
            for (var i = 1; i <= 25; i++)
            {
                switch (i)
                {
                    case 1:
                    {
                        var lignes1 = lignesAnx1.ToList();
                        foreach (var lig in lignes1)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.Traitement,
                                MontantPayee = lig.RevenuBrutImposable - lig.RevenuReinvesti,
                                RetenueSource = lig.MontantRetenuesRegimeCommun + lig.MontantRetenuesTauxVingt,
                                MontantNetServi = lig.MontantNetServie,
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 2:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Honoraires)
                                .ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.Honoraires,
                                MontantPayee = lig.MontantBurtHonoraires,
                                RetenueSource = lig.MontantRetenueOperee,
                                MontantNetServi = lig.MontantNetServi,
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 3:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Commissions)
                                .ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.Commissions,
                                MontantPayee = lig.MontantBurtHonoraires,
                                RetenueSource = lig.MontantRetenueOperee,
                                MontantNetServi = lig.MontantNetServi,
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 4:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Courtages)
                                .ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.Courtages,
                                MontantPayee = lig.MontantBurtHonoraires,
                                RetenueSource = lig.MontantRetenueOperee,
                                MontantNetServi = lig.MontantNetServi,
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 5:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Loyers).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.Loyers,
                                MontantPayee = lig.MontantBurtHonoraires,
                                RetenueSource = lig.MontantRetenueOperee,
                                MontantNetServi = lig.MontantNetServi,
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 6:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiPersonne == TypeMontantServiAnnexe2.Remuneration)
                                .ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RemunerationsActivite,
                                MontantPayee = lig.MontantBurtHonoraires, //A213
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 7:
                    {
                        var lignes2 = lignesAnx2.Where(x => x.HonorairesSociete > 0).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.HonorairesPersonnePhysiqueMoraleSoumiseRegimeReel,
                                MontantPayee = lig.HonorairesSociete, //A214
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 8:
                    {
                        var lignes2 = lignesAnx2.Where(x => x.RemunerationsArtistes > 0).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RemunerationsAriste,
                                MontantPayee = lig.RemunerationsArtistes, //A219
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 9:
                    {
                        var lignes2 = lignesAnx2.Where(x => x.HonorairesBureauEtude > 0).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.HonorairesBureau,
                                MontantPayee = lig.HonorairesBureauEtude, //A220
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 10:
                    {
                        var lignes2 =
                            lignesAnx2.Where(
                                x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Honoraires).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.HonorairesOperationExport,
                                MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 Where A221 = 1
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 11:
                    {
                        var lignes2 =
                            lignesAnx2.Where(
                                x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Commissions).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.CommissionOperationExport,
                                MontantPayee = lig.MontantBrutHonorairesOperationExportation, // A222 where A221 = 2
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 12:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Courtages)
                                .ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.CourtagesOpeationExport,
                                MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 where A221 = 3
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 13:
                    {
                        var lignes2 =
                            lignesAnx2.Where(x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Loyers)
                                .ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.LoyersOperationExport,
                                MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 where A221 = 4
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 14:
                    {
                        var lignes2 =
                            lignesAnx2.Where(
                                x => x.TypeMontantServiOperationExport == TypeMontantServiAnnexe2.Remuneration).ToList();
                        foreach (var lig in lignes2)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RemunerationOperationExport,
                                MontantPayee = lig.MontantBrutHonorairesOperationExportation, //A222 where A221 = 5
                                RetenueSource = lig.MontantRetenueOperee, //A223
                                MontantNetServi = lig.MontantNetServi, //A225
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 15:
                    {
                        var lignes3 = lignesAnx3.Where(x => x.CompteSpeciaux > 0).ToList();
                        foreach (var lig in lignes3)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.InteretCompteEpargne,
                                MontantPayee = lig.CompteSpeciaux, //A312 where A312 >0 
                                RetenueSource = lig.MontantRetenueOperee, //A315
                                MontantNetServi = lig.MontantNetServi, //A317
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 16:
                    {
                        var lignes3 = lignesAnx3.Where(x => x.PretEtabBancaire > 0).ToList();
                        foreach (var lig in lignes3)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.InteretPretEtablissementBancaires,
                                MontantPayee = lig.PretEtabBancaire, //A314 where A314 > 0
                                RetenueSource = lig.MontantRetenueOperee, //A315
                                MontantNetServi = lig.MontantNetServi, //A317
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 17:
                    {
                        var lignes3 = lignesAnx3.Where(x => x.AutreCapitauxMobilier > 0).ToList();
                        foreach (var lig in lignes3)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RevenusValeursMobilier,
                                MontantPayee = lig.AutreCapitauxMobilier, //A314 where A314 > 0
                                RetenueSource = lig.MontantRetenueOperee, //A315
                                MontantNetServi = lig.MontantNetServi, //A317
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 18:
                    {
                        var lignes4 = lignesAnx4.Where(x => x.MontantHonoraireNonResidente > 0).ToList();
                        foreach (var lig in lignes4)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.HonorairesPersonneNonResident,
                                MontantPayee = lig.MontantHonoraireNonResidente, //A416 where A416 > 0
                                RetenueSource = lig.MontantRetenueOperee, //A426
                                MontantNetServi = lig.MontantNetServi, //A427
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 19:
                    {
                        var lignes4 = lignesAnx4.Where(x => x.MontantRevenuValueMobiliere > 0).ToList();
                        foreach (var lig in lignes4)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RevenusMobilierNonResident,
                                MontantPayee = lig.MontantRevenuValueMobiliere, //A4222 where A422 > 0
                                RetenueSource = lig.MontantRetenueOperee, //A426
                                MontantNetServi = lig.MontantNetServi, //A427
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 20:
                    {
                        var lignes4 = lignesAnx4.Where(x => x.MontantParadisFiscaux > 0).ToList();
                        foreach (var lig in lignes4)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RemunerationsPersonneResidentEtabliesParadisFiscaux,
                                MontantPayee = lig.MontantParadisFiscaux, //A425 where A425 > 0
                                RetenueSource = lig.MontantRetenueOperee, //A423
                                MontantNetServi = lig.MontantNetServi, //A427
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 21:
                    {
                        var lignes5 = lignesAnx5.Where(x => x.MontantOpExport > 0).ToList();
                        foreach (var lig in lignes5)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RetenueSourcesMontantOperationExport,
                                MontantPayee = lig.MontantOpExport, //A512 WHERE A512 >0
                                RetenueSource = lig.RetenueOpExport, //A513
                                MontantNetServi = lig.MontantNetServi, //A521
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 22:
                    {
                        var lignes5 = lignesAnx5.Where(x => x.MontantAutreOp > 0).ToList();
                        foreach (var lig in lignes5)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RetenueSourcesMontantAutresOperation,
                                MontantPayee = lig.MontantAutreOp, //A514 WHERE A514 > 0
                                RetenueSource = lig.RetenueAutreOp, //A515
                                MontantNetServi = lig.MontantNetServi, //A521
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 23:
                    {
                        var lignes5 = lignesAnx5.Where(x => x.MontantEtabPublic > 0).ToList();
                        foreach (var lig in lignes5)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee = TypeMontantPayee.RetenueSourcesEtablissementPublic,
                                MontantPayee = lig.MontantEtabPublic, //A516 WHERE A516 > A516
                                RetenueSource = lig.RetenueEtabPublic, //A517
                                MontantNetServi = lig.MontantNetServi, //A521
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 24:
                    {
                        var lignes5 = lignesAnx5.Where(x => x.MontantEtabAlEtranger > 0).ToList();
                        foreach (var lig in lignes5)
                        {
                            var lig7 = new LigneAnnexeSept
                            {
                                Beneficiaire = lig.Beneficiaire,
                                BeneficiaireActivite = lig.BeneficiaireActivite,
                                BeneficiaireAdresse = lig.BeneficiaireAdresse,
                                BeneficiaireIdent = lig.BeneficiaireIdent,
                                BeneficiaireType = lig.BeneficiaireType,
                                TypeMontantPayee =
                                    TypeMontantPayee.RetenueSourcesOperationPersonneNAyantPasEtablissement,
                                MontantPayee = lig.MontantEtabAlEtranger, //A518 WHERE A519
                                RetenueSource = lig.RetenueEtabAlEtranger, //A519
                                MontantNetServi = lig.MontantNetServi, //A521
                            };
                            lignesAnx7.Add(lig7);
                        }
                    }
                        break;
                    case 25:
                    {
                        break;
                    }
                }
            }
        }
    }
}