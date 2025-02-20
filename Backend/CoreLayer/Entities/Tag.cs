using System.ComponentModel.DataAnnotations;

namespace Backend.CoreLayer.Entities
{
    public class Tag
    {
        [Key]
        public int tag_id { get; set; }

        public string tag_name { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
