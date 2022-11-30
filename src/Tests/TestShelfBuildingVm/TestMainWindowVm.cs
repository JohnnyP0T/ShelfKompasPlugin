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
    }
}