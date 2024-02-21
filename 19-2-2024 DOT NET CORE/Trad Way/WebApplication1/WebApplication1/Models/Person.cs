using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace WebApplication1.Models {
    public class Person {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public override string ToString() {
            return JsonSerializer.Serialize<Person>(this);
        }
    }
}
