using System;

namespace DiscographyUnited.Models
{
    public class AwardModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
