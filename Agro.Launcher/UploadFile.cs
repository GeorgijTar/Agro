using System.Collections.ObjectModel;

namespace AgroUpdaterLoad
{
    class UploadFile
    {
        public string? Version { get; set; } = null!;

        public ObservableCollection<LoadFile> LoadFiles { get; set; } = null!;
    }
}
