using Core.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get list of employees
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync( );

        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<EmployeeDto> GetByIdAsync( int employeeId );
    }
}
