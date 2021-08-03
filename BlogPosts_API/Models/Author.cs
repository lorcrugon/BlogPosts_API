using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogPosts_API.Models
{
    public class Author
    {
        //[Key]
        public int AuthorId { get; set; }

        //[Required]
        //[MaxLength(60)] 
        public string FirstName { get; set; }

        //[Required]
        //[MaxLength(60)] 
        public string LastName { get; set; }

        //[Required]
        //[MaxLength(150)] 
        public string Email { get; set; }

        //[Required]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; } // = DateTime.Now;

        //public ICollection<Post> Post { get; set; }
    }
}