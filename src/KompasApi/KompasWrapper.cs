using Kompas6API5;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace KompasApi
{
    /// <summary>
    /// Класс построения стеллажа в Компас 3D.
    /// </summary>
    public class KompasWrapper : IApi
    {
        /// <summary>
		/// Объект Компас 3D.
		/// </summary>
		private KompasObject _kompasObject;

        /// <summary>
        /// 3D документ компаса.
        /// </summary>
        private ksDocument3D _document3D;

        /// <summary>
        /// Часть документа.
        /// </summary>
        private ksPart _part;

        public void CreateDocument()
        {
            if (_kompasObject == null)
            {
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(kompasType);
            }

            if (_kompasObject != null)
            {
                var retry = true;
                short tried = 0;
                while (retry)
                {
                    try
                    {
                        tried++;
                        _kompasObject.Visible = true;
                        retry = false;
                    }
                    catch (COMException)
                    {
                        var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                        _kompasObject =
                            (KompasObject)Activator.CreateInstance(kompasType);

                        if (tried > 3)
                        {
                            retry = false;
                        }
                    }
                }

                _kompasObject.ActivateControllerAPI();
                _document3D = (ksDocument3D)_kompasObject.Document3D();
                _document3D.Create();
                _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
            }
        }

        /// <summary>
        /// Создание точки.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public PointF CreatePoint(double x, double y)
        {
            //return new Point(x, y); TODO
            return new PointF((float)x, (float)y);
        }

        /// <summary>
        /// Создание эскиза.
        /// </summary>
        /// <param name="n">Плоскость.</param>
        /// <returns></returns>
        public ISketch CreateNewSketch(int n)
        {
            return new KompasSketch(_part, n);
        }

        /// <summary>
        /// Выдавливание.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Дистанция выдавливания.</param>
        /// <exception cref="TypeAccessException"></exception>
        public void Extrude(ISketch sketch, double distance)
        {
            if (!(sketch is KompasSketch kompasSketch))
            {
                throw new TypeAccessException($"Неверный тип эскиза." +
                                              $" Нужный тип эскиза {nameof(KompasSketch)}.");
            }

            kompasSketch.EndEdit();
            ksEntity extrude = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = (ksBossExtrusionDefinition)extrude.GetDefinition();
            extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            ksExtrusionParam extrudeParam = (ksExtrusionParam)extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = distance;
            extrude.Create();
        }

        /// <summary>
        /// Выдавливание с вырезом.
        /// </summary>
        /// <param name="sketch">Эскиз.</param>
        /// <param name="distance">Дистанция выдавливания.</param>
        /// <exception cref="TypeAccessException"></exception>
        public void CutExtrude(ISketch sketch, double distance)
        {
            if (!(sketch is KompasSketch kompasSketch))
            {
                throw new TypeAccessException($"Неверный тип эскиза." +
                                              $" Нужный тип эскиза {nameof(KompasSketch)}.");
            }

            kompasSketch.EndEdit();
            ksEntity extrude = (ksEntity)_part.NewEntity((int)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition extrudeDefinition = (ksCutExtrusionDefinition)extrude.GetDefinition();
            extrudeDefinition.directionType = (int)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(kompasSketch.Sketch);
            ksExtrusionParam extrudeParam = (ksExtrusionParam)extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = distance;
            extrude.Create();
        }
    }
}
