using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Services;

namespace Buidler
{
    /// <summary>
    /// Класс для создания стеллажа.
    /// </summary>
    public class ShelfBuilder
    {
        /// <summary>
        /// Метод для создания стеллажа
        /// </summary>
        /// <param name="fenceParameters">Параметры стеллажа</param>
        /// <param name="apiService">Апи</param>
        public void BuildShelf(ShelfParameters fenceParameters, IApi apiService)
        {
            apiService = apiService;

            var points = new List<PointF>
            {
                apiService.CreatePoint(0, 0),
                apiService.CreatePoint(100, 100),

            };

            apiService.CreateDocument();
            var sketchXy = apiService.CreateNewSketch(3, 0);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);



            apiService.Extrude(sketchXy, 100);






            points = new List<PointF>
            {
                apiService.CreatePoint(10, 10),
                apiService.CreatePoint(90, 90),

            };

            var sketchXy1 = apiService.CreateNewSketch(1, 0);

            sketchXy1.CreateTwoPointRectangle(points[0], points[1]);
            apiService.CutExtrude(sketchXy1, 100);
        }
    }
}
