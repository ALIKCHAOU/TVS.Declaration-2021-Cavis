using System;
using System.Collections.Generic;
using System.Linq;
using TVS.Core;
using TVS.Core.Models;
using TVS.Module.Cnss.UcConfig.Views;

namespace TVS.Module.Cnss.UcConfig.Controller
{
    public class CategorieController
    {
        private readonly DeclarationService _service;

        public CategorieController(DeclarationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
        }

        public void Update(CategorieView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            _service.CnssService.CategorieCnssUpdate(view.Id,
                view.Intitule,
                view.CodeExploitation,
                view.TauxPatronal,
                view.TauxSalarial,
                view.AccidentTravail,
                view.TypeVariablePaie,
                view.CodePaie);
        }

        public int Ajouter(CategorieView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            return _service.CnssService.CategorieCreate(
                view.No,
                view.Intitule,
                view.CodeExploitation,
                view.TauxPatronal,
                view.TauxSalarial,
                view.AccidentTravail,
                view.TypeVariablePaie,
                view.CodePaie);
        }

        public IEnumerable<CategorieView> GetAll()
        {
            return _service.CnssService.GetAllCategories().Select(ToView).OrderBy(x => x.No);
        }

        public CategorieView InitCategorie()
        {
            var categories = _service.CnssService.GetAllCategories().ToList();
            var maxCategorie = !categories.Any() ? -1 : categories.Max(x => x.No);

            return new CategorieView
            {
                No = maxCategorie + 1
            };
        }

        public CategorieView ToView(CategorieCnss categorie)
        {
            return new CategorieView
            {
                CodeExploitation = categorie.CodeExploitation,
                Intitule = categorie.Intitule,
                Id = categorie.Id,
                TauxSalarial = categorie.TauxSalarial,
                TauxPatronal = categorie.TauxPatronal,
                AccidentTravail = categorie.AccidentTravail,
                No = categorie.No,
                CodePaie = categorie.CodePaie,
                TypeVariablePaie = categorie.TypeVariablePaie
            };
        }

        public void DeleteCategorie(CategorieView view)
        {
            if (view == null) throw new ArgumentNullException("view");
            _service.CnssService.CategorieCnssDelete(view.Id);
        }
    }
}