using CommunityToolkit.Mvvm.Input;
using Core;
using ShelfPluginVm;

namespace TestShelfBuildingVm;

public class Tests
{
    /// <summary>
	/// ����� ������������ <see cref="MainWindowVm"/>.
	/// </summary>
	[TestFixture]
    public class TestMainWindowVm
    {
        /// <summary>
        /// ���������� ����� ��������� ������ <see cref="MainWindowVm"/>.
        /// </summary>
        private MainWindowVm ViewModel => new MainWindowVm();

        [TestCase(TestName = "�������� �������� HasErrors � " +
                             "������ ��������� �������� ���� bool." +
                             " �� ������ ���������� ����������")]
        public void TestHasErrors_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
            {
                var hasError = viewModel.HasErrors;
            },
                "�������� ���������� ��� �������" +
                $" ��������� �������� �������� {nameof(viewModel.HasErrors)}");
        }

        [TestCase(TestName = "�������� �������� HasErrors � ")]
        public void TestHasErrors_CorrectSet()
        {
            var viewModel = ViewModel;

            viewModel.HasErrors = true;
            
            Assert.That(
                viewModel.HasErrors,
                Is.EqualTo(true),
                "�� ������� ��������� HasErrors");
        }

        [TestCase(TestName = "�������� �������� IsCompleted � " +
                             "������ ��������� �������� ���� bool." +
                             " �� ������ ���������� ����������")]
        public void TestIsCompleted_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var isCompleted = viewModel.IsCompleted;
                },
                "�������� ���������� ��� �������" +
                $" ��������� �������� �������� {nameof(viewModel.IsCompleted)}");
        }

        [TestCase(TestName = "�������� �������� ShelfParameters � " +
                             "������ ��������� �������� ���� ShelfParameters." +
                             " �� ������ ���������� ����������")]
        public void TestIsShelfParameters_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var shelfParameters = viewModel.ShelfParameters;
                },
                "�������� ���������� ��� �������" +
                $" ��������� �������� �������� {nameof(viewModel.ShelfParameters)}");
        }

        [TestCase(TestName = "�������� �������� BuildCommand � " +
                             "������ ��������� �������� ���� RelayCommand." +
                             " �� ������ ���������� ����������")]
        public void TestBuildCommand_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var buildCommand = viewModel.BuildCommand;
                },
                "�������� ���������� ��� �������" +
                $" ��������� �������� �������� {nameof(viewModel.BuildCommand)}");
        }

        [TestCase(TestName = "�������� �������� UpdateParametersCommand � " +
                             "������ ��������� �������� ���� RelayCommand." +
                             " �� ������ ���������� ����������")]
        public void TestUpdateParametersCommand_CorrectGet()
        {
            var viewModel = ViewModel;

            Assert.DoesNotThrow(() =>
                {
                    var updateParametersCommand = viewModel.UpdateParametersCommand;
                },
                "�������� ���������� ��� �������" +
                $" ��������� �������� �������� {nameof(viewModel.UpdateParametersCommand)}");
        }
    }
}