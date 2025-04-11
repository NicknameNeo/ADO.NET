using System;
using System.Collections.Generic;
using ADO.NET.Entities;

namespace ADO.NET.EnterFace
{
    public interface IMedicineRepository
    {
        /// <summary>
        /// Создание нового лекарстава
        /// </summary>
        /// <param name="medicine"></param>
        /// <returns></returns>
        public Medicine AddMedicine(Medicine medicine);
        /// <summary>
        /// Вывод всех лекарств
        /// </summary>
        /// <returns></returns>
        public List<Medicine> GetAllMedicines();
        /// <summary>
        /// Обнавления записи у лекарства по определеному Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="medicine"></param>
        /// <returns></returns>
        
        public Medicine UpdateMedicineById(Guid Id, Medicine medicine);
        /// <summary>
        /// Удаления лекарство через Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        
        public Medicine DeleteMedicineById(Guid Id);
        
        
    }
}