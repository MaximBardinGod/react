using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class Action
    {
        [Key]
        public int ActionId { get; set; }
        public string Description { get; set; }

    }
}
