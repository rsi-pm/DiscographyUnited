using System;
using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscographyUnited.Repositories
{
    public class AwardRepository : IBaseRepository<AwardEntity>, IDisposable
    {
        private readonly DiscographyUnitedContext _context;

        public AwardRepository(DiscographyUnitedContext discographyUnitedContext)
        {
            _context = discographyUnitedContext;
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<AwardEntity> FindAll()
        {
            return _context.Award.ToList();
        }

        public AwardEntity FindById(long id)
        {
            return _context.Award.Find(id);
        }

        public void Create(AwardEntity award)
        {
            _context.Award.Add(award);
        }

        public void Update(AwardEntity award)
        {
            _context.Entry(award).State = EntityState.Modified;
            _context.Award.Update(award);
        }

        public void Delete(AwardEntity award)
        {
            _context.Award.Remove(award);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}