using Microsoft.EntityFrameworkCore;
using MinhaSolucaoDDD.Application.Services;
using MinhaSolucaoDDD.Infrastructure.Data;
using MinhaSolucaoDDD.Domain.Repositories;
using MinhaSolucaoDDD.Infrastructure.Repositories;
using MinhaSolucaoDDD.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar Entity Framework Core para usar InMemoryDatabase
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("MinhaSolucaoDDD"));

// Configurar servi�os
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configurar o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

app.Run();