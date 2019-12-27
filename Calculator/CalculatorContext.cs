using Calculator.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class CalculatorContext : DbContext
    {
        public DbSet<MathOperationsHistory> OperationsHistory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BP3JMTE;Database=Calc;Integrated Security=True;");
        }
    }
}
