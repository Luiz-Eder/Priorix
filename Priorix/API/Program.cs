using Microsoft.EntityFrameworkCore;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Services;
using Priorix.Data.Context;
using Priorix.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ✅ MVC + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<ITaskHistoryService, TaskHistoryService>();
builder.Services.AddTransient<IPriorizationService, PriorizationService>();

// ✅ Repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ITaskHistoryRepository, TaskHistoryRepository>();
builder.Services.AddTransient<IPriorizationMetricsRepository, PriorizationMetricsRepository>();

// ✅ Serviço de IA (Gemini)
var geminiApiKey = "Chave";
builder.Services.AddSingleton(new GeminiService(geminiApiKey));

// ✅ Banco de dados SQLite local
var connectionString = "Data Source=DB_Priorix_v3.db;";
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString)
);

// 🔒 ADIÇÃO: CORS - Permitir comunicação com o front Vue
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyVueApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173") // Porta padrão do Vite (Vue)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // se for necessário cookies/autenticação
    });
});

var app = builder.Build();

// ✅ Swagger no modo dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🚀 Habilita CORS antes de HTTPS/Authorization
app.UseCors("AllowMyVueApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ✅ Criação automática do banco
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
    DatabaseSeeder.Seed(context);
}

app.Run();
