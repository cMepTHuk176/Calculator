using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    /// <summary>
    /// Класс, предоставляющий различные физические константы
    /// </summary>
    public static class PhysConstants
    {
        /// <summary>
        /// Газовая постоянная
        /// </summary>
        public const double R = 8.314;

        /// <summary>
        /// Тут не нужно объяснять
        /// </summary>
        public const double g = 9.81;

        /// <summary>
        /// Гравитационная постоянная
        /// </summary>
        public const double G = 6.67E-11;

        /// <summary>
        /// Атмосферное давление на уровне моря
        /// </summary>
        public const double DefaultPressure = 101325.0;

        /// <summary>
        /// Молярная масса воздуха
        /// </summary>
        public const double MolarMass_Air = 0.029;
    }
}
