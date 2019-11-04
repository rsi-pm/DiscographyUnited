using System.Collections.Generic;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.SampleData;

namespace DiscographyUnited.Tests.Fakes
{
    public class PersonServiceFake : IPersonService
    {
        private readonly List<PersonModel> _personModels;

        public PersonServiceFake()
        {
            _personModels = new List<PersonModel>
            {
                SamplePersonData.ValidSamplePerson1(),
                SamplePersonData.ValidSamplePerson2(),
                SamplePersonData.ValidSamplePerson3()
            };
        }

        public void Create(PersonModel entity)
        {
            _personModels.Add(entity);
        }

        public void Delete(PersonModel entity)
        {
            _personModels.Remove(entity);
        }

        public IEnumerable<PersonModel> FindAll()
        {
            return _personModels;
        }

        public PersonModel FindById(long id)
        {
            return _personModels.Find(a => a.Id == id);
        }

        public void Save()
        {
        }

        public void Update(PersonModel entity)
        {
            var index = _personModels.FindIndex(a => a.Id == entity.Id);
            if (index > 0) _personModels[index] = entity;
        }
    }
}