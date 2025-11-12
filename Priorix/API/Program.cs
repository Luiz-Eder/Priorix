using Microsoft.EntityFrameworkCore;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Services;
using Priorix.Data.Context;
using Priorix.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// ✅ MVC + Swagger
=======
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
// ✅ Services
=======
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<ITaskHistoryService, TaskHistoryService>();
builder.Services.AddTransient<IPriorizationService, PriorizationService>();

<<<<<<< HEAD
// ✅ Repositories
=======
>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ITaskHistoryRepository, TaskHistoryRepository>();
builder.Services.AddTransient<IPriorizationMetricsRepository, PriorizationMetricsRepository>();

// ✅ Serviço de IA (Gemini)
<<<<<<< HEAD
var geminiApiKey = "AIzaSyAXayfOAfp0NL9pxDJGykrC38aIO8h8C6g";
builder.Services.AddSingleton(new GeminiService(geminiApiKey));

// ✅ Banco de dados SQLite local
=======
var geminiApiKey = "AIzaSyAXayfOAfp0NL9pxDJGykrC38aIO8h8C6g"; 
builder.Services.AddSingleton(new GeminiService(geminiApiKey));

>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
var connectionString = "Data Source=DB_Priorix.db;";
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString)
);

<<<<<<< HEAD
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
=======
var app = builder.Build();

>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD
// 🚀 Habilita CORS antes de HTTPS/Authorization
app.UseCors("AllowMyVueApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// ✅ Criação automática do banco
=======
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
<<<<<<< HEAD
    DatabaseSeeder.Seed(context);
=======

>>>>>>> 8e90a372d2359bc509180117527eed62a8603956
}

app.Run();
