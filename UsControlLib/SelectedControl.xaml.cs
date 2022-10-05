﻿using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UsControlLib;
/// <summary>
/// Логика взаимодействия для SelectedControl.xaml
/// </summary>
public partial class SelectedControl : UserControl
{
    #region ItemSource : IEnumerable - Элементы панели

    /// <summary>Элементы панели</summary>
    public static readonly DependencyProperty ItemSourceProperty =
        DependencyProperty.Register(
            nameof(ItemSource),
            typeof(IEnumerable),
            typeof(SelectedControl),
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
            typeof(SelectedControl),
            new PropertyMetadata(default(object)));

    /// <summary>Выбранный элемент</summary>
    [Description("Выбранный элемент")]
    public object SelectedItem { get => (object)GetValue(SelectedItemProperty); set => SetValue(SelectedItemProperty, value); }

    #endregion

    #region AddNewItemCommand : ICommand - Добавление нового элемента

    /// <summary>Добавление нового элемента</summary>
    public static readonly DependencyProperty AddNewItemCommandProperty =
        DependencyProperty.Register(
            nameof(AddNewItemCommand),
            typeof(ICommand),
            typeof(SelectedControl),
            new PropertyMetadata(default(ICommand)));

    /// <summary>Добавление нового элемента</summary>
    [Description("Добавление нового элемента")]
    public ICommand AddNewItemCommand
    {
        get => (ICommand)GetValue(AddNewItemCommandProperty);
        set => SetValue(AddNewItemCommandProperty, value);
    }

    #endregion

    #region EditItemCommand : ICommand - Редактирование элемента

    /// <summary>Редактирование элемента</summary>
    public static readonly DependencyProperty EditItemCommandProperty =
        DependencyProperty.Register(
            nameof(EditItemCommand),
            typeof(ICommand),
            typeof(SelectedControl),
            new PropertyMetadata(default(ICommand)));

    /// <summary>Редактирование элемента</summary>
    [Description("Редактирование элемента")]
    public ICommand EditItemCommand
    {
        get => (ICommand)GetValue(EditItemCommandProperty);
        set => SetValue(EditItemCommandProperty, value);
    }

    #endregion

    /// <summary>Ширина элемента</summary>
    public static readonly DependencyProperty DisplayWidthProperty =
        DependencyProperty.Register(
            nameof(DisplayWidth),
            typeof(double),
            typeof(SelectedControl),
            new PropertyMetadata(default(double)));

    /// <summary>Ширина элемента</summary>
    [Description("Ширина элемента")]
    public double DisplayWidth { get => (double)GetValue(DisplayWidthProperty); set => SetValue(DisplayWidthProperty, value); }


    #region ItemTemplate : DataTemplate - Шаблон элемента выпадающего списка

    /// <summary>Шаблон элемента выпадающего списка</summary>
    public static readonly DependencyProperty ItemTemplateProperty =
        DependencyProperty.Register(
            nameof(ItemTemplate),
            typeof(DataTemplate),
            typeof(SelectedControl),
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
            typeof(SelectedControl),
            new PropertyMetadata(default(string)));

    /// <summary>Имя отображаемого свойства</summary>
    //[Category("")]
    [Description("Имя отображаемого свойства")]
    public string DisplayMemberPath { get => (string)GetValue(DisplayMemberPathProperty); set => SetValue(DisplayMemberPathProperty, value); }

    #endregion

    public SelectedControl()
    {
        InitializeComponent();
    }
}