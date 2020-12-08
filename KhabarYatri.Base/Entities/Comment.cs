using System;
using System.ComponentModel.DataAnnotations;

namespace KhabarYatri.Base.Entities
{
    public class Comment
    {
        public Comment()
        {
            CommentedDate = DateTime.Now.ToString("yyyy-MM-dd");
            CommentedTime = DateTime.Now.ToString("hh:mm:ss");
        }
        public int CommentId { get; set; }

        [Display(Name ="Comment")]
        public string Cmnt { get; set; }

        public string CommentedDate { get; set; }
        public string CommentedTime { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
