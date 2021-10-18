using AutoMapper;
using Core.Model.Dto;
using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    /// <summary>
    /// Implementation of the IEmployeeRepository
    /// Handles the DB operation of the Employee entity
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// The application db context
        /// </summary>
        protected readonly EFDBContext _context;

        /// <summary>
        /// Mapper interface
        /// </summary>
        protected readonly IMapper _mapper;

        public EmployeeRepository( EFDBContext context, IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// Get all the employees
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync( )
            => _mapper.Map<IEnumerable<EmployeeDto>>( await _context.Employees.ToListAsync() );


        /// <summary>
        /// Get employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<EmployeeDto> GetByIdAsync( int employeeId )
            => _mapper.Map<EmployeeDto>( await _context.Employees.Where( x => x.Id == employeeId ).FirstOrDefaultAsync() );
    }
}