﻿
using Agro.DAL.Entities.Base;

namespace Agro.DAL.Entities;

/// <summary>
/// Должность
/// </summary>
public class Post : Entity
{
    /// <summary>Статус</summary>
    private Status _status = null!;
    public Status Status { get => _status; set => Set(ref _status, value); }

    /// <summary>Наименование должности</summary>
    private string _name = null!;
    public string Name { get => _name; set => Set(ref _name, value); } 


}