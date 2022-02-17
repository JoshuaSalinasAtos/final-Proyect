using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Models
{
    public class BookCourse : Entity
    {
        public int BookId { get; set; }
        public int CourseId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(1)]
        public int Status { get; set; }

    }
}
