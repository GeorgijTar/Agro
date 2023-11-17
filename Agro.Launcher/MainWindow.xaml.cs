using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Agro.WPF.Commands;
using AgroUpdaterLoad;
using FluentFTP;

namespace Agro.Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        #region NPC
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string? proppertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proppertyName));
        }

        /// <summary>
        /// Universal method for applying changes to ViewModels fields. 
        /// </summary>
        /// <typeparam name="T">Any type of field.</typeparam>
        /// <param name="field">Reference to the current field.</param>
        /// <param name="value">New value for field.</param>
        /// <param name="propertyName">Name of property, that has called this method.</param>
        /// <returns></returns>
        public virtual bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }


        #endregion

        #region Property

        private string? _currentVersion;
        public string? CurrentVersion { get => _currentVersion; set => Set(ref _currentVersion, value); }

        private string? _newVersion;
        public string? NewVersion { get => _newVersion; set => Set(ref _newVersion, value); }

        private string? _versionLoader;
        public string? VersionLoader { get => _versionLoader; set => Set(ref _versionLoader, value); }

        private ObservableCollection<string> _messageCollection = new();
        public ObservableCollection<string> MessageCollection { get => _messageCollection; set => Set(ref _messageCollection, value); }

        private ObservableCollection<LoadFile> loadFileCollection = new();

        #endregion
        public MainWindow()
        {
            InitializeComponent();
            LoadData();

        }

        private async void LoadData()
        {
            try
            {

                VersionLoader = Assembly.GetExecutingAssembly().GetName().Version!.ToString();
                var item = new FileInfo("Agro.WPF.exe");
                if (item.Exists)
                {
                    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(item.FullName);
                    CurrentVersion = myFileVersionInfo.FileVersion;
                }
                MessageCollection.Add("Проверка обновлений ...");
                string fileName = Directory.GetCurrentDirectory() + @"/UploadFile.json";
                if (await LoadFileAsync(fileName, @"/Agro/UploadFile.json"))
                {
                    if (File.Exists(fileName))
                    {
                        string jsonString = File.ReadAllText(fileName);
                        UploadFile uploadFile = JsonSerializer.Deserialize<UploadFile>(jsonString)!;
                        if (uploadFile.Version!.Equals(CurrentVersion))
                        {
                            NewVersion = "Нет";
                            MessageCollection.Add($"Установленна последняя версия ПО ({uploadFile.Version!})");
                            MessageCollection.Add("Обновление не требуется!");
                            MessageCollection.Add("Запуск приложения ...");
                            await ShowAgro();
                        }
                        else
                        {
                            NewVersion = uploadFile.Version;
                            MessageCollection.Add("Cоставляю список загружаемых файлов ...");
                            await Task.Delay(1000);
                            foreach (var loadFile in uploadFile.LoadFiles)
                            {
                                if (File.Exists(loadFile.PathFile))
                                {
                                    byte[] n;
                                    using (var md5 = MD5.Create())
                                    {
                                        using (var stream = File.OpenRead(loadFile.PathFile))
                                        {
                                            n = md5.ComputeHash(stream);
                                        }
                                    }

                                    string hash = BitConverter.ToString(n).Replace("-", "").ToLowerInvariant();
                                    if (!hash.Equals(loadFile.HashFile))
                                    {
                                        loadFileCollection.Add(loadFile);
                                    }
                                }
                                else
                                {
                                    loadFileCollection.Add(loadFile);
                                }
                            }

                            foreach (var loadFile in loadFileCollection)
                            {
                                MessageCollection.Add($"Загружаю файл {loadFile.Name} ...");
                                await LoadFileAsync(loadFile.PathFile, @$"/Agro/{NewVersion}/{loadFile.Name}");
                                MessageCollection.Add($"Файл {loadFile.Name} загружен");
                            }

                            MessageCollection.Add("Все файлы успешно загружены");
                            File.Delete("UploadFile.json");
                            await ShowAgro();
                        }
                    }

                }
                else
                {
                    MessageCollection.Add("Не удалось проверить обновления");
                    return;
                }
            }
            catch (Exception e)
            {
                var mass=e.Message;
                if (e.InnerException != null)
                {
                    mass=e.InnerException.Message;
                }
                MessageCollection.Add($"Не удалось проверить обновления: {mass}");
                return;
            }

        }

        private async Task ShowAgro()
        {
            if (File.Exists("Agro.WPF.exe"))
            {
                try
                {
                    var pr = Process.Start("Agro.WPF.exe");
                    await Task.Delay(4000);
                    MessageCollection.Add("Приложение запущено");
                }
                catch (Exception e)
                {
                    MessageCollection.Add($"Не удалось запустить приложение! {e.Message}");
                    return;
                }
            }
            await Task.Delay(1000);
            Application.Current.Shutdown();
        }

        private async Task<bool> LoadFileAsync(string pathFile, string loadPath)
        {
            try
            {
                string newPathFile= pathFile;
                if (File.Exists(pathFile))
                {
                    newPathFile = pathFile + ".new";
                }
                using var ftpClient = new AsyncFtpClient("ftp://81.177.140.103", "root", "01061984", 21);
                await ftpClient.Connect();
                var res = await ftpClient.DownloadFile(newPathFile, loadPath, FtpLocalExists.Overwrite);
                await ftpClient.Disconnect();

                if (!newPathFile.Equals(pathFile))
                {
                    File.Delete(pathFile);
                    File.Move(newPathFile, pathFile);
                }

                return true;
            }
            catch (WebException e)
            {
                var status = ((FtpWebResponse)e.Response!).StatusDescription;
                MessageBox.Show(status, "Клиент");
                return false;
            }
            catch (Exception ex)
            {
                var mass = ex.Message;
                if (ex.InnerException != null)
                {
                    mass = ex.InnerException.Message;
                }
                MessageBox.Show($"Произошла ошибка соединения: {mass}", "Клиент2");
                return false;
            }
        }

        #region Commands

        private ICommand? _closeCommand;

        public ICommand CloseCommand => _closeCommand
            ??= new RelayCommand(OnCloseExecuted);

        private void OnCloseExecuted(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


    }
}
