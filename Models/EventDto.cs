namespace RaceDay_MVC.Models
{
    public class EventDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Distance { get; set; }
        public string EventType { get; set; }
        public int OrganiserId { get; set; }
    }
}