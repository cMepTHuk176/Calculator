using Xamarin.Forms;

namespace Calculator
{
    /// <summary>
    /// Класс-конвертер, преобразующий различные величины
    /// </summary>
    public static class Converter
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="resultPicker">Параметр, к единице измерения которого должен быть приведен результат</param>
        /// <param name="pickers">Все сравниваемые значения</param>
        /// <returns>Множитель дальнейшего результата</returns>
        public static double ConvertToLength(Picker resultPicker, params Picker[] pickers)
        {
            double multiplier = 1;

            switch ((LengthPickerState)resultPicker.SelectedIndex)
            {
                case LengthPickerState.м:
                    foreach (var item in pickers)
                    {
                        switch ((LengthPickerState)item.SelectedIndex)
                        {
                            case LengthPickerState.дм:
                                multiplier *= 0.1;
                                break;

                            case LengthPickerState.см:
                                multiplier *= 0.01;
                                break;

                            case LengthPickerState.мм:
                                multiplier *= 0.001;
                                break;
                        }

                    }
                    break;

                case LengthPickerState.дм:
                    foreach (var item in pickers)
                    {
                        switch ((LengthPickerState)item.SelectedIndex)
                        {
                            case LengthPickerState.м:
                                multiplier *= 10;
                                break;

                            case LengthPickerState.см:
                                multiplier *= 0.1;
                                break;

                            case LengthPickerState.мм:
                                multiplier *= 0.01;
                                break;
                        }

                    }
                    break;

                case LengthPickerState.см:
                    foreach (var item in pickers)
                    {
                        switch ((LengthPickerState)item.SelectedIndex)
                        {
                            case LengthPickerState.м:
                                multiplier *= 100;
                                break;

                            case LengthPickerState.дм:
                                multiplier *= 10;
                                break;

                            case LengthPickerState.мм:
                                multiplier *= 0.1;
                                break;
                        }
                    }
                    break;

                case LengthPickerState.мм:
                    foreach (var item in pickers)
                    {
                        switch ((LengthPickerState)item.SelectedIndex)
                        {
                            case LengthPickerState.м:
                                multiplier *= 1000;
                                break;

                            case LengthPickerState.дм:
                                multiplier *= 100;
                                break;

                            case LengthPickerState.см:
                                multiplier *= 10;
                                break;
                        }

                    }
                    break;
            }

            return multiplier;
        }
    }
}