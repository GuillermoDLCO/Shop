using Shop.UIForms.ViewModels;

namespace Shop.UIForms.Infrastructure
{
    using ViewModels;

    //Sirve para mantener una unica instancia de MainViewModel durante todo el proyecto
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
