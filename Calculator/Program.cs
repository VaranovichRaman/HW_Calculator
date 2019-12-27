using Calculator.Interfaces;
using Calculator.Services;
using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new Menu();
            menu.Start();
        }
    }
}
