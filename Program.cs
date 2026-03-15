using MyCrudApi.Models;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);


// Adiciona servicos ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracao do DbContext com SQLite
var dbPath = Path.Combine(builder.Environment.ContentRootPath, "produtos.db");

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlite($"Data Source={dbPath}"));

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

// PRIMEIRO BLOCO: CRIAR BANCO E TABELAS apos criar fecha a conexao
using (var scope  =  app.Services.CreateScope())
{
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        // GARANTE QUE O BANCO E AS TABELAS EXISTEM
       // dbContext.Database.EnsureDeleted(); //opcional: apaga banco existente
        
       dbContext.Database.EnsureCreated(); // Cria banco e tabelas se nao existirem


        // FECHA A CONEXAO EXPLICITAMENTE
        Console.WriteLine("✅ Banco de dados e tabelas criados com sucesso!");
}

// SEGUNDO BLOCO: Cria um novo contexto para adicionar dados
using (var scope = app.Services.CreateScope())
{
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        dbContext.Database.EnsureCreated();

         try
                {
                         dbContext.Produtos.AddRange(
                                        new Produto{Nome = "Mouse Gamer", Preco = 89.90m, QuantidadeEmEstoque = 15},
                                        new Produto{Nome = "Teclado mecânico", Preco = 199.99m, QuantidadeEmEstoque = 8},
                                        new Produto{Nome = "Monitor 24\"", Preco = 899.99m, QuantidadeEmEstoque = 4 }
                        
                                );
                        
                        dbContext.SaveChanges();
                        Console.WriteLine($"✅ {dbContext.Produtos.Count()} produtos inseridos com sucesso!");

                                
                }


                catch (Exception ex)
                {
                        Console.WriteLine($"❌ Erro detalhado: {ex.Message}");

                }       
        
}

// Configurar o pipeline de requisicoes HTTP
if (app.Environment.IsDevelopment())
{
        app.UseSwagger();
        app.UseSwaggerUI();
}

//else {app.UseHttpsRedirection(); // so em producao}
// Arquivos estaticos

app.UseCors("PermitirTudo");
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();


app.MapControllers();

// ultma  verifiaçãoo antes de rodas
using (var scope = app.Services.CreateScope())
{
        try
        {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var count = dbContext.Produtos.Count();
                Console.WriteLine($"✅ Banco OK! {count} produtos encontrados");
        }

        catch( Exception ex)
        {
                Console.WriteLine($"⚠️ Aviso: {ex.Message}");
        }
}

app.Run();

