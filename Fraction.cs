using System;

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
        // метод нахождения наибольшего общего делителя 
        public static int NOD(int a, int b)
        {
            while (b != 0) // пока значение b не равно нулю
            {
                int temp = b; // временная переменная, чтобы менять значения a и b
                b = a % b; // остаток от деления a на b
                a = temp; // значению a приравниваем значение b
            }
            return a; // возвращаем НОД
        }

        // метод сокращения дроби
        public Fraction Reduction()
        {
            int num = Math.Abs(numerator); // абсолютное значение числителя 
            int denom = Math.Abs(denominator); // абсолютное значение знаменателя 
            int nod = NOD(num, denom); // НОД числителя и знаменателя
            int sign = Math.Sign(numerator * denominator); // -1, если произведение числителя на знаменатель < 0
                                                           // 0, если = 0
                                                           // 1, если > 0
            return new Fraction(sign * num / nod, denom / nod);
        }

        // метод, позволяющий получить числитель, доступ к которому напрямую ограничен
        public int getNumerator()
        {
            return numerator;
        }

        // метод, позволяющий получить знаменатель, доступ к которому напрямую ограничен
        public int getDenominator()
        {
            return denominator;
        }

        // метод сложения дробей
        public static Fraction Sum(Fraction a, Fraction b)
        {
            // ЧИСЛИТЕЛЬ = складываем произведение числителя первой дроби на знаменатель второй дроби и
            // числитель второй дроби на знаменатель первой дроби,
            // ЗНАМЕНАТЕЛЬ = умножаем знаменатель первой дроби на знаменатель второй дроби            
            return new Fraction(a.numerator * b.denominator + b.numerator * a.denominator, a.denominator * b.denominator); ;
        }

        // метод вычитания дробей
        public static Fraction Sub(Fraction a, Fraction b)
        {
            // ЧИСЛИТЕЛЬ = вычитаем произведение числителя первой дроби на знаменатель второй дроби и
            // числитель второй дроби на знаменатель первой дроби,
            // ЗНАМЕНАТЕЛЬ = умножаем знаменатель первой дроби на знаменатель второй дроби
            return new Fraction(a.numerator * b.denominator - b.numerator * a.denominator, a.denominator * b.denominator);
        }

        // метод умножения дробей
        public static Fraction Mul(Fraction a, Fraction b)
        {
            // ЧИСЛИТЕЛЬ = произведение числителя первой дроби на числитель второй дроби
            // ЗНАМЕНАТЕЛЬ = произведение знаменателя первой дроби на знаменатель второй дроби
            return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);
        }

        // метод деления дробей
        public static Fraction Div(Fraction a, Fraction b)
        {
            // ЧИСЛИТЕЛЬ = произведение числителя первой дроби на знаменатель второй дроби
            // ЗНАМЕНАТЕЛЬ = произведение знаменателя первой дроби на числитель второй дроби
            return new Fraction(a.numerator * b.denominator, a.denominator * b.numerator);
        }

        // метод сравнения дробей
        public static string Compare(Fraction a, Fraction b)
        {
            string outMessage = ""; // строка, в которую записывается результат сравнения двух дробей
            int chislitel1, chislitel2; // числители первой и второй дроби

            // ЧИСЛИТЕЛЬ ПЕРВОЙ ДРОБИ = произведение числителя первой дроби на знаменатель второй дроби
            chislitel1 = a.numerator * b.denominator;

            // ЧИСЛИТЕЛЬ ВТОРОЙ ДРОБИ = произведение числителя второй дроби на знаменатель первой дроби
            chislitel2 = b.numerator * a.denominator;

            // если числитель первой дроби меньше числителя второй дроби
            if ((Convert.ToInt32(chislitel1) < (Convert.ToInt32(chislitel2))))
            {
                outMessage = a + " < " + b; // первая дробь меньше второй
            }
            // если числитель первой дроби больше числителя второй дроби
            else if ((Convert.ToInt32(chislitel1) > (Convert.ToInt32(chislitel2))))
            {
                outMessage = a + " > " + b; // первая дробь больше второй
            }
            else
            {
                outMessage = a + " = " + b; // иначе дроби равны
            }
            return outMessage; // возвращаем строку
        }

        // метод сравнения сокращенных дробей
        public static string Compare(Fraction a, Fraction b, bool c)
        {
            string outMessage = "";
            int chislitel1, chislitel2; // числители первой и второй дроби

            // ЧИСЛИТЕЛЬ ПЕРВОЙ ДРОБИ = произведение числителя первой дроби на знаменатель второй дроби
            chislitel1 = a.numerator * b.denominator;

            // ЧИСЛИТЕЛЬ ВТОРОЙ ДРОБИ = произведение числителя второй дроби на знаменатель первой дроби
            chislitel2 = b.numerator * a.denominator;

            // если числитель первой дроби меньше числителя второй дроби
            if ((Convert.ToInt32(chislitel1) < (Convert.ToInt32(chislitel2))))
            {
                outMessage = a.Reduction() + " < " + b.Reduction(); // первая сокращенная дробь меньше второй сокращенной
            }
            // если числитель первой дроби больше числителя второй дроби
            else if ((Convert.ToInt32(chislitel1) > (Convert.ToInt32(chislitel2))))
            {
                outMessage = a.Reduction() + " > " + b.Reduction(); // первая сокращенная дробь больше второй сокращенной
            }
            else
            {
                outMessage = a.Reduction() + " = " + b.Reduction(); // иначе дроби равны
            }
            return outMessage;
        }

        // метод вывода дроби (строковое представление)
        public override string ToString()
        {
            // числитель/знаменатель
            return numerator.ToString() + "/" + denominator.ToString();
        }
    }
}