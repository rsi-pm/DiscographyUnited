using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;

namespace DiscographyUnited.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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
