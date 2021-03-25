using DevExpress.XtraLayout;

namespace TVS.Config
{
    public interface IOptionUserControl
    {
        int No { get; }

        string Titre { get; }

        string Description { get; }

        bool IsDefault { get; }

        BaseLayoutItem LayoutItem { get; }

        void RefreshSource();
    }
}