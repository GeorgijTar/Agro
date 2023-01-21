
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Agro.DAL.Entities;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.Commands;
using Agro.WPF.ViewModels.Base;

namespace Agro.WPF.ViewModels.Personnel;

public class DocumentViewModel : ViewModel
{
    private readonly IBaseRepository<Status> _statusRepository;
    private readonly IBaseRepository<TypeDoc> _typeRepository;
    private readonly IBaseRepository<GroupDoc> _groupRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }


    private IdentityDocument _document = new();
    public IdentityDocument Document { get => _document; set => Set(ref _document, value); }


    private IEnumerable<TypeDoc> _types = null!;
    public IEnumerable<TypeDoc> Types { get => _types; set => Set(ref _types, value); }


    private IEnumerable<GroupDoc> _nameProp = null!;
    public IEnumerable<GroupDoc> Groups { get => _nameProp; set => Set(ref _nameProp, value); }

    private bool _isReadOnly;
    public bool IsReadOnly { get => _isReadOnly; set => Set(ref _isReadOnly, value); }

    public object SenderModel { get; set; } = null!;

    public DocumentViewModel(
        IBaseRepository<Status> statusRepository,
        IBaseRepository<TypeDoc> typeRepository,
        IBaseRepository<GroupDoc> groupRepository)
    {
        _statusRepository = statusRepository;
        _typeRepository = typeRepository;
        _groupRepository = groupRepository;
        LoadData();
        Document.PropertyChanged += DocChahg;
    }

    public async void DocChahg(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "TypeDoc")
        {
            var gr = await _groupRepository.GetAllAsync();
            Groups = gr!.Where(g => g.TypeApplication == Document.TypeDoc.Name).ToArray();
            if (Document.TypeDoc.Id != 15)
            {
                IsReadOnly = true;
            }
            else
            {
                IsReadOnly = false;
            }
        }

        if (e.PropertyName == "Group")
        {
            if (Document.Group.Id != 20)
            {
                Document.NameDocument = Document.Group.Name;
            }
        }

    }

    private async void LoadData()
    {
        var tp = await _typeRepository.GetAllAsync();
        Types = tp!.Where(t => t.TypeApplication == "Документ").ToArray();

    }

    #region Commands
    private ICommand? _saveCommand;

    public ICommand SaveCommand => _saveCommand
        ??= new RelayCommand(OnSaveExecuted, CanSaveExecuted);

    private bool CanSaveExecuted(object arg)
    {
        return Document.TypeDoc != null! && Document.Group != null! &&
               Document.NameDocument != null! && Document.NameDocument.Trim().Length > 5 &&
               Document.Number != null! && Document.Number.Trim().Length > 0 &&
               Document.Issuing != null! && Document.Issuing.Trim().Length > 3;
    }

    private async void OnSaveExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is PeopleViewModel peopleViewModel)
            {
                Document.Status = await _statusRepository.GetByIdAsync(5);
                var pl = peopleViewModel.People.Documents!.FirstOrDefault(d => d.Id == Document.Id);
                if (pl! == null!)
                {
                    peopleViewModel.People.Documents!.Add(Document);
                }
                
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
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