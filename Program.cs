using NET9.BlazorWebAppServerGlobal.App;
using NET9.BlazorWebAppServerGlobal.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StudentService>();

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
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
