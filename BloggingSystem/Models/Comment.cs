using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloggingSystem.Models
{
    public class Comment
    {
        public int ID { get; set; }

        [Required]
        public int ArticleID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string CommentText { get; set; }


        public virtual ApplicationUser User { get; set; }
    }
}