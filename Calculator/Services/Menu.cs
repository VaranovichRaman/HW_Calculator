using Calculator.Interfaces;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculator.Services
{
    public class Menu : IMenu
    {
        public void Start()
        {
            using (var context = new CalculatorContext())
            {
                var flag = true;
                double x = 0;
                double y = 0;
                Console.WriteLine($"Welcome in CalculatorTry!");
                while (flag)
                {
                    var wrongEnter = false;
                    Console.WriteLine($"\nThe operators our calculator works with: \n\ndigits from 0 to 9;   operator " +
                        $"\"+\";    operator \"-\";\n\noperator \"/\";         operator \"*\";    operator \"^\"\n\n" +
                        $"operator \"sin\";       operator \"cos\";  operator \"tg\";\n\noperator \"exit\" for app closing" +
                        $"\n\nPlease enter your mathematical expression for solution:\n");
                    var mathExpression = new MathOperationsHistory();
                    mathExpression.MathExpression = Console.ReadLine().ToLower();
                    string[] separators = { "+", "-", "/", "*", "^", "sin", "cos", "tg" };
                    string[] splitMathExpression = mathExpression.MathExpression.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    if (mathExpression.MathExpression.Contains("sin") || mathExpression.MathExpression.Contains("cos") ||
                        mathExpression.MathExpression.Contains("tg"))
                    {
                        double.TryParse(splitMathExpression.ElementAt(0), out x);
                    }
                    else if(mathExpression.MathExpression.Contains("+") || mathExpression.MathExpression.Contains("-") ||
                        mathExpression.MathExpression.Contains("/") || mathExpression.MathExpression.Contains("*") ||
                        mathExpression.MathExpression.Contains("^"))
                    {
                        double.TryParse(splitMathExpression.ElementAt(0), out x);
                        double.TryParse(splitMathExpression.ElementAt(1), out y);
                    }
                    else
                    {
                        if (!mathExpression.MathExpression.Contains("exit")) Console.WriteLine($"Wrong operation! Try again!");
                        wrongEnter = true;
                    }
                    if (mathExpression.MathExpression.Contains('+'))
                    {
                        IPlusOperation plus = new PlusOperation();
                        mathExpression.MathResult = plus.Plus(x, y);
                    }
                    else if (mathExpression.MathExpression.Contains('-'))
                    {
                        IMinusOperation minus = new MinusOperation();
                        mathExpression.MathResult = minus.Minus(x, y);
                    }
                    else if (mathExpression.MathExpression.Contains('/'))
                    {
                        IDivisionOperation division = new DivisionOperation();
                        mathExpression.MathResult = division.Division(x, y);
                    }
                    else if (mathExpression.MathExpression.Contains('*'))
                    {
                        IMultiplicationOperation multiply = new MultiplicationOperation();
                        mathExpression.MathResult = multiply.Multiply(x, y);
                    }
                    else if (mathExpression.MathExpression.Contains('^'))
                    {
                        IExponintationOperation exponent = new ExponintationOperation();
                        mathExpression.MathResult = exponent.Exponintation(x, y);
                    }
                    else if (mathExpression.MathExpression.Contains("sin"))
                    {
                        ISinOperation sin = new SinOperation();
                        mathExpression.MathResult = sin.Sin(x);
                    }
                    else if (mathExpression.MathExpression.Contains("cos"))
                    {
                        ICosOperation cos = new CosOperation();
                        mathExpression.MathResult = cos.Cos(x);
                    }
                    else if (mathExpression.MathExpression.Contains("tg"))
                    {
                        ITgOperation tg = new TgOperation();
                        mathExpression.MathResult = tg.Tg(x);
                    }
                    else if (mathExpression.MathExpression.Contains("exit"))
                    {
                        flag = false;
                        Console.WriteLine($"\nThanks for using our application! Good bye!");
                    }
                    if (!wrongEnter) Console.WriteLine($"\nResult = {mathExpression.MathResult }\n");                  
                    context.Add(mathExpression);
                    context.SaveChanges();
                }
            }
        }
    }
}


