using CodedHomes.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace WebApplication1.ViewModels
{
    public class HomesListsViewModel : ViewModelBase
    {
        public IList<Home> Homes { get; set; }

        public string HomeJSON
        {
            get
            {
                JsonSerializerSettings settings =
                    new JsonSerializerSettings();

                settings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();

                var homes = JsonConvert.SerializeObject(this.Homes, settings);
                return homes;
            }
        }

        public string ImageUrlPrefix
        {
            get { return WebApplication1.Config.ImageUrlPrefix;  }
        }


    }
}