using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBackEndLibrary.Models
{
    public class Book : Entity
    {

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Autor { get; set; }

        public string? Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(0)]
        public int Status { get; set; }
    }
}
