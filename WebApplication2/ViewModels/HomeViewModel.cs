using CodedHomes.Models;

namespace WebApplication2.2ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public Home Home { get; set; }
        public bool IsNew { get; set; }

        public string ImageUrlPrefix
        {
            get { return WebApplication2.2Config.ImagesUrlPrefix; }
        }

        public HomeViewModel()
        {
            this.Home = new Home();
        }
    }
}