using System.ComponentModel.DataAnnotations;

namespace WebBackEndLibrary.Dtos
{
    public class BookDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Description { get; set; }
    }
}
