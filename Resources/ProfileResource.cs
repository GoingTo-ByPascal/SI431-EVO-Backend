namespace GoingTo_API.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CountryResource Country { get; set; }
    }
}
