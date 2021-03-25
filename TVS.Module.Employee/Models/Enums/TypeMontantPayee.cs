using System.ComponentModel;

namespace TVS.Module.Employee.Models.Enums
{
    public enum TypeMontantPayee : int
    {
        [Description("Traitements, salaires, pensions et rentes viagérers")] Traitement = 1,

        [Description("Honoraires")] Honoraires = 2,

        [Description("Commissions")] Commissions = 3,

        [Description("Courtages")] Courtages = 4,

        [Description("Layers")] Loyers = 5,

        [Description("Rémunérations des activitésnon commerciales")] RemunerationsActivite = 6,

        [Description("Honoraires servis aux personnes morales et personnes physiques soumises au régime réel")] HonorairesPersonnePhysiqueMoraleSoumiseRegimeReel = 7,

        [Description("Honoraires servis aux artistes et créateurs")] RemunerationsAriste = 8,

        [Description("Honoraires servis aux bureaux d’études exportateurs ")] HonorairesBureau = 9,

        [Description("Honoraires au titre des opérations d’export")] HonorairesOperationExport = 10,

        [Description("Commissions au titre des opérations d’export")] CommissionOperationExport = 11,

        [Description("Courtages au titre des opérations d’export")] CourtagesOpeationExport = 12,

        [Description("Loyers au titre des opérations d’export")] LoyersOperationExport = 13,

        [Description("Rémunérations des activités non commerciales provenant des opérations d’export ")] RemunerationOperationExport = 14,

        [Description("Intéréts des comptes spéciaux d’épargne ouverts auprés des banques et de la CENT")] InteretCompteEpargne = 15,

        [Description("Intérêts des prêts payés aux établissements bancaires non établis en Tunisie.")] InteretPretEtablissementBancaires = 16,

        [Description("Revenus des autres capitaux mobiliers")] RevenusValeursMobilier = 17,

        [Description(
             "Honoraires servis aux personnes non résidentes qui réalisent des travaux de construction ou des opérations de montages ou des services de contrôle connexes ou d'autres services pour une durée ne dépassant pas 6 mois"
         )] HonorairesPersonneNonResident = 18,

        [Description(
             "Revenus des valeurs mobilières servis aux non résidents y compris les jetons de sociales revenant  aux personnes physiques et aux personnes morales non résidentes"
         )] RevenusMobilierNonResident = 19,

        [Description("Rémunérations servies à des personnes résidentes ou établies dans des paradis fiscaux")] RemunerationsPersonneResidentEtabliesParadisFiscaux = 20,

        [Description(
             "Retenues à la source au titre des montants  égaux ou supérieurs à 1000 dinars y compris la TVA au titre des op rations d’export et des ventes des entreprises soumises à l’IS au taux de 10%"
         )] RetenueSourcesMontantOperationExport = 21,

        [Description(
             "Retenues à la source au titre des montants  égaux ou supérieurs à 1000 dinars y compris la TVA au titre des autres opérations."
         )] RetenueSourcesMontantAutresOperation = 22,

        [Description(
             "Retenues  à la source de la TVA au titre des montants égaux ou supérieurs 1000 dinars payés par  les établissements et les entreprises publics."
         )] RetenueSourcesEtablissementPublic = 23,

        [Description(
             "Retenues  à la source de la TVA au titre des opérations réalisées avec les personnes n’ayant pas d’établissement en Tunisie."
         )] RetenueSourcesOperationPersonneNAyantPasEtablissement = 24,

        [Description("Redevance au profit de la caisse générale de compensation")] RedevenceProfit = 25
    }
}