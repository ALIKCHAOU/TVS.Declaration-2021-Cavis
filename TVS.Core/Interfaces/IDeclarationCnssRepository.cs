using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IDeclarationCnssRepository
    {
        int Create(DeclarationCnss declaration);

        IEnumerable<DeclarationCnss> GetAll(int exerciceNo, int societeNo);

        IEnumerable<DeclarationCnss> GetAll(int societeNo);

        bool ExerciceHasDeclaration(int exerciceNo);

        DeclarationCnss GetDeclaration(int trimestre, int exerciceNo, int societeNo);

        DeclarationCnss GetDeclaration(int no);
        DeclarationCnss GetDeclarationCnss(int no);


        //   IEnumerable<Societe> SocieteGetAll();
        IEnumerable<DeclarationCnss> GetDeclarationByTrimestre(int trimestre ,int  exerciceNo, int trimestreF, int exerciceNoF);

        void Delete(int declarationNo);

        void Cloturer(int declarationNo, bool isCloturer);

        void Archiver(int declarationNo);
    }
}