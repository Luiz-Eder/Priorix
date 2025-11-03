using Priorix.Core.Entities;
using Priorix.Core.Interfaces.Repositories;
using Priorix.Core.Services;
using Priorix.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Priorix.Data.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly DataContext _db;

        public StatusRepository(DataContext db)
        {
            _db = db;
        }

        public List<Status> GetStatuses()
        {
            return _db.Status.ToList();
        }

        public Status FindById(int id)
        {
            return _db.Status.FirstOrDefault(s => s.Id == id);
        }

        public void CreateStatus(Status status)
        {
            _db.Status.Add(status);
            _db.SaveChanges();
        }

        public void UpdateStatus(Status status)
        {
            _db.Status.Update(status);
            _db.SaveChanges();
        }

        public void DeleteStatus(int id)
        {
            var status = _db.Status.FirstOrDefault(s => s.Id == id);
            if (status != null)
            {
                _db.Status.Remove(status);
                _db.SaveChanges();
            }
        }

        public void DeleteStatus(int id, object v)
        {
            throw new NotImplementedException();
        }

        public List<Status> GetStatus()
        {
            throw new NotImplementedException();
        }

        public object GetV()
        {
            throw new NotImplementedException();
        }
    }
}
