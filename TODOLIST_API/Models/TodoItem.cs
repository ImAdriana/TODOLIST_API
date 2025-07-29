using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TODOLIST_API.Models
{
    public class TodoItem
    {
        [Key] // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionItem { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndedDate { get; set; }
        public bool isCompleted { get; set; }
    }
}
