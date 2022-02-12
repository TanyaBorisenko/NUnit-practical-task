using System;

namespace TestProject1
{
    public class Calculator
    {
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
    }
}