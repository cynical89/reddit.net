using System;
using System.ComponentModel.DataAnnotations;

namespace Reddit.net.Models
{
    public class PostModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Can't make a post with an empty Title")]
        public string Title { get; set; }
        public bool Approved { get; set; }
        [Required(ErrorMessage = "Can't make an empty post.")]
        public string Content { get; set; }
        public string Subnet { get; set; }
        public int Comments { get; set; }
        public int Reputation { get; set; }
        public DateTime TimeAndDate { get; set; }
    }
}
