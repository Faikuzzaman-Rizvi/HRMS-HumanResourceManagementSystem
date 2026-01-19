using AutoMapper;
using HRMS.DTOs.EmployeeDetails;
using HRMS.DTOs.Organization;
using HRMS.Models.EmployeeDetails;
using HRMS.Models.Organization;
using static HRMS.DTOs.EmployeeDetails.EmployeeDTOs;
using static HRMS.DTOs.Organization.CompanyDTOs;

namespace HRMS.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Company Mappings
            CreateMap<Company, CompanyDTO>();
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<UpdateCompanyDTO, Company>();

            // Department Mappings
            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : null))
                .ForMember(dest => dest.ParentDepartmentName, opt => opt.MapFrom(src => src.ParentDepartment != null ? src.ParentDepartment.Name : null))
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.FullName : null));

            CreateMap<CreateDepartmentDTO, Department>();
            CreateMap<UpdateDepartmentDTO, Department>();

            // Location Mappings
            CreateMap<Location, LocationDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            CreateMap<CreateLocationDTO, Location>();

            // Designation Mappings
            CreateMap<Designation, DesignationDTO>();
            CreateMap<CreateDesignationDTO, Designation>();

            // Grade Mappings
            CreateMap<Grade, GradeDTO>();
            CreateMap<CreateGradeDTO, Grade>();

            // Employee Mappings
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.DesignationTitle, opt => opt.MapFrom(src => src.Designation.Title))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : null))
                .ForMember(dest => dest.ReportingManagerName, opt => opt.MapFrom(src => src.ReportingManager != null ? src.ReportingManager.FullName : null));

            CreateMap<Employee, EmployeeDetailDTO>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.DesignationTitle, opt => opt.MapFrom(src => src.Designation.Title))
                .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src => src.Grade.Name))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location != null ? src.Location.Name : null))
                .ForMember(dest => dest.ReportingManagerName, opt => opt.MapFrom(src => src.ReportingManager != null ? src.ReportingManager.FullName : null))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Educations, opt => opt.MapFrom(src => src.Educations))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences))
                .ForMember(dest => dest.BankAccounts, opt => opt.MapFrom(src => src.BankAccounts));

            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

            // Employee Address Mappings
            CreateMap<EmployeeAddress, EmployeeAddressDTO>();
            CreateMap<CreateEmployeeAddressDTO, EmployeeAddress>();

            // Employee Education Mappings
            CreateMap<EmployeeEducation, EmployeeEducationDTO>();
            CreateMap<CreateEmployeeEducationDTO, EmployeeEducation>();

            // Employee Experience Mappings
            CreateMap<EmployeeExperience, EmployeeExperienceDTO>();
            CreateMap<CreateEmployeeExperienceDTO, EmployeeExperience>();

            // Employee Bank Account Mappings
            CreateMap<EmployeeBankAccount, EmployeeBankAccountDTO>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchName));

            CreateMap<CreateEmployeeBankAccountDTO, EmployeeBankAccount>();
        }
    }
}