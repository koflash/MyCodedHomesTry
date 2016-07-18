using CodedHomes.Models;

namespace WebApplication.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Home Home { get; set; }
        public bool IsNew { get; set; }

        public string ImageUrlPrefix
        {
            get { return WebApplication.Config.ImageUrlPrefix; }
        }

        public HomeViewModel()
        {
            this.Home = new Home();
        }
    }
}