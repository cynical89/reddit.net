using System;
using System.ComponentModel.DataAnnotations;

namespace Reddit.net.Models
{
    public class MessageModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

    }
}
