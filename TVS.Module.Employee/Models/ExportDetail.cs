using TVS.Module.Employee.Models;

namespace TVS.Module.Employee
{
    public abstract class ExportDetail
    {
        public ZoneAttribute Zone { get; set; }

        public string Propriete { get; set; }

        public override int GetHashCode()
        {
            return new
            {
                Propriete,
                Zone.Position
            }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ExportDetail;
            return other != null && GetHashCode() == other.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Property:{0}, Zone:{1}", Propriete, Zone);
        }
    }
}