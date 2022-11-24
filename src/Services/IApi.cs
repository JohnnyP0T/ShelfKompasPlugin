using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Сервис для API.
    /// </summary>
    public interface IApi
    {
        /// <summary>
        /// Создать документ API.
        /// </summary>
        void CreateDocument();

        /// <summary>
        /// Создание точки.
        /// </summary>
        /// <param name="x">X координата.</param>
        /// <param name="y">Y координата.</param>
        /// <returns>Точку.</returns>
        PointF CreatePoint(double x, double y);

        /// <summary>
        /// Создание эскиза.
        /// </summary>
        /// <param name="n"> Плоскость 1 - ZY; 2 - ZX; 3 - XY.</param>
        /// <param name="offset">Расстояние от плоскости.</param>
        /// <returns></returns>
        ISketch CreateNewSketch(int n, double offset);

        /// <summary>
        /// Выдавливание по эскизу.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Расстояние выдавливания.</param>
        void Extrude(ISketch sketch, double distance);

        /// <summary>
        /// Выдавливание с вырезом по эскизу.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Расстояние выдавливания.</param>
        void CutExtrude(ISketch sketch, double distance);
    }
}
