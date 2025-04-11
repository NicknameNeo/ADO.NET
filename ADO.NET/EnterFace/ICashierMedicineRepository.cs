using System;
using System.Collections.Generic;
using ADO.NET.Entities;

namespace ADO.NET.EnterFace
{
    public interface ICashierMedicineRepository
    {
        /// <summary>
        /// добавления связи между кассиром и лекарством
        /// </summary>
        /// <param name="cashierMedicine"></param>
        /// <returns></returns>
        public CashierMedicine AddCashierMedicine(CashierMedicine cashierMedicine);
        
        /// <summary>
        /// Вывщд всех записей
        /// </summary>
        /// <returns></returns>
        public List<CashierMedicine> GetCashierMedicines();
        
        /// <summary>
        /// обновления информации
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cashierMedicine"></param>
        /// <returns></returns>
        public CashierMedicine UpdateCashierMedicine(Guid id, CashierMedicine cashierMedicine);
        
        /// <summary>
        /// Удаления информации
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CashierMedicine DeleteCashierMedicine(Guid id);
    }
}