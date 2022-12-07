using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using Services;
using Point = Inventor.Point;

namespace InventorApi;
public class InventorSketch : ISketch
{
    /// <summary>
    /// Геометрия.
    /// </summary>
    private readonly TransientGeometry _transientGeometry;

    /// <summary>
    /// Возвращает эскиз.
    /// </summary>
    public PlanarSketch PlanarSketch
    {
        get;
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="planarSketch">Эскиз.</param>
    /// <param name="transientGeometry">Геометрия приложения.</param>
    public InventorSketch(PlanarSketch planarSketch, TransientGeometry transientGeometry)
    {
        PlanarSketch = planarSketch;
        _transientGeometry = transientGeometry;
    }

    /// <inheritdoc/>
    public void CreateTwoPointRectangle(PointF point1, PointF point2)
    {
        var newPoint1 = _transientGeometry.CreatePoint2d(point1.X, point1.Y);
        var newPoint2 = _transientGeometry.CreatePoint2d(point2.X, point2.Y);
        PlanarSketch.SketchLines.AddAsTwoPointRectangle(newPoint1, newPoint2);
    }
}
