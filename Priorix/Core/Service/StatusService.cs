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

        public Status FindById(int id) => _repository.FindById(id);

        public void CreateStatus(Status status) => _repository.CreateStatus(status);

        public void UpdateStatus(Status status) => _repository.UpdateStatus(status);

        public void DeleteStatus(int id) => _repository.DeleteStatus(id, _repository.GetV());

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
