using System.ComponentModel.DataAnnotations;

namespace MyApp.Models {
    public class Person {
        public int Id { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public int Age { get; set; }
        public DateTime createdAt { get; set; }

        public override string ToString() {
            return $"[ name = {Name}, age = {Age} ]";
        }
    }
}
