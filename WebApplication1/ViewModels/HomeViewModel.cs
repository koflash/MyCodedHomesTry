using CodedHomes.Models;

namespace WebApplication1.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Home Home { get; set; }
        public bool IsNew { get; set; }

        public string ImageUrlPrefix
        {
            get { return WebApplication1.Config.ImageUrlPrefix; }
        }

        public HomeViewModel()
        {
            this.Home = new Home();
        }
    }
}