using System.Collections.Generic;

namespace TVS.Module.Liasse.Model
{
    public class F6004 : IF600X
    {
        public F6004(Core.Models.Liass.F6004 mF6004)
        {
            MF6004 = mF6004;
            Lignes= new List<LigneLiasse>();
            for (int j = 1; j <= 117; j++)
            {
                Lignes.Add(new LigneLiasse()
                {
                    Ordre = j,
                    CodeN = $"F60040{j:000}",
                    CodeN1 = $"F60041{j:000}",
                    Libelle = Libelles[j-1],
                    ObjectLiasse = mF6004
                });
            }

        }

        public List<LigneLiasse> Lignes { get; set; }
        public Core.Models.Liass.F6004 MF6004 { get; private set; }

        List<string> Libelles = new List<string>() {@"Flux de tr?sorerie lies a l'exploitation ",
            @"Encaissements re?us des clients",
            @"S.Debiteurs Clts et Rattaches et Regul.bruts en Debut d?exercice",
            @"S.Crediteurs Clts et Rattaches et Regul.bruts en Debut d?exercice",
            @"Ventes TTC",
            @"Ajustements des ventes des exercices anterieurs portes en modifications comptables (compte 128) majores de la TVA",
            @"Creances clients passees en pertes (comptes 634)",
            @"Gains de change sur creances clients en devises  ",
            @"Pertes de change sur creances client en devises ",
            @"S.Debiteurs Clts et Rattaches et Regul.bruts en Fin d?exercice",
            @"S.Crediteurs Clts et Rattaches et Regul.bruts en Fin d?exercice",
            @"Sommes versees aux fournisseurs (d'exploitation)",
            @"S.Crediteurs Frs Expl. et Rattaches et Regul. en Debut d?exercice ",
            @"S.Debiteurs Frs Expl. et Rattaches et Regul. en Debut d?exercice ",
            @"S.C. Etat, RaS  et autres I et T/Ch.Exploitation en Debut d'exercice",
            @"Achats TTC (des comptes 60, 61, 62 et 63 en partie) ",
            @"Ajustements des achats des exercices anterieurs portes en modifications comptables (compte 128) majores de la TVA",
            @"Gains de change sur dettes Frs Expl. en devises ",
            @"Pertes de change sur dettes Frs Expl. en devises",
            @"S.Crediteurs Frs Expl. et Rattaches et Regul. en Fin d?exercice",
            @"S.Debiteurs Frs Expl. et Rattaches et Regul. en Fin d'exercice",
            @"S.C. Etat, RaS  et autres I et T/Ch.Exploitation en Fin d'exercice",
            @"Sommes versees au personnel",
            @"S.Crediteurs PL(Org.Sociaux) et Lies et Regul.en Debut d'exercice",
            @"S.Debiteurs PL(Org.Sociaux) et Lies et Regul.en Debut d'exercice",
            @"S.C. Etat, RaS  et autres I et T/Ch.du personnel en Debut d'exercice",
            @"Charges de personnel de l?exercice",
            @"Ajustements des charges de personnel des exercices anterieurs portes en modifications comptables (compte 128)",
            @"S.Crediteurs PL(Org.Sociaux) et Lies et Regul.en Fin d'exercice",
            @"S.Debiteurs PL(Org.Sociaux) et Lies et Regul.en Fin d'exercice",
            @"S.C. Etat, RaS  et autres I et T/Ch.du personnel en Fin d'exercice",
            @"Interets payes",
            @"S.C. Interets dus et Rattaches et Regul.a Payer en Debut d?exercice",
            @"S.D. Interets comptes de Regul.d'Avance en Debut d?exercice",
            @"S.C. Etat, RaS/Revenus de Capitaux en Debut d?exercice",
            @"Charges Financieres de l?exercice",
            @"Ajustements des charges d?interet des exercices anterieurs portes en modifications comptables (compte 128)",
            @"Frais d?emission d?emprunt",
            @"Dot.Resorp. Frais d?emission et Primes de Rembours.Empts",
            @"Dot.Prov. Risques et charges financiers  et  Risques de change  et  deprec.immo.financieres  et  deprec.placements et prets courants",
            @"Reprise/Prov. Risques  et charges financiers  et  Risques de change  et  deprec.immo.financieres  et  deprec.placements et prets courants",
            @"S.C. Interets dus et Rattaches et Regul.a Payer en Fin d?exercice",
            @"S.D. Interets Comptes de Regul.d'Avance en Fin d?exercice",
            @"S.C. Etat, RaS/Revenus de Capitaux en Fin d?exercice",
            @"Impots et taxes payes",
            @"S.Crediteurs ( Etat, impots et taxes ) en Debut d'exercice",
            @"S.Debiteurs ( Etat, impots et taxes ) en Debut d?exercice",
            @"S.C.Impot/Resultat differe (+)actif;(-)passif en Debut d?exercice ",
            @"Impot sur les Resultats (69)",
            @"Impots et Taxes de l?exercice  (66)",
            @"TVA et autres Taxes/B et S Hors exploitation",
            @"Impot/Resultat differe (+)actif;(-)passif constate durant l'exercice sans passer par l?Etat de resultat ",
            @"Impots et Taxes portes en Modif.Compt.(cpt128)",
            @"Impot/Resultat a(+)liquider;(-)imputer portes en Modif.Compt.",
            @"S.Crediteurs ( Etat, impot et taxes ) en Fin d'exercice",
            @"S.Debiteurs ( Etat, impot et taxes ) en Fin d'exercice",
            @"S.C.Impot/Resultat differe (+)actif;(-)passif en Fin d?exercice",
            @"Flux de tresorerie lies aux activites d'investissement",
            @"Decaissements lies aux immo. Corporelles et incorporelles",
            @"S.C.FRS d?Invest. et Rattaches et Regul. en Debut d?exercice",
            @"S.C. Etat, RaS operee/plus value immobiliere en Fin d?exercice",
            @"Valeurs brutes des Invest. d'exercice ",
            @"TVA payee/Investissements de l?exercice",
            @"S.C. FRS d?Invest. et Rattaches et Regul. en Fin d?exercice",
            @"S.C. Etat, RaS operee/plus value immobiliere en Fin d?exercice",
            @"Encaissements lies aux immo. Corporelles et incorporelles",
            @"S.D. Immo.Corporelles et Incorporelles en Debut d'exercice",
            @"S.D. Debiteurs  et  autres Creances TTC / cession des Immo.en Debut d'exercice",
            @"S.C.TVA collectee/cession Investissements en Debut d'exercice",
            @"S.C.TVA a reverser/cession Investissements en Debut d'exercice",
            @"S.D.Etat, RaS supportee/plus value immobiliere en Debut d?exercice",
            @"TVA a reverser/cession d'Invest. durant l'exercice",
            @"Produits nets/Cession des Invest.(-TVA a reverser comprise) durant l'exercice",
            @"Charges Nettes/Cession des Invest. durant l'exercice",
            @"S.D. Immo.Corporelles et Incorporelles en Fin d'exercice",
            @"S.D.Debiteurs  et  autres Creances TTC / cession des Invest. en Fin d'exercice",
            @"S.C. TVA collectee/cession investissements en Fin d'exercice",
            @"S.C. TVA a reverser/cession investissements en Fin d'exercice",
            @"S.D.Etat, RaS supportee/plus value immobiliere en Fin d?exercice",
            @"Decaissements lies aux immobilisations financieres",
            @"Dettes/acquisition d'immo. Financieres en fin d'exercice",
            @"Valeur brute des titres acquis durant l?exercice",
            @"Dettes/acquisition d'immo. Finan. en debut d'exercice",
            @"Encaissements lies aux immobilisations financieres",
            @"Creances sur cessions d?immo.Fin. en debut d?exercice",
            @"Cessions /Immo.Financieres durant l'exercice",
            @"Remboursements/Immo.Financieres durant l'exercice",
            @"Creances sur cessions d?immo.financ. en fin d?exercice",
            @"Flux de tresorerie lies aux activites de financement",
            @"Encaissements suite a l'emission d'actions",
            @"Capital en fin d'exercice",
            @"Primes liees au capital en fin d'exercice",
            @"Augmentations du capital durant l'exercice",
            @"Conversion de dettes en capital durant l'exercice",
            @"Capital en debut d'exercice",
            @"Primes liees au capital en debut d'exercice",
            @"Dividendes at autres distributions",
            @"Dividendes dus aux actionnaires en debut d?exercice",
            @"Dividendes attribues en (N)",
            @"Prelevements sur les reserves en (N)",
            @"Rachat d'actions et autres reductions de capital (non motivees par des pertes ou modif.Comptable) en (N)",
            @"Dividendes dus aux actionnaires en fin d?exercice",
            @"Encaissements/remboursements d'emprunts",
            @"S.C. (Emprunts et dettes assimilees) en fin d'exercice",
            @"S.C. (Emprunts courants) en fin d'exercice",
            @"S.C. (Emprunts et dettes assimilees) en debut d'exercice",
            @"S.C. (Emprunts courants) en debut d'exercice",
            @"Decaissements/remboursements de prets et des placements",
            @"S.D.(Prets et Creances Fin. courants) en fin d'exercice",
            @"S.D. (Placements Courants) en fin d'exercice",
            @"S.D.(Prets et Creances Fin. courants) en debut d'exercice",
            @"S.D. (Placements Courants) en debut d'exercice",
            @"Incidences des variations des taux de change/les liquidites et equiv.",
            @"Autres Postes des Flux de Tresorerie",
            @"Variation de Tresorerie",
            @"Tresorerie au debut de la periode ",
            @"Tresorerie a la cloture de la periode "};
    }
}