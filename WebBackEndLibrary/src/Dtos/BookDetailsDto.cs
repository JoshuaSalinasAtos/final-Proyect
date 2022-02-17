using System.ComponentModel.DataAnnotations;
using WebBackEndLibrary.Models;

namespace WebBackEndLibrary.Dtos
{
    public class BookDetailsDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
