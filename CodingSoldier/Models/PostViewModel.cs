using System.ComponentModel.DataAnnotations;

namespace CodingSoldier.Models
{
    public class PostViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PostTitle { get; set; }
        public string PostUrl { get; set; }

        private string _postContent;
        [Required]
        public string PostContent
        {
            get
            {
                return _postContent;
            }
            set
            {
                _postContent = value;
            }
        }
        [Required]
        public bool IsAQuestion { get; set; }
        public string Tags { get; set; }
        [Required]
        public string CategoryName { get; set; }

        private string TweakPostContent(string postContent)
        {
            if (string.IsNullOrEmpty(postContent) || string.IsNullOrEmpty(PostUrl))
                return postContent;

            var subStringLength = 700;
            while (postContent.Length < subStringLength)
                subStringLength -= 20;

            var result = postContent.Substring(0, subStringLength);
            result += $"<a target='_blank' href={PostUrl}>....</a>";
            return result;
        }
    }
}