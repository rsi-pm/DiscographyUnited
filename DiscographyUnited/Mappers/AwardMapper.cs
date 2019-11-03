using DiscographyUnited.Entities;
using DiscographyUnited.Models;

namespace DiscographyUnited.Mappers
{
    public static class AwardMapper
    {
        public static AwardModel ToModel(AwardEntity awardEntity)
        {
            if (awardEntity == null)
            {
                return null;
            }
            return new AwardModel
            {
                Description = awardEntity.Description,
                Id = awardEntity.Id,
                Name = awardEntity.Name
            };
        }

        public static AwardEntity ToEntity(AwardModel awardModel)
        {
            if (awardModel == null)
            {
                return null;
            }
            return new AwardEntity
            {
                Description = awardModel.Description,
                Id = awardModel.Id,
                Name = awardModel.Name
            };
        }
    }
}
