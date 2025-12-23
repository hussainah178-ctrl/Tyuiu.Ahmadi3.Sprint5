using System;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.Ahmadi3.Sprint5.Task5.V22.Lib
{
    public class DataService :ISprint5Task0V22
    {
        public double Calculate(double x)
        {
            if (x == 0)
                throw new DivideByZeroException("Знаменатель не может быть равен нулю.");

            double numerator = Math.Pow(1 - x, 2);
            double denominator = -3 * x;
            return numerator / denominator;
        }

        public string SaveToFileTextData(int x)
        {
            throw new NotImplementedException();
        }
    }
}