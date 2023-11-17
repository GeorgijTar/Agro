
using System;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using SHDocVw;
using MSHTML;
using WebBrowser = System.Windows.Controls.WebBrowser;


namespace Agro.WPF.ViewModels.Shared;
public class LookViewModel:ViewModel
{
    private string _sours = null!;
    public string Sours { get => _sours; set => Set(ref _sours, value); }

    #region Commands

    #region Print

    private ICommand? _printCommand;

    public ICommand PrintCommand => _printCommand
        ??= new RelayCommand(OnPrintExecuted, PrintCan);

    private bool PrintCan(object arg)
    {
        var wb = arg as WebBrowser;
        return wb!=null! && wb.Document != null!;
    }

    private void OnPrintExecuted(object obj)
    {
        var wb = obj as WebBrowser;
        mshtml.IHTMLDocument2 doc = (wb!.Document as mshtml.IHTMLDocument2)!;
        doc.execCommand("Print", true, null);
    }

    #endregion

    #region Preview

    private ICommand? _previewCommand;

    public ICommand PreviewCommand => _previewCommand
        ??= new RelayCommand(OnPreviewExecuted, PreviewCan);

    private bool PreviewCan(object arg)
    {
        var wb = arg as WebBrowser;
        return wb != null! && wb.Document != null!;
    }

    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    internal interface IServiceProvider
    {
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object QueryService(ref Guid guidService, ref Guid riid);
    }
    static readonly Guid SID_SWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
    private void OnPreviewExecuted(object obj)
    {
        var wb = obj as WebBrowser;
        IServiceProvider serviceProvider = null;
        if (wb.Document != null)
        {
            serviceProvider = (IServiceProvider)wb.Document;
        }

        Guid serviceGuid = SID_SWebBrowserApp;
        Guid iid = typeof(IWebBrowser2).GUID;

        object NullValue = null;

        IWebBrowser2 target = (IWebBrowser2)serviceProvider.QueryService(ref serviceGuid, ref iid);
        target.ExecWB(SHDocVw.OLECMDID.OLECMDID_PRINTPREVIEW, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref NullValue, ref NullValue);
    }

    #endregion

    #endregion

}
