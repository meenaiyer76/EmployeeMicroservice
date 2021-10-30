using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EmployeeMicroservice.Constants;
using EmployeeMicroservice.Models;
using EmployeeMicroservice.Repositories;
using Newtonsoft.Json;
using OfferMicroservice.Models;

namespace EmployeeMicroservice.Services
{
    public class EmployeeService : IConstant
    {
        OfferHelper _api = new OfferHelper();
        public readonly EmployeeRepository _employee;

        public EmployeeService()
        {
            _employee = new EmployeeRepository();
        }
        public List<Employee> GetEmployeeList()
        {
           return _employee.Employees;
        }

        public async Task<List<PointsData>> GetPointsList()
        {
            List<PointsData> offers = new List<PointsData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/points");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                offers = JsonConvert.DeserializeObject<List<PointsData>>(results);
            }
            return offers;
        }

        public async Task<IList<OfferData>> ViewEmployeeOffers(int employeeId)
        {
            List<OfferData> offers = new List<OfferData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Offer/GetOffersList");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                offers = JsonConvert.DeserializeObject<List<OfferData>>(results);
            }
            return offers;
        }

        public async Task<IList<OfferData>> ViewMostLikedOffers(int employeeId)
        {
            List<OfferData> offers = new List<OfferData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Offer/GetOffersList");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                offers = JsonConvert.DeserializeObject<List<OfferData>>(results);
            }
            return offers;
        }
    }
}
