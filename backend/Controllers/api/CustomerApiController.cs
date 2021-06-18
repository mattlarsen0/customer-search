using System.Net;
using backend.DomainServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using backend.ModelServices;
using backend.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerApiController : Controller
    {
        private readonly ICustomerRepository databaseRepo;
        private readonly ICustomerAdapter customerAdapter;

        public CustomerApiController(ICustomerRepository databaseRepo = null, ICustomerAdapter customerAdapter = null)
        {
            this.databaseRepo = databaseRepo ?? new CustomerRepository();
            this.customerAdapter = customerAdapter ?? new CustomerAdapter();
        }

        [HttpGet]
        public ContentResult Search()
        {
            var convertedCustomers = databaseRepo.Search().Select(c => customerAdapter.ConvertToModel(c));

            var model = new CustomerListModel()
            {
                customers = convertedCustomers
            };

            return getJsonResponse(model);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            DisposeDatabase();
            base.OnActionExecuted(context);
        }

        public void DisposeDatabase()
        {
            // dispose of db repo, this should be handled by Unity or similar
            databaseRepo.Dispose();
        }
        
        private ContentResult getJsonResponse(object model)
        {
            var json = JsonConvert.SerializeObject(model);

            return Content(json, "application/json");
        }
    }
}