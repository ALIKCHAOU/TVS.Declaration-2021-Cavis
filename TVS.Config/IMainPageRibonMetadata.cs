namespace TVS.Config
{
    public interface IMainPageRibonMetadata
    {
        string PageName { get; }

        string Caption { get; }

        int LevelNo { get; }

        bool AllowTabbedViewHeader { get; }
    }
}