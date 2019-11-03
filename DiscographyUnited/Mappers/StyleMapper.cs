using DiscographyUnited.Entities;
using DiscographyUnited.Models;

namespace DiscographyUnited.Mappers
{
    public static class StyleMapper
    {
        public static StyleModel ToModel(StyleEntity styleEntity)
        {
            if (styleEntity == null)
            {
                return null;
            }
            return new StyleModel
            {
                Description = styleEntity.Description,
                Id = styleEntity.Id,
                Name = styleEntity.Name
            };
        }

        public static StyleEntity ToEntity(StyleModel styleModel)
        {
            if (styleModel == null)
            {
                return null;
            }
            return new StyleEntity
            {
                Description = styleModel.Description,
                Id = styleModel.Id,
                Name = styleModel.Name
            };
        }
    }
}
