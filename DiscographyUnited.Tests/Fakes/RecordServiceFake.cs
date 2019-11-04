using System.Collections.Generic;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.SampleData;

namespace DiscographyUnited.Tests.Fakes
{
    public class RecordServiceFake : IRecordService
    {
        private readonly List<RecordModel> _recordModels;

        public RecordServiceFake()
        {
            _recordModels = new List<RecordModel>
            {
                SampleRecordData.ValidRecordRecord1(),
                SampleRecordData.ValidRecordRecord2(),
                SampleRecordData.ValidRecordRecord3()
            };
        }

        public void Create(RecordModel entity)
        {
            _recordModels.Add(entity);
        }

        public void Delete(RecordModel entity)
        {
            _recordModels.Remove(entity);
        }

        public IEnumerable<RecordModel> FindAll()
        {
            return _recordModels;
        }

        public RecordModel FindById(long id)
        {
            return _recordModels.Find(a => a.Id == id);
        }

        public void Save()
        {
        }

        public void Update(RecordModel entity)
        {
            var index = _recordModels.FindIndex(a => a.Id == entity.Id);
            if (index > 0) _recordModels[index] = entity;
        }
    }
}