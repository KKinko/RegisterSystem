using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Facade.AbstractViews;

namespace RegisterSystem.Pages.AbstractPages
{
    public abstract class BasePage<TView, TEntity, TRepo> : PageModel
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : IBaseRepo<TEntity>
    {

        protected readonly TRepo repo;
        protected abstract TView toView(TEntity? entity);
        protected abstract TEntity toObject(TView? item);
        protected abstract IActionResult redirectToIndex();
        [BindProperty] public TView Item { get; set; } = new TView();
        public IList<TView> Items { get; set; } = new List<TView>();
        public string ItemId => Item?.Id ?? string.Empty;
        public BasePage(TRepo r) => repo = r;
        protected abstract IActionResult getCreate();
        protected abstract Task<IActionResult> postCreateAsync();
        protected abstract Task<IActionResult> getDetailsAsync(string id);
        protected abstract Task<IActionResult> getDeleteAsync(string id);
        protected abstract Task<IActionResult> postDeleteAsync(string id);
        protected abstract Task<IActionResult> getEditAsync(string id);
        protected abstract Task<IActionResult> postEditAsync();
        protected abstract Task<IActionResult> getIndexAsync();
        public IActionResult OnGetCreate() => getCreate();
        public async Task<IActionResult> OnPostCreateAsync()
            => await postCreateAsync();
        public async Task<IActionResult> OnGetDetailsAsync(string id)
            => await getDetailsAsync(id);
        public async Task<IActionResult> OnGetDeleteAsync(string id)
            => await getDeleteAsync(id);
        public async Task<IActionResult> OnPostDeleteAsync(string id)
            => await postDeleteAsync(id);
        public async Task<IActionResult> OnGetEditAsync(string id)
            => await getEditAsync(id);
        public async Task<IActionResult> OnPostEditAsync()
            => await postEditAsync();
        public async Task<IActionResult> OnGetIndexAsync()
            => await getIndexAsync();
    }
}
