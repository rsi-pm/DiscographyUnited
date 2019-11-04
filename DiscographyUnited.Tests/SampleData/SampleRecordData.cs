using System;
using DiscographyUnited.Models;

namespace DiscographyUnited.Tests.SampleData
{
    public static class SampleRecordData
    {
        public static RecordModel ValidRecordRecord1()
        {
            return new RecordModel
            {
                Id = 1,
                Name = "Parallel Lines",
                Description = "Parallel Lines record",
                Genre = SampleGenreData.ValidSampleGenre1(),
                Format = "Parallel Lines",
                ReleaseDate = new DateTime(1978, 1, 1),
                Label = "Chrysalis",
                RecordLength = 137,
                Country = "US",
                Style = SampleStyleData.ValidSampleStyle1()
            };
        }

        public static RecordModel ValidRecordRecord2()
        {
            return new RecordModel
            {
                Id = 2,
                Name = "Ba-Na-Na-Bam-Boo",
                Description = "Ba-Na-Na-Bam-Boo record",
                Genre = SampleGenreData.ValidSampleGenre2(),
                Format = "Vinyl, 7\", 45 RPM, Single",
                ReleaseDate = new DateTime(1987, 4, 1),
                Label = "RCA ‎– BOOM 2",
                RecordLength = 152,
                Country = "UK",
                Style = SampleStyleData.ValidSampleStyle2()
            };
        }

        public static RecordModel ValidRecordRecord3()
        {
            return new RecordModel
            {
                Id = 3,
                Name = "The 2 Live Crew ‎– Live In Concert",
                Description = "The 2 Live Crew ‎– Live In Concert record",
                Genre = SampleGenreData.ValidSampleGenre3(),
                Format = "Parallel Lines",
                ReleaseDate = new DateTime(1990, 1, 1),
                Label = "Effect Records ‎– CDE 3003",
                RecordLength = 193,
                Country = "US",
                Style = SampleStyleData.ValidSampleStyle3()
            };
        }
    }
}
