using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhabarYatri.Base.Entities
{
    public class Post
    {
        public Post()
        {
            PublishedDate = DateTime.Now;
        }
        public int PostId { get; set; }

        [Required]
        public string PostTitle { get; set; }

        public string Image { get; set; }

        [Required]
        public string PostBody { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
