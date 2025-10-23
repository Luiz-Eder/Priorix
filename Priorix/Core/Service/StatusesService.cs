using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;
using System.Collections.Generic;

namespace Priorix.Core.Services
{
    public class StatusesService : IStatusesService
    {
        private readonly IStatusesRepository _repository;

        public StatusesService(IStatusesRepository repository)
        {
            _repository = repository;
        }

        public List<Statuses> GetStatuses() => _repository.GetStatuses();

        public Statuses FindById(int id) => _repository.FindById(id);

        public void CreateStatus(Statuses status) => _repository.CreateStatus(status);

        public void UpdateStatus(Statuses status) => _repository.UpdateStatus(status);

        public void DeleteStatus(int id) => _repository.DeleteStatus(id);
    }
}
