using Core;

namespace TestCore;

/// <summary>
/// ����� ��� ������������ ������ <see cref="Core.ShelfParameters"/>.
/// </summary>
[TestFixture]
public class TestShelfParameters
{
    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="Core.ShelfParameters"/>.
    /// </summary>
    private ShelfParameters ShelfParameters => new ShelfParameters();

    [TestCase(ParameterType.Length, 1000,
        TestName = "�������� ����������� ���������" +
                         " �������� �������� Length.")]
    [TestCase(ParameterType.Height, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� Height.")]
    [TestCase(ParameterType.Width, 500,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� Width.")]
    [TestCase(ParameterType.WidthRack, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� WidthRack.")]
    [TestCase(ParameterType.WidthShelf, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� WidthShelf.")]
    [TestCase(ParameterType.HeightShelf, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� HeightShelf.")]
    [TestCase(ParameterType.UpperIndent, 0,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� UpperIndent.")]
    [TestCase(ParameterType.LowerIndent, 0,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� LowerIndent.")]
    public void TestGetValue_CorrectGetValue(ParameterType parameterType, double value)
    {
        var shelfParameters = ShelfParameters;

        var expected = value;

        shelfParameters.ShelfParameterCollection[parameterType].Value = value;

        var actual = shelfParameters.ShelfParameterCollection[parameterType].Value;

        Assert.AreEqual(expected, actual, "��������� ������������ ��������.");
    }

    [TestCase(ParameterType.Length, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� Length.")]
    [TestCase(ParameterType.Height, 1000,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� Height.")]
    [TestCase(ParameterType.Width, 500,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� Width.")]
    [TestCase(ParameterType.WidthRack, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� WidthRack.")]
    [TestCase(ParameterType.WidthShelf, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� WidthShelf.")]
    [TestCase(ParameterType.HeightShelf, 20,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� HeightShelf.")]
    [TestCase(ParameterType.UpperIndent, 0,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� UpperIndent.")]
    [TestCase(ParameterType.LowerIndent, 0,
        TestName = "�������� ����������� ���������" +
                   " �������� �������� LowerIndent.")]
    public void TestSetValue_CorrectSetValue(ParameterType parameterType, double value)
    {
        var shelfParameters = ShelfParameters;

        Assert.DoesNotThrow(() => 
                shelfParameters.ShelfParameterCollection[parameterType].Value = value,
            "�� ������� ��������� ���������� ��������.");
    }

    [TestCase(ParameterType.Length, 9.0,
        TestName = "�������� ������������ �������� �������� �������� Length," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.Length, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� Length," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.Height, 9.0,
        TestName = "�������� ������������ �������� �������� �������� Height," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.Height, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� Height," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.Width, 9.0,
        TestName = "�������� ������������ �������� �������� �������� Width," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.Width, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� Width," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.WidthRack, 9.0,
        TestName = "�������� ������������ �������� �������� �������� WidthRack," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.WidthRack, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� WidthRack," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.WidthShelf, 9.0,
        TestName = "�������� ������������ �������� �������� �������� WidthShelf," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.WidthShelf, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� WidthShelf," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.HeightShelf, 9.0,
        TestName = "�������� ������������ �������� �������� �������� HeightShelf," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.HeightShelf, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� HeightShelf," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.UpperIndent, -9.0,
        TestName = "�������� ������������ �������� �������� �������� UpperIndent," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.UpperIndent, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� UpperIndent," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    [TestCase(ParameterType.LowerIndent, -9.0,
        TestName = "�������� ������������ �������� �������� �������� LowerIndent," +
                   " �������� ������������." +
                   "  ������ ��������� ����������.")]
    [TestCase(ParameterType.LowerIndent, 10000.0,
        TestName = "�������� ������������ �������� �������� �������� LowerIndent," +
                   " �������� �������������." +
                   " ������ ��������� ����������.")]
    public void TestSetValue_IncorrectSetValue(ParameterType parameterType, double value)
    {
        var shelfParameters = ShelfParameters;
        shelfParameters.ShelfParameterCollection[parameterType].Value = value;
        Assert.That(shelfParameters.ShelfParameterCollection[parameterType].HasError, Is.EqualTo(true),
            "��������� �������� �� �������� � ��������.");
    }
}