using System.ComponentModel.DataAnnotations;

namespace ProyectoLambda.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The phone is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
