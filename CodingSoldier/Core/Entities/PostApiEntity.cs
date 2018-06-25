using System.ComponentModel.DataAnnotations;

namespace CodingSoldier.Core.Entities
{
    public class PostApiEntity : IApiEntity
    {
        public int Id { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string PostContent { get; set; }
        [Required]
        public bool IsAQuestion { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
