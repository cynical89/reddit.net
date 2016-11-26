using System;
using System.ComponentModel.DataAnnotations;

namespace Reddit.net.Models
{
    public class CommentModel
    {
        [Key]
        public Guid Id { get; set; }
        public string ParentPost { get; set; }
        public string User { get; set; }
        [Required(ErrorMessage = "You can't leave an empty comment.")]
        public string Content { get; set; }
        public int Reputation { get; set; }
    }
}
