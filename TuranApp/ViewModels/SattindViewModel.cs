using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuranApp.Views;

namespace TuranApp.ViewModels
{
    public partial class SattindViewModel : BaseViewModel
    {
        [ObservableProperty]
        int curentTheme = (int)App.Current.RequestedTheme.GetTypeCode();


        [RelayCommand]
        public void ResetPinCode()
        {
            Preferences.Clear("_current_code");
            Logout();
        }

        [RelayCommand]
        public void Logout()
        {
            //TODO Очистка всех гугловских данных
            App.Current.MainPage = new LoginPage();
        }

        [RelayCommand]
        public void ChangeTheme()
        {
            if (CurentTheme > 2)
            {
                CurentTheme = 0;
                App.Current.UserAppTheme = AppTheme.Unspecified;
            }
            else if(CurentTheme == 2)    
            {
                CurentTheme++;
                App.Current.UserAppTheme = AppTheme.Light;
            }
            else
            {
                CurentTheme++;
                App.Current.UserAppTheme = AppTheme.Dark;
            }
        }

        


    }
}
