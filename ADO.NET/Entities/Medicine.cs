using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ADO.NET.Entities
{
    public class Medicine
    {
        [Key]
        public Guid MedicineId { get; set; }
        [MaxLength(500)]
        [Required]
        public string MedicineName { get; set; }
        [MaxLength(500)]
        [Required]
        public string Barcode { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public DateTime ExpiryDate { get; set; }
        
        public List<Medicine> Cashiers { get; set; } = new ();
        
        public List<CashierMedicine> CashierMedicines { get; set; } = new ();
    }
}