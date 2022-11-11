using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core;

namespace ShelfPluginVm
{
    public class MainWindowVm : ObservableObject
    {
        #region -- Fields --

        private ShelfParameters _shelfParameters;

        private bool _hasErrors;

        #endregion

        #region -- Properties --

        /// <summary>
        /// Параметры стеллажа.
        /// </summary>
        public ShelfParameters ShelfParameters
        {
            get => _shelfParameters;
            set
            {
                SetProperty(ref _shelfParameters, value);
                OnPropertyChanged(nameof(ShelfParameters));
            }
        }

        /// <summary>
        /// Есть ли ошибки в параметрах.
        /// </summary>
        public bool HasErrors
        {
            get => _hasErrors;
            set
            {
                SetProperty(ref _hasErrors, value);
                OnPropertyChanged(nameof(HasErrors));
            }
        }

        #endregion

        #region -- Commands --

        /// <summary>
        /// Обновление параметров стеллажа.
        /// </summary>
        public RelayCommand UpdateParametersCommand => new RelayCommand(() =>
        {
            ShelfParameters.UpdateValues();
        });

        /// <summary>
        /// Построение стеллажа.
        /// </summary>
        public RelayCommand BuildCommand => new RelayCommand(() =>
        {
            if (!ShelfParameters.ShelfParameterCollection.All(x => x.Value.HasError))
            {

            }
        });

        #endregion

        #region -- Constructors --

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainWindowVm()
        {
            ShelfParameters = new ShelfParameters();
            //MessageBox.Show("Исправьте введенные параметры", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            //ShelfBuilder s = new ShelfBuilder();
            //var api = new KompasWrapper();
            //s.BuildShelf(ShelfParameters, api);
        }

        #endregion
    }
}
