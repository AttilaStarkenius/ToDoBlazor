using ToDoBlazor.Shared.Entities;

namespace ToDoBlazor.Services
{
    public interface IToDoClient
    {
        Task<IEnumerable<Item>?> GetAsync();
        Task<Item?> PostAsync(CreateItem createItem);
        Task<bool> PutAsync(Item item);
        Task<bool> RemoveAsync(string id);
    }
}