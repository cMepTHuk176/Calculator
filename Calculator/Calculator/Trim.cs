// мега костыльняая фигня на свиче
// состояния condition:
// Состояние 0 - начальный нуль
// Состояние 1 - последний символ - цифра
// Состояние 2 - последний символ - знак
// Состояние 3 - последний символ - точка
// Состояние 4 - последний символ - нуль после знака (так надо)
// Основные баги возникают при стирании выражения по 1 символу
namespace Calculator
{
    class Trim
    {
        static int condition = 0;
        public static string Result(string num, string button, bool number_mode)
        {
            if (num.IndexOf('=') != -1)
                num = num.Remove(0, num.IndexOf('=')+2) ;
            switch (condition)
            {
                case 0:
                    switch (number_mode)
                    {
                        case true:
                            if (button != "0")
                            {
                                num += button;
                                num = num.TrimStart('0');
                                condition = 1;
                                break;
                            }
                            break;
                        case false:
                            if (button == ".")
                            {
                                num += button;
                                condition = 3;
                                break;
                            }
                            num += button;
                            condition = 2;
                            break;
                    }
                    break;
                case 1:
                    switch (number_mode)
                    {
                        case true:
                            num += button;
                            condition = 1;
                            break;
                        case false:
                            if (button == ".")
                            {
                                num += button;
                                condition = 3;
                                break;
                            }
                            num += button;
                            condition = 2;
                            break;
                    }
                    break;
                case 2:
                    switch (number_mode)
                    {
                        case true:
                            if (button == "0")
                            {
                                num += button;
                                condition = 4;
                                break;
                            }
                            num += button;
                            condition = 1;
                            break;
                        case false:
                            break;
                    }
                    break;
                case 3:
                    switch (number_mode)
                    {
                        case true:
                            num += button;
                            break;
                        case false:
                            if (button != ".")
                            {
                                num += button;
                                condition = 2;
                                break;
                            }
                            else
                                break;
                    }
                    break;
                case 4:
                    switch (number_mode)
                    {
                        case true:
                            break;
                        case false:
                            if (button == ".")
                            {
                                num += button;
                                condition = 3;
                                break;
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }

            return num;
        }
        public static string Delete(string mod, bool state)
        {
            string last;
            switch (state)
            {
                case true:
                    if (mod.IndexOf('=') != -1)
                        break;
                    if (mod.Length > 1)
                    {
                        mod = mod.Substring(0, mod.Length - 1);
                        last = mod.Substring(mod.Length - 1);
                        if (last == "0")
                            Trim.condition = 4;
                        else if (last == ".")
                            Trim.condition = 3;
                        else if (last == "-" && last == "+" && last == "×" && last == "÷")
                            Trim.condition = 2;
                        else
                            Trim.condition = 1;
                    }
                    else
                    {
                        mod = "0";
                        Trim.condition = 0;
                    }
                    break;
                case false:
                    mod = "0";
                    Trim.condition = 0;
                    break;
            }
            return mod;
        }
    }
}
