using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__3
{
    public class Fraction
    {
        // поля класса
        private int numerator; // числитель
        private int denominator; // знаменатель

        // конструктор
        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        // метод вывода ответа (строковое представление)
        public override string ToString()
        {
            // числитель/знаменатель
            return numerator.ToString() + "/" + denominator.ToString();
        }
    }
}
