using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using Services;
using Inventor;
using Application = Inventor.Application;
namespace InventorApi;

public class InventorWrapper : IApi
{
    #region -- Properties --

    /// <summary>
    /// Ссылка на работу с документацией АПИ.
    /// </summary>
    private PartDocument PartDoc
    {
        get; set;
    }

    /// <summary>
    /// Ссылка на приложение Inventor.
    /// </summary>
    private Application InvApp
    {
        get; set;
    }

    /// <summary>
    /// Описание документа.
    /// </summary>
    private PartComponentDefinition PartDefinition
    {
        get; set;
    }

    /// <summary>
    /// Геометрия приложения.
    /// </summary>
    private TransientGeometry TransientGeometry
    {
        get; set;
    }

    /// <inheritdoc/>
    public double Unit => 10.0;

    #endregion

    #region -- IApiService --

    /// <inheritdoc/>
    public void CreateDocument()
    {
        InvApp = null;
        try
        {
            InvApp = (Application)Marshal2.GetActiveObject("Inventor.Application");
        }
        catch (COMException)
        {
            try
            {
                //Если не получилось перехватить приложение - выкинется исключение на то,
                //что такого активного приложения нет. Попробуем создать приложение вручную.
                var invAppType = Type.GetTypeFromProgID("Inventor.Application");

                InvApp = (Application)Activator.CreateInstance(invAppType);
                InvApp.Visible = true;
            }
            catch (Exception)
            {
                throw new ApplicationException(@"Не получилось запустить Inventor.");
            }
        }

        // В открытом приложении создаем документ
        PartDoc = (PartDocument)InvApp.Documents.Add
        (DocumentTypeEnum.kPartDocumentObject,
            InvApp.FileManager.GetTemplateFile
            (DocumentTypeEnum.kPartDocumentObject,
                SystemOfMeasureEnum.kMetricSystemOfMeasure));

        // Описание документа
        PartDefinition = PartDoc.ComponentDefinition;
        // Инициализация метода геометрии
        TransientGeometry = InvApp.TransientGeometry;
    }

    /// <inheritdoc/>
    public PointF CreatePoint(double x, double y)
    {
        var point = TransientGeometry.CreatePoint2d(x, y);
        return new PointF((float)point.X, (float)point.Y);
    }

    /// <inheritdoc/>
    public ISketch CreateNewSketch(int n)
    {
        return new InventorSketch(MakeNewSketch(n, 0), TransientGeometry);
    }

    /// <inheritdoc/>
    public void Extrude(ISketch sketch, double distance)
    {
        if (!(sketch is InventorSketch planarSketch))
        {
            throw new ArgumentException("Не подходящий экземпляр эскиза.");
        }

        Extrude(planarSketch.PlanarSketch, distance);
    }

    public void CutExtrude(ISketch sketch, double distance, bool isReverse)
    {
        if (!(sketch is InventorSketch planarSketch))
        {
            throw new ArgumentException("Не подходящий экземпляр эскиза.");
        }

        CatExtrude(planarSketch.PlanarSketch, distance);
    }

    #endregion

    #region -- Public Methods --

    /// <inheritdoc/>
    public override string ToString()
    {
        return "Inventor";
    }

    #endregion

    #region -- Private Methods --

    /// <summary>
    /// Создает новый эскиз на рабочей плоскости.
    /// </summary>
    /// <param name="n">1 - ZY; 2 - ZX; 3 - XY.</param>
    /// <param name="offset">Расстояние от поверхности.</param>
    /// <returns>Новый эскиз.</returns>
    private PlanarSketch MakeNewSketch(int n, double offset)
    {
        var mainPlane = PartDefinition.WorkPlanes[n];
        var offsetPlane = PartDefinition.WorkPlanes.AddByPlaneAndOffset(
            mainPlane, offset, false);
        offsetPlane.Visible = false;
        var sketch = PartDefinition.Sketches.Add(offsetPlane, false);
        return sketch;
    }

    /// <summary>
    /// Выдавливание.
    /// </summary>
    /// <param name="sketch">Эскиз.</param>
    /// <param name="distance">Значение, на которое происходит выдавливание.</param>
    private void Extrude(PlanarSketch sketch, double distance)
    {
        sketch.Visible = false;
        var sketchProfile = sketch.Profiles.AddForSolid();
        var extrudeDef =
            PartDefinition.Features.ExtrudeFeatures
                .CreateExtrudeDefinition(sketchProfile,
                    PartFeatureOperationEnum.kJoinOperation);
        extrudeDef.SetDistanceExtent(distance,
            PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
        var extrude = PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);
        var objectCollection = CreateObjectCollection();
        objectCollection.Add(extrude);
    }

    /// <summary>
    /// Выдавливание.
    /// </summary>
    /// <param name="sketch">Эскиз.</param>
    /// <param name="distance">Значение, на которое происходит выдавливание.</param>
    private void CatExtrude(PlanarSketch sketch, double distance)
    {
        sketch.Visible = false;
        var sketchProfile = sketch.Profiles.AddForSolid();
        var extrudeDef =
            PartDefinition.Features.ExtrudeFeatures
                .CreateExtrudeDefinition(sketchProfile,
                    PartFeatureOperationEnum.kCutOperation);
        extrudeDef.SetDistanceExtent(distance,
            PartFeatureExtentDirectionEnum.kPositiveExtentDirection);
        var extrude = PartDefinition.Features.ExtrudeFeatures.Add(extrudeDef);
        var objectCollection = CreateObjectCollection();
        objectCollection.Add(extrude);
    }

    /// <summary>
    /// Создание объекта коллекции.
    /// </summary>
    /// <returns>Коллекция объектов</returns>
    private ObjectCollection CreateObjectCollection()
    {
        return InvApp.TransientObjects.CreateObjectCollection();
    }

    #endregion
}


