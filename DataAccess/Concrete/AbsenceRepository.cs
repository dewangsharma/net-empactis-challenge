using AutoMapper;
using Core.Model.Dto;
using DataAccess.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    /// <summary>
    /// Implementation of IAbsenceRepository
    /// Handles the DB operation of the Absence entity
    /// </summary>
    public class AbsenceRepository : IAbsenceRepository
    {
        /// <summary>
        /// The application db context
        /// </summary>
        protected readonly EFDBContext _context;

        /// <summary>
        /// Mapper interface
        /// </summary>
        protected readonly IMapper _mapper;

        public AbsenceRepository( EFDBContext context, IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get absence-count by employee
        /// Note: This is not counting the days,
        /// it is counting the number of times absence is occured for that employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public int GetAbsenceCountByEmployee( EmployeeDto employeeDto )
        {
            return _context.Absences.Where( x => x.Employee.Id == employeeDto.Id ).Count();
        }

        /// <summary>
        /// Get list of absences by employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AbsenceDto>> GetAllByEmployeeAsync( EmployeeDto employeeDto )
        {
            return _mapper.Map<IEnumerable<AbsenceDto>>( _context.Absences.Where( x => x.Employee.Id == employeeDto.Id ) );
        }
    }
}
