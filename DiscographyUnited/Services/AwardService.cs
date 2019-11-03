using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;
using DiscographyUnited.Repositories;

namespace DiscographyUnited.Services
{
    public class AwardService : IBaseService<AwardModel>
    {
        private readonly AwardRepository _awardRepository;

        public AwardService(DiscographyUnitedContext discographyUnitedContext)
        {
            _awardRepository = new AwardRepository(discographyUnitedContext);
        }

        public void Create(AwardModel entity)
        {
            _awardRepository.Create(AwardMapper.ToEntity(entity));
        }

        public void Delete(AwardModel entity)
        {
            _awardRepository.Delete(AwardMapper.ToEntity(entity));
        }

        public IEnumerable<AwardModel> FindAll()
        {
            var recordEntities = _awardRepository.FindAll();
            return recordEntities.Select(AwardMapper.ToModel);

        }

        public AwardModel FindById(long id)
        {
            return AwardMapper.ToModel(_awardRepository.FindById(id));
        }

        public void Save()
        {
            _awardRepository.Save();
        }

        public void Update(AwardModel entity)
        {
            _awardRepository.Update(AwardMapper.ToEntity(entity));
        }
    }
}
