using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;
using Services;

namespace KompasApi
{
    /// <summary>
    /// Класс эскиза Компас 3D.
    /// </summary>
    public class KompasSketch : Services.ISketch
    {
        /// <summary>
        /// 2D документ.
        /// </summary>
        private ksDocument2D _document2D;

        /// <summary>
        /// Определенны эскиз.
        /// </summary>
        private readonly ksSketchDefinition _sketchDefinition;

        /// <summary>
        /// Возвращает эскиз.
        /// </summary>
        public ksEntity Sketch { get; }

        private bool _isInvertZx
        {
            get;
            set;
        }
        private bool _isInvertZy
        {
            get;
            set;
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="n">1 - ZY; 2 - ZX; 3 - XY.</param>
        public KompasSketch(ksPart part, int n)
        {
            ksEntity plane;
            if (n == 1)
            {
                plane = (ksEntity)part.GetDefaultEntity((int)Obj3dType.o3d_planeYOZ);
                _isInvertZx = false;
                _isInvertZy = true;
            }
            else if(n == 2)
            {
                plane = (ksEntity)part.GetDefaultEntity((int)Obj3dType.o3d_planeXOZ);
                _isInvertZx = true;
                _isInvertZy = false;
            }
            else
            {
                plane = (ksEntity)part.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
                _isInvertZx = false;
                _isInvertZy = false;
            }
            Sketch = (ksEntity)part.NewEntity((int)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)Sketch.GetDefinition();
            _sketchDefinition.SetPlane(plane);
            Sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();
        }

        /// <summary>
        /// Завершить редактирование.
        /// </summary>
        public void EndEdit()
        {
            _sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Создать прямоугольник по двум точкам.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void CreateTwoPointRectangle(PointF point1, PointF point2)
        {
            if (_isInvertZx)
            {
                _document2D.ksLineSeg(-point1.X, -point1.Y, -point2.X, -point1.Y, 1);
                _document2D.ksLineSeg(-point2.X, -point1.Y, -point2.X, -point2.Y, 1);
                _document2D.ksLineSeg(-point1.X, -point2.Y, -point2.X, -point2.Y, 1);
                _document2D.ksLineSeg(-point1.X, -point1.Y, -point1.X, -point2.Y, 1);
            }
            else if (_isInvertZy)
            {
                (point2.X, point2.Y) = (point2.Y, point2.X);
                (point1.X, point1.Y) = (point1.Y, point1.X);

                _document2D.ksLineSeg(-point1.X, -point1.Y, -point2.X, -point1.Y, 1);
                _document2D.ksLineSeg(-point2.X, -point1.Y, -point2.X, -point2.Y, 1);
                _document2D.ksLineSeg(-point1.X, -point2.Y, -point2.X, -point2.Y, 1);
                _document2D.ksLineSeg(-point1.X, -point1.Y, -point1.X, -point2.Y, 1);
            }
            else
            {
                _document2D.ksLineSeg(point1.X, point1.Y, point2.X, point1.Y, 1);
                _document2D.ksLineSeg(point2.X, point1.Y, point2.X, point2.Y, 1);
                _document2D.ksLineSeg(point1.X, point2.Y, point2.X, point2.Y, 1);
                _document2D.ksLineSeg(point1.X, point1.Y, point1.X, point2.Y, 1);
            }
        }
    }
}
