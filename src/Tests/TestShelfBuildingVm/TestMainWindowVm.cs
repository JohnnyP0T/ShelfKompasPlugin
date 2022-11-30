using ShelfPluginVm;

namespace TestShelfBuildingVm;

public class Tests
{
    /// <summary>
	/// Класс тестирования <see cref="MainWindowVm"/>.
	/// </summary>
	[TestFixture]
    public class TestMainWindowVm
    {
        /// <summary>
        /// Возвращает новый экземпляр класса <see cref="MainWindowVm"/>.
        /// </summary>
        private MainWindowVm ViewModel => new MainWindowVm();

        [TestCase(TestName = "Проверка свойства HasErrors — " +
                             "должно вернуться значение типа bool." +
                             " Не должно вызываться исключение")]
        public void TestHasErrors_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
            {
                var hasError = viewModel.HasErrors;
            },
                "Вылетело исключение при попытке" +
                $" получения значения свойства {nameof(viewModel.HasErrors)}");
        }
    }
}