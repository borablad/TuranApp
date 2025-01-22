using TuranApp.ViewModels;

namespace TuranApp.Views;
//[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class LoginPage : ContentPage
{
    private LoginViewModel vm;
    public LoginPage()
    {
        InitializeComponent();
        vm = new LoginViewModel();
        BindingContext = vm;
    }

}