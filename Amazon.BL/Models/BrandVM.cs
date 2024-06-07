using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Amazon.BL.Models
{
    public class BrandVM
    {
        public int Id { get; set; }
        public string _id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Image { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
