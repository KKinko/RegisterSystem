using Microsoft.AspNetCore.Mvc;
using RegisterSystem.Aids;
using RegisterSystem.Domain.AbstractEntities;
using RegisterSystem.Domain.IRepos;
using RegisterSystem.Facade.AbstractViews;
using System.ComponentModel;

namespace RegisterSystem.Pages.AbstractPages
{
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>, IIndexModel<TView>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : ICrudRepo<TEntity>
    {
        protected CrudPage(TRepo r) : base(r) { }
        protected override IActionResult getCreate() => Page();
        protected override IActionResult redirectToIndex() => RedirectToPage("/Events/Index", "Index");
        protected virtual async Task<IActionResult> getItemPage(string id)
        {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        protected override async Task<IActionResult> getDetailsAsync(string id) => await getItemPage(id);
        protected override async Task<IActionResult> getDeleteAsync(string id) => await getItemPage(id);
        protected override async Task<IActionResult> getEditAsync(string id) => await getItemPage(id);
        protected override async Task<IActionResult> postCreateAsync()
        {
            if (!ModelState.IsValid) return Page();
            _ = await repo.AddAsync(toObject(Item));
            return redirectToIndex();
        }
        protected override async Task<IActionResult> postDeleteAsync(string id)
        {
            if (id == null) return NotFound();
            _ = await repo.DeleteAsync(id);
            return redirectToIndex();
        }
        protected override async Task<IActionResult> postEditAsync()
        {
            if (!ModelState.IsValid) return Page();
            var obj = toObject(Item);
            var updated = await repo.UpdateAsync(obj);
            return !updated ? NotFound() : redirectToIndex();
        }
        protected override async Task<IActionResult> getIndexAsync()
        {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            foreach (var obj in list)
            {
                var v = toView(obj);
                Items.Add(v);
            }
            return Page();
        }
        private async Task<TView> getItem(string id)
            => toView(await repo.GetAsync(id));
        public virtual string[] IndexColumns => Array.Empty<string>();
        public virtual object? GetValue(string name, TView v)
            => Safe.Run(() =>
            {
                var pi = v?.GetType()?.GetProperty(name);
                return pi?.GetValue(v);
            }, null);
        public string? DisplayName(string name) => Safe.Run(() =>
        {
            var p = typeof(TView).GetProperty(name);
            var a = p?.CustomAttributes?
                .FirstOrDefault(x => x.AttributeType == typeof(DisplayNameAttribute));
            return a?.ConstructorArguments[0].Value?.ToString() ?? name;
        }, name);
    }
}
