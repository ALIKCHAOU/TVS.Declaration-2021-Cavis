using DevExpress.XtraEditors.DXErrorProvider;

namespace TVS.Declaration
{
    public class AuthentView : IDXDataErrorInfo
    {
        #region Proprietes

        public string Login { get; set; }

        public string Password { get; set; }

        public int SocieteNo { get; set; }

        #endregion Proprietes

        #region Methods

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
            if (propertyName == "Login" && string.IsNullOrEmpty(Login))
            {
                info.ErrorText = "Le champs [Login] est obligatoire!";
            }

            if (propertyName == "Password" && string.IsNullOrEmpty(Password))
            {
                info.ErrorText = "Le champs[Password] est obligatoire!";
            }

            if (propertyName == "SocieteNo" && string.IsNullOrEmpty(SocieteNo.ToString()))
            {
                info.ErrorText = "Societe est obligatoire";
            }
        }

        public void GetError(ErrorInfo info)
        {
        }

        #endregion Methods
    }
}