using RegisterSystem.Facade.AbstractViews;

namespace RegisterSystem.Pages.AbstractPages
{
    public interface IIndexModel<TView> where TView : UniqueView
    {
        string[] IndexColumns { get; }
        IList<TView>? Items { get; }
        object? GetValue(string name, TView v);
        string? DisplayName(string name);
    }
}
