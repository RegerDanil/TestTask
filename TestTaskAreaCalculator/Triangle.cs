using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskAreaCalculator
{
    public class Triangle : Shape
    {
        /// <summary>
        /// Создаёт новый экземпляр Triangle с переданными сторонами
        /// </summary>
        /// <param name="_side1">Сторона треугольника A</param>
        /// <param name="_side2">Сторона треугольника B</param>
        /// <param name="_side3">Сторона треугольника C</param>
        public Triangle(double _side1, double _side2, double _side3)
        {
            Measurments = new List<double>() { _side1, _side2, _side3 }.AsReadOnly();
        }

        /// <summary>
        /// Выполняет проверку переданного списка отрезков на описание действительного треугольника: длина списка - 3, double.MaxValue >= значение длины каждой из сторон > 0,
        /// Сумма длинн каждых 2 сторон больше длинны третьей стороны.
        /// </summary>
        /// <param name="measurments">Список отрезков, содержащий стороны треугольника</param>
        /// <returns>True - список отрезков описывает действительный треугольник, False - список отрезков не описывает действительный треугольник</returns>
        protected override bool IsValid(List<double> measurments)
        {
            if (measurments.Count == 3 &&
                measurments[0] > 0 &&
                measurments[1] > 0 &&
                measurments[2] > 0 &&
                measurments[0] <= double.MaxValue &&
                measurments[1] <= double.MaxValue &&
                measurments[2] <= double.MaxValue &&
                measurments[0] + measurments[1] > measurments[2] &&
                measurments[0] + measurments[2] > measurments[1] &&
                measurments[1] + measurments[2] > measurments[0]
            )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Определяет является ли треугольник прямоугольным.
        /// </summary>
        /// <returns>True - треугольник является прямоугольным, False - треугольник не является прямоугольным, null - невозможно определить тип треугольника из-за переполнения double</returns>
        public bool? IsRightTriangle()
        {
            var orderedMeasurments = Measurments.OrderByDescending(m => m).ToList();

            double csqr = Math.Pow(orderedMeasurments[0], 2);
            double bsqr = Math.Pow(orderedMeasurments[1], 2);
            double asqr = Math.Pow(orderedMeasurments[2], 2);

            if (double.IsInfinity(csqr) || double.IsInfinity(bsqr + asqr))
            {
                return null;
            }

            if (csqr == bsqr + asqr)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Выполняет рассчёт площади треугольника по 3 его сторонам
        /// </summary>
        /// <returns>Площадь треугольника. Возвращает double.PositiveInfinity, если в ходе вычисления произошло переполнение double</returns>
        protected override double CalculateArea()
        {
            double p = (Measurments[0] + Measurments[1] + Measurments[2]) / 2;
            return Math.Sqrt(p * (p - Measurments[0]) * (p - Measurments[1]) * (p - Measurments[2]));
        }
    }
}
