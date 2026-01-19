using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.DTOs.Organization;
using HRMS.Models.Organization;
using HRMS.Repositories.Interfaces;
using static HRMS.DTOs.Organization.CompanyDTOs;

namespace HRMS.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<ApiResponse<IEnumerable<DepartmentDTO>>> GetAllAsync();
        Task<ApiResponse<IEnumerable<DepartmentDTO>>> GetByCompanyIdAsync(int companyId);
        Task<ApiResponse<DepartmentDTO>> GetByIdAsync(int id);
        Task<ApiResponse<DepartmentDTO>> CreateAsync(CreateDepartmentDTO dto, int createdBy);
        Task<ApiResponse<DepartmentDTO>> UpdateAsync(int id, UpdateDepartmentDTO dto, int updatedBy);
        Task<ApiResponse<bool>> DeleteAsync(int id);
    }
}