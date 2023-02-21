namespace AV22YRGO.web.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PortfolioLink { get; set; }
        public ICollection<PortfolioImage> PortfolioImages { get; set; }
        public string ProfilePicture { get; set;}
    }
}