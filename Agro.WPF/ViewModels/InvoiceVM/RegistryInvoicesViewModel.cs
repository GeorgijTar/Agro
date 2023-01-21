
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Agro.DAL.Entities;
using Agro.DAL.Entities.InvoiceEntity;
using Agro.Interfaces.Base.Repositories;
using Agro.WPF.ViewModels.Base;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Agro.WPF.Commands;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Globalization;
using System.ComponentModel;
using System.Windows.Data;
using Agro.WPF.Views.Windows.UserSettings;
using Notification.Wpf;

namespace Agro.WPF.ViewModels.InvoiceVM;

public class RegistryInvoicesViewModel : ViewModel
{
    private static readonly string currentPath = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!, "TMP");

    private readonly IRegistryInvoiceRepository<RegistryInvoice> _registryInvoiceRepository;
    private readonly INotificationManager _notificationManager;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<RegistryInvoice> _registryInvoices = new();
    public ObservableCollection<RegistryInvoice> RegistryInvoices { get => _registryInvoices; set => Set(ref _registryInvoices, value); }

    private RegistryInvoice _registryInvoice = null!;
    public RegistryInvoice RegistryInvoice { get => _registryInvoice; set => Set(ref _registryInvoice, value); }

    private IEnumerable<Status> _statusEnumerable = null!;
    public IEnumerable<Status> StatusEnumerable { get => _statusEnumerable; set => Set(ref _statusEnumerable, value); }

    private ICollectionView? _collectionView;
    public ICollectionView? CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    private int _regNumberFilter;
    public int RegNumberFilter { get => _regNumberFilter; set => Set(ref _regNumberFilter, value); }


    private DateTime? _regdateOnFilter;
    public DateTime? RegDateOnFilter { get => _regdateOnFilter; set => Set(ref _regdateOnFilter, value); }


    private DateTime? _regdateOfFilter;
    public DateTime? RegDateOfFilter { get => _regdateOfFilter; set => Set(ref _regdateOfFilter, value); }


    private string _invoiceNumberFilter = null!;
    public string InvoiceNumberFilter { get => _invoiceNumberFilter; set => Set(ref _invoiceNumberFilter, value); }


    private DateTime? _invoiceDateOnFilter;
    public DateTime? InvoiceDateOnFilter { get => _invoiceDateOnFilter; set => Set(ref _invoiceDateOnFilter, value); }


    private DateTime? _invoiceDateOfFilter;
    public DateTime? InvoiceDateOfFilter { get => _invoiceDateOfFilter; set => Set(ref _invoiceDateOfFilter, value); }

    private string _name = null!;
    public string NameFilter { get => _name; set => Set(ref _name, value); }

    private string _inn = null!;
    public string InnFilter { get => _inn; set => Set(ref _inn, value); }

    public RegistryInvoicesViewModel(
        IRegistryInvoiceRepository<RegistryInvoice> registryInvoiceRepository,
        INotificationManager notificationManager)
    {
        _registryInvoiceRepository = registryInvoiceRepository;
        _notificationManager = notificationManager;
        Title = "Список реестров на оплату";
        LoadData();

        PropertyChanged += ModelChahged;

        CollectionView = CollectionViewSource.GetDefaultView(RegistryInvoices);
    }

    private void ModelChahged(object? sender, PropertyChangedEventArgs e)
    {
        if (CollectionView != null!)
        {
            switch (e.PropertyName)
            {
                case "RegNumberFilter":
                    CollectionView.Filter = FilterByRegNumber;
                    break;
                case "RegDateOnFilter":
                    CollectionView.Filter = FilterByRegDate;
                    break;
                case "RegDateOfFilter":
                    CollectionView.Filter = FilterByRegDate;
                    break;
                case "InvoiceNumberFilter":
                    CollectionView.Filter = FilterByInvoiceNumber;
                    break;
                case "InvoiceDateOnFilter":
                    CollectionView.Filter = FilterByInvoiceDate;
                    break;
                case "InvoiceDateOfFilter":
                    CollectionView.Filter = FilterByInvoiceDate;
                    break;
                case "NameFilter":
                    CollectionView.Filter = FilterByName;
                    break;
                case "InnFilter":
                    CollectionView.Filter = FilterByInn;
                    break;
            }
        }
    }

    #region Filters
    private bool FilterByInn(object obj)
    {
        if (!string.IsNullOrEmpty(InnFilter))
        {
            RegistryInvoice? dto = obj as RegistryInvoice;
            foreach (var invoice in dto!.Invoices!)
            {
                return invoice.Counterparty.Inn.ToUpper().Contains(InnFilter.ToUpper());
            }
        }
        return true;
    }

    private bool FilterByName(object obj)
    {
        if (!string.IsNullOrEmpty(NameFilter))
        {
            RegistryInvoice? dto = obj as RegistryInvoice;
            foreach (var invoice in dto!.Invoices!)
            {
                return invoice.Counterparty.Name.ToUpper().Contains(NameFilter.ToUpper()) || invoice.Counterparty.PayName.ToUpper().Contains(NameFilter.ToUpper());
            }
        }
        return true;
    }

    private bool FilterByInvoiceDate(object obj)
    {
        if (InvoiceDateOnFilter != null! && InvoiceDateOfFilter != null!)
        {
            RegistryInvoice? dto = obj as RegistryInvoice;
            foreach (var invoice in dto!.Invoices!)
            {
                return invoice.DateInvoice.Date >= InvoiceDateOnFilter.Value.Date && invoice.DateInvoice.Date <= InvoiceDateOfFilter.Value.Date;
            }
        }
        return true;
    }

    private bool FilterByInvoiceNumber(object obj)
    {
        if (!string.IsNullOrEmpty(InvoiceNumberFilter))
        {
            RegistryInvoice? dto = obj as RegistryInvoice;
            foreach (var invoice in dto!.Invoices!)
            {
                return invoice.Number.ToUpper().Contains(InvoiceNumberFilter.ToUpper());
            }
        }
        return true;
    }

    private bool FilterByRegDate(object obj)
    {
        if (RegDateOnFilter != null! && RegDateOfFilter != null!)
        {
            RegistryInvoice? dto = obj as RegistryInvoice;
            return dto!.Date.Date >= RegDateOnFilter.Value.Date && dto!.Date.Date <= RegDateOfFilter.Value.Date;
        }
        return true;
    }

    private bool FilterByRegNumber(object obj)
    {
        if (RegNumberFilter != 0)
        {
            RegistryInvoice? dto = obj as RegistryInvoice;
            return dto!.Number == RegNumberFilter;
        }
        return true;
    }
    #endregion

    private async void LoadData()
    {
        RegistryInvoices.Clear();
        var reg = await _registryInvoiceRepository.GetAllByIdNoAsync(6);
        StatusEnumerable = reg.Select(r => r.Status).Distinct().ToArray();
        foreach (var registry in reg)
        {
            RegistryInvoices.Add(registry);
        }
    }


    private async Task<bool> SendRegistrMail(RegistryInvoice registryInvoice)
    {
        MailMessage message = new MailMessage(new MailAddress("mikhailovskoe@inbox.ru", "ООО АПК Михайловское"), new MailAddress("i@gtararin.ru"));
        message.Subject = $"Реестр № {registryInvoice.Number} от {registryInvoice.Date.ToShortDateString()}";
        message.CC.Add(new MailAddress("mikhailovskoe@inbox.ru", "ООО АПК Михайловское"));
        message.Body = "Тест отправки реестра";

        if (!Directory.Exists(currentPath))
        {
            Directory.CreateDirectory(currentPath);
        }
        else
        {
            DirectoryInfo di = new DirectoryInfo(currentPath);

            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        message.Attachments.Add(new Attachment(SavePdfRegistry(currentPath, registryInvoice)));

        foreach (var registryInvoiceInvoice in RegistryInvoice.Invoices!)
        {
            var inv = await _registryInvoiceRepository.GetInvoseScanFilesAsync(registryInvoiceInvoice.Id);
            foreach (var scanFile in inv!.ScanFiles!)
            {
                var filePath = currentPath + "\\" + scanFile.Name;

                if (File.Exists(filePath))
                {
                    var filename = scanFile.Name.Split(".");
                    Random rnd = new Random();
                    var name = "";
                    for (int i = 0; i < filename.Length - 1; i++)
                    {
                        name += filename[i];
                    }

                    var fn = name + $"_{rnd.Next()}.{filename.Last()}";
                    filePath = currentPath + "\\" + fn;
                }
                File.WriteAllBytes(filePath, scanFile.BodyBytes);
                message.Attachments.Add(new Attachment(filePath));
            }
        }

        SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
        smtp.EnableSsl = true;

        smtp.Credentials = new NetworkCredential("mikhailovskoe@inbox.ru", "qsJCZZNz3Fz34BwmgqQL"); //qsJCZZNz3Fz34BwmgqQL
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        try
        {
            smtp.Send(message);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return false;
        }

        return true;
    }


    #region Commands

    #region Send

    private ICommand? _sendCommand;

    public ICommand SendCommand => _sendCommand
        ??= new RelayCommand(OnSendExecuted, SendCan);

    private bool SendCan(object arg)
    {
        return RegistryInvoice != null! && RegistryInvoice.Status!.Id == 17;
    }

    private async void OnSendExecuted(object obj)
    {
        try
        {
            if (await SendRegistrMail(RegistryInvoice))
            {
                await _registryInvoiceRepository.SetStatusAsync(16, RegistryInvoice);
            }
            _notificationManager.Show("Логер","Реестр успешно отправлен", NotificationType.Information);
        }
        catch (Exception e)
        {
            _notificationManager.Show("Логер", $"При отправке реестра возникла ошибка: {e.Message}", NotificationType.Error);
        }

    }
    #endregion

    #region Print
    private ICommand? _printCommand;

    public ICommand PrintCommand => _printCommand
        ??= new RelayCommand(OnPrintExecuted, PrintCan);

    private bool PrintCan(object arg)
    {
        return RegistryInvoice != null!;
    }

    private void OnPrintExecuted(object obj)
    {
        var filename = SavePdfRegistry(currentPath, RegistryInvoice);
        var p = new Process();
        p.StartInfo = new ProcessStartInfo(filename)
        {
            UseShellExecute = true
        };
        p.Start();
    }
    #endregion

    #region Approve
    private ICommand? _approveCommand;

    public ICommand ApproveCommand => _approveCommand
        ??= new RelayCommand(OnApproveExecuted, ApproveCan);

    private bool ApproveCan(object arg)
    {
        return RegistryInvoice != null! && RegistryInvoice.Status!.Id == 16;
    }

    private async void OnApproveExecuted(object obj)
    {
        RegistryInvoice = await _registryInvoiceRepository.AcceptanceAsync(RegistryInvoice);
    }
    #endregion

    #region Reject

    private ICommand? _rejectCommand;

    public ICommand RejectCommand => _rejectCommand
        ??= new RelayCommand(OnRejectExecuted, RejectCan);

    private bool RejectCan(object arg)
    {
        return RegistryInvoice != null! && (RegistryInvoice.Status!.Id == 16 || RegistryInvoice!.Status!.Id == 18);
    }

    private async void OnRejectExecuted(object obj)
    {
        RegistryInvoice = await _registryInvoiceRepository.RejectAsync(RegistryInvoice);
    }
    #endregion

    #region Delete
    private ICommand? _daleteCommand;

    public ICommand DeleteCommand => _daleteCommand
        ??= new RelayCommand(OnDeleteExecuted, DeleteCan);

    private bool DeleteCan(object arg)
    {
        return RegistryInvoice != null! && RegistryInvoice.Status!.Id == 17;
    }

    private async void OnDeleteExecuted(object obj)
    {
        RegistryInvoice = await _registryInvoiceRepository.DeleteRegAsync(RegistryInvoice);
    }

    #endregion

    #region Refresh
    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshExecuted);

    private void OnRefreshExecuted(object obj)
    {
        LoadData();
    }

    #endregion

    #region Settings
    private ICommand? _settingsCommand;

    public ICommand SettingsCommand => _settingsCommand
        ??= new RelayCommand(OnSettingsExecuted);

    private void OnSettingsExecuted(object obj)
    {
        var view = new RegistryInvoiceSettings();
        view.ShowDialog();
    }
    #endregion

    #endregion

    /// <summary>
    /// Метод сохранения реестра счетов на оплату в PDF файл
    /// </summary>
    /// <param name="currentPath"> Путь для сохранения файла </param>
    /// <param name="registryInvoice">Реестр счетов на оплату</param>
    /// <returns>Путь к сохраненному файлу</returns>
    private string SavePdfRegistry(string currentPath, RegistryInvoice registryInvoice)
    {
        if (!string.IsNullOrWhiteSpace(currentPath) && registryInvoice != null!)
        {
            var fileName = "\\Реестр " + registryInvoice.Number + " от " + registryInvoice.Date.ToShortDateString();
            var filePath = currentPath + fileName + ".pdf";

            if (File.Exists(filePath))
            {
                Random rnd = new Random();
                filePath = currentPath + fileName + "_" + rnd.Next() + ".pdf";
            }
            //Объект документа пдф
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            //Создаем объект записи пдф-документа в файл
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            //Открываем документ
            doc.Open();
            //Определение шрифта необходимо для сохранения кириллического текста
            //Иначе мы не увидим кириллический текст
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Times.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);
            Font fontBold = new Font(baseFont, Font.DEFAULTSIZE, Font.BOLD);
            //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
            PdfPTable table = new PdfPTable(5);
            float[] widths = { 60, 200, 300, 320, 220 };
            table.TotalWidth = 1100;
            table.SetWidths(widths);
            //Добавим в таблицу общий заголовок
            PdfPCell cell = new PdfPCell(
                new Phrase($"Реестр счетов на оплату № {registryInvoice.Number} от {RegistryInvoice.Date.ToShortDateString()}", fontBold));

            cell.Colspan = 5;
            cell.HorizontalAlignment = 1;
            cell.Border = 0;
            table.AddCell(cell);

            //Добавляем заголовки столбцов
            cell = new PdfPCell(new Phrase(new Phrase("№ п/п", font)));
            //Фоновый цвет (необязательно, просто сделаем по красивее)
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Phrase("Номер и дата счета", font)));
            //Фоновый цвет (необязательно, просто сделаем по красивее)
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Phrase("Контрагент", font)));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Phrase("Описание", font)));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);

            cell = new PdfPCell(new Phrase(new Phrase("Сумма, руб.", font)));
            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(cell);

            int i = 1;
            decimal total = 0;
            foreach (var invoice in registryInvoice.Invoices!)
            {
                table.AddCell(new Phrase(i.ToString(), font));
                table.AddCell(new Phrase($"{invoice.Number} от {invoice.DateInvoice.ToShortDateString()}", font));
                table.AddCell(new Phrase($"{invoice.Counterparty.Name} ({invoice.Counterparty.Inn})", font));
                table.AddCell(new Phrase($"{invoice.Description}", font));
                table.AddCell(new Phrase($"{invoice.TotalAmount.ToString("C", CultureInfo.CreateSpecificCulture("ru-Ru"))}", font));
                i++;
                total += invoice.TotalAmount;
            }
            cell = new PdfPCell(new Phrase(new Phrase("Итого", fontBold)));
            cell.Colspan = 4;
            table.AddCell(cell);
            table.AddCell(new Phrase($"{total.ToString("C", CultureInfo.CreateSpecificCulture("ru-Ru"))}", fontBold));

            //Добавляем таблицу в документ
            doc.Add(table);
            //Закрываем документ
            doc.Close();

            return filePath;
        }
        else
        {
            return "";
        }
    }
}

