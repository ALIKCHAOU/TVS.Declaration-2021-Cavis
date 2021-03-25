using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6005 : IF600X
    {
        public F6005(Core.Models.Liass.F6005 mF6005)
        {
            MF6005 = mF6005;
            Lignes= new List<LigneLiasse>();
            int libIndex = 0;
            for (int j = 1; j <= 108; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F60050{j:000}",
                    CodeN1 = $"F60051{j:000}",
                    Libelle = Libelles[libIndex++],
                    ObjectLiasse = mF6005
                });
                if(j==55) Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F600509{j:00}",
                    CodeN1 = $"F600519{j:00}",
                    Libelle = Libelles[libIndex++],
                    ObjectLiasse = mF6005
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6005 MF6005 { get; private set; }

        List<string> Libelles = new List<string>() {@"Nature resultat net comptable apres modifications comptables (avant impôt)",
            @"Resultat net comptable apres modifications comptables (avant impôts)",
            @"Charges non déductibles",
            @"Rénumérations de l'exploitant individuel, ou des associés en nom des sociétés de personnes et assimilés",
            @"Charges relatifs aux établissements situés à l'étranger",
            @"Quote-part des frais de siège imputable aux établissements situés à l'étranger ( frais du siège x (chiffre d'affaires de l'établissement stable /chiffre d'affaires total))",
            @"Charges relatives aux résidences secondaires, avions et bateaux de plaisance ne faisant pas l'objet de l'exploitation",
            @"Charges relatives aux véhicules de tourismes d'une puissance supérieur à 9 CV ne faisant pas l'objet de l'exploitation",
            @"Cadeaux et frais de réception non déductibles",
            @"Cadeaux et frais de réception excédentaires",
            @"Commissions, courtages, ristournes commerciales ou autres, vacations, honoraires er rémunérations de performance non déclarés dans la déclaration de l'employeur",
            @"Dons et subventions non déductibles",
            @"Dons et subventions excédentaires",
            @"Abandon de créances non déductibles",
            @"Pertes de change non réalisées",
            @"Gains de change non réalisés antérieurement non imposés",
            @"Intérêts servis à l'exploitant ou aux associés des sociétés de personnes et assimilés",
            @"Rémunération excédentaires des titres participatifs et des comptes courants associés",
            @"Charges d'une valeur supérieure ou égale à 5.000 dinars payée en espèces",
            @"Moins values de cession des titres des organismes de placement collectif en valeurs mobilières dans la limite des dividendes réalisés",
            @"Impôts directs supportés aux lieu et place d'autrui",
            @"Taxe de voyages ()",
            @"Transactions, amendes, confiscations et pénalités non déductibles",
            @"Dépenses excédentaires engagées  pour la réalisation des opérations d'essaimage",
            @"Amortissements",
            @"Amort. Non déductibles relatifs aux établissements situés à l'étranger",
            @"Amortissements non déductibles relatifs aux résidences secondaires, avions et bateaux de plaisance ne faisant pas l'objet de l'exploitation",
            @"Amortissements non déductibles relatifs aux véhicules de tourisme d'une puissance fiscale supérieure à 9 CV ne faisant pas l'objet de l'exploitation",
            @"Amort. Non déductibles relatifs aux terrains et fonds de commerce",
            @"Amort. Non déductibles relatifs aux terrains et fonds de commerce actifs d'une valeur supérieure ou égale à 5000 DT payée en espèces",
            @"Partie des amort. Ayant dépassé la limite autorisée par la législation en vigueur",
            @"Partie des amortissements correspondant à une période inférieure à la période autorisée par la législation en vigueur, pour les immobilisations acquises dans le cadre d'un contrat de leasing ou d'ijara",
            @"Provisions",
            @"Provisions non déductibles",
            @"Provisions déductibles pour créances douteuses (autres que celles constituées par les établissements de crédit)",
            @"Provisions déductibles pour dépréciation des actions cotées en bourse autres que celles constituées par les sociétés d'investissement à capital risque)",
            @"provisions déductibles pour dépréciation des stocks destinés à la vente",
            @"Provisions déductibles pour risque d'exigibilité des engagements techniques (compagnie d'assurance)",
            @"Produits non comptabilisés ou insuffisamment comptabilisés ∑ 40 à 43",
            @"Intérêts non décomptés relatifs aux comptes courants associés et aux créances non commerciales",
            @"Intérêts insuffisamment décomptés relatifs aux comptes courants associés et aux créance non commerciales",
            @"Plus value de cession des actifs non comptabilisée",
            @"Plus value de cession des actifs insuffisammen comptabilisée",
            @"Autres réintégrations",
            @"TOTAL DES RÉINTÉGRATIONS F60050003+F60050025+F60050033+F60050039+F60050044",
            @"Produits réalisés par les établissements situés à l'étranger",
            @"Reprise sur provisions réintégrées au résultat fiscal de l'année de leur constitution",
            @"Amortissements excédentaires réintégrés aux résultats des années antérieures",
            @"Gains de change réintégrés aux résultats des années antérieures",
            @"Gains de change non réalisés",
            @"Pertes de change antérieurement constatées",
            @"50% des salaires servis aux demandeurs d'emploi recrutés pour la première fois",
            @"Autres déductions ",
            @"TOTAL DES DÉDUCTIONS ∑ 46 à 53",
            @"Nature du Résultat Fiscal avant Déduction des Provisions (Perte, Bénéfice)",
            @"F60050955	Resultat fiscal avant déduction des provisions)",
            @"RÉSULTAT FISCAL (Bénificiaire)",
            @"Provisions pour créances douteuses",
            @"Provisions pour dépréciation des stocks destinés à la vente",
            @"Prov. pour dépréciation de la valeur des actions côtées en bourse",
            @"Prov° pour risuqes d'exégibilité des engagements techniques(companies d'assurances)",
            @"RÉSULTAT FISCAL après déduction des provisions F60050061=F60050056-Inf( ∑F60050057 à F60050060, F60050056/2 )",
            @"Déduction de la moins value provenant de la levée de l'option par les salariés de souscription au capital des sociétés ou d'acquisition de leurs actions ou parts sociales dans la limite de 5% du résultat fiscal après déduction des provisions (Société de s",
            @"Résultat fiscal après déduction des provisions et avant déduction des déficits et des amortissements",
            @"Réintégration des amortissements d l'exercice",
            @"Déduction des déficits reportés",
            @"Déduction des amortissements de l'exercice",
            @"Déduction des amortissements différés en période déficitaire",
            @"RÉSULTAT FISCAL après déduction des provisions, des déficits et amortissements différés",
            @"Dividendes et assimilés distribués par des sociétés établis en Tunisie",
            @"Plus-value de cession des actions dans le cadre d'une opération d'introduction en bourse",
            @"Plus-value de cession des actions cotées à la bourse des valeurs mobilières de Tunis  cédées après l'expiration de l'année suivant celle de leur acquisition ou de leursouscription",
            @"Plus-value de cession des actions et des parts sociales réalisée par l'intermédiaire des sociétés d'investissement à capital rique (totalement ou dans la limite de 50%)",
            @"Plus-value de cession des parts des fonds communs de placement à risque (totalement ou dans la limite de 50%)",
            @"Plus-value de cession des parts des fonds d'amorçage",
            @"Plus-value d'apport dans le cadre d'une opération de fusion ou deission totale de sociétés, ou d'une opération d'apport des entreprises individuelles dans le capital d'une société (au niveau de la société absorbée,indée ou de la société ayant fait l'appor",
            @"Plus-value provenant de l'apport d'actions ou de parts sociales au capital de la société mère ou de la société holding dans le cadre des opérations de restructuration des entreprises ayant pour objet l'introduction de la société mère ou de la société hold",
            @"Plus-value provenant de la cession totale ou partielle des éléments de l'actif constituant une unité indépendante et autonome suite au départ à la retraite du propriétaire de l'entreprise ou à cause de l'incapacité de poursuivre la gestion de l'entreprise",
            @"Plus-value provenant de la cession des entreprises en difficultés économiques dans le cadre du règlement judiciare prévu par la loi relative au redressemen des entreprises",
            @"intérêts des dépôts et de titres en devises ou en dinars convertibles",
            @"Résultat fiscal avant déduction des bénéfices provenant de l'exploitation",
            @"Revenus accessoires",
            @"Loyers ",
            @"Revenus de capitaux mobiliers",
            @"Dividendes de source étrangère",
            @"Autres revenus accessoires",
            @"Gains Exceptionnels",
            @"Plus value de cession des immeubles bâtis et non bâtis et des fonds de commerce",
            @"Gains de change non rattachés à l'activité principale",
            @"Plus value provenant de la cession des titres",
            @"Autres gains exceptionnels",
            @"Total",
            @"Bénéfice servant de base pour la détermination de la quote-part des bénéfices provenant de l'exploitation déductible",
            @"Au titre de l'exportation",
            @"Au titre du développement régional",
            @"Au titre du développement agricole",
            @"Autres déductions",
            @"Total",
            @"Bénéfice fiscal après déduction des bénéfices au titre de l'exploitation",
            @"Déductions des revenus réinvestis",
            @"Réintégration du cinquième de la plus-value provenant d’opérations de fusion,ission ou d’opérations d’apport (dans la limite de 50%) pour la société absorbante ou la société bénéficiaire de laission ou de l’apport d’entreprise individuelle.",
            @"Résultat imposable",
            @"Cas déficitaire / RÉSULTAT FISCAL",
            @"Réintégration des amortissements de l'exercice",
            @"Déduction des déficits reportés",
            @"Déduction des amortissements de l'exrcice",
            @"Déduction des amortissements diféfrés en périodes déficitaires",
            @"RÉSULTAT FISCAL (déficit reportable)",
            @"Autre résultat imposable (bénéfice exportation période supérieure à 10 ans)"};
    }
}