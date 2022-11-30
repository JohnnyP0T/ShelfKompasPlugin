using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace CommonTestClass;

/// <summary>
/// Тестовый класс эскиза.
/// </summary>
public class TestSketch : Services.ISketch
{
    /// <summary>
    /// Флаг создания прямоугольника.
    /// </summary>
    public bool IsCreateTwoPointRectangle { get; private set; } = false;

    /// <inheritdoc/>
    public void CreateTwoPointRectangle(PointF point1, PointF point2)
    {
        IsCreateTwoPointRectangle = true;
    }
}
