using TuranApp.Views;

namespace TuranApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute($"//{nameof(PinCodePage)}", typeof(PinCodePage));
        }
    }
}
