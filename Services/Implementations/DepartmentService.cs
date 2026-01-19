using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.Models.Organization;
using HRMS.Repositories.Interfaces;
using HRMS.Services.Interfaces;
using static HRMS.DTOs.Organization.CompanyDTOs;

namespace HRMS.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<DepartmentDTO>>> GetAllAsync()
        {
            try
            {
                var departments = await _unitOfWork.Departments.FindAsync(
                    d => d.IsActive,
                    d => d.Company,
                    d => d.Location,
                    d => d.ParentDepartment,
                    d => d.Manager
                );

                var departmentDTOs = _mapper.Map<IEnumerable<DepartmentDTO>>(departments);

                return ApiResponse<IEnumerable<DepartmentDTO>>.SuccessResponse(
                    departmentDTOs,
                    "Departments retrieved successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<DepartmentDTO>>.ErrorResponse(
                    "Error retrieving departments",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<IEnumerable<DepartmentDTO>>> GetByCompanyIdAsync(int companyId)
        {
            try
            {
                var departments = await _unitOfWork.Departments.FindAsync(
                    d => d.CompanyId == companyId && d.IsActive,
                    d => d.Company,
                    d => d.Location,
                    d => d.ParentDepartment,
                    d => d.Manager
                );

                var departmentDTOs = _mapper.Map<IEnumerable<DepartmentDTO>>(departments);

                return ApiResponse<IEnumerable<DepartmentDTO>>.SuccessResponse(
                    departmentDTOs,
                    "Departments retrieved successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<DepartmentDTO>>.ErrorResponse(
                    "Error retrieving departments",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<DepartmentDTO>> GetByIdAsync(int id)
        {
            try
            {
                var department = await _unitOfWork.Departments.GetByIdAsync(
                    id,
                    d => d.Company,
                    d => d.Location,
                    d => d.ParentDepartment,
                    d => d.Manager
                );

                if (department == null || !department.IsActive)
                {
                    return ApiResponse<DepartmentDTO>.ErrorResponse("Department not found");
                }

                var departmentDTO = _mapper.Map<DepartmentDTO>(department);
                return ApiResponse<DepartmentDTO>.SuccessResponse(departmentDTO);
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmentDTO>.ErrorResponse(
                    "Error retrieving department",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<DepartmentDTO>> CreateAsync(CreateDepartmentDTO dto, int createdBy)
        {
            try
            {
                // Check if code already exists
                var exists = await _unitOfWork.Departments.AnyAsync(d => d.Code == dto.Code);
                if (exists)
                {
                    return ApiResponse<DepartmentDTO>.ErrorResponse(
                        "Department code already exists");
                }

                // Validate company exists
                var companyExists = await _unitOfWork.Companies.AnyAsync(c => c.Id == dto.CompanyId && c.IsActive);
                if (!companyExists)
                {
                    return ApiResponse<DepartmentDTO>.ErrorResponse("Invalid company");
                }

                var department = _mapper.Map<Department>(dto);
                department.CreatedAt = DateTime.Now;
                department.CreatedBy = createdBy;
                department.IsActive = true;

                await _unitOfWork.Departments.AddAsync(department);
                await _unitOfWork.SaveChangesAsync();

                var departmentDTO = _mapper.Map<DepartmentDTO>(department);
                return ApiResponse<DepartmentDTO>.SuccessResponse(
                    departmentDTO,
                    "Department created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmentDTO>.ErrorResponse(
                    "Error creating department",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<DepartmentDTO>> UpdateAsync(int id, UpdateDepartmentDTO dto, int updatedBy)
        {
            try
            {
                var department = await _unitOfWork.Departments.GetByIdAsync(id);

                if (department == null)
                {
                    return ApiResponse<DepartmentDTO>.ErrorResponse("Department not found");
                }

                _mapper.Map(dto, department);
                department.UpdatedAt = DateTime.Now;
                department.UpdatedBy = updatedBy;

                await _unitOfWork.Departments.UpdateAsync(department);
                await _unitOfWork.SaveChangesAsync();

                var departmentDTO = _mapper.Map<DepartmentDTO>(department);
                return ApiResponse<DepartmentDTO>.SuccessResponse(
                    departmentDTO,
                    "Department updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmentDTO>.ErrorResponse(
                    "Error updating department",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var department = await _unitOfWork.Departments.GetByIdAsync(id);

                if (department == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Department not found");
                }

                // Check if has sub-departments
                var hasSubDepartments = await _unitOfWork.Departments.AnyAsync(
                    d => d.ParentDepartmentId == id && d.IsActive);

                if (hasSubDepartments)
                {
                    return ApiResponse<bool>.ErrorResponse(
                        "Cannot delete department with active sub-departments");
                }

                // Soft delete
                department.IsActive = false;
                department.UpdatedAt = DateTime.Now;

                await _unitOfWork.Departments.UpdateAsync(department);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Department deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Error deleting department",
                    new List<string> { ex.Message });
            }
        }
    }
}