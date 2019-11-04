using DiscographyUnited.Models;

namespace DiscographyUnited.Tests.SampleData
{
    public static class SampleStyleData
    {
        public static StyleModel ValidSampleStyle1()
        {
            return new StyleModel
            {
                Id = 1,
                Name = "Pop Rock",
                Description = "Pop Rock grew out of Rock & Roll and Beat in the 1960s."
            };
        }

        public static StyleModel ValidSampleStyle2()
        {
            return new StyleModel
            {
                Id = 2,
                Name = "House",
                Description = "In early 1980s Chicago, club visitors named House the mixture of music played by Frankie Knuckles at the discotheque 'Warehouse'"
            };
        }

        public static StyleModel ValidSampleStyle3()
        {
            return new StyleModel
            {
                Id = 3,
                Name = "Punk",
                Description = "Punk rock (or 'punk') is a rock music genre that emerged in the mid-1970s in the United States, United Kingdom, and Australia."
            };
        }
    }
}
