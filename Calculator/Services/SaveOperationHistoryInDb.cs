using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Services
{
    public class SaveOperationHistoryInDb : ISaveOperationHistoryInDb
    {
        public void SaveInDb(MathOperationsHistory history)
        {
            using (var context = new CalculatorContext())
            {
                context.OperationsHistory.Add(history);
                context.SaveChanges();
            }
        }
    }
}
