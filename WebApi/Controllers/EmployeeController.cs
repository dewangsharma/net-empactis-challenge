using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApi.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// EmployeeAbsence service
        /// </summary>
        private readonly IEmployeeAbsenceService _employeeAbsenceService;
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="employeeAbsenceService"></param>
        public EmployeeController( IEmployeeAbsenceService employeeAbsenceService )
        {
            _employeeAbsenceService = employeeAbsenceService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get( )
        {
            return Ok( await _employeeAbsenceService.GetEmployeesWithAbsenceCountAsync() );
        }

        // GET api/<EmployeeController>/5
        [HttpGet( "{id}" )]
        public async Task<IActionResult> Get( int id )
        {
            return Ok( await _employeeAbsenceService.GetAbsencesByEmployeeIdAsync( id ) );
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post( [FromBody] string value )
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut( "{id}" )]
        public void Put( int id, [FromBody] string value )
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete( "{id}" )]
        public void Delete( int id )
        {
        }
    }
}
