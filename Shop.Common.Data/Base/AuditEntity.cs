using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Data.Base
{
    public abstract class AuditEntity<TType> : BaseEntity<TType>
    {
        [Column("")]
        public override TType Id { get ; set ; }

        [Key]
        public int custid { get; set; }
        [StringLength(40, ErrorMessage = "No se pueden exceder de 40 caracteres.")]
        public string companyname { get; set; }
        [StringLength(30, ErrorMessage = "No se pueden exceder de 30 caracteres.")]
        public string contactname { get; set; }
        [StringLength(30, ErrorMessage = "No se pueden exceder de 30 caracteres.")]
        public string contacttitle { get; set; }
        [StringLength(60, ErrorMessage = "No se pueden exceder de 60 caracteres.")]
        public string address { get; set; }
        [StringLength(50, ErrorMessage = "No se pueden exceder de 50 caracteres.")]
        public string email { get; set; }
        [StringLength(15, ErrorMessage = "No se pueden exceder de 15 caracteres.")]
        public string city { get; set; }
        public string? region { get; set; }
        public string? postalcode { get; set; }
        [StringLength(15, ErrorMessage = "No se pueden exceder de 15 caracteres.")]
        public string country { get; set; }
        [StringLength(24, ErrorMessage = "No se pueden exceder de 24 caracteres.")]
        public string phone { get; set; }
        public string? fax { get; set; }

        [Key]
        public int UserId { get; set; }
        [StringLength(50, ErrorMessage = "No se pueden exceder de 59 caracteres.")]
        public string Email { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string Password { get; set; }
        [StringLength(200, ErrorMessage = "No se pueden exceder de 200 caracteres.")]
        public string Name { get; set; }
    }
}
