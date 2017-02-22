using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ForumMVC4ForGeeksForLess.Domain.Entities;
using ForumMVC4ForGeeksForLess.Models;

namespace ForumMVC4ForGeeksForLess.Models
{
    public class TopicModelView
    {
        public Topic Topic { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}