using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Интерфейс эскиза.
    /// </summary>
    public interface ISketch
    {
        /// <summary>
        /// Построение на эскизе прямоугольника через две точки.
        /// </summary>
        /// <param name="point1">Первая точка.</param>
        /// <param name="point2">Вторая точка.</param>
        void CreateTwoPointRectangle(PointF point1, PointF point2);
    }
}
