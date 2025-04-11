using System;
using System.Collections.Generic;
using System.Linq;
using ADO.NET.EnterFace;
using ADO.NET.Entities;

namespace ADO.NET.Repositories
{
    public class MedicineRepository: IMedicineRepository
    {
        private readonly MyAppContext _context;
        private ICashierRepository _cashierRepositoryImplementation;

        public MedicineRepository(MyAppContext context)
        {
            _context = context;
        }
        public Medicine AddMedicine(Medicine medicine)
        {
            var newMedicine = new Medicine()
            {
                MedicineName = medicine.MedicineName,
                Price = medicine.Price,
                ExpiryDate = medicine.ExpiryDate,
                Barcode = medicine.Barcode
            };
            _context.Medicine.Add(newMedicine);
            _context.SaveChanges(); 
            return newMedicine; 
        }

        public List<Medicine> GetAllMedicines()
        {
            return _context.Medicine.ToList();
        }

        public Medicine UpdateMedicineById(Guid id, Medicine medicine)
        {
            var medicineById = _context.Medicine.FirstOrDefault(m => m.MedicineId == id);
            if (medicineById != null)
            {
                medicineById.MedicineName = medicine.MedicineName;
                medicineById.Price = medicine.Price;
                medicineById.ExpiryDate = medicine.ExpiryDate;
                medicineById.Barcode = medicine.Barcode;
                _context.Medicine.Update(medicineById);
                _context.SaveChanges();
            }
            return medicine;
        }

        public Medicine DeleteMedicineById(Guid id)
        {
            var deletedMedicine = _context.Medicine.FirstOrDefault(m => m.MedicineId == id);
            if (deletedMedicine != null)
            {
                _context.Medicine.Remove(deletedMedicine);
                _context.SaveChanges();
            }
            return deletedMedicine;
        }
        
    }
}