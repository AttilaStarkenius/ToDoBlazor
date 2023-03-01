using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    //app =>
    //{
    //    //app.UseMiddleware<>
    //})
    .ConfigureServices(services =>
    {
       // services.AddScoped<>();
    })
    .Build();

host.Run();
