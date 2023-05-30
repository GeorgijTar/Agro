

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgroUpdaterLoad
{
   public class LoadFile : INotifyPropertyChanged
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

        private string _name = null!;
        public string Name { get => _name; set => Set(ref _name, value); }


        private string _pathFile = null!;
        public string PathFile { get => _pathFile; set => Set(ref _pathFile, value); }

        private string _sizeFile;
        public string SizeFile { get => _sizeFile; set => Set(ref _sizeFile, value); }

        private string _hashFile = null!;
        public string HashFile { get => _hashFile; set => Set(ref _hashFile, value); }

        private bool _check;
        public bool Check { get => _check; set => Set(ref _check, value); }
    }
}
