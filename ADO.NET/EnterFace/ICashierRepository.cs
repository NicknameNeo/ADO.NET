using System;
using System.Collections.Generic;
using ADO.NET.Entities;

namespace ADO.NET.EnterFace
{
    public interface ICashierRepository
    {
        // Создание нового кассира
        public Cashier AddCashier(Cashier cashier);
        // Вывод всех кассиров
        public List<Cashier> GetAllCashiers();
        //Обнавления кассиров
        public Cashier UpdateCashier(Guid id, Cashier cashier);
        //Удаления кассров
        public Cashier DeleteCashierById(Guid Id);
    }
}