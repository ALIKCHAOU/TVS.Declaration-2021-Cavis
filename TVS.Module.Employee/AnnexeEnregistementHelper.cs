using Ninject.Infrastructure.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TVS.Module.Employee;
using TVS.Module.Employee.Models;
using TVS.Module.Employee.Models.Recap;

namespace TVS.Module.Employee.Services
{
    internal static class AnnexeEnregistementHelper
    {
        public static string GetEnregistrementText<T>(T enregistrement, SharedDetailAnnexe sharedDetailAnnexe)
            where T : IAnnexeEnregistrement, new()
        {
            var exportDetails = GetExportDetails<T>().OrderBy(x => x.Zone.Position);

            var lignebuilder = new StringBuilder();
            foreach (var detail in exportDetails)
            {
                var zoneValue = detail is ExportDetailShared
                    ? typeof(SharedDetailAnnexe).GetProperty(detail.Propriete).GetValue(sharedDetailAnnexe)
                    : typeof(T).GetProperty(detail.Propriete).GetValue(enregistrement);

                var zone = detail.Zone;
                if (!zone.Exported) continue;
                var zoneText = string.Empty;
                switch (zone.Type)
                {
                    case ZoneType.X:
                        zoneText = zoneValue.ToString().PadRight(zone.Longueur).Substring(0, zone.Longueur);
                        break;

                    case ZoneType.N:
                        zoneText =
                            ((decimal) zoneValue*(zone.Longueur == 15 ? 1000 : 100)).ToString("0")
                                .PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.D:
                        zoneText = ((DateTime) zoneValue).ToString("ddMMyyyy").PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.I:
                        zoneText = ((int) zoneValue).ToString("0").PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.E:
                        zoneText = ((int) zoneValue).ToString("0").PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.Xr:
                        zoneText = string.Empty.PadRight(zone.Longueur);
                        break;

                    case ZoneType.Nr:
                        zoneText = string.Empty.PadRight(zone.Longueur, '0');
                        break;

                    default:
                        throw new NotImplementedException("zone type invalide!");
                }
                lignebuilder.Append(zoneText);
            }
            if (lignebuilder.Length != 405)
                throw new InvalidOperationException("Longueur de la ligne est invalide!");
            return lignebuilder.ToString();
        }

        private static IEnumerable<ExportDetail> GetExportDetails<T>()
            where T : IAnnexeEnregistrement, new()
        {
            var type = typeof(T);
            var propertiesInfo = type.GetProperties()
                .Where(pi => pi.HasAttribute<ZoneAttribute>());

            var exportProperties = propertiesInfo.Select(x => new ExportDetailPropertie
            {
                Propriete = x.Name,
                Zone = x.GetCustomAttribute<ZoneAttribute>()
            }).ToList<ExportDetail>();

            var sharedType = typeof(SharedDetailAnnexe);
            var sharedPropertiesInfo = sharedType.GetProperties()
                .Where(pi => pi.HasAttribute<ZoneAttribute>());

            var sharedExportProperties = sharedPropertiesInfo.Select(x => new ExportDetailShared
            {
                Propriete = x.Name,
                Zone = x.GetCustomAttribute<ZoneAttribute>()
            }).ToList<ExportDetail>();

            return exportProperties
                .Union(sharedExportProperties)
                .OrderBy(x => x.Zone.Position);
        }

        public static IEnumerable<LigneAnnexeZoneValue> GetZonesValue<T>(T instance)
            where T : IAnnexeEnregistrement, new()
        {
            return GetExportDetails<T>()
                .Where(x => x.Zone.Type != ZoneType.Xr && x.Zone.Type != ZoneType.Nr && x.Zone.Position >= 25)
                .Select(x =>
                {
                    var zone = x.Zone;
                    var propertie = typeof(T).GetProperty(x.Propriete);
                    return new LigneAnnexeZoneValue
                    {
                        Code = zone.Code,
                        Description = zone.Designation,
                        Type = zone.Type,
                        Value = propertie?.GetValue(instance),
                        EnumType = zone.EnumType,
                        PropertieFieldName = x.Propriete,
                        EditingInGrid = zone.EditingInGrid
                    };
                });
        }

        public static T SetAnnexeEnregistrementValue<T>(IEnumerable<LigneAnnexeZoneValue> zoneValues)
            where T : IAnnexeEnregistrement, new()
        {
            var instance = new T();
            foreach (var zoneVal in zoneValues)
            {
                var propinfo = typeof(T).GetProperty(zoneVal.PropertieFieldName);
                propinfo?.SetValue(instance, zoneVal.Value);
            }

            return instance;
        }

        private static IEnumerable<ExportDetail> GetExportDetailsRecap<T>()
            where T : IEnregistrementAnnexeRecap, new()
        {
            var type = typeof(T);
            var propertiesInfo = type.GetProperties()
                .Where(pi => pi.HasAttribute<ZoneAttribute>());

            var exportProperties = propertiesInfo.Select(x => new ExportDetailPropertie
            {
                Propriete = x.Name,
                Zone = x.GetCustomAttribute<ZoneAttribute>()
            }).ToList<ExportDetail>();

            return exportProperties
                .OrderBy(x => x.Zone.Position);
        }

        public static string GetEnregistrementRecapText<T>(T enregistrement)
            where T : IEnregistrementAnnexeRecap, new()
        {
            var exportDetails = GetExportDetailsRecap<T>().OrderBy(x => x.Zone.Position);

            var lignebuilder = new StringBuilder();
            foreach (var detail in exportDetails)
            {
                var x = typeof(T).GetProperty(detail.Propriete);
                if (x == null) continue;
                var zoneValue = x.GetValue(enregistrement);

                var zone = detail.Zone;
                var zoneText = string.Empty;
                switch (zone.Type)
                {
                    case ZoneType.X:
                        zoneText = zoneValue.ToString().PadRight(zone.Longueur).Substring(0, zone.Longueur);
                        break;

                    case ZoneType.N:
                        zoneText =
                            ((decimal) zoneValue*(zone.Longueur == 15 ? 1000 : 100)).ToString("0")
                                .PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.D:
                        zoneText = ((DateTime) zoneValue).ToString("ddMMyyyy").PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.I:
                        if (zoneValue is bool)
                        {
                            zoneText = Convert.ToInt32(!(bool) zoneValue).ToString().PadLeft(zone.Longueur, '0');
                        }
                        else
                        {
                            zoneText = ((int) zoneValue).ToString("0").PadLeft(zone.Longueur, '0');
                        }
                        break;

                    case ZoneType.E:
                        zoneText = ((int) zoneValue).ToString("0").PadLeft(zone.Longueur, '0');
                        break;

                    case ZoneType.Xr:
                        zoneText = string.Empty.PadRight(zone.Longueur);
                        break;

                    //2018 A1 Decemp03    
                    //case ZoneType.S:
                    //    zoneText = string.Empty.PadRight(20,' ');
                    //    break;

                    case ZoneType.Nr:
                        zoneText = string.Empty.PadRight(zone.Longueur, '0');
                        break;


                    default:
                        throw new NotImplementedException("zone type invalide!");
                }
                lignebuilder.Append(zoneText);
            }
            if (lignebuilder.Length != 38)
                throw new InvalidOperationException("Longueur de la ligne est invalide!");
            return lignebuilder.ToString();
        }
    }
}