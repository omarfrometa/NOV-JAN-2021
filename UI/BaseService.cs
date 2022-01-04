using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class BaseService
    {
        public static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["BaseAddress"].ToString())
        };
    }
}
