using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TuranApp.Views;

namespace TuranApp.ViewModels
{
    public partial class PinCodeViewModel : BaseViewModel
    {
        public PinCodeViewModel() { }
        [ObservableProperty]
        string code = "";

        
        string _curent_code = Preferences.Get(nameof(_curent_code), "");
        string _code = "";

        [ObservableProperty]
        bool circle1, circle2, circle3, circle4;

        [ObservableProperty] //отоброжение текста для регистрации кода и его проверка
        bool isCurentCode,isRegCodeStep;



        internal async void OnAppearing()
        {
            try
            {
                _curent_code = Preferences.Get(nameof(_curent_code), "");
                IsCurentCode = !string.IsNullOrEmpty(_curent_code) ;
                IsRegCodeStep = true;
                Code = string.Empty;
                UpdateCircles();
            }
            catch (Exception ex) {  } // TODO обработать эту залупу 
        }

        [RelayCommand]
        public async Task Authorization()
        {
            if (Code.Length == 4)
            {

                IsBusy = true;
                await Task.Delay(250);
                try
                {
                   

                    IsBusy = false;


                    App.Current.MainPage = new AppShell();


                }

                catch (Exception ex)
                {

                    Code = "";
                    UpdateCircles();
                    IsBusy = false;

                    //if (ex.Message.Equals("invalid_code"))
                    //    //await DialogService.ShowToast($"{Resources.AppResources.InvalidCode}");
                    //else if (ex.Message.Equals("open_shift"))
                    //    //await DialogService.ShowToast(AppResources.NoFindCashRegister);
                    //else if (ex.Message.Contains("access work"))
                    //    //await DialogService.ShowToast($"{AppResources.YouDontWorkTerminal}");
                    //else
                    //{
                    //    //await DialogService.ShowToast($"{AppResources.FailedLogin}", ToastDuration.Long);
                    //    //Crashes.TrackError(ex);
                    //}

                }
                finally
                {
                    IsBusy = false;
                }

            }
        }

        public async Task RegistCode()
        {
            if (IsRegCodeStep)
            {
                IsRegCodeStep = false;
                _code = Code;
                Code = string.Empty;
                UpdateCircles();
                return;
            }
            if (_code == Code)
            {
                Preferences.Set(nameof(_curent_code), Code);
                await Authorization();
                IsCurentCode = true;
            }
            else await AppShell.Current.DisplayPromptAsync("Код не совподает","попробуйте снова");
            IsRegCodeStep = true;
            


        }

        [RelayCommand]
        public void KeyInput(string parm)
        {
            try
            {
                if (parm == "back" && Code.Length > 0)
                {
                    Code = Code.Substring(0, Code.Length - 1);
                    UpdateCircles();
                    return;
                }
                if (parm == "=")
                {
                    Code = "";
                    UpdateCircles();
                    return;
                }

                if (parm.Length != 1)
                    return;

                if (Code.Length < 4)
                    Code += parm;
                UpdateCircles();
                return;
            }
            catch (Exception ex) 
            { 
                //Crashes.TrackError(ex); 
            }
        }



        private async void UpdateCircles()
        {
            Circle1 = Code.Length > 0;
            Circle2 = Code.Length > 1;
            Circle3 = Code.Length > 2;
            Circle4 = Code.Length > 3;
            if (Circle4)
            {
                await Task.Delay(50);
                if(isCurentCode) 
                    await Authorization();
                else
                    await RegistCode();
            }
        }



        [RelayCommand]
        private void LogOut()
        {
            try
            {
                //CurrentEmpId = string.Empty;
                //CurrentBrandId = string.Empty;
                //CurrentSalePointId = string.Empty;
                //CurrentDivaceId = string.Empty;

                App.Current.MainPage = new LoginPage();
            }
            catch (Exception ex) 
            { 
                //Crashes.TrackError(ex); 
            }
        }
    }
}
