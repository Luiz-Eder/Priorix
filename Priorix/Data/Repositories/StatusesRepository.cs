using System.Collections.Generic;
using System.Linq;
using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Data.Context;
using TaskEntity = Priorix.Core.Entities.Task;

namespace Priorix.Data.Repositories
{
    public class StatusesRepository : IStatusesRepository
    {
        private readonly DataContext _db;

        public StatusesRepository(DataContext db)
        {
            _db = db;
        }

        public List<Statuses> GetStatuses() => _db.Statuses.ToList();

        public Statuses FindById(int id) => _db.Statuses.FirstOrDefault(s => s.Id == id);

        public void CreateStatus(Statuses status)
        {
            _db.Statuses.Add(status);
            _db.SaveChanges();
        }

        public void UpdateStatus(Statuses status)
        {
            _db.Statuses.Update(status);
            _db.SaveChanges();
        }

        public void DeleteStatus(int id)
        {
            var status = _db.Statuses.FirstOrDefault(s => s.Id == id);
            if (status != null)
            {
                _db.Statuses.Remove(status);
                _db.SaveChanges();
            }
        }
    }
}
