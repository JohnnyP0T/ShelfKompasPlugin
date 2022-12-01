using System.Collections.Immutable;
using Buidler;
using Core;

namespace TestBuilder;

/// <summary>
/// ����� ������������ <see cref="Buidler.ShelfBuilder"/>.
/// </summary>
[TestFixture]
public class TestShelfBuilder
{
    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="TestApiService"/>.
    /// </summary>
    private TestApiService TestApiService => new TestApiService();

    /// <summary>
    /// ���������� ����� ��������� ������ <see cref="ShelfParameters"/>.
    /// </summary>
    private ShelfParameters ShelfParameters => new ShelfParameters();

    /// <summary>
    /// ���������� ����� ������ ������ <see cref="Buidler.ShelfBuilder"/>.
    /// </summary>
    private ShelfBuilder ShelfBuilder => new ShelfBuilder();

    [TestCase(TestName = "������������ ���������� ����������� ��������.")]
    public void TestBuildShelf_DoesNotThrowException()
    {
        var shelfBuilder = ShelfBuilder;
        var testApiService = TestApiService;
        var shelfParameters = ShelfParameters;

        Assert.DoesNotThrow(() => shelfBuilder.BuildShelf(shelfParameters, testApiService), "��������� ������ ��� ����������.");
        Assert.IsTrue(testApiService.IsCreateDocument, "�������� �� ������.");
        Assert.IsTrue(testApiService.IsCreateNewSketch, "�� ���� ����� �� ������.");
        Assert.IsTrue(testApiService.IsCreatePoint, "�� ���� ����� �� �������.");
        Assert.IsTrue(testApiService.IsExtrude, "�� ������ ������������ �� ���������.");
    }
}