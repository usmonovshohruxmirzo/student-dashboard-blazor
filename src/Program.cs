using Microsoft.AspNetCore.Components;
using NET9.BlazorWebAppServerGlobal.Presentation;
using NET9.BlazorWebAppServerGlobal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StudentService>();

builder.Services.AddControllers();

builder.Services.AddHttpClient("ApiClient", client =>
{
  client.BaseAddress = new Uri("https://localhost:5001/");
});

builder.Services.AddScoped(sp => new HttpClient
{
  BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri)
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAntiforgery();

app.MapControllers();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
