using System;
using System.Collections.Generic;
using DiscographyUnited.Data;
using DiscographyUnited.Models;

namespace DiscographyUnited.Tests.SampleData
{
    public static class SamplePersonData
    {
        public static PersonModel ValidSamplePerson1()
        {
            return new PersonModel
            {
                Id = 1,
                BirthDate = new DateTime(1946, 3, 6),
                Email = "David.Gilmour@musicstore.net",
                FirstName = "David",
                LastName = "Gilmour",
                FamilyMembers = new List<PersonModel> { ValidSamplePerson2(), ValidSamplePerson3()},
                IsArtist = true
            };
        }

        public static PersonModel ValidSamplePerson2()
        {
            return new PersonModel
            {
                Id = 2,
                BirthDate = new DateTime(1994, 4, 29),
                Email = "Polly.Samson@musicstore.net",
                FirstName = "Polly",
                LastName = "Samson",
                IsArtist = false,
                FamilyMemberType = FamilyMemberType.Wife
            };
        }

        public static PersonModel ValidSamplePerson3()
        {
            return new PersonModel
            {
                Id = 3,
                BirthDate = new DateTime(1997, 1, 1),
                Email = "Gabriel.Gilmour@musicstore.net",
                FirstName = "Gabriel",
                LastName = "Gilmour",
                IsArtist = false,
                FamilyMemberType = FamilyMemberType.Son
            };
        }
    }
}
