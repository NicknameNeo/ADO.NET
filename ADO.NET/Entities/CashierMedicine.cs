using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADO.NET.Entities
{
    public class CashierMedicine
    {
        [Key]
        public Guid CashierMedicineId { get; set; }
        [Column("MedicineId")]
        public Guid MedicineId { get; set; }
        [Column("CashierId")]
        public Guid CashierId { get; set; }
        
        public Medicine Medicine { get; set; }
        
        public Cashier Cashier { get; set; }
    }
}