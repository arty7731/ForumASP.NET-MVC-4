using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC4ForGeeksForLess.Domain.Entities
{
    public class Message
    {
        //ID
        public int Id { get; set; }
        //TextMessage
        [Required]
        [Display(Name = "Text message")]
        [DataType(DataType.MultilineText)]
        //[MaxLength(512, ErrorMessage = "Exceeded the maximum record length")]
        //[MinLength(24, ErrorMessage = "Minimum record length 24 char")]
        public string TextMessage { get; set; }
        //Date
        [DisplayFormat(DataFormatString = "hh:mm:ss MM/dd/yyyy", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        //TopicId
        public int? TopicId { get; set; }
        public Topic Topic { get; set; }
        //UserId
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}