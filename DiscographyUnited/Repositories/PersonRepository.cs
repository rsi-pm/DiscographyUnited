using System;
using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Entities;
using Microsoft.EntityFrameworkCore;

namespace DiscographyUnited.Repositories
{
    public class PersonRepository : IBaseRepository<PersonEntity>, IDisposable
    {
        private readonly DiscographyUnitedContext _context;

        public PersonRepository(DiscographyUnitedContext discographyUnitedContext)
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

        public IEnumerable<PersonEntity> FindAll()
        {
            return _context.Person.ToList();
        }

        public PersonEntity FindById(long id)
        {
            return _context.Person.Find(id);
        }

        public void Create(PersonEntity person)
        {
            _context.Person.Add(person);
        }

        public void Update(PersonEntity person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.Person.Update(person);
        }

        public void Delete(PersonEntity person)
        {
            _context.Person.Remove(person);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}