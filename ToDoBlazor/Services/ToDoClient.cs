using System.Net.Http.Headers;
using System.Net.Http.Json;
using ToDoBlazor.Shared.Entities;

namespace ToDoBlazor.Services
{
    public class ToDoClient : IToDoClient
    {
        private readonly HttpClient httpClient;

        public ToDoClient(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            //  this.httpClient.BaseAddress = new Uri("https://localhost:7149");
            //this.httpClient.BaseAddress = new Uri("https://todoblazorapi.azurewebsites.net");

            var baseAddress = configuration.GetSection("BaseAddress").Value;

            ArgumentNullException.ThrowIfNull(baseAddress, nameof(configuration));

            this.httpClient.BaseAddress = new Uri(baseAddress);
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Item>?> GetAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Item>>("api/todos");
        }

        public async Task<Item?> PostAsync(CreateItem createItem)
        {
            var response = await httpClient.PostAsJsonAsync("api/todos", createItem);
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Item>() : null;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            return (await httpClient.DeleteAsync($"api/todos/{id}")).IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync(Item item)
        {
            return (await httpClient.PutAsJsonAsync($"api/todos/{item.Id}", item)).IsSuccessStatusCode;
        }
    }
}
