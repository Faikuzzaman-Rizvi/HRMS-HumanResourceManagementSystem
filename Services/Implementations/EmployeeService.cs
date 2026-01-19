using AutoMapper;
using HRMS.DTOs.Common;
using HRMS.Models.EmployeeDetails;
using HRMS.Repositories.Interfaces;
using HRMS.Services.Interfaces;
using static HRMS.DTOs.EmployeeDetails.EmployeeDTOs;

namespace HRMS.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<EmployeeDTO>>> GetAllAsync()
        {
            try
            {
                var employees = await _unitOfWork.Employees.FindAsync(
                    e => e.IsActive,
                    e => e.Company,
                    e => e.Department,
                    e => e.Designation,
                    e => e.Grade,
                    e => e.Location,
                    e => e.ReportingManager
                );

                var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

                return ApiResponse<IEnumerable<EmployeeDTO>>.SuccessResponse(
                    employeeDTOs,
                    "Employees retrieved successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<EmployeeDTO>>.ErrorResponse(
                    "Error retrieving employees",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<EmployeeDetailDTO>> GetByIdAsync(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(
                    id,
                    e => e.Company,
                    e => e.Department,
                    e => e.Designation,
                    e => e.Grade,
                    e => e.Location,
                    e => e.ReportingManager,
                    e => e.Addresses,
                    e => e.Educations,
                    e => e.Experiences,
                    e => e.BankAccounts
                );

                if (employee == null || !employee.IsActive)
                {
                    return ApiResponse<EmployeeDetailDTO>.ErrorResponse("Employee not found");
                }

                var employeeDTO = _mapper.Map<EmployeeDetailDTO>(employee);
                return ApiResponse<EmployeeDetailDTO>.SuccessResponse(employeeDTO);
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeDetailDTO>.ErrorResponse(
                    "Error retrieving employee",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<EmployeeDetailDTO>> GetByEmployeeCodeAsync(string employeeCode)
        {
            try
            {
                var employee = await _unitOfWork.Employees.FirstOrDefaultAsync(
                    e => e.EmployeeCode == employeeCode && e.IsActive,
                    e => e.Company,
                    e => e.Department,
                    e => e.Designation,
                    e => e.Grade,
                    e => e.Location,
                    e => e.ReportingManager,
                    e => e.Addresses,
                    e => e.Educations,
                    e => e.Experiences,
                    e => e.BankAccounts
                );

                if (employee == null)
                {
                    return ApiResponse<EmployeeDetailDTO>.ErrorResponse("Employee not found");
                }

                var employeeDTO = _mapper.Map<EmployeeDetailDTO>(employee);
                return ApiResponse<EmployeeDetailDTO>.SuccessResponse(employeeDTO);
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeDetailDTO>.ErrorResponse(
                    "Error retrieving employee",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<EmployeeDetailDTO>> CreateAsync(CreateEmployeeDTO dto, int createdBy)
        {
            try
            {
                // Generate employee code
                var lastEmployee = (await _unitOfWork.Employees.GetAllAsync())
                    .OrderByDescending(e => e.Id)
                    .FirstOrDefault();

                var nextId = (lastEmployee?.Id ?? 0) + 1;
                var employeeCode = $"EMP{nextId:D6}";

                // Validate email uniqueness
                var emailExists = await _unitOfWork.Employees.AnyAsync(e => e.Email == dto.Email);
                if (emailExists)
                {
                    return ApiResponse<EmployeeDetailDTO>.ErrorResponse("Email already exists");
                }

                // Validate references
                var companyExists = await _unitOfWork.Companies.AnyAsync(c => c.Id == dto.CompanyId && c.IsActive);
                if (!companyExists)
                {
                    return ApiResponse<EmployeeDetailDTO>.ErrorResponse("Invalid company");
                }

                var departmentExists = await _unitOfWork.Departments.AnyAsync(d => d.Id == dto.DepartmentId && d.IsActive);
                if (!departmentExists)
                {
                    return ApiResponse<EmployeeDetailDTO>.ErrorResponse("Invalid department");
                }

                var employee = _mapper.Map<Employee>(dto);
                employee.EmployeeCode = employeeCode;
                employee.FullName = $"{dto.FirstName} {dto.MiddleName} {dto.LastName}".Trim();
                employee.EmploymentStatus = "Probation";
                employee.ProbationEndDate = dto.JoiningDate.AddMonths(6);
                employee.Email = dto.Email;
                employee.CreatedAt = DateTime.Now;
                employee.CreatedBy = createdBy;
                employee.IsActive = true;

                await _unitOfWork.Employees.AddAsync(employee);
                await _unitOfWork.SaveChangesAsync();

                var employeeDTO = _mapper.Map<EmployeeDetailDTO>(employee);
                return ApiResponse<EmployeeDetailDTO>.SuccessResponse(
                    employeeDTO,
                    "Employee created successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeDetailDTO>.ErrorResponse(
                    "Error creating employee",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<EmployeeDetailDTO>> UpdateAsync(int id, UpdateEmployeeDTO dto, int updatedBy)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);

                if (employee == null)
                {
                    return ApiResponse<EmployeeDetailDTO>.ErrorResponse("Employee not found");
                }

                _mapper.Map(dto, employee);
                employee.FullName = $"{employee.FirstName} {employee.MiddleName} {employee.LastName}".Trim();
                employee.UpdatedAt = DateTime.Now;
                employee.UpdatedBy = updatedBy;

                await _unitOfWork.Employees.UpdateAsync(employee);
                await _unitOfWork.SaveChangesAsync();

                var employeeDTO = _mapper.Map<EmployeeDetailDTO>(employee);
                return ApiResponse<EmployeeDetailDTO>.SuccessResponse(
                    employeeDTO,
                    "Employee updated successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeDetailDTO>.ErrorResponse(
                    "Error updating employee",
                    new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.GetByIdAsync(id);

                if (employee == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Employee not found");
                }

                // Soft delete
                employee.IsActive = false;
                employee.UpdatedAt = DateTime.Now;

                await _unitOfWork.Employees.UpdateAsync(employee);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Employee deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Error deleting employee",
                    new List<string> { ex.Message });
            }
        }

        public async Task<PagedResponse<IEnumerable<EmployeeDTO>>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            string searchTerm = null,
            int? departmentId = null)
        {
            try
            {
                var (employees, totalCount) = await _unitOfWork.Employees.GetPagedAsync(
                    pageNumber,
                    pageSize,
                    filter: e => e.IsActive &&
                        (!departmentId.HasValue || e.DepartmentId == departmentId.Value) &&
                        (string.IsNullOrEmpty(searchTerm) ||
                         e.FullName.Contains(searchTerm) ||
                         e.EmployeeCode.Contains(searchTerm) ||
                         e.Email.Contains(searchTerm)),
                    orderBy: q => q.OrderBy(e => e.EmployeeCode),
                    e => e.Company,
                    e => e.Department,
                    e => e.Designation,
                    e => e.Grade,
                    e => e.Location
                );

                var employeeDTOs = _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                return new PagedResponse<IEnumerable<EmployeeDTO>>
                {
                    Success = true,
                    Message = "Employees retrieved successfully",
                    Data = employeeDTOs,
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
                return new PagedResponse<IEnumerable<EmployeeDTO>>
                {
                    Success = false,
                    Message = "Error retrieving employees",
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        // Address Management
        public async Task<ApiResponse<EmployeeAddressDTO>> AddAddressAsync(int employeeId, CreateEmployeeAddressDTO dto)
        {
            try
            {
                var employeeExists = await _unitOfWork.Employees.AnyAsync(e => e.Id == employeeId && e.IsActive);
                if (!employeeExists)
                {
                    return ApiResponse<EmployeeAddressDTO>.ErrorResponse("Employee not found");
                }

                var address = _mapper.Map<EmployeeAddress>(dto);
                address.EmployeeId = employeeId;
                address.CreatedAt = DateTime.Now;
                address.IsActive = true;

                // If this is primary, remove primary from others
                if (dto.IsPrimary)
                {
                    var otherAddresses = await _unitOfWork.EmployeeAddresses.FindAsync(
                        a => a.EmployeeId == employeeId && a.AddressType == dto.AddressType);

                    foreach (var addr in otherAddresses)
                    {
                        addr.IsPrimary = false;
                        await _unitOfWork.EmployeeAddresses.UpdateAsync(addr);
                    }
                }

                await _unitOfWork.EmployeeAddresses.AddAsync(address);
                await _unitOfWork.SaveChangesAsync();

                var addressDTO = _mapper.Map<EmployeeAddressDTO>(address);
                return ApiResponse<EmployeeAddressDTO>.SuccessResponse(addressDTO, "Address added successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeAddressDTO>.ErrorResponse("Error adding address", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteAddressAsync(int addressId)
        {
            try
            {
                var address = await _unitOfWork.EmployeeAddresses.GetByIdAsync(addressId);
                if (address == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Address not found");
                }

                await _unitOfWork.EmployeeAddresses.DeleteAsync(address);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Address deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse("Error deleting address", new List<string> { ex.Message });
            }
        }

        // Education Management
        public async Task<ApiResponse<EmployeeEducationDTO>> AddEducationAsync(int employeeId, CreateEmployeeEducationDTO dto)
        {
            try
            {
                var employeeExists = await _unitOfWork.Employees.AnyAsync(e => e.Id == employeeId && e.IsActive);
                if (!employeeExists)
                {
                    return ApiResponse<EmployeeEducationDTO>.ErrorResponse("Employee not found");
                }

                var education = _mapper.Map<EmployeeEducation>(dto);
                education.EmployeeId = employeeId;
                education.CreatedAt = DateTime.Now;
                education.IsActive = true;

                await _unitOfWork.EmployeeEducations.AddAsync(education);
                await _unitOfWork.SaveChangesAsync();

                var educationDTO = _mapper.Map<EmployeeEducationDTO>(education);
                return ApiResponse<EmployeeEducationDTO>.SuccessResponse(educationDTO, "Education added successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeEducationDTO>.ErrorResponse("Error adding education", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteEducationAsync(int educationId)
        {
            try
            {
                var education = await _unitOfWork.EmployeeEducations.GetByIdAsync(educationId);
                if (education == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Education not found");
                }

                await _unitOfWork.EmployeeEducations.DeleteAsync(education);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Education deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse("Error deleting education", new List<string> { ex.Message });
            }
        }

        // Experience Management
        public async Task<ApiResponse<EmployeeExperienceDTO>> AddExperienceAsync(int employeeId, CreateEmployeeExperienceDTO dto)
        {
            try
            {
                var employeeExists = await _unitOfWork.Employees.AnyAsync(e => e.Id == employeeId && e.IsActive);
                if (!employeeExists)
                {
                    return ApiResponse<EmployeeExperienceDTO>.ErrorResponse("Employee not found");
                }

                var experience = _mapper.Map<EmployeeExperience>(dto);
                experience.EmployeeId = employeeId;
                experience.CreatedAt = DateTime.Now;
                experience.IsActive = true;

                await _unitOfWork.EmployeeExperiences.AddAsync(experience);
                await _unitOfWork.SaveChangesAsync();

                var experienceDTO = _mapper.Map<EmployeeExperienceDTO>(experience);
                return ApiResponse<EmployeeExperienceDTO>.SuccessResponse(experienceDTO, "Experience added successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeExperienceDTO>.ErrorResponse("Error adding experience", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteExperienceAsync(int experienceId)
        {
            try
            {
                var experience = await _unitOfWork.EmployeeExperiences.GetByIdAsync(experienceId);
                if (experience == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Experience not found");
                }

                await _unitOfWork.EmployeeExperiences.DeleteAsync(experience);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Experience deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse("Error deleting experience", new List<string> { ex.Message });
            }
        }

        // Bank Account Management
        public async Task<ApiResponse<EmployeeBankAccountDTO>> AddBankAccountAsync(int employeeId, CreateEmployeeBankAccountDTO dto)
        {
            try
            {
                var employeeExists = await _unitOfWork.Employees.AnyAsync(e => e.Id == employeeId && e.IsActive);
                if (!employeeExists)
                {
                    return ApiResponse<EmployeeBankAccountDTO>.ErrorResponse("Employee not found");
                }

                var bankAccount = _mapper.Map<EmployeeBankAccount>(dto);
                bankAccount.EmployeeId = employeeId;
                bankAccount.CreatedAt = DateTime.Now;
                bankAccount.IsActive = true;

                // If this is primary, remove primary from others
                if (dto.IsPrimary)
                {
                    var otherAccounts = await _unitOfWork.EmployeeBankAccounts.FindAsync(
                        a => a.EmployeeId == employeeId && a.IsActive);

                    foreach (var acc in otherAccounts)
                    {
                        acc.IsPrimary = false;
                        await _unitOfWork.EmployeeBankAccounts.UpdateAsync(acc);
                    }
                }

                await _unitOfWork.EmployeeBankAccounts.AddAsync(bankAccount);
                await _unitOfWork.SaveChangesAsync();

                var bankAccountDTO = _mapper.Map<EmployeeBankAccountDTO>(bankAccount);
                return ApiResponse<EmployeeBankAccountDTO>.SuccessResponse(bankAccountDTO, "Bank account added successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeBankAccountDTO>.ErrorResponse("Error adding bank account", new List<string> { ex.Message });
            }
        }

        public async Task<ApiResponse<bool>> DeleteBankAccountAsync(int bankAccountId)
        {
            try
            {
                var bankAccount = await _unitOfWork.EmployeeBankAccounts.GetByIdAsync(bankAccountId);
                if (bankAccount == null)
                {
                    return ApiResponse<bool>.ErrorResponse("Bank account not found");
                }

                await _unitOfWork.EmployeeBankAccounts.DeleteAsync(bankAccount);
                await _unitOfWork.SaveChangesAsync();

                return ApiResponse<bool>.SuccessResponse(true, "Bank account deleted successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.ErrorResponse("Error deleting bank account", new List<string> { ex.Message });
            }
        }
    }
}