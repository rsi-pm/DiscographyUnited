using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;
using DiscographyUnited.Repositories;

namespace DiscographyUnited.Services
{
    public class RecordService : IBaseService<RecordModel>
    {
        private readonly RecordRepository _recordRepository;

        public RecordService(DiscographyUnitedContext discographyUnitedContext)
        {
            _recordRepository = new RecordRepository(discographyUnitedContext);
        }

        public void Create(RecordModel entity)
        {
            _recordRepository.Create(RecordMapper.ToEntity(entity));
        }

        public void Delete(RecordModel entity)
        {
            _recordRepository.Delete(RecordMapper.ToEntity(entity));
        }

        public IEnumerable<RecordModel> FindAll()
        {
            var recordEntities = _recordRepository.FindAll();
            return recordEntities.Select(RecordMapper.ToModel);

        }

        public RecordModel FindById(long id)
        {
            return RecordMapper.ToModel(_recordRepository.FindById(id));
        }

        public void Save()
        {
            _recordRepository.Save();
        }

        public void Update(RecordModel entity)
        {
            _recordRepository.Update(RecordMapper.ToEntity(entity));
        }
    }
}
