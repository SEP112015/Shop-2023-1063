using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.Modules.Domain.Entities
{
    [Table("Users", Schema = "Security")]
    public class Users : AuditEntity<int>
    {
        [Column("UserId")]
        public override int Id { get; set; }
    }
}
