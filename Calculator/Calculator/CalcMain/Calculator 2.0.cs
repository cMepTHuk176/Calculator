using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {

        // Counting соответственно его вычисляет
        // Все исключения обрабатываются тупым try
        // метод вывода результата
        public static string Calculate(string input)
        {
            string output = Modification(input);
            return Counting(output);
        }
        // приоритетность разрешенных символов
        private static byte Priority(char c)
        {
            return c switch
            {
                '(' => 0,
                ')' => 1,
                '+' => 2,
                '-' => 3,
                '*' => 4,
                '/' => 4,
                '^' => 5,
                'c' => 6,
                's' => 6,
                'x' => 6,
                _ => 8,
            };
        }
        // обработка тригонометрических функций
        private static string Tg_mod(string input)
        {
            if (input.IndexOf('s') != -1)
            {
                input = input.Replace("sin", "s");
            }
            if (input.IndexOf('c') != -1)
            {
                input = input.Replace("cos", "c");
            }
            return input;
        }
        // обработка операторов
        private static bool IfOperator(char с)
        {
            if ("+-÷×^()cs".IndexOf(с) != -1)
                return true;
            return false;
        }
        // обработка разделителей
        private static bool Separator(char c)
        {
            if (" ".IndexOf(c) != -1)
                return true;
            return false;
        }

        //преобразование строки в обратную польскую запись
        private protected static string Modification(string input)
        {
            input = Tg_mod(input);
            string output = string.Empty;
            // operStack - основной стек выражения
            Stack<char> operStack = new();
            try
            {
                input = Tg_mod(input);
                for (int i = 0; i < input.Length; i++)
                {
                    if (Separator(input[i]))
                        continue;
                    if (Char.IsDigit(input[i]))
                    {
                        while (!Separator(input[i]) && !IfOperator(input[i]))
                        {
                            output += input[i];
                            i++;

                            if (i == input.Length) break;
                        }
                        output += " ";
                        i--;
                    }
                    if (IfOperator(input[i]))
                    {
                        if (input[i] == '(')
                            operStack.Push(input[i]);
                        else if (input[i] == ')')
                        {

                            char s = operStack.Pop();

                            while (s != '(')
                            {
                                output += s.ToString() + ' ';
                                s = operStack.Pop();
                            }
                        }
                        else
                        {
                            if (operStack.Count > 0)
                                if (Priority(input[i]) <= Priority(operStack.Peek()))
                                    output += operStack.Pop().ToString() + " ";

                            operStack.Push(char.Parse(input[i].ToString()));

                        }
                    }
                }


                while (operStack.Count > 0)
                    output += operStack.Pop() + " ";
            }
            catch
            {
                return "Ошибка";
            }
            return output;
        }
        // вычисление строки обратной польской записи в число
        private protected static string Counting(string input)
        {
            decimal result = 0;
            Stack<decimal> temp = new();
            string buf;
            try
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]))
                    {
                        string a = string.Empty;

                        while (!Separator(input[i]) && !IfOperator(input[i]))
                        {
                            a += input[i];
                            i++;
                            if (i == input.Length) break;
                        }
                        temp.Push(decimal.Parse(a));
                        i--;
                    }
                    else if (IfOperator(input[i]))
                    {
                        decimal a = temp.Pop();
                        decimal b = temp.Pop();

                        switch (input[i])
                        {
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '×': result = b * a; break;
                            case '÷': result = b / a; break;
                            case 'c': result = decimal.Parse(Math.Cos(double.Parse(a.ToString())).ToString()); break;
                            case 's': result = decimal.Parse(Math.Sin(double.Parse(a.ToString())).ToString()); break;
                            case '^': result = decimal.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                        }
                        temp.Push(result);
                    }
                }
                buf = Convert.ToString(temp.Peek());
            }
            catch
            {
                return "Ошибка";
            }
            return buf;
        }
    }
}
