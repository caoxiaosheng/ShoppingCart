using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ShoppingCart.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString HtmlComvertToJson(this HtmlHelper htmlHelper, object model)
        {
            var setting=new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            return new HtmlString(JsonConvert.SerializeObject(model,setting));
        }
    }
}