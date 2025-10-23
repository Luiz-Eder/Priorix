using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Repositories
{
    public interface IStatusesRepository
    {
        List<Statuses> GetStatuses();
        Statuses FindById(int id);
        void CreateStatus(Statuses status);
        void UpdateStatus(Statuses status);
        void DeleteStatus(int id);
    }
}
