using System.Collections.Generic;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Models;
using DiscographyUnited.Tests.SampleData;

namespace DiscographyUnited.Tests.Fakes
{
    public class GenreServiceFake : IGenreService
    {
        private readonly List<GenreModel> _genreModels;

        public GenreServiceFake()
        {
            _genreModels = new List<GenreModel>
            {
                SampleGenreData.ValidSampleGenre1(),
                SampleGenreData.ValidSampleGenre2(),
                SampleGenreData.ValidSampleGenre2()
            };
        }

        public void Create(GenreModel entity)
        {
            _genreModels.Add(entity);
        }

        public void Delete(GenreModel entity)
        {
            _genreModels.Remove(entity);
        }

        public IEnumerable<GenreModel> FindAll()
        {
            return _genreModels;
        }

        public GenreModel FindById(long id)
        {
            return _genreModels.Find(a => a.Id == id);
        }

        public void Save()
        {
        }

        public void Update(GenreModel entity)
        {
            var index = _genreModels.FindIndex(a => a.Id == entity.Id);
            if (index > 0) _genreModels[index] = entity;
        }
    }
}