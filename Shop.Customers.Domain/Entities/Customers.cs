using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Modules.Domain.Entities
{
    public class Customers : AuditEntity<int>
    {
        [Column("custid")]
        public override int Id { get; set; }
    }
}
