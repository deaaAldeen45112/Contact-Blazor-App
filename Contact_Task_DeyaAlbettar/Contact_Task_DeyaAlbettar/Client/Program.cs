using Blazored.Toast;
using Contact_Task_DeyaAlbettar;
using Contact_Task_DeyaAlbettar.Service;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Contact_Task_DeyaAlbettar
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
          

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7149/api/") 
            });
            builder.Services.AddScoped<ContactService>();

            await builder.Build().RunAsync();
        }
    }
}