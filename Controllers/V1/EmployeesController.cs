using HRMS.DTOs.EmployeeDetails;
using HRMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static HRMS.DTOs.EmployeeDetails.EmployeeDTOs;

namespace HRMS.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _employeeService.GetAllAsync();

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _employeeService.GetByIdAsync(id);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("code/{employeeCode}")]
        public async Task<IActionResult> GetByEmployeeCode(string employeeCode)
        {
            var result = await _employeeService.GetByEmployeeCodeAsync(employeeCode);

            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchTerm = null,
            [FromQuery] int? departmentId = null)
        {
            var result = await _employeeService.GetPagedAsync(pageNumber, pageSize, searchTerm, departmentId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int createdBy = 1;

            var result = await _employeeService.CreateAsync(dto, createdBy);

            if (!result.Success)
                return BadRequest(result);

            return CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int updatedBy = 1;

            var result = await _employeeService.UpdateAsync(id, dto, updatedBy);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // Address Management
        [HttpPost("{employeeId}/addresses")]
        public async Task<IActionResult> AddAddress(int employeeId, [FromBody] CreateEmployeeAddressDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _employeeService.AddAddressAsync(employeeId, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("addresses/{addressId}")]
        public async Task<IActionResult> DeleteAddress(int addressId)
        {
            var result = await _employeeService.DeleteAddressAsync(addressId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // Education Management
        [HttpPost("{employeeId}/educations")]
        public async Task<IActionResult> AddEducation(int employeeId, [FromBody] CreateEmployeeEducationDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _employeeService.AddEducationAsync(employeeId, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("educations/{educationId}")]
        public async Task<IActionResult> DeleteEducation(int educationId)
        {
            var result = await _employeeService.DeleteEducationAsync(educationId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // Experience Management
        [HttpPost("{employeeId}/experiences")]
        public async Task<IActionResult> AddExperience(int employeeId, [FromBody] CreateEmployeeExperienceDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _employeeService.AddExperienceAsync(employeeId, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("experiences/{experienceId}")]
        public async Task<IActionResult> DeleteExperience(int experienceId)
        {
            var result = await _employeeService.DeleteExperienceAsync(experienceId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        // Bank Account Management
        [HttpPost("{employeeId}/bank-accounts")]
        public async Task<IActionResult> AddBankAccount(int employeeId, [FromBody] CreateEmployeeBankAccountDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _employeeService.AddBankAccountAsync(employeeId, dto);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("bank-accounts/{bankAccountId}")]
        public async Task<IActionResult> DeleteBankAccount(int bankAccountId)
        {
            var result = await _employeeService.DeleteBankAccountAsync(bankAccountId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}