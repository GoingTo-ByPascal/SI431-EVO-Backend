namespace GoingTo_API.Domain.Models
{
    public class Profile
    {
        // atributes
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string CreatedAt { get; set; }
        public Country Country { get; set; }

        // relational
        public int UserId { get; set; }
        public int CountryId { get; set; }
    }
}
