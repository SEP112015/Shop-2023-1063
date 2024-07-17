﻿using Shop.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Modules.Domain.Entities
{
    [Table("Customers", Schema = "Sales")]
    public class Customers : BaseEntity<int>
    {
        [Key]
        [Column("custid")]
        public override int Id { get; set; }

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
    }
}
