using Microsoft.EntityFrameworkCore;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Services;
using Priorix.Data.Context;
using Priorix.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITaskService, TaskService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<ITaskHistoryService, TaskHistoryService>();
builder.Services.AddTransient<IPriorizationService, PriorizationService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ITaskRepository, TaskRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ITaskHistoryRepository, TaskHistoryRepository>();
builder.Services.AddTransient<IPriorizationMetricsRepository, PriorizationMetricsRepository>();

// ✅ Serviço de IA (Gemini)
var geminiApiKey = "AIzaSyAXayfOAfp0NL9pxDJGykrC38aIO8h8C6g"; 
builder.Services.AddSingleton(new GeminiService(geminiApiKey));

var connectionString = "Data Source=DB_Priorix.db;";
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(connectionString)
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();

}

app.Run();
