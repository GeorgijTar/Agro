
using System.Windows.Controls;
using System.Windows;

namespace Agro.WPF.Views.Components;
public class ExtendedTreeView : TreeView
{
    public ExtendedTreeView()
        : base()
    {
        this.SelectedItemChanged += new RoutedPropertyChangedEventHandler<object>(___ICH);
    }

    void ___ICH(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (base.SelectedItem != null)
        {
            SetValue(SelectedItemProperty, base.SelectedItem);
        }
    }

    public object SelectedItem
    {
        get { return (object)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(ExtendedTreeView), new UIPropertyMetadata(null));
}
