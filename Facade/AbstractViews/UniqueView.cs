using System.ComponentModel.DataAnnotations;

namespace RegisterSystem.Facade.AbstractViews
{
    public abstract class UniqueView
    {
        [Required] public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
