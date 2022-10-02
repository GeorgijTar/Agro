
using Agro.DAL.Entities.Personnel;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;
using System.Windows.Input;
using System.Windows;
using System;
using System.Linq;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;

namespace Agro.WPF.ViewModels.Personnel;

public class PostViewModel : ViewModel
{
    private readonly IBaseRepository<Post> _postRepository;
    private readonly IBaseRepository<Status> _statusRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private Post _post = new();
    public Post Post { get => _post; set => Set(ref _post, value); }

    public object SenderModel { get; set; } = null!;

    public PostViewModel(IBaseRepository<Post> postRepository, IBaseRepository<Status> statusRepository)
    {
        _postRepository = postRepository;
        _statusRepository = statusRepository;
    }

    #region Commands

    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSavePeoplesExecuted, CanSavePeoplesExecuted);

    private bool CanSavePeoplesExecuted(object arg)
    {
        return Post.Name!=null! && Post.Name.Trim().Length>3 && Post.ShortName!=null! && Post.ShortName.Trim().Length>3;
    }

    private async void OnSavePeoplesExecuted(object obj)
    {
        Post.Status = await _statusRepository.GetByIdAsync(5);
        var pl = await _postRepository.SaveAsync(Post);
        if (SenderModel is PostsViewModel postsViewModel)
        {
            var pld = postsViewModel.Posts.FirstOrDefault(x => x.Id == pl.Id);
            if (pld! == null!)
            {
                postsViewModel.Posts.Add(pl);
            }
        }
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }

    
    private ICommand? _closeCommand;

    public ICommand CloseCommand => _closeCommand
        ??= new RelayCommand(OnCloseExecuted);

    private void OnCloseExecuted(object obj)
    {
        var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
        if (window != null!)
            window.Close();
    }


    #endregion

}
