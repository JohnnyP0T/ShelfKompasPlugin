using Core;

namespace TestCore;

/// <summary>
/// Класс для тестирования класса <see cref="Core.ShelfParameters"/>.
/// </summary>
[TestFixture]
public class TestShelfParameters
{
    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="Core.ShelfParameters"/>.
    /// </summary>
    private ShelfParameters ShelfParameters => new ShelfParameters();

    [TestCase(ParameterType.Length, 1000,
        TestName = "Проверка корректного получения" +
                         " значения свойства Length.")]
    [TestCase(ParameterType.Height, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства Height.")]
    [TestCase(ParameterType.Width, 500,
        TestName = "Проверка корректного получения" +
                   " значения свойства Width.")]
    [TestCase(ParameterType.WidthRack, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства WidthRack.")]
    [TestCase(ParameterType.WidthShelf, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства WidthShelf.")]
    [TestCase(ParameterType.HeightShelf, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства HeightShelf.")]
    [TestCase(ParameterType.UpperIndent, 0,
        TestName = "Проверка корректного получения" +
                   " значения свойства UpperIndent.")]
    [TestCase(ParameterType.LowerIndent, 0,
        TestName = "Проверка корректного получения" +
                   " значения свойства LowerIndent.")]
    public void TestGetValue_CorrectGetValue(ParameterType parameterType, double value)
    {
        var shelfParameters = ShelfParameters;

        var expected = value;

        shelfParameters.ShelfParameterCollection[parameterType].Value = value;

        var actual = shelfParameters.ShelfParameterCollection[parameterType].Value;

        Assert.AreEqual(expected, actual, "Вернулось некорректное значение.");
    }

    [TestCase(ParameterType.Length, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства Length.")]
    [TestCase(ParameterType.Height, 1000,
        TestName = "Проверка корректного получения" +
                   " значения свойства Height.")]
    [TestCase(ParameterType.Width, 500,
        TestName = "Проверка корректного получения" +
                   " значения свойства Width.")]
    [TestCase(ParameterType.WidthRack, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства WidthRack.")]
    [TestCase(ParameterType.WidthShelf, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства WidthShelf.")]
    [TestCase(ParameterType.HeightShelf, 20,
        TestName = "Проверка корректного получения" +
                   " значения свойства HeightShelf.")]
    [TestCase(ParameterType.UpperIndent, 0,
        TestName = "Проверка корректного получения" +
                   " значения свойства UpperIndent.")]
    [TestCase(ParameterType.LowerIndent, 0,
        TestName = "Проверка корректного получения" +
                   " значения свойства LowerIndent.")]
    public void TestSetValue_CorrectSetValue(ParameterType parameterType, double value)
    {
        var shelfParameters = ShelfParameters;

        Assert.DoesNotThrow(() =>
                shelfParameters.ShelfParameterCollection[parameterType].Value = value,
            "Не удалось присвоить корректное значение.");
    }

    [TestCase(ParameterType.Length, 9.0,
        TestName = "Проверка некорректной передачи значения свойства Length," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.Length, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства Length," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.Height, 9.0,
        TestName = "Проверка некорректной передачи значения свойства Height," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.Height, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства Height," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.Width, 9.0,
        TestName = "Проверка некорректной передачи значения свойства Width," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.Width, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства Width," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.WidthRack, 9.0,
        TestName = "Проверка некорректной передачи значения свойства WidthRack," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.WidthRack, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства WidthRack," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.WidthShelf, 9.0,
        TestName = "Проверка некорректной передачи значения свойства WidthShelf," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.WidthShelf, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства WidthShelf," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.HeightShelf, 9.0,
        TestName = "Проверка некорректной передачи значения свойства HeightShelf," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.HeightShelf, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства HeightShelf," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.UpperIndent, -9.0,
        TestName = "Проверка некорректной передачи значения свойства UpperIndent," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.UpperIndent, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства UpperIndent," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    [TestCase(ParameterType.LowerIndent, -9.0,
        TestName = "Проверка некорректной передачи значения свойства LowerIndent," +
                   " меньшему минимальному." +
                   "  Должно выбросить исключение.")]
    [TestCase(ParameterType.LowerIndent, 10000.0,
        TestName = "Проверка некорректной передачи значения свойства LowerIndent," +
                   " большему максимальному." +
                   " Должно выбросить исключение.")]
    public void TestSetValue_IncorrectSetValue(ParameterType parameterType, double value)
    {
        var shelfParameters = ShelfParameters;
        shelfParameters.ShelfParameterCollection[parameterType].Value = value;
        Assert.That(shelfParameters.ShelfParameterCollection[parameterType].HasError, Is.EqualTo(true),
            "Присвоило значение не входящие в диапазон.");
    }

    [TestCase(ParameterType.HeightShelf,
        TestName = "Проверка зависимых параметров")]
    public void TestUpdateValues_CorrectSetValue(ParameterType parameterType)
    {
        var shelfParametersActual = new ShelfParameters();
        var shelfParametersExpected = new ShelfParameters();

        shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].MinValue =
            shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value;
        shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].MaxValue =
            shelfParametersActual.ShelfParameterCollection[ParameterType.Height].Value
            - shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value * 2;
        shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].Value =
            shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].Value;

        shelfParametersActual.ShelfParameterCollection[ParameterType.UpperIndent].MaxValue =
            shelfParametersActual.ShelfParameterCollection[ParameterType.Height].Value -
            (Math.Floor((shelfParametersActual.ShelfParameterCollection[ParameterType.Height].Value -
                         shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value * 2) /
                        (shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].Value +
                         shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value)) *
             (shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].Value +
              shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value) +
             (shelfParametersActual.ShelfParameterCollection[ParameterType.LowerIndent].Value +
              shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value));
        shelfParametersActual.ShelfParameterCollection[ParameterType.UpperIndent].Value =
            shelfParametersActual.ShelfParameterCollection[ParameterType.UpperIndent].Value;

        shelfParametersActual.ShelfParameterCollection[ParameterType.LowerIndent].MaxValue =
            shelfParametersActual.ShelfParameterCollection[ParameterType.Height].Value -
            (Math.Floor((shelfParametersActual.ShelfParameterCollection[ParameterType.Height].Value -
                         shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value * 2) /
                        (shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].Value +
                         shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value)) *
             (shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].Value +
              shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value)
             + (shelfParametersActual.ShelfParameterCollection[ParameterType.UpperIndent].Value +
                shelfParametersActual.ShelfParameterCollection[ParameterType.WidthShelf].Value));
        shelfParametersActual.ShelfParameterCollection[ParameterType.LowerIndent].Value =
            shelfParametersActual.ShelfParameterCollection[ParameterType.LowerIndent].Value;

        shelfParametersExpected.UpdateValues();

        Assert.That(shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].MinValue,
            Is.EqualTo(shelfParametersExpected.ShelfParameterCollection[ParameterType.HeightShelf].MinValue),
            "Значение HeightShelf");
        Assert.That(shelfParametersActual.ShelfParameterCollection[ParameterType.HeightShelf].MaxValue,
            Is.EqualTo(shelfParametersExpected.ShelfParameterCollection[ParameterType.HeightShelf].MaxValue),
            "Значение HeightShelf");
        Assert.That(shelfParametersActual.ShelfParameterCollection[ParameterType.UpperIndent].MaxValue,
            Is.EqualTo(shelfParametersExpected.ShelfParameterCollection[ParameterType.UpperIndent].MaxValue),
            "Значение UpperIndent");
        Assert.That(shelfParametersActual.ShelfParameterCollection[ParameterType.UpperIndent].Value,
            Is.EqualTo(shelfParametersExpected.ShelfParameterCollection[ParameterType.UpperIndent].Value),
            "Значение UpperIndent");
        Assert.That(shelfParametersActual.ShelfParameterCollection[ParameterType.LowerIndent].MaxValue,
            Is.EqualTo(shelfParametersExpected.ShelfParameterCollection[ParameterType.LowerIndent].MaxValue),
            "Значение LowerIndent");
        Assert.That(shelfParametersActual.ShelfParameterCollection[ParameterType.LowerIndent].Value,
            Is.EqualTo(shelfParametersExpected.ShelfParameterCollection[ParameterType.LowerIndent].Value),
            "Значение LowerIndent");
    }


}