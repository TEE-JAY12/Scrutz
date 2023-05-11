using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrutz.Model
{
    public class AccountSetting
    {
        [Key] // Specify the primary key attribute
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? BrandName { get; set; }
        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get;set; }
        
        //public string? BrandLogo { get; set; }
        public string? WebsiteAddress { get; set; }

        public string? Colour { get; set;}

        public string CompanyLogo { get; set; }

    }
}
