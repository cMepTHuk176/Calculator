using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.CalcMain
{
    class DoubleCalculator : Calculator
    {
        // метод XMod принимает на вход строку калькулятора
        // разделяет строку на 3. Каждая строка содержит лишь элементы,
        // с которыми можно производить математические действия.
        // далее строка отправляется в конструкцию Modification -> Counting 
        // стандартного калькулятора на обратной польской записи.
        // После вычислений 3 строки, содержащие по одному числу (по крайней мере 0)
        // проходят расчет квадратного уравнения.
        // Если число комплексное возратит NaN
        public static (string, string, string) DoubleCalculate(string input)
        {
            string a, b, c;
            (a, b, c) = XMod(input);
            a = Counting(Modification(a));
            b = Counting(Modification(b));
            c = Counting(Modification(c));
            if (a == "Ошибка" || b == "Ошибка" || c == "Ошибка")
                return (a, b, c);
            return SolveQuadraticEquation(double.Parse(a), double.Parse(b), double.Parse(c));
        }
        private static (string, string, string) XMod(string input)
        {
            try
            {
                // для удобства парсинга неизвестные x^2 и x заменяются на a и b
                string a = "0", b = "0", c = "0";
                if (input.IndexOf('x') != -1)
                {
                    if (input.IndexOf('^') + 1 != -1)
                    {
                        input = input.Replace("x²", "a");
                    }
                    input = input.Replace("x", "b");
                }

                for (int i = 0; i < input.Length; i++)
                {
                    string buf = null;
                    // сначала записывается оператор числа
                    if (IfOperator(input[i]))
                    {
                        buf += input[i];
                        // переходит на следующий элемент, где ожидается число
                        i++;
                    }
                    // пока не встретили новый оператор, записываем все получившееся число
                    while (!IfOperator(input[i]))
                    {
                        buf += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    // если в итоговом числе содержится а, b неизвестная удаляется
                    // а число заносится в свою соответствующую строку
                    // если итоговое число = ничего, заносится единица.
                    if (buf.IndexOf('a') != -1)
                    {
                        buf = buf.Remove(buf.IndexOf('a'));
                        if (buf == "" || buf == "-")
                            buf += "1";
                        a += buf;
                    }
                    else if (buf.IndexOf('b') != -1)
                    {
                        buf = buf.Remove(buf.IndexOf('b'));
                        if (buf == "" || buf == "-")
                            buf += "1";
                        b += buf;
                    }
                    else if (buf != "0")
                        c += buf;
                    i--;
                }
                return (a, b, c);
            }
            // обязательно нужно, чтобы после оператора бало хоть какое то число
            // иначе сразу ошибка
            catch
            {
                return ("Ошибка", "Ошибка", "Ошибка");
            }
        }
        // расчет квадратного уравнения по 3 переменным
        public static (string, string, string) SolveQuadraticEquation(double a, double b, double c)
        {
            double discRoot = Math.Sqrt(b * b - 4 * a * c);
            double x1 = (-b + discRoot) / (2 * a);
            double x2 = (-b - discRoot) / (2 * a);
            return (x1.ToString(), x2.ToString(), discRoot.ToString());
        }

    }
}
