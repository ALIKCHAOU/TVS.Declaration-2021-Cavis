using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Core.Interfaces
{
    public interface IExerciceRepository
    {
        IEnumerable<Exercice> GetAll();
 //IEnumerable<Societe> GetAllSoc();

        Exercice Get(string annee);
        Exercice Get(int id);
Exercice GetExercice(int id);


        int Create(string annee);

        void Delete(int no);

        void Cloturer(int no);

        void Decloturer(int no);
    }
}