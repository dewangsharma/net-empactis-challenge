using AutoMapper;
using Core.Model.Dto;
using CoreLogic.Model.Objects.Entities;

namespace Core.Model.Mappers
{
    public class EmployeeProfile: Profile, IMap
    {
        public EmployeeProfile( )
        {
            // Employee -> EmployeeDTO
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
