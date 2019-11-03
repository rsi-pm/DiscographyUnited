using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;

namespace DiscographyUnited.Services
{
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository _styleRepository;

        public StyleService(IStyleRepository styleRepository)
        {
            _styleRepository = styleRepository;
        }

        public void Create(StyleModel entity)
        {
            _styleRepository.Create(StyleMapper.ToEntity(entity));
        }

        public void Delete(StyleModel entity)
        {
            _styleRepository.Delete(StyleMapper.ToEntity(entity));
        }

        public IEnumerable<StyleModel> FindAll()
        {
            var recordEntities = _styleRepository.FindAll();
            return recordEntities.Select(StyleMapper.ToModel);

        }

        public StyleModel FindById(long id)
        {
            return StyleMapper.ToModel(_styleRepository.FindById(id));
        }

        public void Save()
        {
            _styleRepository.Save();
        }

        public void Update(StyleModel entity)
        {
            _styleRepository.Update(StyleMapper.ToEntity(entity));
        }
    }
}
