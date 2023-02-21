using System.ComponentModel.DataAnnotations.Schema;

namespace AV22YRGO.web.Models
{
    public class PortfolioImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProfileId { get; set; }
        [ForeignKey("ProfileId")]
        public Profile Profile { get; set; }
    }
}