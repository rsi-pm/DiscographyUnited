using System;
using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscographyUnited.Repositories
{
    public class RecordRepository : IRecordRepository, IDisposable
    {
        private readonly DiscographyUnitedContext _context;

        public RecordRepository(DiscographyUnitedContext discographyUnitedContext)
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

        public IEnumerable<RecordEntity> FindAll()
        {
            return _context.Record.ToList();
        }

        public RecordEntity FindById(long id)
        {
            return _context.Record.Find(id);
        }

        public void Create(RecordEntity record)
        {
            _context.Record.Add(record);
        }

        public void Update(RecordEntity record)
        {
            _context.Entry(record).State = EntityState.Modified;
            _context.Record.Update(record);
        }

        public void Delete(RecordEntity record)
        {
            _context.Record.Remove(record);
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}