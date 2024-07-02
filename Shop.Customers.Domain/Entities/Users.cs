using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace Shop.Modules.Domain.Entities
{
    public class Users : AuditEntity<int>
    {
        [Column("UserId")]
        public override int Id { get; set; }
    }
}
