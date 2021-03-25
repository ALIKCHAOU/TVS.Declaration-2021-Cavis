using System.Collections.Generic;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface ILigneCnssRepository
    {
        IEnumerable<LigneCnss> GetAll(int categorieNo, int declarationNo);

        IEnumerable<LigneCnss> GetLignesByEmployees(int employeeNo);

        bool Existe(int employeeNo, int declarationNo, string matricule, int categorie);

        IEnumerable<LigneCnss> GetLignesByDeclaration(int declarationNo);

        IEnumerable<LigneCnss> GetLigne(int employeNo , int trim1, int ex1, int trim2, int ex2);


        IEnumerable<LigneCnss> GetAll(int declarationNo, int emplayeNo, string numeroInterne);

        LigneCnss Get(DeclarationCnss declaration, Employee employe);

        LigneCnss Get(int no);

        void Create(LigneCnss ligne);

        void Update(LigneCnss ligne);

        void Delete(LigneCnss ligne);

        bool ExistCategorieHasLigne(int categorieNo);

        void DeleteLigneDeclaration(int declarationNo);
    }
}