using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADO.NET.Entities
{
    public class Cashier
    {
        [Key]
        [Column("CashierId")]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Column("CashierName")]
        public string CashierName { get; set; }
        [Column("CashierPhoneNumber")]
        public long CashierPhoneNumber { get; set; }

        public List<Medicine> Medicines { get; set; } = new();

        public List<CashierMedicine> CashiersMedicines { get; set; } = new();

    }
}