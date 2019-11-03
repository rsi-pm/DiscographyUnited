using System;

namespace DiscographyUnited.Models
{
    public class RecordModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int RecordLength { get; set; }
        public string Label { get; set; }
        public string Format { get; set; }
        public string Country { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public GenreModel Genre { get; set; }
        public StyleModel Style { get; set; }
    }
}
