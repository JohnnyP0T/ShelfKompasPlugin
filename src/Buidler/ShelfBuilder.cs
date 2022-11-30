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
        private ShelfParameters _shelfParameters;

        private IApi _apiService;

        /// <summary>
        /// Метод для создания стеллажа
        /// </summary>
        /// <param name="shelfParameters">Параметры стеллажа</param>
        /// <param name="apiService">Апи</param>
        public void BuildShelf(ShelfParameters shelfParameters, IApi apiService)
        {
            _shelfParameters = shelfParameters;
            _apiService = apiService;

            CreateBaseFigure();
            CreateLowerIndent();
            CreateUpperIndent();
            CreateShelf();
        }

        #region Создание основной коробки
        /// <summary>
        /// Создание основной коробки.
        /// </summary>
        private void CreateBaseFigure()
        {

            var points = new List<PointF>
            {
                _apiService.CreatePoint(0, 0),
                _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.Width].Value, 
                    _shelfParameters.ShelfParameterCollection[ParameterType.Length].Value),
            };

            _apiService.CreateDocument();
            var sketchXy = _apiService.CreateNewSketch(3, 0);

            sketchXy.CreateTwoPointRectangle(points[0], points[1]);

            _apiService.Extrude(sketchXy, _shelfParameters.ShelfParameterCollection[ParameterType.Height].Value);

        }
        #endregion

        #region Нижний отступ

        /// <summary>
        /// Нижний отступ.
        /// </summary>
        private void CreateLowerIndent()
        {
            #region Нижний отступ сзади

            var points = new List<PointF>
            {
                _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value, 0),
                _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.Width].Value - _shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                    _shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value),
            };

            var sketchXy1 = _apiService.CreateNewSketch(2, 0);

            sketchXy1.CreateTwoPointRectangle(points[0], points[1]);
            _apiService.CutExtrude(sketchXy1, _shelfParameters.ShelfParameterCollection[ParameterType.Length].Value);

            #endregion

            #region Нижний отступ спереди

            points = new List<PointF>
            {
                _apiService.CreatePoint(0, -_shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value),
                _apiService.CreatePoint(-_shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value,
                    -(_shelfParameters.ShelfParameterCollection[ParameterType.Length].Value - _shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value)),
            };

            var sketchXy3 = _apiService.CreateNewSketch(1, 0);

            sketchXy3.CreateTwoPointRectangle(points[0], points[1]);
            _apiService.CutExtrude(sketchXy3, _shelfParameters.ShelfParameterCollection[ParameterType.Width].Value);

            #endregion
        }

        #endregion

        #region Верхний отступ

        /// <summary>
        /// Верхний отступ
        /// </summary>
        private void CreateUpperIndent()
        {
            #region Верхний отступ сзади

            var points = new List<PointF>
            {
                _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value, _shelfParameters.ShelfParameterCollection[ParameterType.Height].Value),
                _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.Width].Value - _shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                    _shelfParameters.ShelfParameterCollection[ParameterType.Height].Value - _shelfParameters.ShelfParameterCollection[ParameterType.UpperIndent].Value),
            };

            var sketchXy5 = _apiService.CreateNewSketch(2, 0);

            sketchXy5.CreateTwoPointRectangle(points[0], points[1]);
            _apiService.CutExtrude(sketchXy5, _shelfParameters.ShelfParameterCollection[ParameterType.Length].Value);

            #endregion

            #region Верхний отступ спереди

            points = new List<PointF>
            {
                _apiService.CreatePoint(-_shelfParameters.ShelfParameterCollection[ParameterType.Height].Value, -_shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value),
                _apiService.CreatePoint(-(_shelfParameters.ShelfParameterCollection[ParameterType.Height].Value - _shelfParameters.ShelfParameterCollection[ParameterType.UpperIndent].Value),
                    -(_shelfParameters.ShelfParameterCollection[ParameterType.Length].Value - _shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value)),
            };

            var sketchXy6 = _apiService.CreateNewSketch(1, 0);

            sketchXy6.CreateTwoPointRectangle(points[0], points[1]);
            _apiService.CutExtrude(sketchXy6, _shelfParameters.ShelfParameterCollection[ParameterType.Width].Value);

            #endregion
        }

        #endregion

        #region Полки

        /// <summary>
        /// Полки.
        /// </summary>
        private void CreateShelf()
        {
            var counter = Math.Floor((_shelfParameters.ShelfParameterCollection[ParameterType.Height].Value -
                                      _shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value -
                                      _shelfParameters.ShelfParameterCollection[ParameterType.UpperIndent].Value -
                                      _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value) /
                                     (_shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value +
                                      _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value));
            for (int i = 0; i < counter; i++)
            {
                #region Полка сбоку

                var points = new List<PointF>
                {
                    _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                        _shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i + _shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                    _apiService.CreatePoint(_shelfParameters.ShelfParameterCollection[ParameterType.Width].Value - _shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value,
                        (_shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value) + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i +
                        _shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value + _shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                };
                var sketchXy2 = _apiService.CreateNewSketch(2, 0);

                sketchXy2.CreateTwoPointRectangle(points[0], points[1]);
                _apiService.CutExtrude(sketchXy2, _shelfParameters.ShelfParameterCollection[ParameterType.Length].Value);

                #endregion

                #region Полка спереди

                points = new List<PointF>
                {
                    _apiService.CreatePoint(-(_shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i + _shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                        -_shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value),
                    _apiService.CreatePoint(-((_shelfParameters.ShelfParameterCollection[ParameterType.LowerIndent].Value + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value) + _shelfParameters.ShelfParameterCollection[ParameterType.WidthShelf].Value * i +
                                             _shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value + _shelfParameters.ShelfParameterCollection[ParameterType.HeightShelf].Value * i),
                        -(_shelfParameters.ShelfParameterCollection[ParameterType.Length].Value - _shelfParameters.ShelfParameterCollection[ParameterType.WidthRack].Value)),
                };
                var sketchXy4 = _apiService.CreateNewSketch(1, 0);

                sketchXy4.CreateTwoPointRectangle(points[0], points[1]);
                _apiService.CutExtrude(sketchXy4, _shelfParameters.ShelfParameterCollection[ParameterType.Width].Value);

                #endregion
            }
        }

        #endregion
    }
}
