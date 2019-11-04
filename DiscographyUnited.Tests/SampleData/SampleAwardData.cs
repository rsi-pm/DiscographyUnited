using System;
using DiscographyUnited.Models;

namespace DiscographyUnited.Tests.SampleData
{
    public static class SampleAwardData
    {
        public static AwardModel ValidSampleAward1()
        {
            return new AwardModel
            {
                Id = 1,
                Name = "Entertainer of the Year",
                Description =
                    "The Academy of Country Music Award for Entertainer of the Year is the biggest competitive category presented at the Academy of Country Music Awards",
                ReceivedDate = new DateTime(2017, 1, 1)
            };
        }

        public static AwardModel ValidSampleAward2()
        {
            return new AwardModel
            {
                Id = 2,
                Name = "Male Vocalist of the Year",
                Description = "Top male vocalist of the year",
                ReceivedDate = new DateTime(2018, 1, 1)
            };
        }

        public static AwardModel ValidSampleAward3()
        {
            return new AwardModel
            {
                Id = 3,
                Name = "Female Vocalist of the Year",
                Description = "Top female vocalist of the year",
                ReceivedDate = new DateTime(2019, 1, 1)
            };
        }
    }
}
