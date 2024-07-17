using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.Modules.Domain.Entities
{
    [Table("Users", Schema = "Security")]
    public class Users : BaseEntity<int>
    {
        [Key]
        [Column("UserId")]
        public override int Id { get; set; }
        [StringLength(60, ErrorMessage = "No se pueden exceder de 60 caracteres.")]
        public string Email { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string Password { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string Name { get; set; }
    }
}
