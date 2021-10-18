using Core.Model.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IAbsenceRepository
    {
        /// <summary>
        /// Get absence-count by employee
        /// Note: This is not counting the days,
        /// it is counting the number of times absence is occured for that employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        int GetAbsenceCountByEmployee( EmployeeDto  employeeDto);

        /// <summary>
        /// Get list of absences by employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        Task<IEnumerable<AbsenceDto>> GetAllByEmployeeAsync(  EmployeeDto employeeDto );
     }
}
