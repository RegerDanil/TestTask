using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestTaskAreaCalculator
{
    /// <summary>
    /// Создаем абстрактный класс от которого будут наследоваться остальные. 
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Заведем лист, в котором будут содержаться измерения, чтобы расчитывать площадь различных фигур
        /// </summary>
        private List<double> measurments;

        public ReadOnlyCollection<double> Measurments
        {
            set
            {
                if (IsValid(value.ToList()))
                {
                    measurments = value.ToList();
                }
                else
                {
                    throw new ArgumentException("Shape measurments are invalid");
                }
            }
            get
            {
                return measurments.AsReadOnly();
            }

        }
        /// <summary>
        /// Данный абстрактный метод проверяет поступивший список измерений на то, что они описывают действительную фигуру
        /// </summary>
        /// <param name="_measurments">Список измерений для проверки</param>
        /// <returns>True - список измерений описывает действительную фигуру, False - список измерений не описывает действительную фигуру</returns>
        protected abstract bool IsValid(List<double> _measurments);
        /// <summary>
        /// Абстрактный метод, который вычисляет площадь фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        protected abstract double CalculateArea();
        /// <summary>
        /// Свойство, возвращающее площадь фигуры
        /// </summary>
        public double Area { get { return CalculateArea(); } }
    }
}
