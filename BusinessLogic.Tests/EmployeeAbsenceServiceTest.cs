using Autofac;
using AutoMapper;
using BusinessLogic.Concrete;
using BusinessLogic.Contracts;
using Core.Model.Dto;
using CoreLogic.Model.Objects.Entities;
using DataAccess.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLogic.Tests
{
    public class EmployeeAbsenceServiceTest
    {
        protected ContainerBuilder _containerBuilder = new ContainerBuilder();
        protected Mock<IEmployeeRepository> _employeeRepository = new Mock<IEmployeeRepository>();
        protected Mock<IAbsenceRepository> _absenceRepository = new Mock<IAbsenceRepository>();
        protected Mock<IMapper> _mapperMock = new Mock<IMapper>();
        protected IEmployeeAbsenceService _sut;
        public EmployeeAbsenceServiceTest( )
        {
            _sut = new EmployeeAbsenceService( _employeeRepository.Object, _absenceRepository.Object );
        }

        [Fact]
        public async Task Success_GetEmployeeWithAbsenceCount( )
        {
            // Arrange
            var employee1 = new EmployeeDto() { Id = 1, Name = "Glenn" };
            var employee2 = new EmployeeDto() { Id = 2, Name = "Steve" };
            var returnEmployees = new List<EmployeeDto>() { employee1, employee2 };

            // Mock return of employee repository
            _employeeRepository.Setup( x => x.GetEmployeesAsync() )
                .ReturnsAsync( returnEmployees );

            int employee1AbsenceCount = 2;
            int employee2AbsenceCount = 4;
            // Mock return of absence repository
            _absenceRepository.Setup( x => x.GetAbsenceCountByEmployee( employee1 ) ).Returns( employee1AbsenceCount );
            _absenceRepository.Setup( x => x.GetAbsenceCountByEmployee( employee2 ) ).Returns( employee2AbsenceCount );

            // Act
            var result = await _sut.GetEmployeesWithAbsenceCountAsync();

            // Assert 
            _employeeRepository.Verify( x => x.GetEmployeesAsync(), Times.Once );
            _absenceRepository.Verify( x => x.GetAbsenceCountByEmployee( It.IsAny<EmployeeDto>() ), Times.Exactly( 2 ) );
            Assert.Equal( result.Count(), returnEmployees.Count );
            Assert.Equal( result.Where( x => x.Employee.Id == employee1.Id ).FirstOrDefault().AbsenceCount, employee1AbsenceCount );
        }

        [Fact]
        public async Task Success_GetAbsencesByEmployeeIdAsync( )
        {
            // Arrange
            var employee1 = new EmployeeDto() { Id = 100, Name = "Glenn" };

            // Mock return of employee repository
            _employeeRepository.Setup( x => x.GetByIdAsync( employee1.Id ) )
                .ReturnsAsync( employee1 );

            var absence1 = new AbsenceDto() { Id = 10, Employee = employee1, Start = DateTime.Now.AddDays( -3 ), End = DateTime.Now, Type = AbsenceType.AbsenceType1 };
            var absence2 = new AbsenceDto() { Id = 11, Employee = employee1, Start = DateTime.Now.AddDays( -30 ), End = DateTime.Now.AddDays( -28 ), Type = AbsenceType.AbsenceType1 };
            var absence3 = new AbsenceDto() { Id = 12, Employee = employee1, Start = DateTime.Now.AddDays( -15 ), End = DateTime.Now.AddDays( -13 ), Type = AbsenceType.AbsenceType1 };
            var absenceList = new List<AbsenceDto>() { absence1, absence2, absence3 };

            // Mock return of absence repository
            _absenceRepository.Setup( x => x.GetAllByEmployeeAsync( employee1 ) ).ReturnsAsync( absenceList );
            
            // Act
            var result = await _sut.GetAbsencesByEmployeeIdAsync( employee1.Id );

            // Assert 
            _employeeRepository.Verify( x => x.GetByIdAsync(employee1.Id), Times.Once );
            _absenceRepository.Verify( x => x.GetAllByEmployeeAsync( employee1 ), Times.Once );
            Assert.Equal( result.Count(), absenceList.Count );
        }
    }
}
