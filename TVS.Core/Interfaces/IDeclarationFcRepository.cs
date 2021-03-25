using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IDeclarationFcRepository
    {
        int Create(DeclarationFc declaration);

        IEnumerable<DeclarationFc> GetAll(int exerciceNo, int societeNo);

        IEnumerable<DeclarationFc> GetAll(int societeNo);

        bool ExerciceHasDeclaration(int exerciceNo);

        DeclarationFc GetDeclaration(int trimestre, int exerciceNo, int societeNo);

        DeclarationFc GetDeclaration(int no);

        void Delete(int declarationNo);

        void Cloturer(int declarationNo, bool isCloturer);

        void Archiver(int declarationNo);
    }
}