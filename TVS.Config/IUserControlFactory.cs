using DevExpress.XtraEditors;

namespace TVS.Config
{
    public interface IUserControlFactory
    {
        T Create<T>() where T : XtraUserControl;
    }
}