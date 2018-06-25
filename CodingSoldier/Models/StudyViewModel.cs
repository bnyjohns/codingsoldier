using System.ComponentModel.DataAnnotations;

namespace CodingSoldier.Models
{
    public class StudyViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        //[AllowHtml]
        public string StudyHeader { get; set; }
        //[AllowHtml]
        [Required]
        public string StudyContent { get; set; }
        [Required]
        public string CategoryName { get; set; }     
    }
}