using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AppRpgEtec.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "")//tudo isso é o estalo pra view model ativar e trazer ou pegar a informacao
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //o ?. significa difernete de nulo
        }
    }
}
