using RazorProject.Front.Services;
using RazorProject.Front.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "https://localhost:5001/";
builder.Services.AddHttpClient<IChamadoApiService, ChamadoApiService>(client =>
    client.BaseAddress = new Uri(apiBaseUrl));
builder.Services.AddHttpClient<ICategoriaApiService, CategoriaApiService>(client =>
    client.BaseAddress = new Uri(apiBaseUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chamados}/{action=Index}/{id?}");

app.Run();
