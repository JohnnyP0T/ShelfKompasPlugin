using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.Input;
using Core;

namespace ParametersCustomControlLibrary
{
    /// <summary>
    /// Элемент упралвения для параметров.
    /// </summary>
    public class ParametersCustomControl : Control
    {
        /// <summary>
        /// Словарь параметров.
        /// </summary>
        public Dictionary<ParameterType, Parameter> Parameters
        {
            get => (Dictionary<ParameterType, Parameter>)GetValue(ParametersProperty);
            set => SetValue(ParametersProperty, value);
        }

        /// <summary>
        /// Свойство параметров.
        /// </summary>
        public static readonly DependencyProperty ParametersProperty =
            DependencyProperty.Register(nameof(Parameters), typeof(Dictionary<ParameterType, Parameter>),
                typeof(ParametersCustomControl));

        /// <summary>
        /// Есть ли ошибки.
        /// </summary>
        public bool HasErrors
        {
            get => (bool)GetValue(HasErrorsProperty);
            set => SetValue(HasErrorsProperty, value);
        }

        /// <summary>
        /// Свойство есть ли ошибки.
        /// </summary>
        public static readonly DependencyProperty HasErrorsProperty =
            DependencyProperty.Register(nameof(HasErrors), typeof(bool),
                typeof(ParametersCustomControl));

        /// <summary>
        /// Команда для обновления параметров. Запускается при изменении параметров.
        /// </summary>
        public RelayCommand UpdateParametersCommand
        {
            get => (RelayCommand)GetValue(UpdateParametersCommandProperty);
            set => SetValue(UpdateParametersCommandProperty, value);
        }

        /// <summary>
        /// Свойство команды.
        /// </summary>
        public static readonly DependencyProperty UpdateParametersCommandProperty =
            DependencyProperty.Register(nameof(UpdateParametersCommand), typeof(RelayCommand),
                typeof(ParametersCustomControl));

        public RelayCommand CheckErrors => new RelayCommand(() =>
        {
            if (Parameters.Any(x => x.Value.HasError))
            {
                HasErrors = true;
            }
            else
            {
                HasErrors = false;
            }
        });


        /// <summary>
        /// Конструктор.
        /// </summary>
        static ParametersCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ParametersCustomControl),
                new FrameworkPropertyMetadata(typeof(ParametersCustomControl)));

        }
    }
}
