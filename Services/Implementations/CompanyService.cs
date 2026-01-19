using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.Models.Organization;
using HRMS.Repositories.Interfaces;
using HRMS.Services.Interfaces;
using static HRMS.DTOs.Organization.CompanyDTOs;

namespace HRMS.Services.Implementations
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<CompanyDTO>>> GetAllAsync()
        {
            try
            {
                var companies = await _unitOfWork.Companies.FindAsync(c => c.IsActive);
                var companyDTOs = _mapper.Map<IEnumerable<CompanyDTO>>(companies);

                return ApiResponse<IEnumerable<CompanyDTO>>.SuccessResponse(
                    companyDTOs,
                    "Companies retrieved successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CompanyDTO>>.ErrorResponse(
                    "Error retrieving companies",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<CompanyDTO>> GetByIdAsync(int id)
        {
            try
            {
                var company = await _unitOfWork.Companies.GetByIdAsync(id);

                if (company == null || !company.IsActive)
                {
                    return ApiResponse<CompanyDTO>.ErrorResponse("Company not found");
                }

                var companyDTO = _mapper.Map<CompanyDTO>(company);
                return ApiResponse<CompanyDTO>.SuccessResponse(companyDTO);
            }
            catch (Exception ex)
            {
                return ApiResponse<CompanyDTO>.ErrorResponse(
                    "Error retrieving company",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<CompanyDTO>> CreateAsync(CreateCompanyDTO dto, int createdBy)
        {
            try
            {
                // Check if code already exists
                var exists = await _unitOfWork.Companies.AnyAsync(c => c.Code == dto.Code);
                if (exists)
                {
                    return ApiResponse<CompanyDTO>.ErrorResponse(
                        "Company code already exists");
                }

                var company = _mapper.Map<Company>(dto);
                company.CreatedAt = DateTime.Now;
                company.CreatedBy = createdBy;
                company.IsActive = true;

                await _unitOfWork.Companies.AddAsync(company);
                await _unitOfWork.SaveChangesAsync();

                var companyDTO = _mapper.Map<CompanyDTO>(company);
                return ApiResponse<CompanyDTO>.SuccessResponse(
                    companyDTO,
                    "Company created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<CompanyDTO>.ErrorResponse(
                    "Error creating company",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<CompanyDTO>> UpdateAsync(int id, UpdateCompanyDTO dto, int updatedBy)
        {
            try
            {
                var company = await _unitOfWork.Companies.GetByIdAsync(id);

                if (company == null)
                {
                    return ApiResponse<CompanyDTO>.ErrorResponse("Company not found");
                }

                _mapper.Map(dto, company);
                company.UpdatedAt = DateTime.Now;
                company.UpdatedBy = updatedBy;

                await _unitOfWork.Companies.UpdateAsync(company);
                await _unitOfWork.SaveChangesAsync();

                var companyDTO = _mapper.Map<CompanyDTO>(company);
                return ApiResponse<CompanyDTO>.SuccessResponse(
                    companyDTO,
                    "Company updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<CompanyDTO>.ErrorResponse(
                    "Error updating company",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var company = await _unitOfWork.Companies.GetByIdAsync(id);

                if (company == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Company not found");
                }

                // Soft delete
                company.IsActive = false;
                company.UpdatedAt = DateTime.Now;

                await _unitOfWork.Companies.UpdateAsync(company);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Company deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Error deleting company",
                    new List<string> { ex.Message });
            }
        }

        public async Task<PagedResponse<IEnumerable<CompanyDTO>>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string searchTerm = null)
        {
            try
            {
                var (companies, totalCount) = await _unitOfWork.Companies.GetPagedAsync(
                    pageNumber,
                    pageSize,
                    filter: c => c.IsActive &&
                        (string.IsNullOrEmpty(searchTerm) ||
                         c.Name.Contains(searchTerm) ||
                         c.Code.Contains(searchTerm)),
                    orderBy: q => q.OrderBy(c => c.Name)
                );

                var companyDTOs = _mapper.Map<IEnumerable<CompanyDTO>>(companies);

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                return new PagedResponse<IEnumerable<CompanyDTO>>
                {
                    Success = true,
                    Message = "Companies retrieved successfully",
                    Data = companyDTOs,
                    Pagination = new PaginationMetadata
                    {
                        CurrentPage = pageNumber,
                        PageSize = pageSize,
                        TotalCount = totalCount,
                        TotalPages = totalPages,
                        HasPrevious = pageNumber > 1,
                        HasNext = pageNumber < totalPages
                    }
                };
            }
            catch (Exception ex)
            {
                return new PagedResponse<IEnumerable<CompanyDTO>>
                {
                    Success = false,
                    Message = "Error retrieving companies",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}