using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scrutz.Model
{
    public class MediaType
    {
        [Key] // Specify the primary key attribute
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Media { get; set; }
    }
}
