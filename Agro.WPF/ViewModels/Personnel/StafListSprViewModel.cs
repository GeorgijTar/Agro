

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Agro.DAL.Entities;
using System.Windows.Data;
using Agro.DAL.Entities.Personnel;
using Agro.Interfaces.Base.Repositories.Base;
using Agro.WPF.ViewModels.Base;
using Agro.WPF.Commands;
using Agro.WPF.Views.Windows.Personnel;
using System.Windows.Input;
using System.Windows;
using System;

namespace Agro.WPF.ViewModels.Personnel;

public class StafListSprViewModel : ViewModel
{
    private readonly IBaseRepository<StaffListPosition> _listRepository;
    private string _title = null!;
    public string Title { get => _title; set => Set(ref _title, value); }

    private ObservableCollection<StaffListPosition> _positions = new();
    public ObservableCollection<StaffListPosition> Positions { get => _positions; set => Set(ref _positions, value); }


    private StaffListPosition _position = null!;
    public StaffListPosition Position { get => _position; set => Set(ref _position, value); } 


    public object SenderModel { get; set; } = null!;

    private string _divisionFilter = null!;
    public string DivisionFilter { get => _divisionFilter; set => Set(ref _divisionFilter, value); }

    private string _postFilter = null!;
    public string PostFilter { get => _postFilter; set => Set(ref _postFilter, value); }

    private ICollectionView _collectionView = null!;
    public ICollectionView CollectionView { get => _collectionView; set => Set(ref _collectionView, value); }
    public StafListSprViewModel(IBaseRepository<StaffListPosition> listRepository)
    {
        _listRepository = listRepository;
        LoadData();
        CollectionView = CollectionViewSource.GetDefaultView(Positions);
        this.PropertyChanged += Filter;
    }

    private async void LoadData()
    {
        Positions.Clear();
        var staflists = await _listRepository.GetAllAsync();
        staflists = staflists!.Where(s => s.StaffList.Status!.Id ==5).ToArray();
        foreach (var staffListPosition in staflists)
        {
            Positions.Add(staffListPosition);
        }
    }

    private void Filter(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "DivisionFilter")
        {
            CollectionView.Filter = FilterByDivision;
        }
        if (e.PropertyName == "PostFilter")
        {
            CollectionView.Filter = FilterByTabPost;
        }
    }

    private bool FilterByTabPost(object obj)
    {
        if (PostFilter != null!)
        {
            var dto = obj as StaffListPosition;
            return dto!.Post.Name.ToUpper().Contains(PostFilter.ToUpper());
        }
        return true;
    }

    private bool FilterByDivision(object obj)
    {
        if (DivisionFilter != null!)
        {
            var dto = obj as StaffListPosition;
            return dto!.Division.Name.ToUpper().Contains(DivisionFilter.ToUpper());
        }
        return true;
    }


    #region Commands

    private ICommand? _selectRowCommand;

    public ICommand SelectRowCommand => _selectRowCommand
        ??= new RelayCommand(OnSelectRowExecuted);

    private void OnSelectRowExecuted(object obj)
    {
        if (SenderModel != null!)
        {
            if (SenderModel is EmployeeViewModel employeeViewModel)
            {
                employeeViewModel.Employee.Division = Position.Division;
                employeeViewModel.Employee.Post=Position.Post;
                var window = obj as Window ?? throw new InvalidOperationException("Нет окна для закрытия");
                if (window != null!)
                    window.Close();
            }
        }
    }

    #endregion
}
