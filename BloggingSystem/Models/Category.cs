using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BloggingSystem.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }
}