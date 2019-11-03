using DiscographyUnited.Models;
using DiscographyUnited.Entities;

namespace DiscographyUnited.Mappers
{
    public static class RecordMapper
    {
        public static RecordModel ToModel(RecordEntity recordEntity)
        {
            if (recordEntity == null)
            {
                return null;
            }
            return new RecordModel
            {
                Style = StyleMapper.ToModel(recordEntity.Style),
                Name = recordEntity.Name,
                Description = recordEntity.Description,
                Id = recordEntity.Id,
                Country = recordEntity.Country,
                Format = recordEntity.Format,
                Genre = GenreMapper.ToModel(recordEntity.Genre),
                Label = recordEntity.Label,
                RecordLength = recordEntity.RecordLength,
                ReleaseDate = recordEntity.ReleaseDate
            };
        }

        public static RecordEntity ToEntity(RecordModel recordModel)
        {
            if (recordModel == null)
            {
                return null;
            }
            return new RecordEntity
            {
                Style = StyleMapper.ToEntity(recordModel.Style),
                Name = recordModel.Name,
                Description = recordModel.Description,
                Id = recordModel.Id,
                Country = recordModel.Country,
                Format = recordModel.Format,
                Genre = GenreMapper.ToEntity(recordModel.Genre),
                Label = recordModel.Label,
                RecordLength = recordModel.RecordLength,
                ReleaseDate = recordModel.ReleaseDate
            };
        }
    }
}
