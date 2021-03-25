using DevExpress.XtraEditors.DXErrorProvider;
using TVS.Core.Enums;

namespace TVS.Declaration.Societes.Views
{
    public class ConnectionView : IDXDataErrorInfo
    {
        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public TypeAuthentification Type { get; set; }

        public void GetError(ErrorInfo info)
        {
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
        }
    }
}