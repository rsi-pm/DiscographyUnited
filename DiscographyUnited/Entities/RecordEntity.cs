using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscographyUnited.Entities
{
    public class RecordEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int RecordLength { get; set; }
        public string Label { get; set; }
        public string Format { get; set; }
        public string Country { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public GenreEntity Genre { get; set; }
        public StyleEntity Style { get; set; }
    }
}
