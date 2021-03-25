using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IDeclarationBcRepository
    {
        int Create(DeclarationBc declaration);

        IEnumerable<DeclarationBc> GetAll(int exerciceNo, int societeNo);

        IEnumerable<DeclarationBc> GetAll(int societeNo);

        bool ExerciceHasDeclaration(int exerciceNo);

        DeclarationBc GetDeclaration(int trimestre, int exerciceNo, int societeNo);

        DeclarationBc GetDeclaration(int no);

        void Delete(int declarationNo);

        void Cloturer(int declarationNo, bool isCloturer);

        void Archiver(int declarationNo);
    }
}