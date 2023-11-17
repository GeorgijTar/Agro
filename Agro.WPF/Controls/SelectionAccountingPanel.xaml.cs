using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Agro.WPF.Controls
{
 public partial class SelectionAccountingPanel
    {

        #region ItemSource : IEnumerable - Элементы панели

   
        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register(
                nameof(ItemSource),
                typeof(IEnumerable),
                typeof(SelectionAccountingPanel),
                new PropertyMetadata(default(IEnumerable)));

      
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
                typeof(SelectionAccountingPanel),
                new PropertyMetadata(default(object)));

        /// <summary>Выбранный элемент</summary>
        public object SelectedItem { get => (object)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

        #endregion

        #region ItemTemplate : DataTemplate - Шаблон элемента выпадающего списка

        /// <summary>Шаблон элемента выпадающего списка</summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register(
                nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(SelectionAccountingPanel),
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

        #region DisplayMemberPath : string - Имя отображаемого свойства

        /// <summary>Имя отображаемого свойства</summary>
        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register(
                nameof(DisplayMemberPath),
                typeof(string),
                typeof(SelectionAccountingPanel),
                new PropertyMetadata(default(string)));


        [Description("Имя отображаемого свойства")]
        public string DisplayMemberPath { get => (string)GetValue(DisplayMemberPathProperty); set => SetValue(DisplayMemberPathProperty, value); }

        #endregion
        #region EditItemCommand : ICommand - Редактирование элемента

        /// <summary>Редактирование элемента</summary>
        public static readonly DependencyProperty ClearItemCommandProperty =
            DependencyProperty.Register(
                nameof(ClearItemCommand),
                typeof(ICommand),
                typeof(SelectionAccountingPanel),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Редактирование элемента</summary>
        //[Category("")]
        [Description("Редактирование элемента")]
        public ICommand ClearItemCommand
        {
            get => (ICommand)GetValue(ClearItemCommandProperty);
            set => SetValue(ClearItemCommandProperty, value);
        }

        #endregion

        #region EditItemCommand : ICommand - Редактирование элемента

        /// <summary>Редактирование элемента</summary>
        public static readonly DependencyProperty ShowSprCommandProperty =
            DependencyProperty.Register(
                nameof(ShowSprCommand),
                typeof(ICommand),
                typeof(SelectionAccountingPanel),
                new PropertyMetadata(default(ICommand)));

        /// <summary>Редактирование элемента</summary>
        //[Category("")]
        [Description("Редактирование элемента")]
        public ICommand ShowSprCommand
        {
            get => (ICommand)GetValue(ShowSprCommandProperty);
            set => SetValue(ShowSprCommandProperty, value);
        }

        #endregion






        public SelectionAccountingPanel()
        {
            InitializeComponent();
            
        }

    }
}
