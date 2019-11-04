using DiscographyUnited.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscographyUnited.Entities
{
    public class PersonEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Email { get; set; }
        public bool IsArtist { get; set; }
        public FamilyMemberType? FamilyMemberType { get; set; }
        public virtual ICollection<PersonEntity> FamilyMembers { get; set; }
        public virtual ICollection<RecordEntity> Records { get; set; }
        public virtual ICollection<AwardEntity> Awards { get; set; }
    }
}
