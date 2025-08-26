
namespace CampusEventAggregator.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        //public ICollection<User>? RegisteredUsers { get; set; }
    }
}
//Id ,Title,Description,Date,Location,Category ,Icollections<User>? RegisteredUsers;
