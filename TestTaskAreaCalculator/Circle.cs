using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskAreaCalculator
{
    /// <summary>
    /// Класс, создает объект круг и вычисляет его площадь
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="_radius">Радиус</param>
        public Circle(double _radius)
        {
            Measurments = new List<double>() { _radius }.AsReadOnly();
        }
        /// <summary>
        /// Метод проводит проверку на описание действительного круга: измерение равно 1, длина измерения больше нуля, длина измерения не превышает максимального допустимого значения
        /// </summary>
        /// <param name="measurments">Измерения</param>
        /// <returns></returns>
        protected override bool IsValid(List<double> measurments)
        {
            if (measurments.Count == 1 && measurments[0] > 0 && measurments[0] <= double.MaxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Выполняет рассчёт площади круга по его радиусу
        /// </summary>
        /// <returns>Площадь круга</returns>
        protected override double CalculateArea()
        {
            return Math.PI * Math.Pow(Measurments[0], 2);
        }
    }
}
