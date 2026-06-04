using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain.Entities;
using StudentManagement.Domain.Interfaces;
using StudentManagement.Infrastructure.Persistence;
using StudentManagement.Infrastructure.Repositories;
using StudentManagement.Presentation;
using StudentManagement.Application.Services;
using StudentManagement.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddControllers();

builder.Services.AddHttpClient("ApiClient", client =>
{
  client.BaseAddress = new Uri("https://localhost:5126/");
});

builder.Services.AddScoped(sp => new HttpClient
{
  BaseAddress = new Uri(sp.GetRequiredService<NavigationManager>().BaseUri)
});
builder.Services.AddScoped<IRepository<Student, int>, EfRepository<Student, int>>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAntiforgery();

app.MapControllers();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
