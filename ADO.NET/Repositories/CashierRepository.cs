using System;
using System.Collections.Generic;
using System.Linq;
using ADO.NET.EnterFace;
using ADO.NET.Entities;

namespace ADO.NET.Repositories
{
    public class CashierRepository : ICashierRepository
    {
        private readonly MyAppContext _context;

        public CashierRepository(MyAppContext context)
        {
            _context = context;
        }
        
        public Cashier AddCashier(Cashier cashier)
        {
            var newCashier = new Cashier()
            {
                CashierName = cashier.CashierName,
                CashierPhoneNumber  = cashier.CashierPhoneNumber
            };
            _context.Cashiers.Add(newCashier);
            _context.SaveChanges(); 
            return newCashier; 
        }

        public List<Cashier> GetAllCashiers()
        {
            return _context.Cashiers.ToList();
        }

        public Cashier UpdateCashier(Guid id, Cashier cashier)
        {
            var cashierById = _context.Cashiers.FirstOrDefault(c => c.Id == id);
            if (cashierById != null)
            {
                cashierById.CashierName = cashier.CashierName;
                cashierById.CashierPhoneNumber = cashier.CashierPhoneNumber;
                _context.Cashiers.Update(cashierById);
                _context.SaveChanges();
            }
            return cashierById;
        }

        public Cashier DeleteCashierById(Guid Id)
        {
            var deletedCashier = _context.Cashiers.FirstOrDefault(c => c.Id == Id);
            if (deletedCashier != null)
            {
                _context.Cashiers.Remove(deletedCashier);
                _context.SaveChanges();
            }
            return deletedCashier;
        }
    }
}