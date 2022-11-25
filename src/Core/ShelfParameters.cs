using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Класс параметров стеллажа.
    /// </summary>
    public class ShelfParameters : ObservableObject
    {
        #region -- Fields --

        private Dictionary<ParameterType, Parameter> _shelfParameterCollection;


        #endregion

        #region -- Properties --

        /// <summary>
        /// Словарь параметров.
        /// </summary>
        public Dictionary<ParameterType, Parameter> ShelfParameterCollection
        {
            get => _shelfParameterCollection;
            set
            {
                SetProperty(ref _shelfParameterCollection, value);
                OnPropertyChanged(nameof(ShelfParameterCollection));
            }
        }

        #endregion

        #region -- Constructors --
        
        /// <summary>
        /// Конструктор.
        /// </summary>
        public ShelfParameters()
        {
            SetDefaultValues();
        }

        #endregion

        #region -- Public Methods --

        /// <summary>
        /// Установить значения поумолчанию
        /// </summary>
        public void SetDefaultValues()
        {
            ShelfParameterCollection = new Dictionary<ParameterType, Parameter>()
            {
                {
                    ParameterType.Length,
                    new()
                    {
                        Name = "Длинна стеллажа L, мм:",
                        MinValue = 1000,
                        MaxValue = 2000,
                        Value = 1000,
                        ErrorMessage = $"Ошибка параметра не входит в диапазон"
                    }
                },
                {
                    ParameterType.Height,
                    new()
                    {
                        Name = "Высота стеллажа H, мм:",
                        MinValue = 1000,
                        MaxValue = 3000,
                        Value = 1000,
                        ErrorMessage = "Ошибка параметра не входит в диапазон"
                    }
                },
                {
                    ParameterType.Width,
                    new()
                    {
                        Name = "Ширина стеллажа W, мм:",
                        MinValue = 500,
                        MaxValue = 1000,
                        Value = 500,
                        ErrorMessage = "Ошибка параметра не входит в диапазон"
                    }
                },

                {
                    ParameterType.WidthRack,
                    new()
                    {
                        Name = "Ширина стойки w1, мм:",
                        MinValue = 20,
                        MaxValue = 30,
                        Value = 20,
                        ErrorMessage = "Ошибка параметра не входит в диапазон"
                    }
                },

                {
                    ParameterType.WidthShelf,
                    new()
                    {
                        Name = "Ширина полки w2, мм:",
                        MinValue = 20,
                        MaxValue = 30,
                        Value = 20,
                        ErrorMessage = "Ошибка параметра не входит в диапазон"
                    }
                }
            };

            ShelfParameterCollection.Add(
                ParameterType.HeightShelf,
                new()
                {
                    Name = "Расстояние между полками стеллажа h1, мм:",
                    MinValue = ShelfParameterCollection[ParameterType.WidthShelf].Value,
                    MaxValue = ShelfParameterCollection[ParameterType.Height].Value,
                    Value = ShelfParameterCollection[ParameterType.WidthShelf].Value,
                    ErrorMessage = "Ошибка параметра не входит в диапазон"
                }
            );

            ShelfParameterCollection.Add(
                ParameterType.UpperIndent,
                new()
                {
                    Name = "Расстояние верхнего отстпуа h2, мм:",
                    MinValue = 0,
                    MaxValue = ShelfParameterCollection[ParameterType.Height].Value - ShelfParameterCollection[ParameterType.HeightShelf].Value,
                    Value = 0,
                    ErrorMessage = "Ошибка параметра не входит в диапазон"
                }
            );

            ShelfParameterCollection.Add(
                ParameterType.LowerIndent,
                new()
                {
                    Name = "Расстояние нижнего отстпуа  h3, мм:",
                    MinValue = 0,
                    MaxValue = ShelfParameterCollection[ParameterType.Height].Value - ShelfParameterCollection[ParameterType.HeightShelf].Value,
                    Value = 0,
                    ErrorMessage = "Ошибка параметра не входит в диапазон"
                }
            );

        }

        /// <summary>
        /// Обновить зависимые параметры стеллажа.
        /// </summary>
        public void UpdateValues()
        {
            ShelfParameterCollection[ParameterType.HeightShelf].MinValue = ShelfParameterCollection[ParameterType.WidthShelf].Value;
            ShelfParameterCollection[ParameterType.HeightShelf].MaxValue = ShelfParameterCollection[ParameterType.Height].Value - ShelfParameterCollection[ParameterType.WidthShelf].Value * 2;
            ShelfParameterCollection[ParameterType.HeightShelf].Value = ShelfParameterCollection[ParameterType.HeightShelf].Value;

            ShelfParameterCollection[ParameterType.UpperIndent].MaxValue = ShelfParameterCollection[ParameterType.Height].Value -
                                                                           (getCountShelf() *
                                                                            (ShelfParameterCollection[ParameterType.HeightShelf].Value + ShelfParameterCollection[ParameterType.WidthShelf].Value) + 
                                                                           (ShelfParameterCollection[ParameterType.LowerIndent].Value + ShelfParameterCollection[ParameterType.WidthShelf].Value));
            ShelfParameterCollection[ParameterType.UpperIndent].Value = ShelfParameterCollection[ParameterType.UpperIndent].Value;

            ShelfParameterCollection[ParameterType.LowerIndent].MaxValue = ShelfParameterCollection[ParameterType.Height].Value -
                                                               (getCountShelf() *
                                                                (ShelfParameterCollection[ParameterType.HeightShelf].Value + ShelfParameterCollection[ParameterType.WidthShelf].Value) 
                                                               + (ShelfParameterCollection[ParameterType.UpperIndent].Value + ShelfParameterCollection[ParameterType.WidthShelf].Value));
            ShelfParameterCollection[ParameterType.LowerIndent].Value = ShelfParameterCollection[ParameterType.LowerIndent].Value;
        }

        private double getCountShelf()
        {
     
            var s = Math.Floor((ShelfParameterCollection[ParameterType.Height].Value -
                                ShelfParameterCollection[ParameterType.WidthShelf].Value * 2) /
                               (ShelfParameterCollection[ParameterType.HeightShelf].Value +
                                ShelfParameterCollection[ParameterType.WidthShelf].Value));
            return Math.Floor((ShelfParameterCollection[ParameterType.Height].Value -
                               ShelfParameterCollection[ParameterType.WidthShelf].Value * 2) /
                              (ShelfParameterCollection[ParameterType.HeightShelf].Value +
                               ShelfParameterCollection[ParameterType.WidthShelf].Value));
        }

        #endregion
    }
}
