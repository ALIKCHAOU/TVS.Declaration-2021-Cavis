using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core;
using TVS.Core.Enums;
using TVS.Core.Models;
using TVS.Declaration.Societes.Views;

namespace TVS.Declaration.Societes.Controllers
{
    public class SocieteController
    {
        private readonly DeclarationService _service;

        public SocieteController(DeclarationService service)
        {
            _service = service;
        }

        public int Create(SocieteView view)
        {
            if (!Program.IsMultiSociete)
                throw new InvalidOperationException("Opération invalide! Licence mono-societé");
            if (view == null) throw new InvalidOperationException("viewSociete");
            if (string.IsNullOrEmpty(view.RaisonSocial))
                throw new InvalidOperationException("Raison social invalide");
           return _service.SocieteCreate(view.RaisonSocial,
                view.Activite,
                view.Adresse,
                view.CodePostal,
                view.Ville,
                view.Pays,
                view.NumeroEmployeur,
                view.CleEmployeur,
                view.MatriculFiscal,
                view.MatriculCle,
                view.MatriculCodeTva,
                view.MatriculCategorie,
                view.MatriculEtablissement,
                view.CodeBureau,
                view.ConnectionView.ServerName,
                view.ConnectionView.DatabaseName,
                view.ConnectionView.User,
                view.ConnectionView.Password,
                view.ConnectionView.Type,
                view.CnssTypeMatricule);
        }

        public IEnumerable<SocieteView> GetAll()
        {
            var societes = _service.SocieteGetAll().Select(ToView);
            if (Program.IsMultiSociete) return societes;
            return new List<SocieteView> {societes.First()};
        }

        public IEnumerable<SocieteView> GetSocieteByUser()
        {
            return _service.SocieteGetByUser(_service.User.Id).Select(ToView);          
        }

        private SocieteView ToView(Societe societe)
        {
            var cnxView = new ConnectionView
            {
                ServerName = societe.ServerName,
                User = societe.User,
                DatabaseName = societe.DatabaseName,
                Password = societe.Password,
                Type = societe.Type
            };
            return new SocieteView
            {
                Activite = societe.Activite,
                Adresse = societe.Adresse,
                CodeBureau = societe.CodeBureau,
                CodePostal = societe.CodePostal,
                Id = societe.Id,
                MatriculFiscal = societe.MatriculFiscal,
                MatriculCle = societe.MatriculCle,
                MatriculCodeTva = societe.MatriculCodeTva,
                MatriculCategorie = societe.MatriculCategorie,
                MatriculEtablissement = societe.MatriculEtablissement,
                NumeroEmployeur = societe.NumeroEmployeur,
                Pays = societe.Pays,
                RaisonSocial = societe.RaisonSocial,
                Ville = societe.Ville,
                CleEmployeur = societe.CleEmployeur,
                ConnectionView = cnxView,
                CnssTypeMatricule = societe.CnssTypeMatricule
            };
        }

        internal void Delete(SocieteView currentView)
        {
            if (currentView == null) throw new ArgumentNullException("currentView");
            if (currentView.Id == 0) return;
            _service.SocieteDelete(currentView.Id);
        }

        internal SocieteView InitNew()
        {
            return new SocieteView();
        }

        internal bool IsSocieteExists(SocieteView currentView)
        {
            if (currentView == null) throw new ArgumentNullException("currentView");
            return _service.SocieteGetAll().Any(x => x.RaisonSocial == currentView.RaisonSocial);
        }

        internal void Update(SocieteView currentView)
        {
            if (currentView == null) throw new ArgumentNullException("currentView");
            if (currentView.Id == 0) throw new InvalidOperationException("Opération invalide!");
            _service.SocieteUpdate(currentView.Id,
                currentView.RaisonSocial,
                currentView.Activite,
                currentView.Adresse,
                currentView.CodePostal,
                currentView.Ville,
                currentView.Pays,
                currentView.NumeroEmployeur,
                currentView.CleEmployeur,
                currentView.MatriculFiscal,
                currentView.MatriculCle,
                currentView.MatriculCodeTva,
                currentView.MatriculCategorie,
                currentView.MatriculEtablissement,
                currentView.CodeBureau,
                currentView.ConnectionView.ServerName,
                currentView.ConnectionView.DatabaseName,
                currentView.ConnectionView.User,
                currentView.ConnectionView.Password,
                currentView.ConnectionView.Type,
                currentView.CnssTypeMatricule
            );
            var context = Program.Context;
            // si la societe modifier est la societe courante
            if (context?.Societe?.Id == currentView.Id)
            {
                context.Societe = _service.Societe;
            }
        }

        public void RefreshSource()
        {
            Societe societe = _service.SocieteGetAll().Single(x => x.Id == _service.Societe.Id);

            _service.SetSociete(societe);
        }

        internal void NouveauExercice()
        {
            var exercices = _service.ExerciceGetAll().ToList();
            var currentExercice = _service.Exercice;
            var annee = Convert.ToInt32(currentExercice.Annee);
            while (exercices.Any(x => x.Annee == annee.ToString()))
            {
                annee++;
            }
            _service.ExerciceCreate(annee.ToString());
        }

        internal void DeleteExercice(Exercice exercice)
        {
            _service.DeleteExercice(exercice.Id);
        }

        internal void CloturerExercice(Exercice exercice)
        {
            _service.CloturerExercice(exercice.Id);
        }

        internal IEnumerable<Exercice> GetAllExercice()
        {
            return _service.ExerciceGetAll().OrderBy(x => x.Annee);
        }

        internal IEnumerable<User> GetAllUsers()
        {
            return _service.UserGetAll();
        }

        internal void DeleteUserBySociety(int idSociete)
        {
             _service.DeleteUserSociete(idSociete);
        }
        internal int CreateUserSociete(int idUser,int idSociete)
        {
            return _service.AddUserSociete(idUser, idSociete);
        }

        internal IEnumerable<User> GetUserBySociete(int idSociete)
        {
            return _service.UserGetUserBySociete(idSociete);
        }

        public Societe GetCurrentSociete()
        {
            return _service.Societe;
        }

        public Exercice GetCurrentExercie()
        {
            return _service.Exercice;
        }

        public void ChangeCurrentParametre(SocieteView societeView, Exercice exercice)
        {
            var societe = _service.SocieteGet(societeView.Id);
            _service.SetSociete(societe);
            _service.ChangeExerciceCourant(exercice);
        }


        public void VerifierConnexion(SocieteView view)
        {
            if (view == null) throw new ArgumentNullException("view");

            if (view.ConnectionView == null) throw new ArgumentException("ConnectionView");

            // affecter les valeur de la connection
            var server = view.ConnectionView.ServerName;
            var dataBase = view.ConnectionView.DatabaseName;
            var type = view.ConnectionView.Type == TypeAuthentification.Windows;
            var user = view.ConnectionView.User;
            var password = view.ConnectionView.Password;

            var standardFormat = "data source={0};initial catalog={1};integrated security={2};user={3};password={4};";
            var connectionString = string.Format(standardFormat, server, dataBase, type, user, password);
            try
            {
                using (var con = new SqlConnection(connectionString))
                {
                    con.Open();
                    // connexion etablie, verifiee, valide, ...
                }
            }
            catch
            {
                // echec de la connexion
                throw new ArgumentException("La connexion est erronée!");
            }
        }
    }
}