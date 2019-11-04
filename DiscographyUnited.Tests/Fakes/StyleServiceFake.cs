using System.Collections.Generic;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.SampleData;

namespace DiscographyUnited.Tests.Fakes
{
    public class StyleServiceFake : IStyleService
    {
        private readonly List<StyleModel> _styleModels;

        public StyleServiceFake()
        {
            _styleModels = new List<StyleModel>
            {
                SampleStyleData.ValidSampleStyle1(),
                SampleStyleData.ValidSampleStyle2(),
                SampleStyleData.ValidSampleStyle3()
            };
        }

        public void Create(StyleModel entity)
        {
            _styleModels.Add(entity);
        }

        public void Delete(StyleModel entity)
        {
            _styleModels.Remove(entity);
        }

        public IEnumerable<StyleModel> FindAll()
        {
            return _styleModels;
        }

        public StyleModel FindById(long id)
        {
            return _styleModels.Find(a => a.Id == id);
        }

        public void Save()
        {
        }

        public void Update(StyleModel entity)
        {
            var index = _styleModels.FindIndex(a => a.Id == entity.Id);
            if (index > 0) _styleModels[index] = entity;
        }
    }
}