using System;
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

        public List<Status> GetStatus() => _repository.GetStatus();

        public Status FindById(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            var status = _repository.FindById(id);

            if (status == null)
                throw new Exception("Status não encontrado.");

            return status;
        }

        public void CreateStatus(Status status)
        {
            if (status == null)
                throw new Exception("Status inválido.");

            if (status.Name == null || status.Name == "")
                throw new Exception("O nome do status é obrigatório.");

            _repository.CreateStatus(status);
        }

        public void UpdateStatus(Status status)
        {
            if (status == null)
                throw new Exception("Status inválido.");

            if (status.Id <= 0)
                throw new Exception("Id inválido.");

            var existing = _repository.FindById(status.Id);
            if (existing == null)
                throw new Exception("Status não existe.");

            if (status.Name == null || status.Name == "")
                throw new Exception("O nome do status é obrigatório.");

            _repository.UpdateStatus(status);
        }

        public void DeleteStatus(int id)
        {
            if (id <= 0)
                throw new Exception("Id inválido.");

            var existing = _repository.FindById(id);
            if (existing == null)
                throw new Exception("Status não existe.");

            _repository.DeleteStatus(id, _repository.GetV());
        }

        public List<Status> GetStatuses()
        {
            throw new NotImplementedException();
        }

        object? IStatusService.GetStatus()
        {
            return GetStatus();
        }
    }
}
