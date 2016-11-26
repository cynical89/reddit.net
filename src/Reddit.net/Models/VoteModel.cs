using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reddit.net.Models
{
    public class VoteModel
    {
        [Key]
        public int Id { get; set; }
        public Guid UserId { get; set; }
        [Required]
        public Guid ContentId { get; set; }
        [Required]
        public int Point { get; set; }
        [Required]
        public ContentType Type { get; set; }

        public enum ContentType
        {
            Subnet,
            Post,
            Comment
        }
    }
}
