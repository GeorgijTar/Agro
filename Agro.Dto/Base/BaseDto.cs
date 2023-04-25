namespace Agro.Dto.Base;
public class BaseDto : NotifyPropertyChanged
{
    private int _id;
    public int Id { get => _id; set => Set(ref _id, value); }
}

