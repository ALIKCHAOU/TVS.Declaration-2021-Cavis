using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Services;

namespace TVS.Module.Employee.UiAnnexe
{
    public class DeclarationEmployeurController<TL, TP>
        where TL : ILigneAnnexe, new()
        where TP : IPiedAnnexe
    {
        private readonly IAnnexeService<TL, TP> _annexeService;

        public DeclarationEmployeurController(IAnnexeService<TL, TP> annexeService)
        {
            if (annexeService == null)
                throw new ArgumentNullException(nameof(annexeService));

            _annexeService = annexeService;
        }

        public List<TL> Importer(string path)
        {
            //if (string.IsNullOrEmpty(path))
            //    throw new ArgumentNullException(nameof(path));
            var lignes = _annexeService.GetAll(path);
            return lignes.ToList();
        }

        public IList<LigneAnnexeZoneValue> GetZoneValues(TL ligne)
        {
            if (ligne == null)
                throw new ArgumentNullException(nameof(ligne));

            return _annexeService.GetZonesValue(ligne).ToList();
        }

        public IAnnexe<TL, TP> LoadAnnexe()
        {
            return _annexeService.GetAnnexe();
        }

        public IList<LigneAnnexeZoneValue> GetZoneValues()
        {
            return _annexeService.GetZonesValue(new TL()).ToList();
        }

        public TL InitializeLigneAnnexe(IList<LigneAnnexeZoneValue> ligneAnnexeZoneValues)
        {
            return _annexeService.SetLigneEnregistrementValue(ligneAnnexeZoneValues);
        }

        public void Update(TL ligne)
        {
            if (ligne == null) throw new ArgumentNullException(nameof(ligne));
            _annexeService.Update(ligne);
        }

        public List<ValidationFailure> Verifier(TL ligne)
        {
            if (ligne == null) throw new ArgumentNullException(nameof(ligne));
            _annexeService.Update(ligne);
            // verifier les lignes
            var lignesErrors = new List<ValidationFailure>();
            // ajouter les erreurs dans la list
            _annexeService.VerifyLigne(ligne, lignesErrors);

            return lignesErrors;
        }

        public TL GetLigne(int ligneNo)
        {
            return _annexeService.Get(ligneNo);
        }

        public void Delete(TL ligne)
        {
            if (ligne == null) throw new ArgumentNullException(nameof(ligne));
            _annexeService.DeleteLigne(ligne);
        }

        public string VerifierLigne(List<TL> lignes)
        {
            if (lignes == null) throw new ArgumentNullException(nameof(lignes));
            var dictionnaryFailure = new Dictionary<int, List<ValidationFailure>>();
            var counter = 0;
            // get all lignes errors
            foreach (var ligne in lignes)
            {
                counter++;
                // verifier les lignes
                var lignesErrors = new List<ValidationFailure>();
                // ajouter les erreurs dans la list
                if (!_annexeService.VerifyLigne(ligne, lignesErrors))
                {
                    dictionnaryFailure.Add(counter, lignesErrors);
                }
            }
            // concat all errors
            if (dictionnaryFailure.Count == 0)
                return string.Empty;
            var stringBuilder = new StringBuilder();
            //var ligneErreurCounter = 0;
            foreach (var rowDictionnary in dictionnaryFailure)
            {
                foreach (var erreur in rowDictionnary.Value)
                {
                    // afficher les dix premier erreur de la list
                    //ligneErreurCounter++;
                    var str = string.Format("Ligne {0}: {1}", rowDictionnary.Key, erreur);
                    stringBuilder.AppendLine(str);
                    //if (ligneErreurCounter == 10)
                    //    return stringBuilder.ToString();
                }
            }
            // return all erreur
            return stringBuilder.ToString();
        }

        public void Ajouter(List<TL> lignes)
        {
             if (lignes == null)
                throw new InvalidOperationException(nameof(lignes));
            // get erreur
            var erreurList = VerifierLigne(lignes);
            // verifier les lignes
            if (!string.IsNullOrEmpty(erreurList))
                throw new InvalidOperationException(erreurList);
            var failure = new List<ValidationFailure>();
            var counter = 0;
            foreach (var ligne in lignes)
            {
                counter++;
                if (!_annexeService.Ajouter(ligne, failure))
                    throw new InvalidOperationException(string.Format("La ligne [{0}] contient des erreurs!", counter));
            }
        }

        public void Ajouter(TL ligne)
        {
            if (ligne == null)
                throw new InvalidOperationException(nameof(ligne));
            // get erreur
            //var erreurList = VerifierLigne(ligne);
            // verifier les lignes
            //if (!string.IsNullOrEmpty(erreurList))
            //    throw new InvalidOperationException(erreurList);
            var failure = new List<ValidationFailure>();
            if (!_annexeService.Ajouter(ligne, failure))
                throw new InvalidOperationException("La ligne contient des erreurs!");
        }

        public void Exporter(string directory)
        {
            _annexeService.Exporter(directory);
        }

        public void Imprimer()
        {
            _annexeService.Imprimer();
        }
    }
}