using System.ComponentModel.DataAnnotations;

namespace KhabarYatri.Base.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name ="Category")]
        public string Cat{ get; set; }
    }
}
