using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rent.ViewModels.Base
{
    internal abstract class ViewModel : INotifyPropertyChanged 
        // данный интерфейс уведомляет о том что внутри объекта изменилось какое-либо свойство. При изменении сам обновляет визуальную часть
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            // Set обновляет значение свойства для которого определено поле в котором данное свойство хранит свои данные
            // данный метод разрешает кольцевые обновления свойства
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }    
    }
}