using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogPosts_API.Models
{
    public class BlogPost
    {
        [Key] // it makes primary key and Identity incremented by 1
        public int BlogPostId { get; set; }

        [Required] // it makes not null constraint 
        [StringLength(150)] // it makes nvarchar(150)
        //[MaxLength(150)] 
        public string Title { get; set; }

        [Required]
        public string Body { get; set; } // nvarchar(max) by default

        ////Foreign key for Author
        public int AuthorId { get; set; }
        //public Author Author { get; set; }

        [Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] // for default value 
        public DateTime CreatedAt { get; set; } // = DateTime.Now;

        [Required] 
        public DateTime UpdatedAt { get; set; } 
    }
}