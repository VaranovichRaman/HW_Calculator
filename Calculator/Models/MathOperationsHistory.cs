using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Models
{
    public class MathOperationsHistory : BaseEntity
    {
        public string MathExpression { get; set; }
        public double MathResult { get; set; }
    }
}
