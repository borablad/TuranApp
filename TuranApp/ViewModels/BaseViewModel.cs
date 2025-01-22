using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuranApp.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        // текуший логин
        public static string CurrentLogin { get => Preferences.Get(nameof(CurrentLogin), ""); set => Preferences.Set(nameof(CurrentLogin), value); }

        public string AppVersion { get => $"v:{VersionTracking.CurrentVersion}({VersionTracking.CurrentBuild})"; }
        // 
        [ObservableProperty]
        protected bool isBusy;

        [ObservableProperty]
        private string title;

        protected Action currentDismissAction;

        internal IConnectivity _connectivity;


        public BaseViewModel()
        {
            //if (_connectivity == null)
            //    _connectivity = ServiceHelper.GetService<IConnectivity>();
        }
        #region old_shit
        // Запуск индикатора активности
        //partial void OnIsBusyChanged(bool value)
        //{
        //    try
        //    {
        //        if (value)
        //        {
        //            currentDismissAction = Services.DialogService.ShowActivityIndicator();
        //        }
        //        else
        //        {
        //            currentDismissAction?.Invoke();
        //            currentDismissAction = null;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }

        //}

        //Регулярное выражение на проверку почты
        //public bool IsValidEmail(string email) =>
        //    Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        // Выход    
        //public async Task LogoutTapped()
        //{
        //    IsBusy = true;
        //    await RealmService.LogoutAsync();

        //    IsBusy = false;
        //    Application.Current.MainPage = new LoginPage();
        //    //await Shell.Current.GoToAsync($"//LoginPage");
        //}





        // Изменение значения числа (калькулятор)
        //[RelayCommand]
        //public async Task ShowNotifications()
        //{

        //    //try {
        //    //    var popup = new NotificationPage();
        //    //    await MopupService.Instance.PushAsync(popup);

        //    //}
        //    //catch (Exception) {

        //    //}

        //    //await Shell.Current.GoToAsync(nameof(NotificationPage));

        //}
        #endregion
    }
}
