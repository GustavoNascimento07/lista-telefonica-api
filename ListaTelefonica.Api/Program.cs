#pragma warning disable

using ListaTelefonica.Api.Services;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Diagnostics; // 👈 Necessário para abrir o navegador automaticamente

var builder = WebApplication.CreateBuilder(args);

////////////////////////////////////
// 🔹 Adicionar serviços da API////
///////////////////////////////////
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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

//////////////////////////////////////////////////////
// 🔹 Registrar o MediatR////////////////////////////
/////////////////////////////////////////////////////
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

///////////////////////////////////
// 🔹 Registrar o ContatoService//
//////////////////////////////////
builder.Services.AddSingleton<ContatoService>();

//////////////////////////////////////////////////////
// 🔹 Definir porta aleatória e configurar servidor //
//////////////////////////////////////////////////////
var random = new Random();
int porta = random.Next(5000, 8000); // Porta aleatória entre 5000 e 8000
string url = $"http://localhost:{porta}";

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(porta);
});

////////////////////////////////
// 🔹 Construir o aplicativo ///
///////////////////////////////
var app = builder.Build();

///////////////////////////////////
// 🔹 Configurar o pipeline HTTP //
//////////////////////////////////
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//////////////////////////////////////////
// 🔹 Abrir o Swagger automaticamente ⚙️ //
//////////////////////////////////////////
app.Lifetime.ApplicationStarted.Register(() =>
{
    var swaggerUrl = $"{url}/swagger";
    Console.WriteLine($"✅ Servidor iniciado na porta {porta}");
    Console.WriteLine($"🌐 Abrindo Swagger: {swaggerUrl}");

    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = swaggerUrl,
            UseShellExecute = true
        });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"⚠️ Não foi possível abrir o navegador: {ex.Message}");
    }
});

/////////////////////////////////
// 🔹 Executar o aplicativo ⚙️ //
/////////////////////////////////
app.Run(url);

////////////////////////////////////////////////////////
// 🔹 Classe Contato (mantida conforme seu código) ⚙️ //
////////////////////////////////////////////////////////
public class Contato
{
    public string Id { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
}

#pragma warning restore
