using System;
using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscographyUnited.Repositories
{
    public class StyleRepository : IStyleRepository, IDisposable
    {
        private readonly DiscographyUnitedContext _context;

        public StyleRepository(DiscographyUnitedContext discographyUnitedContext)
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

        public IEnumerable<StyleEntity> FindAll()
        {
            return _context.Style.ToList();
        }

        public StyleEntity FindById(long id)
        {
            return _context.Style.Find(id);
        }

        public void Create(StyleEntity style)
        {
            _context.Style.Add(style);
        }

        public void Update(StyleEntity style)
        {
            _context.Entry(style).State = EntityState.Modified;
            _context.Style.Update(style);
        }

        public void Delete(StyleEntity style)
        {
            _context.Style.Remove(style);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}