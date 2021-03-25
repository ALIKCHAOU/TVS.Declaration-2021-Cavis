using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TVS.Core.Models;

namespace TVS.Module.Cnss.ImportsSql.Views
{
    
    public class LigneSqlRepository
    {
        public const string EnteteSelectMatricule = @"SELECT   T_SAL.MatriculeSalarie			'Matricule' ";
        public const string EnteteSelectBadge = @"SELECT   T_SAL.NumeroDeBadge			'Matricule' ";

        public const string QueryGetByRubrique = @"
, T3.NoSecu  AS 'NumCnss'
, ISNULL(T3.Cle ,'')	 AS	'CleCnss'
, ISNULL(T2.NoCarte ,'') AS 'Cin'
, ISNULL(T_SAL.Civilite, 0)			 AS 'Civilite'
, ISNULL(FAM.SituationFamille,0)		 AS 'SituationFamille'
, T_SAL.Nom								
, ISNULL(T_SAL.Prenom,'')  'Prenom'
, ISNULL(T_SAL.Prenom2,'') 'AutreNom'
, ISNULL(T_SAL.NomJeuneFille, '') AS 'NomJeuneFille'
, T_SAL.Rue1 AS 'Adresse'
, 1			 AS 'TypeCnss'
,(SELECT        SUM(ValeurMontant) AS Expr1
FROM            T_HBNS
WHERE        (DateHist >= @dateMinBrut1) AND (DateHist <= @dateMaxBrut1) AND (CodeRubrique = @CodePaie) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurMontant > 0)) AS BrutA,
(SELECT        SUM(ValeurMontant) AS Expr1
FROM            T_HBNS AS T_HBNS_4
WHERE        (DateHist >= @dateMinBrut2) AND (DateHist <= @dateMaxBrut2) AND (CodeRubrique = @CodePaie) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurMontant > 0)) AS BrutB,
(SELECT        SUM(ValeurMontant) AS Expr1
FROM            T_HBNS AS T_HBNS_3
WHERE        (DateHist >= @dateMinBrut3) AND (DateHist <= @dateMaxBrut3) AND (CodeRubrique = @CodePaie) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurMontant > 0)) AS BrutC
FROM            T_SAL 
INNER JOIN  T_HST_ETABLISSEMENT AS T0 ON T_SAL.SA_CompteurNumero = T0.NumSalarie AND (T0.InfoEnCours = 1) AND  (T0.CodeEtab = @etablissementNo)
INNER JOIN  T_HST_NATIONALITE AS T2 ON T_SAL.SA_CompteurNumero = T2.NumSalarie AND (T2.InfoEnCours = 1)
INNER JOIN  T_HST_SECU AS T3 ON T_SAL.SA_CompteurNumero = T3.NumSalarie   AND (T3.InfoEnCours = 1)
INNER JOIN  T_ETA AS T1 ON T0.CodeEtab = T1.CodeEtab
LEFT JOIN T_HST_FAMILLE AS FAM ON FAM.NumSalarie = T_SAL.SA_CompteurNumero AND FAM.InfoEnCours = 1
WHERE        
((SELECT        SUM(ValeurMontant) AS Expr1
	FROM            T_HBNS AS T_HBNS_1
	WHERE        (DateHist >= @dateMin) 
			 AND (DateHist <= @dateMax)
			 AND (CodeRubrique = @CodePaie) 
			 AND (NumSalarie = T_SAL.SA_CompteurNumero) 
			 AND (ValeurMontant > 0)) > 0)
";
        public const string QueryGetByRubriqueEtabNull = @"
, T3.NoSecu  AS 'NumCnss'
, ISNULL(T3.Cle ,'')	 AS	'CleCnss'
, ISNULL(T2.NoCarte ,'') AS 'Cin'
, ISNULL(T_SAL.Civilite, 0)			 AS 'Civilite'
, ISNULL(FAM.SituationFamille,0)		 AS 'SituationFamille'
, T_SAL.Nom								
, ISNULL(T_SAL.Prenom,'')  'Prenom'
, ISNULL(T_SAL.Prenom2,'') 'AutreNom'
, ISNULL(T_SAL.NomJeuneFille, '') AS 'NomJeuneFille'
, T_SAL.Rue1 AS 'Adresse'
, 1			 AS 'TypeCnss'
,(SELECT        SUM(ValeurMontant) AS Expr1
FROM            T_HBNS
WHERE        (DateHist >= @dateMinBrut1) AND (DateHist <= @dateMaxBrut1) AND (CodeRubrique = @CodePaie) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurMontant > 0)) AS BrutA,
(SELECT        SUM(ValeurMontant) AS Expr1
FROM            T_HBNS AS T_HBNS_4
WHERE        (DateHist >= @dateMinBrut2) AND (DateHist <= @dateMaxBrut2) AND (CodeRubrique = @CodePaie) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurMontant > 0)) AS BrutB,
(SELECT        SUM(ValeurMontant) AS Expr1
FROM            T_HBNS AS T_HBNS_3
WHERE        (DateHist >= @dateMinBrut3) AND (DateHist <= @dateMaxBrut3) AND (CodeRubrique = @CodePaie) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurMontant > 0)) AS BrutC
FROM            T_SAL 
INNER JOIN  T_HST_ETABLISSEMENT AS T0 ON T_SAL.SA_CompteurNumero = T0.NumSalarie AND (T0.InfoEnCours = 1) 
INNER JOIN  T_HST_NATIONALITE AS T2 ON T_SAL.SA_CompteurNumero = T2.NumSalarie AND (T2.InfoEnCours = 1)
INNER JOIN  T_HST_SECU AS T3 ON T_SAL.SA_CompteurNumero = T3.NumSalarie   AND (T3.InfoEnCours = 1)
INNER JOIN  T_ETA AS T1 ON T0.CodeEtab = T1.CodeEtab
LEFT JOIN T_HST_FAMILLE AS FAM ON FAM.NumSalarie = T_SAL.SA_CompteurNumero AND FAM.InfoEnCours = 1
WHERE        
((SELECT        SUM(ValeurMontant) AS Expr1
	FROM            T_HBNS AS T_HBNS_1
	WHERE        (DateHist >= @dateMin) 
			 AND (DateHist <= @dateMax)
			 AND (CodeRubrique = @CodePaie) 
			 AND (NumSalarie = T_SAL.SA_CompteurNumero) 
			 AND (ValeurMontant > 0)) > 0)
";
        public static IEnumerable<LigneSqlView> GetLigneRubrique(Societe societe , CategorieCnss categorie, DateTime dateMin , DateTime dateMax , string etablissementNo)
        {
            var dateMinBrut1 = dateMin;
            var dateMaxBrut1 = dateMin.AddMonths(1).AddDays(-1);
            var dateMinBrut2 = dateMin.AddMonths(1);
            var dateMaxBrut2 = dateMinBrut2.AddMonths(1).AddDays(-1);
            var dateMinBrut3 = dateMinBrut2.AddMonths(1);
            var dateMaxBrut3 = dateMinBrut3.AddMonths(1).AddDays(-1);
            var query = societe.CnssTypeMatricule == TypeMatriculCnss.Matricule ? EnteteSelectMatricule : EnteteSelectBadge;
            query = string.Format("{0} {1}", query,string.IsNullOrWhiteSpace(etablissementNo)? QueryGetByRubriqueEtabNull: QueryGetByRubrique);
            using (var con = new SqlConnection(societe.GetConnection()))
            {
                var result = con.Query<LigneSqlView>(query, new
                {
                    categorie.CodePaie,
                    dateMin,
                    dateMax,
                    etablissementNo,
                    dateMinBrut1 ,
                    dateMaxBrut1,
                    dateMinBrut2,
                    dateMaxBrut2,
                    dateMinBrut3,
                    dateMaxBrut3
                });

                return result;
            }
        }

        public const string QueryGetByConstante = @"
, T3.NoSecu  AS 'NumCnss'
, ISNULL(T3.Cle,' ')	 AS	'CleCnss'
, ISNULL(T2.NoCarte, '') AS 'Cin'
, ISNULL(T_SAL.Civilite , 0 )			 AS 'Civilite'
, ISNULL(FAM.SituationFamille,0)		 AS 'SituationFamille'
, T_SAL.Nom								
, ISNULL(T_SAL.Prenom,'')  'Prenom'
, ISNULL(T_SAL.Prenom2,'') 'AutreNom'
, ISNULL(T_SAL.NomJeuneFille, '') AS 'NomJeuneFille'
, T_SAL.Rue1 AS 'Adresse'
, 1			 AS 'TypeCnss'
                             ,(SELECT        SUM(ValeurCumul) AS Expr1
                               FROM            T_HCUM
                               WHERE        (DateHist >= @dateMinBrut1) AND (DateHist <= @dateMaxBrut1) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) AS BrutA,
                             (SELECT        SUM(ValeurCumul) AS Expr1
                               FROM            T_HCUM AS T_HCUM_4
                               WHERE        (DateHist >= @dateMinBrut2) AND (DateHist <= @dateMaxBrut2) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) AS BrutB,
                             (SELECT        SUM(ValeurCumul) AS Expr1
                               FROM            T_HCUM AS T_HCUM_3
                               WHERE        (DateHist >= @dateMinBrut3) AND (DateHist <= @dateMaxBrut3) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) AS BrutC 
							   FROM            T_SAL 
INNER JOIN T_CST AS CST ON CST.CodeConstante = @CodePaie
INNER JOIN T_HST_ETABLISSEMENT AS T0 ON T_SAL.SA_CompteurNumero = T0.NumSalarie AND  (T0.InfoEnCours = 1) AND (T0.CodeEtab = @etablissementNo) 
INNER JOIN T_HST_NATIONALITE AS T2 ON T_SAL.SA_CompteurNumero = T2.NumSalarie AND (T2.InfoEnCours = 1)
INNER JOIN T_HST_SECU AS T3 ON T_SAL.SA_CompteurNumero = T3.NumSalarie AND (T3.InfoEnCours = 1)
INNER JOIN T_HST_INFOSSOCIETE AS T4 ON T_SAL.SA_CompteurNumero = T4.NumSalarie AND (T4.InfoEnCours = 1)
INNER JOIN T_ETA AS T1 ON T0.CodeEtab = T1.CodeEtab
LEFT JOIN T_HST_FAMILLE AS FAM ON FAM.NumSalarie = T_SAL.SA_CompteurNumero AND FAM.InfoEnCours = 1
WHERE   ((SELECT        SUM(ValeurCumul) AS Expr1
                                 FROM            T_HCUM AS T_HCUM_1
                                 WHERE        (DateHist >= @dateMin) AND (DateHist <= @dateMax) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) > 0)";

        public const string QueryGetByConstanteEtabNull = @"
, T3.NoSecu  AS 'NumCnss'
, ISNULL(T3.Cle,' ')	 AS	'CleCnss'
, ISNULL(T2.NoCarte, '') AS 'Cin'
, ISNULL(T_SAL.Civilite , 0 )			 AS 'Civilite'
, ISNULL(FAM.SituationFamille,0)		 AS 'SituationFamille'
, T_SAL.Nom								
, ISNULL(T_SAL.Prenom,'')  'Prenom'
, ISNULL(T_SAL.Prenom2,'') 'AutreNom'
, ISNULL(T_SAL.NomJeuneFille, '') AS 'NomJeuneFille'
, T_SAL.Rue1 AS 'Adresse'
, 1			 AS 'TypeCnss'
                             ,(SELECT        SUM(ValeurCumul) AS Expr1
                               FROM            T_HCUM
                               WHERE        (DateHist >= @dateMinBrut1) AND (DateHist <= @dateMaxBrut1) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) AS BrutA,
                             (SELECT        SUM(ValeurCumul) AS Expr1
                               FROM            T_HCUM AS T_HCUM_4
                               WHERE        (DateHist >= @dateMinBrut2) AND (DateHist <= @dateMaxBrut2) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) AS BrutB,
                             (SELECT        SUM(ValeurCumul) AS Expr1
                               FROM            T_HCUM AS T_HCUM_3
                               WHERE        (DateHist >= @dateMinBrut3) AND (DateHist <= @dateMaxBrut3) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) AS BrutC 
							   FROM            T_SAL 
INNER JOIN T_CST AS CST ON CST.CodeConstante = @CodePaie
INNER JOIN T_HST_ETABLISSEMENT AS T0 ON T_SAL.SA_CompteurNumero = T0.NumSalarie AND  (T0.InfoEnCours = 1)  
INNER JOIN T_HST_NATIONALITE AS T2 ON T_SAL.SA_CompteurNumero = T2.NumSalarie AND (T2.InfoEnCours = 1)
INNER JOIN T_HST_SECU AS T3 ON T_SAL.SA_CompteurNumero = T3.NumSalarie AND (T3.InfoEnCours = 1)
INNER JOIN T_HST_INFOSSOCIETE AS T4 ON T_SAL.SA_CompteurNumero = T4.NumSalarie AND (T4.InfoEnCours = 1)
INNER JOIN T_ETA AS T1 ON T0.CodeEtab = T1.CodeEtab
LEFT JOIN T_HST_FAMILLE AS FAM ON FAM.NumSalarie = T_SAL.SA_CompteurNumero AND FAM.InfoEnCours = 1
WHERE   ((SELECT        SUM(ValeurCumul) AS Expr1
                                 FROM            T_HCUM AS T_HCUM_1
                                 WHERE        (DateHist >= @dateMin) AND (DateHist <= @dateMax) AND (Entite = CST.CodeOperande1) AND (NumSalarie = T_SAL.SA_CompteurNumero) AND (ValeurCumul > 0)) > 0)";

        public static IEnumerable<LigneSqlView> GetLigneConstante(Societe societe, CategorieCnss categorie, DateTime dateMin, DateTime dateMax, string etablissementNo)
        {
            var dateMinBrut1 = dateMin;
            var dateMaxBrut1 = dateMin.AddMonths(1).AddDays(-1);
            var dateMinBrut2 = dateMin.AddMonths(1);
            var dateMaxBrut2 = dateMinBrut2.AddMonths(1).AddDays(-1);
            var dateMinBrut3 = dateMinBrut2.AddMonths(1);
            var dateMaxBrut3 = dateMinBrut3.AddMonths(1).AddDays(-1);
            var query = societe.CnssTypeMatricule == TypeMatriculCnss.Matricule ? EnteteSelectMatricule : EnteteSelectBadge;
            query = string.Format("{0} {1}",query, string.IsNullOrWhiteSpace(etablissementNo)? QueryGetByConstanteEtabNull: QueryGetByConstante);
            using (var con = new SqlConnection(societe.GetConnection()))
            {
                var result = con.Query<LigneSqlView>(query, new
                {
                    categorie.CodePaie,
                    dateMin,
                    dateMax,
                    etablissementNo,
                    dateMinBrut1,
                    dateMaxBrut1,
                    dateMinBrut2,
                    dateMaxBrut2,
                    dateMinBrut3,
                    dateMaxBrut3
                });

                return result;
            }
        }

        public static IEnumerable<EtabSqlView> GetEtb(Societe societe)
        {
            var query = @"
select T_ETA.CodeEtab 'Id'
	,T_ETA.Intitule 'Intitule'
FROM T_ETA";
            using (var con = new SqlConnection(societe.GetConnection()))
            {
                var result = con.Query<EtabSqlView>(query);

                return result;
            }
        }
    }


}
