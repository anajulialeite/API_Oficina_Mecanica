using MinhaAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models; // Adicionando a importação para o Swagger

var builder = WebApplication.CreateBuilder(args);

// Adicionando o DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionando o serviço de controladores
builder.Services.AddControllers(); // Registra os controladores

// Adicionando o Swagger
builder.Services.AddEndpointsApiExplorer(); // Para descobrir endpoints
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
});

var app = builder.Build();

// (seus middlewares aqui)

// Habilitando o Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Habilita o Swagger
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API v1"); // Define o caminho da documentação gerada
        c.RoutePrefix = "Swagger"; // Define o prefixo para acessar o Swagger UI
    });
}

// Redireciona de HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita os controladores da API
app.MapControllers(); // Mapear os controladores

app.Run();


