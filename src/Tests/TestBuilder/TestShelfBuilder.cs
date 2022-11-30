using System.Collections.Immutable;
using Buidler;
using Core;

namespace TestBuilder;

/// <summary>
/// Класс тестирования <see cref="Buidler.ShelfBuilder"/>.
/// </summary>
[TestFixture]
public class TestShelfBuilder
{
    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="TestApiService"/>.
    /// </summary>
    private TestApiService TestApiService => new TestApiService();

    /// <summary>
    /// Возвращает новый экземпляр класса <see cref="ShelfParameters"/>.
    /// </summary>
    private ShelfParameters ShelfParameters => new ShelfParameters();

    /// <summary>
    /// Возвращает новый объект класса <see cref="Buidler.ShelfBuilder"/>.
    /// </summary>
    private ShelfBuilder ShelfBuilder => new ShelfBuilder();

    [TestCase(TestName = "Тестирование построения корректного забора.")]
    public void TestBuildFence_DoesNotThrowException()
    {
        var shelfBuilder = ShelfBuilder;
        var testApiService = TestApiService;
        var shelfParameters = ShelfParameters;

        Assert.DoesNotThrow(() => shelfBuilder.BuildShelf(shelfParameters, testApiService), "Произошла ошибка при построении.");
        Assert.IsTrue(testApiService.IsCreateDocument, "Документ не создан.");
        Assert.IsTrue(testApiService.IsCreateNewSketch, "Ни один эскиз не создан.");
        Assert.IsTrue(testApiService.IsCreatePoint, "Ни одна точка не создана.");
        Assert.IsTrue(testApiService.IsExtrude, "Ни одного выдавливания не выполнено.");
    }
}