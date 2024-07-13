using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Modules.Domain.Entities
{
    [Table("Customers", Schema = "Sales")]
    public class Customers : AuditEntity<int>
    {
        [Column("custid")]
        public override int Id { get; set; }
    }
}
