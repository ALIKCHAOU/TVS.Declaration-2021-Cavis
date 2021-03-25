using FluentValidation.Results;
using System.Collections.Generic;
using TVS.Module.Employee;
using TVS.Module.Employee.Models;

namespace TVS.Module.Employee.Services
{
    public interface IAnnexeService<TL, TP>
        where TL : ILigneAnnexe
        where TP : IPiedAnnexe
    {
        bool Ajouter(TL ligne, IList<ValidationFailure> errors);

        bool VerifyLigne(TL ligne, IList<ValidationFailure> errors);

        IAnnexe<TL, TP> GetAnnexe();

        void Exporter(string path);

        void Imprimer();

        IList<LigneAnnexeZoneValue> GetZonesValue(TL linge);

        void Update(TL ligne);

        List<TL> GetAll(string path);

        void DeleteLigne(TL ligne);

        TL Get(int ligneNo);

        TL SetLigneEnregistrementValue(IList<LigneAnnexeZoneValue> ligneAnnexeZoneValues);
    }
}