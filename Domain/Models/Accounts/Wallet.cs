namespace GoingTo_API.Domain.Models
{
    public class Wallet
    {
        //atributes
        public int Id { get; set; }
        public int Points { get; set; }

        // relational
        public User User { get; set; }
    }
}
