using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Interfaces
{
    public interface ISaveOperationHistoryInDb
    {
        void SaveInDb(MathOperationsHistory history);
    }
}
