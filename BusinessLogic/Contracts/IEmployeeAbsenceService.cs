using Core.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Contracts
{
    public interface IEmployeeAbsenceService
    {
        /// <summary>
        /// Get list of employees withe absence count
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeAbsenceDto>> GetEmployeesWithAbsenceCountAsync( );

        /// <summary>
        /// Get list of absences by employeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<IEnumerable<AbsenceDto>> GetAbsencesByEmployeeIdAsync( int employeeId );
    }
}
