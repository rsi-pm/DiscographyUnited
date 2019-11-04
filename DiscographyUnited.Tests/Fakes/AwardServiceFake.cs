using System.Collections.Generic;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.SampleData;

namespace DiscographyUnited.Tests.Fakes
{
    public class AwardServiceFake : IAwardService
    {
        private readonly List<AwardModel> _awardModels;

        public AwardServiceFake()
        {
            _awardModels = new List<AwardModel>
            {
                SampleAwardData.ValidSampleAward1(),
                SampleAwardData.ValidSampleAward2(),
                SampleAwardData.ValidSampleAward3()
            };
        }

        public void Create(AwardModel entity)
        {
            _awardModels.Add(entity);
        }

        public void Delete(AwardModel entity)
        {
            _awardModels.Remove(entity);
        }

        public IEnumerable<AwardModel> FindAll()
        {
            return _awardModels;
        }

        public AwardModel FindById(long id)
        {
            return _awardModels.Find(a => a.Id == id);
        }

        public void Save()
        {
        }

        public void Update(AwardModel entity)
        {
            var index = _awardModels.FindIndex(a => a.Id == entity.Id);
            if (index > 0)
            {
                _awardModels[index] = entity;
            }
        }
    }
}