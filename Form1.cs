using System;
using System.Windows.Forms;

namespace Лабораторная_работа__3
{
    public partial class Form1 : Form
    {
        private static bool enterLast = false; // проверка, введено ли третье число и нажата клавиша Enter
        private static Fraction Droba; // первая дробь
        private static Fraction Drobb; // вторая дробь
        private static int p; // эквивалентное целое число textBox

        public Form1()
        {
            InitializeComponent(); // вызов метода который формирует поля на форме, добавляет свойства,
            // всё то, что находится в Form1.Designer.cs

            this.KeyPreview = true; // обрабатываем клавиши на уровне формы

            // отпускается клавиша, выполняется код Form1_KeyUp
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);

            // метод KeyEventHandler обрабатывает событие KeyDown, которое срабатывает, когда нажата клавиша
            textBox1.KeyDown += new KeyEventHandler(keydown);
            textBox2.KeyDown += new KeyEventHandler(keydown1);
            textBox3.KeyDown += new KeyEventHandler(keydown2);
            textBox4.KeyDown += new KeyEventHandler(keydown3);
            comboBox1.KeyDown += new KeyEventHandler(keydown4);
        }
        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // если нажата клавиша Enter
            {
                textBox2.Focus(); // установка фокуса на textBox знаменателя первой дроби
                e.SuppressKeyPress = true; // отключаем системный звук
            }
        }
        private void keydown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // если нажата клавиша Enter
            {
                textBox3.Focus(); // установка фокуса на textBox числителя второй дроби
                e.SuppressKeyPress = true; // отключаем системный звук
            }
        }
        private void keydown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // если нажата клавиша Enter
            {
                textBox4.Focus(); // установка фокуса на textBox знаменателя второй дроби
                e.SuppressKeyPress = true; // отключаем системный звук
            }
        }
        private void keydown3(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // если нажата клавиша Enter
            {
                comboBox1.Focus(); // установка фокуса на comboBox1 для выбора действия
                comboBox1.DroppedDown = true; // раскрытие comboBox1 программно
                e.SuppressKeyPress = true; // отключаем системный звук
            }
        }
        private void keydown4(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // если нажата клавиша Enter
            {
                enterLast = true; // введены две дроби
                e.SuppressKeyPress = true; // отключаем системный звук
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (enterLast) // если введены две дроби
            {
                comboBox1.DroppedDown = false; // закрытие comboBox1 программно
                button1.PerformClick(); // вызываем подпрограмму button1_Click
            }
            enterLast = false; // опускаем флаг того, что введены две дроби
        }
        // при каждой загрузке формы будет срабатывать следующий код
        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = ""; // очистка label2
            label3.Text = ""; // очистка label3
            label4.Text = ""; // очистка label4
        }
        // кнопка для получения результирующей дроби
        private void button1_Click(object sender, EventArgs e)
        {
            //если textBox1, textBox2, textBox3, textBox4 преобразованы в числа типа int, то
            if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
            {
                // если абсолютное значение textBox1 больше или равно абсолютному значению textBox2
                // И абсолютное значение textBox3 больше или равно абсолютному значению textBox4, то
                if ((Math.Abs(int.Parse(textBox1.Text)) >= (Math.Abs((int.Parse(textBox2.Text))))
                    && ((Math.Abs(int.Parse(textBox3.Text)) >= ((Math.Abs(int.Parse(textBox4.Text))))))))
                {
                    textBox1.Clear(); // очищаем textBox1
                    textBox2.Clear(); // очищаем textBox2
                    textBox3.Clear(); // очищаем textBox3
                    textBox4.Clear(); // очищаем textBox4
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
                // если абсолютное значение textBox1 больше или равно абсолютному значению textBox2
                else if (Math.Abs(int.Parse(textBox1.Text)) >= (Math.Abs(int.Parse(textBox2.Text))))
                {
                    textBox1.Clear(); // очищаем textBox1
                    textBox2.Clear(); // очищаем textBox2
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
                // если абсолютное значение textBox3 больше или равно абсолютному значению textBox4
                else if (Math.Abs(int.Parse(textBox3.Text)) >= (Math.Abs(int.Parse(textBox4.Text))))
                {
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
            }
            switch (textBox1.Text) // сравниваем textBox1 с набором значений
            {
                case "": // если ничего не введено в textBox1
                    label3.Text = "Введите числитель для первой дроби";
                    break; // выходим из switch (textBox1.Text)

                default: // если textBox1 не имеет ни одно из выше указанных значений
                    if (textBox2.Text == "") // если ничего не введено в textBox2
                        label3.Text = "Введите знаменатель для первой дроби";
                    else
                        label3.Text = ""; // иначе очищаем label3
                    break; // выходим из switch (textBox1.Text)
            }
            switch (textBox3.Text)
            {
                case "":
                    label4.Text = "Введите числитель для второй дроби";
                    break;
                default:
                    if (textBox4.Text == "")
                        label4.Text = "Введите знаменатель для второй дроби";
                    else
                        label4.Text = "";
                    break;
            }
            switch (comboBox1.Text)
            {
                case "+":
                    // если textBox1, textBox2, textBox3, textBox4 преобразованы в числа типа int, то
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        // первая дробь
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        // вторая дробь
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));

                        label3.Text = Convert.ToString(Droba); // строкое представление первой дроби в label3
                        label4.Text = Convert.ToString(Drobb); // строкое представление второй дроби в label4                        
                        label2.Text = (Droba + Drobb).ToString(); // строкое представление результирующей дроби в label2
                    }
                    else // иначе
                    {
                        label2.Text = ""; // очистка label2
                        label3.Text = ""; // очистка label3
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "-":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);
                        label2.Text = (Droba - Drobb).ToString();

                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "*":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);
                        label2.Text = Fraction.Mul(Droba, Drobb).ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "/":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);
                        label2.Text = Fraction.Div(Droba, Drobb).ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                // сравнение дробей
                case "<=>":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);
                        label2.Text = Fraction.Compare(Droba, Drobb).ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                // если не выбрано действие в comboBox1
                default:
                    label2.Text = "Выберите действие \n" + "        с дробью";
                    break;
            }
        }
        // кнопка для сокращения первой дроби
        private void button2_Click(object sender, EventArgs e)
        {
            // если textBox1, textBox2 преобразованы в числа типа int, то
            if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p)))
            {
                // если абсолютное значение textBox1 больше или равно абсолютному значению textBox2, то
                if (Math.Abs(int.Parse(textBox1.Text)) >= (Math.Abs(int.Parse(textBox2.Text))))
                {
                    textBox1.Clear(); // очищаем textBox1
                    textBox2.Clear(); // очищаем textBox2
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
            }

            // если textBox1, textBox2 преобразованы в числа типа int, то
            if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p)))
            {
                // первая дробь
                Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

                Droba = Droba.Reduction(); // сокращенная первая дробь

                textBox1.Text = Droba.getNumerator().ToString(); // вывод сокращенного числителя в первый textBox
                textBox2.Text = Droba.getDenominator().ToString(); // вывод сокращенного знаменателя во второй textBox
                label3.Text = Droba.ToString(); // вывод сокращенной дроби в label3

            }
            else
            {
                label2.Text = "";
                label4.Text = "";
                label3.Text = "Введите числа в числитель и знаменатель";
            }
        }
        // кнопка для сокращения второй дроби
        private void button3_Click(object sender, EventArgs e)
        {
            // если textBox3, textBox4 преобразованы в числа типа int, то
            if (int.TryParse(textBox3.Text, out p) && (int.TryParse(textBox4.Text, out p)))
            {
                // если абсолютное значение textBox3 больше или равно абсолютному значению textBox4, то
                if (Math.Abs(int.Parse(textBox3.Text)) >= (Math.Abs(int.Parse(textBox4.Text))))
                {
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
            }
            // если textBox3, textBox4 преобразованы в числа типа int, то
            if ((int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
            {
                // вторая дробь
                Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));

                Drobb = Drobb.Reduction(); // сокращенная вторая дробь

                textBox3.Text = Drobb.getNumerator().ToString(); // вывод сокращенного числителя во второй textBox
                textBox4.Text = Drobb.getDenominator().ToString(); // вывод сокращенного знаменателя в третий textBox
                label4.Text = Drobb.ToString(); // вывод сокращенной дроби в label4
            }
            else
            {
                label2.Text = "";
                label3.Text = "";
                label4.Text = "Введите числа в числитель и знаменатель";
            }
        }
        // кнопка для сокращения результирующей дроби
        private void button4_Click(object sender, EventArgs e)
        {
            // если textBox1, textBox2, textBox3, textBox4 преобразованы в числа типа int, то
            if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
            {
                // если абсолютное значение textBox1 больше или равно абсолютному значению textBox2
                // И абсолютное значение textBox3 больше или равно абсолютному значению textBox4
                if ((Math.Abs(int.Parse(textBox1.Text)) >= (Math.Abs((int.Parse(textBox2.Text))))
                    && ((Math.Abs(int.Parse(textBox3.Text)) >= ((Math.Abs(int.Parse(textBox4.Text))))))))
                {
                    textBox1.Clear(); // очищаем textBox1
                    textBox2.Clear(); // очищаем textBox2
                    textBox3.Clear(); // очищаем textBox3
                    textBox4.Clear(); // очищаем textBox4
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
                // если абсолютное значение textBox1 больше или равно абсолютному значению textBox2
                else if (Math.Abs(int.Parse(textBox1.Text)) >= (Math.Abs(int.Parse(textBox2.Text))))
                {
                    textBox1.Clear(); // очищаем textBox1
                    textBox2.Clear(); // очищаем textBox2
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
                // если абсолютное значение textBox3 больше или равно абсолютному значению textBox4
                else if (Math.Abs(int.Parse(textBox3.Text)) >= (Math.Abs(int.Parse(textBox4.Text))))
                {
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Числитель должен быть меньше знаменателя");
                }
            }
            switch (textBox1.Text)
            {
                case "":
                    label3.Text = "Введите числитель для первой дроби";
                    break;
                default:
                    if (textBox2.Text == "")
                        label3.Text = "Введите знаменатель для первой дроби";
                    else
                        label3.Text = "";
                    break;
            }
            switch (textBox3.Text)
            {
                case "":
                    label4.Text = "Введите числитель для второй дроби";
                    break;
                default:
                    if (textBox4.Text == "")
                        label4.Text = "Введите знаменатель для второй дроби";
                    else
                        label4.Text = "";
                    break;
            }
            switch (comboBox1.Text)
            {
                case "+":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);

                        // сокращаем результирующую дробь с помощью метода Reduction()
                        //label2.Text = Fraction.Sum(Droba, Drobb).Reduction().ToString();
                        label2.Text = (Droba + Drobb).Reduction().ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "-":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);

                        // сокращаем результирующую дробь с помощью метода Reduction()
                        label2.Text = (Droba + Drobb).Reduction().ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "*":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);

                        // сокращаем результирующую дробь с помощью метода Reduction()
                        label2.Text = Fraction.Mul(Droba, Drobb).Reduction().ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "/":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);

                        // сокращаем результирующую дробь с помощью метода Reduction()
                        label2.Text = Fraction.Div(Droba, Drobb).Reduction().ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                case "<=>":
                    if ((int.TryParse(textBox1.Text, out p)) && (int.TryParse(textBox2.Text, out p))
                        && (int.TryParse(textBox3.Text, out p)) && (int.TryParse(textBox4.Text, out p)))
                    {
                        Droba = new Fraction(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                        Drobb = new Fraction(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
                        label3.Text = Convert.ToString(Droba);
                        label4.Text = Convert.ToString(Drobb);
                        // сокращаем результирующую дробь с помощью метода Compare(Fraction a, Fraction b, bool c)
                        label2.Text = Fraction.Compare(Droba, Drobb, true).ToString();
                    }
                    else
                    {
                        label2.Text = "";
                        label3.Text = "";
                        label4.Text = "Введите числа в числитель и знаменатель";
                    }
                    break;

                default:
                    label2.Text = "Выберите действие \n" + "        с дробью";
                    break;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            // очищаем textBox после нажатия клавиши "Очистить"
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            label3.Text = "";
            label4.Text = "";
            label2.Text = "";
            comboBox1.SelectedIndex = -1; // очищаем comboBox1
            textBox1.Focus(); // установка фокуса на textBox числителя первой дроби
        }
        // пункт меню, в котором описано условие задания
        private void заданиеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правильная дробь, задаваемая числителем и знаменателем" + "\n\n" +
                             "    •  сложение" + '\n' +
                             "    •  вычитание" + '\n' +
                             "    •  умножение" + '\n' +
                             "    •  деление двух дробей" + '\n' +
                             "    •  сокращение дроби" + '\n' +
                             "    •  сравнение двух дробей");
        }
    }
}