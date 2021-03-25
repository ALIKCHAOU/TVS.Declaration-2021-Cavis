using System;
using TVS.Module.Employee.Models;

namespace TVS.Module.Employee
{
    public class LigneAnnexeZoneValue
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public ZoneType Type { get; set; }

        public object Value { get; set; }

        public Type EnumType { get; set; }

        public string PropertieFieldName { get; set; }

        public bool EditingInGrid { get; set; }
    }
}