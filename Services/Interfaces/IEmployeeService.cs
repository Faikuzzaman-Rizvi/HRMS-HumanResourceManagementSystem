using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.DTOs.EmployeeDetails;
using HRMS.Models.EmployeeDetails;
using HRMS.Repositories.Interfaces;
using static HRMS.DTOs.EmployeeDetails.EmployeeDTOs;

namespace HRMS.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<ApiResponse<IEnumerable<EmployeeDTO>>> GetAllAsync();
        Task<ApiResponse<EmployeeDetailDTO>> GetByIdAsync(int id);
        Task<ApiResponse<EmployeeDetailDTO>> GetByEmployeeCodeAsync(string employeeCode);
        Task<ApiResponse<EmployeeDetailDTO>> CreateAsync(CreateEmployeeDTO dto, int createdBy);
        Task<ApiResponse<EmployeeDetailDTO>> UpdateAsync(int id, UpdateEmployeeDTO dto, int updatedBy);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<PagedResponse<IEnumerable<EmployeeDTO>>> GetPagedAsync(int pageNumber, int pageSize, string searchTerm = null, int? departmentId = null);

        // Address Management
        Task<ApiResponse<EmployeeAddressDTO>> AddAddressAsync(int employeeId, CreateEmployeeAddressDTO dto);
        Task<ApiResponse<bool>> DeleteAddressAsync(int addressId);

        // Education Management
        Task<ApiResponse<EmployeeEducationDTO>> AddEducationAsync(int employeeId, CreateEmployeeEducationDTO dto);
        Task<ApiResponse<bool>> DeleteEducationAsync(int educationId);

        // Experience Management
        Task<ApiResponse<EmployeeExperienceDTO>> AddExperienceAsync(int employeeId, CreateEmployeeExperienceDTO dto);
        Task<ApiResponse<bool>> DeleteExperienceAsync(int experienceId);

        // Bank Account Management
        Task<ApiResponse<EmployeeBankAccountDTO>> AddBankAccountAsync(int employeeId, CreateEmployeeBankAccountDTO dto);
        Task<ApiResponse<bool>> DeleteBankAccountAsync(int bankAccountId);
    }
}