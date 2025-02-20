namespace Backend.CoreLayer.Entities
{
    public class Tag
    {
        public int tag_id { get; set; }
        public string tag_name { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
