using System.Collections.Generic;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Interfaces.Services;

namespace Priorix.Core.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository;
        }

        public List<Status> GetStatus()
        {
            var statuses = _repository.GetStatus();
            if (statuses == null || !statuses.Any())
                throw new KeyNotFoundException("Nenhum status encontrado.");
            return statuses;
        }

        public Status FindById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            var status = _repository.FindById(id);
            if (status == null)
                throw new KeyNotFoundException("Status não encontrado.");

            return status;
        }

        public void CreateStatus(Status status)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            if (string.IsNullOrWhiteSpace(status.Name))
                throw new ArgumentException("O nome do status é obrigatório.");

            _repository.CreateStatus(status);
        }

        public void UpdateStatus(Status status)
        {
            if (status == null)
                throw new ArgumentNullException(nameof(status));

            if (status.Id <= 0)
                throw new ArgumentException("ID do status inválido.");

            if (string.IsNullOrWhiteSpace(status.Name))
                throw new ArgumentException("O nome do status é obrigatório.");

            if (_repository.FindById(status.Id) == null)
                throw new KeyNotFoundException("Status não encontrado.");

            _repository.UpdateStatus(status);
        }

        public void DeleteStatus(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            if (_repository.FindById(id) == null)
                throw new KeyNotFoundException("Status não encontrado.");

            _repository.DeleteStatus(id, _repository.GetV());
        }

        public List<Status> GetStatuses()
        {
            return GetStatus();
        }

        object? IStatusService.GetStatus()
        {
            return GetStatus();
        }
    }
}
