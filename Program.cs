using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyCrudApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;


var builder = WebApplication.CreateBuilder(args);

// Configuracao do DbContext com SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona servicos ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONGURACAO do CORS
builder.Services.AddCors(options =>
{
        options.AddPolicy("PermitirTudo",
        policy =>
        {
                policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configurar o pipeline de requisicoes HTTP
if (app.Environment.IsDevelopment())
{
        app.UseSwagger();
        app.UseSwaggerUI();
}

// Arquivos estaticos

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("PermitirTudo");
app.UseAuthorization();
app.MapControllers();

// Cria o banco de dados if not exist
using (var scope = app.Services.CreateScope())
{
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.EnsureCreated();
}

app.Run();

