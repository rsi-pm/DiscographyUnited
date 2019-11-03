using System;
using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscographyUnited.Repositories
{
    public class GenreRepository : IBaseRepository<GenreEntity>, IDisposable
    {
        private readonly DiscographyUnitedContext _context;

        public GenreRepository(DiscographyUnitedContext discographyUnitedContext)
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

        public IEnumerable<GenreEntity> FindAll()
        {
            return _context.Genre.ToList();
        }

        public GenreEntity FindById(long id)
        {
            return _context.Genre.Find(id);
        }

        public void Create(GenreEntity genre)
        {
            _context.Genre.Add(genre);
        }

        public void Update(GenreEntity genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            _context.Genre.Update(genre);
        }

        public void Delete(GenreEntity genre)
        {
            _context.Genre.Remove(genre);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}