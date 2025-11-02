using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configurar o Swagger com título, descrição e versão
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Lista Telefônica API",
        Version = "v1",
        Description = "API de gerenciamento de contatos telefônicos",
        Contact = new OpenApiContact
        {
            Name = "Gustavo Nascimento",
            Email = "gustavo@exemplo.com"
        }
    });
});

var app = builder.Build();

// Configurar o ambiente
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lista Telefônica API v1");
        c.RoutePrefix = string.Empty; // Abre o Swagger direto na página inicial
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
