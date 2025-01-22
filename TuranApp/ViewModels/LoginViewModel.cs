using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuranApp.Views;

namespace TuranApp.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        public LoginViewModel() { }

        [RelayCommand]
        private void Login()
        {
            //TODO нужно будет сделать обращение к GooglAuth и обработать это дерьмо
            App.Current.MainPage = new PinCodePage();
        }
    }
}
