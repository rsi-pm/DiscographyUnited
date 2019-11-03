using System.Linq;
using DiscographyUnited.Entities;
using DiscographyUnited.Models;

namespace DiscographyUnited.Mappers
{
    public static class PersonMapper
    {
        public static PersonModel ToModel(PersonEntity personEntity)
        {
            if (personEntity == null)
            {
                return null;
            }
            return new PersonModel
            {
                Id = personEntity.Id,
                FamilyMemberType = personEntity.FamilyMemberType,
                Records = personEntity.Records.Select(RecordMapper.ToModel).ToList(),
                BirthDate = personEntity.BirthDate,
                DeathDate = personEntity.DeathDate,
                Email = personEntity.Email,
                FamilyMembers = personEntity.FamilyMembers.Select(ToModel).ToList(),
                FirstName = personEntity.FirstName,
                IsArtist = personEntity.IsArtist,
                LastName = personEntity.LastName
            };
        }

        public static PersonEntity ToEntity(PersonModel personModel)
        {
            if (personModel == null)
            {
                return null;
            }
            return new PersonEntity
            {
                Id = personModel.Id,
                FamilyMemberType = personModel.FamilyMemberType,
                Records = personModel.Records.Select(RecordMapper.ToEntity).ToList(),
                BirthDate = personModel.BirthDate,
                DeathDate = personModel.DeathDate,
                Email = personModel.Email,
                FamilyMembers = personModel.FamilyMembers.Select(ToEntity).ToList(),
                FirstName = personModel.FirstName,
                IsArtist = personModel.IsArtist,
                LastName = personModel.LastName
            };
        }
    }
}
