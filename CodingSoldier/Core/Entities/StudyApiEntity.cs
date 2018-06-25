using System.ComponentModel.DataAnnotations;

namespace CodingSoldier.Core.Entities
{
    public class StudyApiEntity : IApiEntity
    {
        public int Id { get; set; }
        [Required]
        public string StudyHeader { get; set; }
        [Required]
        public string StudyContent { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
