using System.ComponentModel.DataAnnotations;

namespace Dal.Models
{
    public class Worker
    {
        [Key] 
        public int WorkerId { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }

    }
}
