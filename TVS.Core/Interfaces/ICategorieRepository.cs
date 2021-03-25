using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface ICategorieRepository
    {
        IEnumerable<CategorieCnss> GetAllCategories(int societeNo);

        CategorieCnss GetCategorie(int no);

        int Create(CategorieCnss categorie);

        void Update(CategorieCnss categorie);

        void Delete(CategorieCnss categorie);
    }
}