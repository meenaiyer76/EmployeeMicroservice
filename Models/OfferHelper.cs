using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OfferMicroservice.Models
{
    public class OfferHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389/");
            var client1 = new HttpClient();
            client1.BaseAddress = new Uri("https://offermicroserviceweb.azurewebsites.net/");
            return client1;
        }
    }
}
