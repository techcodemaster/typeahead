using System.Collections.Generic;
using System.Web.Http;
using Typehead.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Typehead.Controllers
{
    public class TypeaheadController : ApiController
    {  
        public List<SelectListItem> Get()
      {
            List<SelectListItem> countryList = new List<SelectListItem>();
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/App_Data/countries.xml"));
            foreach (XmlNode node in doc.SelectNodes("//country"))
            {
                countryList.Add(new SelectListItem() { Text = node.InnerText, Value = node.InnerText });
            }

            return countryList;
        }

        public List<string> Get(string id)
        {
            Typeahead type = new Typeahead();
            var doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/country_state.xml"));
           type.cityList = (from c in doc.Descendants("country")
                                   from s in c.Descendants("state")
                            where c.Attribute("name").Value == id.ToString()
                                   select s.Value).ToList<string>();
           return type.cityList;
        }           
        
    }
}
