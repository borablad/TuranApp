using TuranApp.Views;

namespace TuranApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage(); //TODO Сделать проверку на авторизованость пользователя и перекидывать в Pin если у нас есть уже гугловский токен
        }
    }
}
