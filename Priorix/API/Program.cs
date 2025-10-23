using Microsoft.EntityFrameworkCore;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Services;
using Priorix.Data.Context;
using Priorix.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IStatusesService, StatusesService>();
builder.Services.AddTransient<ITaskHistoryService, TaskHistoryService>();
builder.Services.AddTransient<IPriorizationService, PriorizationService>();

// Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IStatusesRepository, StatusesRepository>();
builder.Services.AddTransient<ITaskHistoryRepository, TaskHistoryRepository>();
builder.Services.AddTransient<IPriorizationMetricsRepository, PriorizationMetricsRepository>();

// Banco de Dados
string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// ✅ Força o Swagger mesmo fora do modo Development
app.UseSwagger();
app.UseSwaggerUI();

// ✅ Remove a necessidade de HTTPS redirection se estiver rodando local
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// ✅ Rotas e autorização
app.UseAuthorization();
app.MapControllers();

// ✅ Redireciona "/" → "/swagger"
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
