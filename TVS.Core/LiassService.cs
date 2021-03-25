using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Interfaces;
using TVS.Core.Interfaces.Liass;
using TVS.Core.Models;

namespace TVS.Core
{
   public class LiassService
    {
        private readonly ISocieteRepository _societeRepository;
        private readonly IF6001Repository _f6001Repo;
        private readonly IF6002Repository _f6002Repo;
        private readonly IF6003Repository _f6003Repo;
        private readonly IF6004Repository _f6004Repo;
        private readonly IF6005Repository _f6005Repo;
        private readonly IF6004ModeleAutorsieRepository _f6004ModeleAutorsieRepo;
        private readonly IF6301Repository _f6301Repo;
        private readonly IF6303Repository _f6303Repo;
        private readonly IF6304Repository _f6304Repo;


        public LiassService(ISocieteRepository societeRepository
            , IF6001Repository f6001Repo
            , IF6002Repository f6002Repo
            , IF6003Repository f6003Repo
            , IF6004Repository f6004Repo
            , IF6005Repository f6005Repo, IF6004ModeleAutorsieRepository f6004MauRepo
            , IF6301Repository f6301Repo, IF6303Repository f6303Repo, IF6304Repository f6304Repo)
        {
            _societeRepository = societeRepository;
            _f6001Repo = f6001Repo;
            _f6002Repo = f6002Repo;
            _f6003Repo = f6003Repo;
            _f6004Repo = f6004Repo;
            _f6005Repo = f6005Repo;
            _f6004ModeleAutorsieRepo = f6004MauRepo;
            _f6301Repo = f6301Repo;
            _f6303Repo = f6303Repo;
            _f6304Repo = f6304Repo;

        }


        public Models.Liass.F6001 F6001Get(int Societe,int exercice)
        {
            var result =  _f6001Repo.Get(Societe, exercice);
            return result;
        }

        public void F6001Create(Core.Models.Liass.F6001 f6001)
        {
            _f6001Repo.Create(f6001);
        }
        public void F6001Update(Core.Models.Liass.F6001 f6001)
        {
            _f6001Repo.Update(f6001);
        }

        public Models.Liass.F6002 F6002Get(int Societe, int exercice)
        {
            var result = _f6002Repo.Get(Societe, exercice);
            return result;
        }

        public void F6002Create(Core.Models.Liass.F6002 f6002)
        {
            _f6002Repo.Create(f6002);
        }
        public void F6002Update(Core.Models.Liass.F6002 f6002)
        {
            _f6002Repo.Update(f6002);
        }
        public Models.Liass.F6003 F6003Get(int Societe, int exercice)
        {
            var result = _f6003Repo.Get(Societe, exercice);
            return result;
        }

        public void F6003Create(Core.Models.Liass.F6003 f6003)
        {
            _f6003Repo.Create(f6003);
        }
        public void F6003Update(Core.Models.Liass.F6003 f6003)
        {
            _f6003Repo.Update(f6003);
        }
        public Models.Liass.F6004 F6004Get(int Societe, int exercice)
        {
            var result = _f6004Repo.Get(Societe, exercice);
            return result;
        }

        public void F6004Create(Core.Models.Liass.F6004 f6004)
        {
            _f6004Repo.Create(f6004);
        }
        public void F6004Update(Core.Models.Liass.F6004 f6004)
        {
            _f6004Repo.Update(f6004);
        }



        public Models.Liass.F6004ModeleAutorsie F6004ModeleAutorsieGet(int Societe, int exercice)
        {
            var result = _f6004ModeleAutorsieRepo.Get(Societe, exercice);
            return result;
        }

        public void F6004ModeleAutorsieCreate(Core.Models.Liass.F6004ModeleAutorsie f6004)
        {
            _f6004ModeleAutorsieRepo.Create(f6004);
        }
        public void F6004ModeleAutorsieUpdate(Core.Models.Liass.F6004ModeleAutorsie f6004)
        {
            _f6004ModeleAutorsieRepo.Update(f6004);
        }



        public Models.Liass.F6005 F6005Get(int Societe, int exercice)
        {
            var result = _f6005Repo.Get(Societe, exercice);
            return result;
        }

        public void F6005Create(Core.Models.Liass.F6005 f6005)
        {
            _f6005Repo.Create(f6005);
        }
        public void F6005Update(Core.Models.Liass.F6005 f6005)
        {
            _f6005Repo.Update(f6005);
        }

        public Models.Liass.F6301 F6301Get(int Societe, int exercice)
        {
            var result = _f6301Repo.Get(Societe, exercice);
            return result;
        }

        public void F6301Create(Core.Models.Liass.F6301 f6301)
        {
            _f6301Repo.Create(f6301);
        }
        public void F6301Update(Core.Models.Liass.F6301 f6301)
        {
            _f6301Repo.Update(f6301);
        }

        public Models.Liass.F6303 F6303Get(int Societe, int exercice)
        {
            var result = _f6303Repo.Get(Societe, exercice);
            return result;
        }

        public void F6303Create(Core.Models.Liass.F6303 f6303)
        {
            _f6303Repo.Create(f6303);
        }
        public void F6303Update(Core.Models.Liass.F6303 f6303)
        {
            _f6303Repo.Update(f6303);
        }

        public Models.Liass.F6304 F6304Get(int Societe, int exercice)
        {
            var result = _f6304Repo.Get(Societe, exercice);
            return result;
        }

        public void F6304Create(Core.Models.Liass.F6304 f6304)
        {
            _f6304Repo.Create(f6304);
        }
        public void F6304Update(Core.Models.Liass.F6304 f6304)
        {
            _f6304Repo.Update(f6304);
        }
    }
}
