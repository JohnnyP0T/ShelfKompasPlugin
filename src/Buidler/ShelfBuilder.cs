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
        /// <param name="shelfParameters">Параметры стеллажа</param>
        /// <param name="apiService">Апи</param>
        public void BuildShelf(ShelfParameters shelfParameters, IApi apiService)
        {
            //TODO

            #region Создание основной коробки

            var points = new List<PointF>
            {
                apiService.CreatePoint(0, 0),
                apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.Width].Value, shelfParameters.ShelfParameterCollection[ParameterType.Length].Value),
            };

            apiService.CreateDocument();
            var sketchXy = apiService.CreateNewSketch(3, 0);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            apiService.Extrude(sketchXy, shelfParameters.ShelfParameterCollection[ParameterType.Height].Value);

            #endregion

            //___________________________________

            #region Нижний отступ

            points = new List<PointF>
            {
                apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value, 0),
                apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.Width].Value - shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                    shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value),
            };

            var sketchXy1 = apiService.CreateNewSketch(2, 0);

            sketchXy1.CreateTwoPointRectangle(points[0], points[1]);
            apiService.CutExtrude(sketchXy1, shelfParameters.ShelfParameterCollection[ParameterType.Length].Value);

            #endregion

            //___________________________________

            #region Нижний отступ спереди

            points = new List<PointF>
            {
                apiService.CreatePoint(0, -shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value),
                apiService.CreatePoint(-shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value,
                    -(shelfParameters.ShelfParameterCollection[ParameterType.Length].Value - shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value)),
            };

            var sketchXy3 = apiService.CreateNewSketch(1, 0);

            sketchXy3.CreateTwoPointRectangle(points[0], points[1]);
            apiService.CutExtrude(sketchXy3, shelfParameters.ShelfParameterCollection[ParameterType.Width].Value);

            #endregion
            //___________________________________

            //___________________________________

            #region Верхний отступ

            
            points = new List<PointF>
            {
                apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value, shelfParameters.ShelfParameterCollection[ParameterType.Height].Value),
                apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.Width].Value - shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                    shelfParameters.ShelfParameterCollection[ParameterType.Height].Value - shelfParameters.ShelfParameterCollection[ParameterType.UpperIndent].Value),
            };

            var sketchXy5 = apiService.CreateNewSketch(2, 0);

            sketchXy5.CreateTwoPointRectangle(points[0], points[1]);
            apiService.CutExtrude(sketchXy5, shelfParameters.ShelfParameterCollection[ParameterType.Length].Value);

            #endregion

            //___________________________________

            #region Верхний отступ спереди

            points = new List<PointF>
            {
                apiService.CreatePoint(-shelfParameters.ShelfParameterCollection[ParameterType.Height].Value, -shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value),
                apiService.CreatePoint(-(shelfParameters.ShelfParameterCollection[ParameterType.Height].Value - shelfParameters.ShelfParameterCollection[ParameterType.UpperIndent].Value),
                    -(shelfParameters.ShelfParameterCollection[ParameterType.Length].Value - shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value)),
            };

            var sketchXy6 = apiService.CreateNewSketch(1, 0);

            sketchXy6.CreateTwoPointRectangle(points[0], points[1]);
            apiService.CutExtrude(sketchXy6, shelfParameters.ShelfParameterCollection[ParameterType.Width].Value);

            #endregion
            //___________________________________

            #region Полки

            var counter = Math.Floor((shelfParameters.ShelfParameterCollection[ParameterType.Height].Value -
                                      shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value -
                                      shelfParameters.ShelfParameterCollection[ParameterType.UpperIndent].Value -
                                      shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value) /
                                     (shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value +
                                      shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value));
            for (int i = 0; i < counter; i++)
            {
                #region Полка сбоку

                points = new List<PointF>
                {
                    apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                        shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i + shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                    apiService.CreatePoint(shelfParameters.ShelfParameterCollection[ParameterType.Width].Value - shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                        (shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value) + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i +
                        shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value + shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                };
                var sketchXy2 = apiService.CreateNewSketch(2, 0);

                sketchXy2.CreateTwoPointRectangle(points[0], points[1]);
                apiService.CutExtrude(sketchXy2, shelfParameters.ShelfParameterCollection[ParameterType.Length].Value);

                #endregion

                //__________________________________________________

                #region Полка спереди

                points = new List<PointF>
                {
                    apiService.CreatePoint(-(shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i + shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                        -shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value),
                    apiService.CreatePoint(-((shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value) + shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i +
                                             shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value + shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                        -(shelfParameters.ShelfParameterCollection[ParameterType.Length].Value - shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value)),
                };
                var sketchXy4 = apiService.CreateNewSketch(1, 0);

                sketchXy4.CreateTwoPointRectangle(points[0], points[1]);
                apiService.CutExtrude(sketchXy4, shelfParameters.ShelfParameterCollection[ParameterType.Width].Value);

                #endregion


            }

            #endregion
        }
    }
}
