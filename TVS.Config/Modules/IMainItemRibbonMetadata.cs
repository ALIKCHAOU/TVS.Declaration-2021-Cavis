namespace TVS.Config.Modules
{
    public enum TypeButton
    {
        SimpleButton,
        CheckButton
    }

    public interface IMainItemRibbonMetadata
    {
        string ItemName { get; }

        string Caption { get; }

        int LevelNo { get; }

        TypeButton TypeButton { get; }
    }
}