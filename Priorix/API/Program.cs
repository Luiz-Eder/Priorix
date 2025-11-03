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

// ✅ Banco de dados SQLite local (sem senha, pois SQLite nativo não suporta senha)
var connectionString = "Data Source=DB_Priorix.db;";
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString)
);

var app = builder.Build();

// ✅ Swagger habilitado no modo desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ✅ Cria e popula o banco automaticamente
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureCreated(); // cria o banco se não existir
    DatabaseSeeder.Seed(context);
}

app.Run();
