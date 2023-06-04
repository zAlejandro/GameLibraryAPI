namespace gamelibraryAPI.Models
{
    public class game
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genres { get; set; }
        public string Platforms { get; set; }
        public string Developers { get; set; }
        public string Publisher { get; set; }
        public long Cost { get; set; }
    }
}
