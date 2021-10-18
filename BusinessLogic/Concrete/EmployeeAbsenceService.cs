using BusinessLogic.Contracts;
using Core.Model.Dto;
using DataAccess.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    /// <summary>
    /// Implementation of IEmployeeService
    /// Handles the business logic of the EmployeeAbsence
    /// </summary>
    public class EmployeeAbsenceService : IEmployeeAbsenceService
    {
        /// <summary>
        /// EmployeeRepository
        /// </summary>
        private readonly IEmployeeRepository _employeeRepo;
        
        /// <summary>
        /// AbsenceRepository
        /// </summary>
        private readonly IAbsenceRepository _absenceRepo;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="employeeRepo"></param>
        /// <param name="absenceRepo"></param>
        public EmployeeAbsenceService( IEmployeeRepository employeeRepo, IAbsenceRepository absenceRepo )
        {
            _employeeRepo = employeeRepo;
            _absenceRepo = absenceRepo;
        }

        /// <summary>
        /// Get list of employees withe absence count
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeAbsenceDto>> GetEmployeesWithAbsenceCountAsync( )
        {
            // All available employees
            var allEmployees = await _employeeRepo.GetEmployeesAsync();
            // Return object initiation
            var result = new List<EmployeeAbsenceDto>();
            // Loop through each employee to get absences
            foreach( var employee in allEmployees )
            {
                var absenceCount = _absenceRepo.GetAbsenceCountByEmployee( employee );

                result.Add( new EmployeeAbsenceDto() { Employee = employee, AbsenceCount = absenceCount } );
            }

            return result;
        }

        /// <summary>
        /// Get list of absences by employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AbsenceDto>> GetAbsencesByEmployeeIdAsync( int employeeId )
        {
            var employeeDto = await _employeeRepo.GetByIdAsync( employeeId );
            if( employeeDto == null )
                throw new System.Exception($"EmployeeID : {employeeId} not found");

            return await _absenceRepo.GetAllByEmployeeAsync( employeeDto );
        }
    }
}
