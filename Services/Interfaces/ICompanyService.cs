
using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.DTOs.Organization;
using HRMS.Models.Organization;
using HRMS.Repositories.Interfaces;
using static HRMS.DTOs.Organization.CompanyDTOs;

namespace HRMS.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<ApiResponse<IEnumerable<CompanyDTO>>> GetAllAsync();
        Task<ApiResponse<CompanyDTO>> GetByIdAsync(int id);
        Task<ApiResponse<CompanyDTO>> CreateAsync(CreateCompanyDTO dto, int createdBy);
        Task<ApiResponse<CompanyDTO>> UpdateAsync(int id, UpdateCompanyDTO dto, int updatedBy);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<PagedResponse<IEnumerable<CompanyDTO>>> GetPagedAsync(int pageNumber, int pageSize, string searchTerm = null);
    }
}

