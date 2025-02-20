namespace Backend.CoreLayer.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public ICollection<MovieSeriesTag> MovieSeriesTags { get; set; }
    }
}
