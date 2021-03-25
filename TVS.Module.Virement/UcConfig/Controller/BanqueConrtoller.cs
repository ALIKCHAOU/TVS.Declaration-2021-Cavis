using System;
using System.Collections.Generic;
using TVS.Core;
using TVS.Core.Models;

namespace TVS.Module.Virement.UcConfig.Controller
{
    public class BanqueController
    {
        private readonly DeclarationService _service;

        public BanqueController(DeclarationService service)
        {
            if (service == null) throw new ArgumentNullException("service");
            _service = service;
        }

        public void Update(SocieteBanque view)
        {
            if (view == null) throw new ArgumentNullException("view");
            _service.VirementService.BanqueUpdate(view.Id,
                view.Adresse,
                view.Agence,
                view.Rib);
        }

        public int Ajouter(SocieteBanque view)
        {
            if (view == null) throw new ArgumentNullException("view");
            return _service.VirementService.BanqueCreate(
                view.Adresse,view.Agence,view.Banque,view.Rib);
        }
        public IEnumerable<SocieteBanque> GetAll()
        {
            return _service.VirementService.GetAllBanque();
        }

        public SocieteBanque InitCategorie()
        {
            return new SocieteBanque();
        }

        public void DeleteCategorie(SocieteBanque view)
        {
            if (view == null) throw new ArgumentNullException("view");
            _service.VirementService.BanqueDelete(view.Id);
        }
    }
}