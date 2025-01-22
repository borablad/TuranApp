using TuranApp.ViewModels;

namespace TuranApp.Views;

public partial class PinCodePage : ContentPage
{
    PinCodeViewModel vm;
	public PinCodePage()
	{
		InitializeComponent();
        vm = new PinCodeViewModel();
        BindingContext = vm;
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.OnAppearing();
    }
}