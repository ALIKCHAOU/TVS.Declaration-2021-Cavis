using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;
using TVS.Core.Interfaces;
using TVS.Core.Models;

namespace TVS.Core
{
    public class DeclarationService
    {
        private IExerciceRepository _exerciceRepository;
        private ISocieteRepository _societeRepository;
        private readonly IUserRepository _userRepository;
        private  IUtilisateurSocieteRepository _userSocieteRepository;

        public DeclarationService(IExerciceRepository exerciceRepository,
            ISocieteRepository societeRepository,
            IUserRepository userRepository,
            CnssService cnssService,
            FcSuspenssionService fcSuspenssionService,
            BcSuspenssionService bcSuspenssionService,
            VirementService virementService,
            LiassService liassService,
              IUtilisateurSocieteRepository userSocieteRepository)
            
        {
            _exerciceRepository = exerciceRepository;
            _societeRepository = societeRepository;
            _userRepository = userRepository;
            _userSocieteRepository = userSocieteRepository;
            FcSuspenssionService = fcSuspenssionService;
            BcSuspenssionService = bcSuspenssionService;
            LiassService = liassService;
            CnssService = cnssService;
            VirementService = virementService;
            CnssService.DeclarationService = this;
            BcSuspenssionService.DeclarationService = this;
            FcSuspenssionService.DeclarationService = this;
            VirementService.DeclarationService = this;
        }

        public Societe Societe { get; set; }
        public User User { get; set; }

        public Exercice Exercice { get; set; }

        public CnssService CnssService { get; private set; }
        public BcSuspenssionService BcSuspenssionService { get; private set; }
        public FcSuspenssionService FcSuspenssionService { get; private set; }
        public LiassService LiassService { get; private set; }
        public VirementService VirementService { get; private set; }

        public void InitService()
        {
            var societe = _societeRepository.GetAll().First();
            SetSociete(societe);
            var exercice = _exerciceRepository.Get(societe.CurrentExerciceNo.Value);
            Exercice = exercice;
            ChangeExerciceCourant(exercice);
        }

        #region Societe 

        public void SetSociete(Societe societe)
        {
            if (societe == null) throw new ArgumentNullException("societe");
            Societe = _societeRepository.Get(societe.Id);
        }
        public void SetUser(string login)
        {
            var user = _userRepository.Get(login);
            if(user == null)throw new InvalidOperationException("Utilisateur invalide");
            User = user;
        }
        public IEnumerable<Societe> SocieteGetAll()
        {
            return _societeRepository.GetAll();
        }

        public IEnumerable<Societe> SocieteGetByUser(int idUser)
        {
            return _societeRepository.GetSocieteByUser(idUser);
        }

        public Societe SocieteGet(int no)
        {
            return _societeRepository.Get(no);
        }

        public int SocieteCreate
        (string raisonSocial,
            string activite,
            string adresse,
            string codePostal,
            string ville,
            string pays,
            string numeroEmployeur,
            string cleEmployeur,
            string matriculFiscal,
            string matriculCle,
            string matriculCodeTva,
            string matriculCategorie,
            string matriculEtablissement,
            string codeBureau,
            string serverName,
            string databaseName,
            string user,
            string password,
            TypeAuthentification type,
            TypeMatriculCnss cnssTypeMatricule
        )
        {
            // checked raison social
            if (string.IsNullOrEmpty(raisonSocial))
                throw new ApplicationException("Raison social invalide!");
            // checked if exist societe by same raison social
            Societe exist = _societeRepository.Get(raisonSocial);
            if (exist != null) throw new ApplicationException("Societe déja existe!");
            var societe = new Societe
            {
                RaisonSocial = raisonSocial,
                CodePostal = codePostal ?? string.Empty,
                CodeBureau = codeBureau ?? string.Empty,
                Activite = activite ?? string.Empty,
                Adresse = adresse ?? string.Empty,
                CleEmployeur = cleEmployeur ?? string.Empty,
                MatriculCategorie = matriculCategorie ?? string.Empty,
                MatriculEtablissement = matriculEtablissement ?? string.Empty,
                NumeroEmployeur = numeroEmployeur ?? string.Empty,
                MatriculCle = matriculCle ?? string.Empty,
                MatriculCodeTva = matriculCodeTva ?? string.Empty,
                MatriculFiscal = matriculFiscal ?? string.Empty,
                Pays = pays ?? string.Empty,
                Ville = ville ?? string.Empty,
                CurrentExerciceNo = Exercice.Id,
                DatabaseName = databaseName,
                Password = password,
                ServerName = serverName,
                Type = type,
                User = user,
                CnssTypeMatricule =cnssTypeMatricule
            };

            return _societeRepository.Create(societe);
        }


        public void SocieteUpdate
        (int no,
            string raisonSocial,
            string activite,
            string adresse,
            string codePostal,
            string ville,
            string pays,
            string numeroEmployeur,
            string cleEmployeur,
            string matriculFiscal,
            string matriculCle,
            string matriculCodeTva,
            string matriculCategorie,
            string matriculEtablissement,
            string codeBureau,
            string serverName,
            string databaseName,
            string user,
            string password,
            TypeAuthentification type,
            TypeMatriculCnss cnssTypeMatricule
        )
        {
            // checked if exist societe by same raison social
            Societe societe = _societeRepository.Get(no);
            if (societe == null) throw new ApplicationException("Societe n'existe pas!");
            societe.RaisonSocial = raisonSocial;
            societe.CodePostal = codePostal;
            societe.CodeBureau = codeBureau;
            societe.Activite = activite;
            societe.Adresse = adresse;
            societe.CleEmployeur = cleEmployeur;
            societe.MatriculCategorie = matriculCategorie;
            societe.MatriculCodeTva = matriculCodeTva;
            societe.MatriculEtablissement = matriculEtablissement;
            societe.NumeroEmployeur = numeroEmployeur;
            societe.MatriculCle = matriculCle;
            societe.MatriculFiscal = matriculFiscal;
            societe.Pays = pays;
            societe.Ville = ville;
            societe.DatabaseName = databaseName;
            societe.Password = password;
            societe.ServerName = serverName;
            societe.Type = type;
            societe.User = user;
            societe.CnssTypeMatricule = cnssTypeMatricule;

            _societeRepository.Update(societe);
            if (Societe.Id == no)
            {
                Societe = _societeRepository.Get(no);
            }
        }

        public void SocieteDelete(int no)
        {
            var societe = _societeRepository.Get(no);
            if (societe == null)
                throw new InvalidOperationException("Societé invalide!");
            if (Societe.Id == societe.Id)
                throw new InvalidOperationException("Impossible de supprimer la société courante!");
            _societeRepository.Delete(no);
        }

        #endregion

        #region Exercice 

        /// <summary>
        /// Get all exercice
        /// </summary>
        /// <returns>return liste des execices</returns>
        public IEnumerable<Exercice> ExerciceGetAll()
        {
            return _exerciceRepository.GetAll();
        }
        public Exercice GetExercice(int no)
        {
            return _exerciceRepository.GetExercice(no);
        }


        public IEnumerable<Societe> GetAllSoc()
        {
            return _societeRepository.GetAll();
        }



        /// <summary>
        /// Creation d'un nouveau exercice 
        /// </summary>
        /// <param name="annee">Nouvelle anne, unique </param>
        /// <returns>id exercice</returns>
        public int ExerciceCreate(string annee)
        {
            // verifier si l'exercice est deja existe
            var isExiste = _exerciceRepository.Get(annee);
            if (isExiste != null)
                throw new InvalidOperationException("Année d'exercice est déja existe!");
            return _exerciceRepository.Create(annee);
        }


        /// <summary>
        ///     Change current exerice
        /// </summary>
        /// <param name="exercice">Exercice</param>
        public void ChangeExerciceCourant(Exercice exercice)
        {
            try
            {
                if (Societe == null) throw new InvalidOperationException("Societé courante invalide!");
                if (exercice == null) throw new ArgumentNullException("exercice");

                Societe societe = _societeRepository.Get(Societe.Id);
                if (societe == null)
                    throw new ApplicationException("Societe invalide!");

                societe.CurrentExerciceNo = exercice.Id;
                _societeRepository.Update(societe);
                Societe = societe;
                Exercice = exercice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///     Delete exercice
        /// </summary>
        /// <param name="no">Id exercice</param>
        public void DeleteExercice(int no)
        {
            // charger l'exercice
            Exercice exercice = _exerciceRepository.Get(no);
            if (exercice == null) throw new InvalidOperationException("Exercice invalide!");
            if (Exercice.Id == no)
                throw new ApplicationException("Impossible du supprimer l'exercice courant");
            // check if exercice has declaration

            //if (_declarationRepository.ExerciceHasDeclaration(no))
            //    throw new InvalidOperationException("Opération invalide! l'exercice contient des déclarations");
            if (Societe.CurrentExerciceNo == no)
                throw new InvalidOperationException("Exercice est en cours d'utilisation!");
            // remove exercice
            _exerciceRepository.Delete(no);
        }

        /// <summary>
        ///     Cloture exercice or decloture
        /// </summary>
        /// <param name="no">Id exercice</param>
        public void CloturerExercice(int no)
        {
            Exercice exercice = _exerciceRepository.Get(no);
            if (exercice == null) throw new InvalidOperationException("Exercice invalide!");
            if (!exercice.IsCloturer)
            {
                // check if exercice archive
                if (exercice.IsArchive) throw new InvalidOperationException("Exercice est déja archivé");

                _exerciceRepository.Cloturer(exercice.Id);
                exercice.IsCloturer = true;
            }
            else
            {
                // check if exercice is archiver
                if (exercice.IsArchive) throw new InvalidOperationException("Exercice est déja archivé");
                _exerciceRepository.Decloturer(exercice.Id);
                exercice.IsCloturer = false;
            }
        }

        #endregion

        #region User 

        public int UserCreate(string login
            ,string password
            ,bool isAdmin
            ,string nom
            ,string prenom
            ,string mail
            ,bool decEmp 
            ,bool decEmpAnnexe1
            ,bool cnss
            ,bool vente 
            ,bool achat 
            ,bool virement
            , bool liasse)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));
            if (password == null) throw new ArgumentNullException(nameof(password));
            var existe = _userRepository.Get(login);
            if (existe != null)
                throw new InvalidOperationException("Utilisateur est déja existe!");
            return _userRepository.Create(new User
            {
                Achat = achat,
                IsAdmin = isAdmin,
                Cnss = cnss,
                DecEmp = decEmp,
                DecEmpAnnexe1 = decEmpAnnexe1,
                Login = login,
                Password = password,
                Vente = vente,
                Virement = virement,
                Mail = mail,
                Nom = nom,
                Prenom = prenom,
                Liasse =liasse
            });
        }
        public void UserUpdate(string login
          , string password
          , bool isAdmin
          , string nom
          , string prenom
          , string mail
          , bool decEmp
          , bool decEmpAnnexe1
          , bool cnss
          , bool vente
          , bool achat
          , bool virement
            ,bool liasse)
        {
            if (login == null) throw new ArgumentNullException(nameof(login));
            if (password == null) throw new ArgumentNullException(nameof(password));
            var existe = _userRepository.Get(login);
            if (existe == null)
                throw new InvalidOperationException("Utilisateur n'est pas existe!");
            existe.Cnss = cnss;
            existe.DecEmp = decEmp;
            existe.DecEmpAnnexe1 = decEmpAnnexe1;
            if (User.Id != existe.Id)
                existe.IsAdmin = isAdmin;
            existe.Password = password;
            existe.Virement = virement;
            existe.Liasse = liasse;
            existe.Mail = mail;
            existe.Nom = nom;
            existe.Prenom = prenom;
            existe.Achat = achat;
            existe.Vente = vente;
            _userRepository.Update(existe);
            if (User.Id == existe.Id)
                User = existe;
        }

        public void UserDelete(string login)
        {
            var existe = _userRepository.Get(login);
            if (existe == null)
                throw new InvalidOperationException("Utilisateur n'est pas existe!");
            if(User.Id == existe.Id)
                throw new InvalidOperationException("Impossible de supprimer l'utilisateur courant!");
            _userRepository.Delete(existe.Id);
        }
        public IEnumerable<User> UserGetAll()
        {
            return _userRepository.GetAll();
        }
        public IEnumerable<User> UserGetUserBySociete(int idSociete)
        {
            return _userRepository.GetAllBySociete(idSociete);
        }

        #endregion

        public bool CanConnect(string login, string password)
        {
            var user = _userRepository.Get(login);
            if (user == null) return false;
            return user.Password == password;
        }

        public void DeleteUserSociete(int no)
        {        
            _userSocieteRepository.DeleteBySociete(no);
        }

        public int AddUserSociete(int idUser, int idSociete)
        {
            return 
            _userSocieteRepository.Create(new UtilisateurSociete {
                IdSociete=idSociete,
                IdUser=idUser
            });
            
        }
    }
}