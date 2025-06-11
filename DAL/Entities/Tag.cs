using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Article> Articles = new List<Article>();
    }
}
