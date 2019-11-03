using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Data;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;
using DiscographyUnited.Repositories;

namespace DiscographyUnited.Services
{
    public class GenreService : IBaseService<GenreModel>
    {
        private readonly GenreRepository _genreRepository;

        public GenreService(DiscographyUnitedContext discographyUnitedContext)
        {
            _genreRepository = new GenreRepository(discographyUnitedContext);
        }

        public void Create(GenreModel entity)
        {
            _genreRepository.Create(GenreMapper.ToEntity(entity));
        }

        public void Delete(GenreModel entity)
        {
            _genreRepository.Delete(GenreMapper.ToEntity(entity));
        }

        public IEnumerable<GenreModel> FindAll()
        {
            var recordEntities = _genreRepository.FindAll();
            return recordEntities.Select(GenreMapper.ToModel);

        }

        public GenreModel FindById(long id)
        {
            return GenreMapper.ToModel(_genreRepository.FindById(id));
        }

        public void Save()
        {
            _genreRepository.Save();
        }

        public void Update(GenreModel entity)
        {
            _genreRepository.Update(GenreMapper.ToEntity(entity));
        }
    }
}
