using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Customers.Application.Dtos.UsersDtos
{
    public class UsersDto
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
