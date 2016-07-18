using System.Web.Http;
using WebApplication.Filters;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Validation.Providers;

namespace WebApplication1
{
    public class CustomGlobalConfig
    {

        public static void Customize(HttpConfiguration config)
        {

            config.Services.RemoveAll(
                typeof(System.Web.Http.Validation.ModelValidatorProvider),
                v => v is InvalidModelValidatorProvider);

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            config.Filters.Add(new ValidationActionFilter());
        }
    }
}