using DiscographyUnited.Entities;
using DiscographyUnited.Models;

namespace DiscographyUnited.Mappers
{
    public static class GenreMapper
    {
        public static GenreModel ToModel(GenreEntity genreEntity)
        {
            if (genreEntity == null) return null;
            return new GenreModel
            {
                Description = genreEntity.Description,
                Id = genreEntity.Id,
                Name = genreEntity.Name
            };
        }

        public static GenreEntity ToEntity(GenreModel genreModel)
        {
            if (genreModel == null) return null;
            return new GenreEntity
            {
                Description = genreModel.Description,
                Id = genreModel.Id,
                Name = genreModel.Name
            };
        }
    }
}