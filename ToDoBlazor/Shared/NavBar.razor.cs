using Microsoft.AspNetCore.Components;

namespace ToDoBlazor.Shared
{
    public partial class NavBar
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;
    }
}
