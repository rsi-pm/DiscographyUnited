using DiscographyUnited.Models;

namespace DiscographyUnited.Tests.SampleData
{
    public static class SampleGenreData
    {
        public static GenreModel ValidSampleGenre1()
        {
            return new GenreModel
            {
                Id = 1,
                Name = "Rock",
                Description =
                    "Rock music is a genre of popular music that originated as 'rock and roll' in the United States in the 1950s"
            };
        }

        public static GenreModel ValidSampleGenre2()
        {
            return new GenreModel
            {
                Id = 2,
                Name = "Electronic",
                Description =
                    "Electronic music is music that employs electronic musical instruments and electronic music technology in its production, an electronic musician being a musician who composes and/or performs such music"
            };
        }

        public static GenreModel ValidSampleGenre3()
        {
            return new GenreModel
            {
                Id = 3,
                Name = "Hip Hop",
                Description =
                    "Hip hop music, also called hip-hop, rap music, or hip-hop music, is a music genre consisting of a stylized rhythmic music that commonly accompanies rapping, a rhythmic and rhyming speech that is chanted"
            };
        }
    }
}
