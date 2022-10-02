using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Agro.WPF.Commands;

namespace UsControlLib
{
    /// <summary>
    /// Логика взаимодействия для InputControl.xaml
    /// </summary>
    public partial class InputControl : UserControl
    {
        #region EditItemCommand : ICommand - Редактирование элемента

        /// <summary>Редактирование элемента</summary>
        public static readonly DependencyProperty EditItemCommandProperty =
            DependencyProperty.Register(
                nameof(EditItemCommand),
                typeof(ICommand),
                typeof(InputControl),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Редактирование элемента</summary>
        [Description("Редактирование элемента")]
        public ICommand EditItemCommand
        {
            get => (ICommand)GetValue(EditItemCommandProperty);
            set => SetValue(EditItemCommandProperty, value);
        }

        #endregion

        #region Test

        private ICommand? _inputCommand;

        public ICommand InputCommand => _inputCommand
            ??= new RelayCommand(OnInputExecuted, CanInputExecuted);

        private bool CanInputExecuted(object arg)
        {
            return Tbox.Text.Length > 3;
        }

        private void OnInputExecuted(object obj)
        {
        }

        #endregion

        #region DisplayMemberPath : string - Имя отображаемого свойства

        /// <summary>Имя отображаемого свойства</summary>
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(Text),
                typeof(string),
                typeof(InputControl),
                new PropertyMetadata(default(string)));

        /// <summary>Имя отображаемого свойства</summary>
        //[Category("")]
        [Description("Имя отображаемого свойства")]
        public string Text { get => (string)GetValue(DisplayMemberPathProperty); set => SetValue(DisplayMemberPathProperty, value); }

        #endregion
        #region ItemSource : IEnumerable - Элементы панели

        /// <summary>Элементы панели</summary>
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(InputControl),
                new PropertyMetadata(default(IEnumerable)));

        /// <summary>Элементы панели</summary>
        [Description("Элементы панели")]
        public IEnumerable ItemSource
        {
            get => (IEnumerable)GetValue(ItemSourceProperty);
            set => SetValue(ItemSourceProperty, value);
        }

        #endregion


        #region SelectedItem : object - Выбранный элемент

        /// <summary>Выбранный элемент</summary>
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register(
                nameof(SelectedItem),
                typeof(object),
                typeof(InputControl),
                new PropertyMetadata(default(object)));

        /// <summary>Выбранный элемент</summary>
        [Description("Выбранный элемент")]
        public object SelectedItem { get => (object)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

        #endregion

        #region ItemSourceLocal : IEnumerable - отфильтрованный список

        /// <summary>Элементы панели</summary>
        public static readonly DependencyProperty ItemSourceLocalProperty =
            DependencyProperty.Register(
                nameof(ItemSourceLocal),
                typeof(IEnumerable),
                typeof(InputControl),
                new PropertyMetadata(default(IEnumerable)));

        /// <summary>Элементы панели</summary>
        [Description("Элементы панели")]
        public IEnumerable ItemSourceLocal
        {
            get => (IEnumerable)GetValue(ItemSourceLocalProperty);
            set => SetValue(ItemSourceLocalProperty, value);
        }

        #endregion


        #region ItemTemplate : DataTemplate - Шаблон элемента выпадающего списка

        /// <summary>Шаблон элемента выпадающего списка</summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(InputControl),
                new PropertyMetadata(default(DataTemplate)));

        /// <summary>Шаблон элемента выпадающего списка</summary>
        //[Category("")]
        [Description("Шаблон элемента выпадающего списка")]
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        #endregion

        public InputControl()
        {
            InitializeComponent();
        }

        private void TextInputEvent(object sender, TextCompositionEventArgs e)
        {
            //ItemSourceLocal = ItemSource;
            PopupItem.IsOpen=true;

        }
    }
}
