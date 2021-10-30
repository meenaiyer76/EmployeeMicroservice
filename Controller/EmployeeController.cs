using EmployeeMicroservice.Models;
using EmployeeMicroservice.Repositories;
using EmployeeMicroservice.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMicroservice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class EmployeeController : ControllerBase
    {
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(EmployeeController));
        OfferHelper _api = new OfferHelper();
        public readonly EmployeeRepository _employee = new EmployeeRepository();
        public readonly EmployeeService _service;
        public EmployeeController()
        {
            _service = new EmployeeService();
        }
        [HttpGet]
        [Route("GetEmployeeList")]
        public ActionResult<List<Employee>> GetEmployeeList()
        {
            _log4net.Info("Employee List is displyed");
            return _service.GetEmployeeList();
        }

        //View All Offers
        [HttpGet]
        [Route("ViewEmployeeOffers/{employeeId}")]
        public async Task<ActionResult<IList<OfferData>>> ViewEmployeeOffers(int employeeId)
        {
            var offers = await _service.ViewEmployeeOffers(employeeId);
            var employeeOffers = offers.Where(c => c.EmployeeId == employeeId).ToList();
            if (employeeOffers.Count== 0)
            {
                _log4net.Info("ViewEmployeeList Method Called and result is not displayed");
                return NotFound("No offers found");
            }
            return employeeOffers;
        }
        [HttpGet]
        [Route("ViewMostLikedOffers/{employeeId}")]
        public async Task<ActionResult<IList<OfferData>>> ViewMostLikedOffers(int employeeId)
        {
            var offers = await _service.ViewMostLikedOffers(employeeId);
            var offer = (from c in offers where c.EmployeeId==employeeId orderby c.Likes descending select c).Take(3).ToList();
            //List<OfferProvider> lists = offers.ToList();
            if(offer.Count==0)
            {
                _log4net.Info("ViewMostLikedOffer Method Called and result is not displayed");
                return NotFound("No Offers Found");
            }
            return offer;

        }
        [HttpGet]
        [Route("GetPointsList")]
        public async Task<List<PointsData>> GetPointsList()
        {
            return await _service.GetPointsList();
        }
    }
}
