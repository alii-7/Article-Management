using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BloggingSystem.Models
{
    public class Article
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [Required]
        public DateTime DateOfPublish { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string ArticleBody { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [NotMapped]
        public string comment { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}