using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Buidler;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core;
using InventorApi;
using KompasApi;
using Services;

namespace ShelfPluginVm
{
    public class MainWindowVm : ObservableObject
    {
        #region -- Fields --

        private IApi _selectedApi;

        private ObservableCollection<IApi> _apiServices;

        private ShelfParameters _shelfParameters;

        private bool _hasErrors;
        
        private BackgroundWorker _worker;

        private bool _isCompleted;

        #endregion

        #region -- Properties --

        /// <summary>
        /// Идет ли процесс загрузки.
        /// </summary>
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                SetProperty(ref _isCompleted, value);
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

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
        /// Параметры стеллажа.
        /// </summary>
        public ObservableCollection<IApi> ApiServices
        {
            get => _apiServices;
            set
            {
                SetProperty(ref _apiServices, value);
                OnPropertyChanged(nameof(ApiServices));
            }
        }

        /// <summary>
        /// Параметры стеллажа.
        /// </summary>
        public IApi SelectedApi
        {
            get => _selectedApi;
            set
            {
                SetProperty(ref _selectedApi, value);
                OnPropertyChanged(nameof(SelectedApi));
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
        public RelayCommand BuildCommand => new RelayCommand( () =>
        {
            if (!ShelfParameters.ShelfParameterCollection.All(x => x.Value.HasError))
            {
                _worker.RunWorkerAsync();
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
            IsCompleted = true;
            ApiServices = new ObservableCollection<IApi>()
            {
                new KompasWrapper(),
                new InventorWrapper()
            };

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.WorkerSupportsCancellation = false;
            _worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            _worker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted; 
        }

        #endregion

        #region -- PrivateMethods --

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IsCompleted = false;
            ShelfBuilder s = new ShelfBuilder();
            var api = SelectedApi;
            s.BuildShelf(ShelfParameters, api);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsCompleted = true;
        }

        #endregion
    }
}
