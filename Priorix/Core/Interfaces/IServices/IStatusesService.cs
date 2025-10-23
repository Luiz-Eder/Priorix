using System.Collections.Generic;
using Priorix.Core.Entities;

namespace Priorix.Core.Interfaces.Services
{
    public interface IStatusesService
    {
        List<Statuses> GetStatuses();
        Statuses FindById(int id);
        void CreateStatus(Statuses status);
        void UpdateStatus(Statuses status);
        void DeleteStatus(int id);
    }
}
