using MeuSiteEmMVC.Data;
using MeuSiteEmMVC.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Acesse a configuração diretamente do builder
var configuration = builder.Configuration;

// Configure o DbContext com a string de conexão
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("myconn")));

// Injeção de dependência
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // Indica aos navegadores que deve ser acessada via HTTPS e não via HTTP
}

app.UseHttpsRedirection(); // Redireciona uma requisição HTTP para HTTPS
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
