using System;
using System.ComponentModel.DataAnnotations;

namespace Reddit.net.Models
{
    public class SubnetModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please enter a Subnet name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Subnet title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Subnet Description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter the Subnet's Sidebar information")]
        public string Sidebar { get; set; }
        [Required(ErrorMessage = "Please enter the Subnet's info to display when a user makes a post")]
        public string SubText { get; set; }
        public Languages Language { get; set; }
        public AccessType Type { get; set; }
        public bool Over18Only { get; set; }
        public bool VisibleInAll { get; set; }

        public enum Languages
        {
            English,
            Spanish,
            Other
        }

        public enum AccessType
        {
            Public,
            Restricted,
            Private,
            Special
        }
    }
}
