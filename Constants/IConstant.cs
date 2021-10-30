using EmployeeMicroservice.Models;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMicroservice.Constants
{
    public interface IConstant
    {
        public List<Employee> GetEmployeeList();
        public Task<IList<OfferData>> ViewEmployeeOffers(int employeeId);
        public Task<IList<OfferData>> ViewMostLikedOffers(int employeeId);
        public Task<List<PointsData>> GetPointsList();
    }
}
