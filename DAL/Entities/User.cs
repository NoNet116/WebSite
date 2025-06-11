using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    
    public class User : IdentityUser
    {
        [MaxLength(50)]
        public required string LastName { get; set; }

        [MaxLength(50)]
        public required string FirstName { get; set; }

        [MaxLength(50)]
        public string? FatherName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? BirthDate { get; set; }

        [MaxLength(255)]
        [DataType(DataType.ImageUrl)]
        public string? Image { get; set; }

        [MaxLength(100)]
        public string? Status { get; set; }

        [MaxLength(500)]
        public string? About { get; set; }
        public ICollection<Article>? Articles { get; set; }
        public ICollection<Comment>? Comments { get; set; }


    }
}
