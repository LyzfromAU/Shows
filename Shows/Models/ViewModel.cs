namespace Shows.Models
{
    public class Venue
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Capacity { get; set; }
        public string? Location { get; set; }
    }
    public class Performance
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public int? VenueId { get; set; }
        public string? Description { get; set; }
    }
    public class Data
    {
        public List<Performance>? Events { get; set; }
        public List<Venue>? Venues { get; set; }
    }
}


