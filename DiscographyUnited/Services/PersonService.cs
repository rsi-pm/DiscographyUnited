using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;
using DiscographyUnited.Repositories;

namespace DiscographyUnited.Services
{
    public class PersonService : IBaseService<PersonModel>
    {
        private readonly PersonRepository _personRepository;

        public PersonService(DiscographyUnitedContext discographyUnitedContext)
        {
            _personRepository = new PersonRepository(discographyUnitedContext);
        }

        public void Create(PersonModel entity)
        {
            _personRepository.Create(PersonMapper.ToEntity(entity));
        }

        public void Delete(PersonModel entity)
        {
            _personRepository.Delete(PersonMapper.ToEntity(entity));
        }

        public IEnumerable<PersonModel> FindAll()
        {
            var recordEntities = _personRepository.FindAll();
            return recordEntities.Select(PersonMapper.ToModel);

        }

        public PersonModel FindById(long id)
        {
            return PersonMapper.ToModel(_personRepository.FindById(id));
        }

        public void Save()
        {
            _personRepository.Save();
        }

        public void Update(PersonModel entity)
        {
            _personRepository.Update(PersonMapper.ToEntity(entity));
        }
    }
}
