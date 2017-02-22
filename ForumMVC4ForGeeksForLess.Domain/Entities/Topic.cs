using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC4ForGeeksForLess.Domain.Entities
{

    public class Topic
    {
        //ID
        public int Id { get; set; }
        //Title
        [Required]
        [Display(Name = "Title")]
        //[MaxLength(128, ErrorMessage = "Exceeded the maximum record length")]
        //[MinLength(8, ErrorMessage = "Minimum record length 8 char")]
        public string Title { get; set; }
        //Text
        [Required]
        [Display(Name = "Text")]
        //[MaxLength(1024, ErrorMessage = "Exceeded the maximum record length")]
        //[MinLength(24, ErrorMessage = "Minimum record length 24 char")]
        public string Text { get; set; }
        //Date
        [DisplayFormat(DataFormatString = "hh:mm:ss MM/dd/yyyy", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        //CountView
        public int CountView { get; set; }
        //User
        public int? UserId { get; set; }
        public User User { get; set; }
        //Messages
        public ICollection<Message> Messages { get; set; }
    }
}