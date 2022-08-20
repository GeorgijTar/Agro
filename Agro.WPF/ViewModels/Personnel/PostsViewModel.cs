using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Views.Windows.Personnel;

namespace Agro.WPF.ViewModels.Personnel;
public class PostsViewModel : ViewModel
{
    private readonly IBaseRepository<Post> _postRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = "Список должностей применяемых в организации";
    public string Title { get => _title; set => Set(ref _title, value); }


    private ObservableCollection<Post> _posts = new();
    public ObservableCollection<Post> Posts { get => _posts; set => Set(ref _posts, value); }


    private Post _post = new();
    public Post Post { get => _post; set => Set(ref _post, value); }
    
    
    private string _nameFilter = null!;
    public string NameFilter { get => _nameFilter; set => Set(ref _nameFilter, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }

    public object SenderModel { get; set; }=null!;

    public PostsViewModel(IBaseRepository<Post> postRepository, IBaseRepository<Status> statusRepository)
    {
        _postRepository = postRepository;
        _statusRepository = statusRepository;
        LoadData();
        CollectionView = CollectionViewSource.GetDefaultView(Posts);
        this.PropertyChanged += PostsChanged;
    }

    private void PostsChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "NameFilter")
        {
            CollectionView.Filter = FilterByName;
        }
    }

    private bool FilterByName(object obj)
    {
        if (!String.IsNullOrEmpty(NameFilter))
        {
            Post? dto = obj as Post;
            return dto!.Name.ToUpper().Contains(NameFilter.ToUpper());
        }
        return true;
    }

    private async void LoadData()
    { 
        Posts.Clear();
        var posts = await _postRepository.GetAllAsync();
        posts = posts!.Where(p => p.Status.Id == 5);
        foreach (var post in posts)
        {
            Posts.Add(post);
        }
    }

    #region Commands

    private ICommand? _addCommand;

    public ICommand AddCommand => _addCommand
        ??= new RelayCommand(OnAddCommandExecuted);

    private void OnAddCommandExecuted(object obj)
    {
        PostView view = new();
        var mod = view.DataContext as PostViewModel;
        mod!.Title = "Добавление новой должности";
        mod.Post = new();
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _editCommand;

    public ICommand EditCommand => _editCommand
        ??= new RelayCommand(OnEditCommandExecuted, CanEditCommandExecuted);

    private bool CanEditCommandExecuted(object arg)
    {
        return Post != null!;
    }

    private void OnEditCommandExecuted(object obj)
    {
        PostView view = new();
        var mod = view.DataContext as PostViewModel;
        mod!.Title = "Редактирование сотрудника";
        mod.Post = Post;
        mod.SenderModel = this;
        view.DataContext = mod;
        view.Show();
    }


    private ICommand? _deleteCommand;

    public ICommand DeleteCommand => _deleteCommand
        ??= new RelayCommand(OnDeleteCommandExecuted, CanEditCommandExecuted);

    private async void OnDeleteCommandExecuted(object obj)
    {
        var result = MessageBox.Show($"Вы действительно хотите удалить должность: {Environment.NewLine}" +
                                     $"{Post.Name}",
            "Редактор", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Post.Status = await _statusRepository.GetByIdAsync(6);
            await _postRepository.UpdateAsync(Post);
            Posts.Remove(Post);
        }
    }


    private ICommand? _refreshCommand;

    public ICommand RefreshCommand => _refreshCommand
        ??= new RelayCommand(OnRefreshCommandExecuted);

    private void OnRefreshCommandExecuted(object obj)
    {
        LoadData();
    }

    

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowCommandExecuted, CanSelectRowCommandExecuted);

    private bool CanSelectRowCommandExecuted(object arg)
    {
        return Post != null!;
    }

    private void OnSelectRowCommandExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is StaffListPositionViewModel staffList)
            {
                staffList.StaffListPosition.Post = Post;
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }
    #endregion
}