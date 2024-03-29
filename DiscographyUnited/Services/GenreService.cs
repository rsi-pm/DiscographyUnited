﻿using System.Collections.Generic;
using System.Linq;
using DiscographyUnited.Interfaces;
using DiscographyUnited.Mappers;
using DiscographyUnited.Models;

namespace DiscographyUnited.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
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
