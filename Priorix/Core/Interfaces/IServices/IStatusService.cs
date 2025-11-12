using Priorix.Core.Entities;
using Priorix.Core.Services;
using System.Collections.Generic;

namespace Priorix.Core.Interfaces.Services
{
    public interface IStatusService
    {
        List<Status> GetStatuses();
        Status FindById(int id);
        void CreateStatus(Status status);
        void UpdateStatus(Status status);
        void DeleteStatus(int id);
        object? GetStatus();
    }
}
