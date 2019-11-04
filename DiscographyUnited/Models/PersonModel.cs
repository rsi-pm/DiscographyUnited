using DiscographyUnited.Data;
using System;
using System.Collections.Generic;

namespace DiscographyUnited.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Email { get; set; }
        public bool IsArtist { get; set; }
        public FamilyMemberType? FamilyMemberType { get; set; }
        public virtual ICollection<PersonModel> FamilyMembers { get; set; }
        public virtual ICollection<RecordModel> Records { get; set; }
        public virtual ICollection<AwardModel> Awards { get; set; }
    }
}
