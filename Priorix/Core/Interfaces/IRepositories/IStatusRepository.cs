using Priorix.Core.Entities;
using Priorix.Core.Services;
using System.Collections.Generic;

namespace Priorix.Core.Interfaces.Repositories
{
    public interface IStatusRepository
    {
        List<Status> GetStatuses();
        Status FindById(int id);
        void CreateStatus(Status status);
        void UpdateStatus(Status status);
        void DeleteStatus(int id, object v);
        List<Status> GetStatus();
        object GetV();
    }
}
