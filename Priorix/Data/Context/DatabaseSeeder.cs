using System;
using System.Linq;
using Priorix.Core.Entities;

namespace Priorix.Data.Context
{
    public static class DatabaseSeeder
    {
        public static void Seed(DataContext context)
        {
            // Cria o banco se ainda não existir
            context.Database.EnsureCreated();

            // --- Usuário inicial ---
            if (!context.Users.Any())
            {
                var user = new User
                {
                    Name = "Eder Ribeiro",
                    Email = "eder@teste.com",
                    Password = "Priorix@123"
                };
                context.Users.Add(user);
            }

            // --- Status inicial ---
            if (!context.Status.Any())
            {
                context.Status.AddRange(
                    new Status { Name = "A Fazer" },
                    new Status { Name = "Em Progresso" },
                    new Status { Name = "Concluído" }
                );
            }

            // --- Tarefa inicial ---
            if (!context.Tasks.Any())
            {
                var firstUser = context.Users.FirstOrDefault();
                var firstStatus = context.Status.FirstOrDefault();

                if (firstUser != null && firstStatus != null)
                {
                    context.Tasks.Add(new Core.Entities.Task
                    {
                        Title = "Testar integração com banco SQLite",
                        Description = "Caso de uso para verificar conexão e persistência",
                        DueDate = DateTime.Now.AddDays(7),
                        IsCompleted = false,
                        Priority = 1,
                        ResponsibleUserId = firstUser.Id,
                        StatusId = firstStatus.Id
                    });
                }
            }

            context.SaveChanges();
        }
    }
}
