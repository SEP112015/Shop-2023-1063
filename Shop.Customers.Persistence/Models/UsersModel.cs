using System.ComponentModel.DataAnnotations;

namespace Shop.CUser.Persistence.Models
{
    public class UsersModel
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(60, ErrorMessage = "No se pueden exceder de 60 caracteres.")]
        public string Email { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string Password { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string Name { get; set; }
    }
}
