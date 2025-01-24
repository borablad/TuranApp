using TuranApp.ViewModels;

namespace TuranApp.Views;

public partial class SattingsPage : ContentPage
{
	SattindViewModel vm;
	public SattingsPage()
	{
		InitializeComponent();
		vm = new SattindViewModel();
		BindingContext = vm;
	}
}