using CommunityToolkit.Mvvm.Input;
using Core;
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

        [TestCase(TestName = "Проверка свойства HasErrors — ")]
        public void TestHasErrors_CorrectSet()
        {
            var viewModel = ViewModel;

            viewModel.HasErrors = true;
            
            Assert.That(
                viewModel.HasErrors,
                Is.EqualTo(true),
                "Не удалось присвоить HasErrors");
        }

        [TestCase(TestName = "Проверка свойства IsCompleted — " +
                             "должно вернуться значение типа bool." +
                             " Не должно вызываться исключение")]
        public void TestIsCompleted_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var isCompleted = viewModel.IsCompleted;
                },
                "Вылетело исключение при попытке" +
                $" получения значения свойства {nameof(viewModel.IsCompleted)}");
        }

        [TestCase(TestName = "Проверка свойства ShelfParameters — " +
                             "должно вернуться значение типа ShelfParameters." +
                             " Не должно вызываться исключение")]
        public void TestIsShelfParameters_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var shelfParameters = viewModel.ShelfParameters;
                },
                "Вылетело исключение при попытке" +
                $" получения значения свойства {nameof(viewModel.ShelfParameters)}");
        }

        [TestCase(TestName = "Проверка свойства BuildCommand — " +
                             "должно вернуться значение типа RelayCommand." +
                             " Не должно вызываться исключение")]
        public void TestBuildCommand_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var buildCommand = viewModel.BuildCommand;
                },
                "Вылетело исключение при попытке" +
                $" получения значения свойства {nameof(viewModel.BuildCommand)}");
        }

        [TestCase(TestName = "Проверка свойства UpdateParametersCommand — " +
                             "должно вернуться значение типа RelayCommand." +
                             " Не должно вызываться исключение")]
        public void TestUpdateParametersCommand_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var updateParametersCommand = viewModel.UpdateParametersCommand;
                },
                "Вылетело исключение при попытке" +
                $" получения значения свойства {nameof(viewModel.UpdateParametersCommand)}");
        }
    }
}