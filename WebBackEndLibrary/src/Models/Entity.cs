using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBackEndLibrary.Models
{
    public abstract class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
