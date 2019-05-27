namespace Shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.UIForms.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "guillermo.dlco@outlook.com";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo
                    "You must enter your email",//Mensaje
                    "Accept");//Boton
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo
                    "You must enter your password",//Mensaje
                    "Accept");//Boton
                return;
            }

            if (!this.Email.Equals("guillermo.dlco@outlook.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", //Titulo
                    "User or password wrong",//Mensaje
                    "Accept");//Boton
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //        "Ok", //Titulo
            //        "Fuck yeah",//Mensaje
            //        "Accept");//Boton
            //return;

            //Para direccionar a la nueva pagina
            //Antes de instanciar la page se debe instanciar la viewModel asociada
            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());

        }
    }
}
