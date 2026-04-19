using HRMS.Data;
using HRMS.Repositories.Interfaces;
using HRMS.Models.Organization;
using HRMS.Models.EmployeeDetails;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRMS.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRMDbContext _context;
        private IDbContextTransaction _transaction;

        // Organization
        private IRepository<Company> _companies;
        private IRepository<Department> _departments;
        private IRepository<Location> _locations;
        private IRepository<WorkStation> _workStations;
        private IRepository<Designation> _designations;
        private IRepository<Grade> _grades;

        // Employee
        private IRepository<Employee> _employees;
        private IRepository<EmployeeAddress> _employeeAddresses;
        private IRepository<EmployeeEducation> _employeeEducations;
        private IRepository<EmployeeExperience> _employeeExperiences;
        private IRepository<EmployeeReference> _employeeReferences;
        private IRepository<EmployeeDocument> _employeeDocuments;
        private IRepository<EmployeeBackgroundCheck> _employeeBackgroundChecks;
        private IRepository<Bank> _banks;
        private IRepository<BankBranch> _bankBranches;
        private IRepository<EmployeeBankAccount> _employeeBankAccounts;

        // Time & Attendance
        private IRepository<Models.TimeAttendance.LeaveType> _leaveTypes;
        private IRepository<Models.TimeAttendance.LeaveYear> _leaveYears;
        private IRepository<Models.TimeAttendance.LeaveBalance> _leaveBalances;
        private IRepository<Models.TimeAttendance.LeaveApplication> _leaveApplications;
        private IRepository<Models.TimeAttendance.Holiday> _holidays;
        private IRepository<Models.TimeAttendance.Shift> _shifts;
        private IRepository<Models.TimeAttendance.ShiftAssignment> _shiftAssignments;
        private IRepository<Models.TimeAttendance.Attendance> _attendances;
        private IRepository<Models.TimeAttendance.ManualAttendance> _manualAttendances;
        private IRepository<Models.TimeAttendance.AttendanceProcess> _attendanceProcesses;

        // Payroll
        private IRepository<Models.Payroll.BenefitType> _benefitTypes;
        private IRepository<Models.Payroll.DeductionType> _deductionTypes;
        private IRepository<Models.Payroll.EmployeeBenefit> _employeeBenefits;
        private IRepository<Models.Payroll.EmployeeDeduction> _employeeDeductions;
        private IRepository<Models.Payroll.LoanType> _loanTypes;
        private IRepository<Models.Payroll.Loan> _loans;
        private IRepository<Models.Payroll.LoanInstallment> _loanInstallments;
        private IRepository<Models.Payroll.LoanSettlement> _loanSettlements;
        private IRepository<Models.Payroll.SalaryMonth> _salaryMonths;
        private IRepository<Models.Payroll.SalaryProcess> _salaryProcesses;
        private IRepository<Models.Payroll.SalaryUpdate> _salaryUpdates;
        private IRepository<Models.Payroll.BonusType> _bonusTypes;
        private IRepository<Models.Payroll.BonusProcess> _bonusProcesses;
        private IRepository<Models.Payroll.EmployeeBonus> _employeeBonuses;

        public UnitOfWork(HRMDbContext context)
        {
            _context = context;
        }

        // Organization Properties
        public IRepository<Company> Companies =>
            _companies ??= new Repository<Company>(_context);

        public IRepository<Department> Departments =>
            _departments ??= new Repository<Department>(_context);

        public IRepository<Location> Locations =>
            _locations ??= new Repository<Location>(_context);

        public IRepository<WorkStation> WorkStations =>
            _workStations ??= new Repository<WorkStation>(_context);

        public IRepository<Designation> Designations =>
            _designations ??= new Repository<Designation>(_context);

        public IRepository<Grade> Grades =>
            _grades ??= new Repository<Grade>(_context);

        // Employee Properties
        public IRepository<Employee> Employees =>
            _employees ??= new Repository<Employee>(_context);

        public IRepository<EmployeeAddress> EmployeeAddresses =>
            _employeeAddresses ??= new Repository<EmployeeAddress>(_context);

        public IRepository<EmployeeEducation> EmployeeEducations =>
            _employeeEducations ??= new Repository<EmployeeEducation>(_context);

        public IRepository<EmployeeExperience> EmployeeExperiences =>
            _employeeExperiences ??= new Repository<EmployeeExperience>(_context);

        public IRepository<EmployeeReference> EmployeeReferences =>
            _employeeReferences ??= new Repository<EmployeeReference>(_context);

        public IRepository<EmployeeDocument> EmployeeDocuments =>
            _employeeDocuments ??= new Repository<EmployeeDocument>(_context);

        public IRepository<EmployeeBackgroundCheck> EmployeeBackgroundChecks =>
            _employeeBackgroundChecks ??= new Repository<EmployeeBackgroundCheck>(_context);

        public IRepository<Bank> Banks =>
            _banks ??= new Repository<Bank>(_context);

        public IRepository<BankBranch> BankBranches =>
            _bankBranches ??= new Repository<BankBranch>(_context);

        public IRepository<EmployeeBankAccount> EmployeeBankAccounts =>
            _employeeBankAccounts ??= new Repository<EmployeeBankAccount>(_context);

        // Time & Attendance Properties
        public IRepository<Models.TimeAttendance.LeaveType> LeaveTypes =>
            _leaveTypes ??= new Repository<Models.TimeAttendance.LeaveType>(_context);
        public IRepository<Models.TimeAttendance.LeaveYear> LeaveYears =>
            _leaveYears ??= new Repository<Models.TimeAttendance.LeaveYear>(_context);
        public IRepository<Models.TimeAttendance.LeaveBalance> LeaveBalances =>
            _leaveBalances ??= new Repository<Models.TimeAttendance.LeaveBalance>(_context);
        public IRepository<Models.TimeAttendance.LeaveApplication> LeaveApplications =>
            _leaveApplications ??= new Repository<Models.TimeAttendance.LeaveApplication>(_context);
        public IRepository<Models.TimeAttendance.Holiday> Holidays =>
            _holidays ??= new Repository<Models.TimeAttendance.Holiday>(_context);
        public IRepository<Models.TimeAttendance.Shift> Shifts =>
            _shifts ??= new Repository<Models.TimeAttendance.Shift>(_context);
        public IRepository<Models.TimeAttendance.ShiftAssignment> ShiftAssignments =>
            _shiftAssignments ??= new Repository<Models.TimeAttendance.ShiftAssignment>(_context);
        public IRepository<Models.TimeAttendance.Attendance> Attendances =>
            _attendances ??= new Repository<Models.TimeAttendance.Attendance>(_context);
        public IRepository<Models.TimeAttendance.ManualAttendance> ManualAttendances =>
            _manualAttendances ??= new Repository<Models.TimeAttendance.ManualAttendance>(_context);
        public IRepository<Models.TimeAttendance.AttendanceProcess> AttendanceProcesses =>
            _attendanceProcesses ??= new Repository<Models.TimeAttendance.AttendanceProcess>(_context);

        // Payroll Properties
        public IRepository<Models.Payroll.BenefitType> BenefitTypes =>
            _benefitTypes ??= new Repository<Models.Payroll.BenefitType>(_context);
        public IRepository<Models.Payroll.DeductionType> DeductionTypes =>
            _deductionTypes ??= new Repository<Models.Payroll.DeductionType>(_context);
        public IRepository<Models.Payroll.EmployeeBenefit> EmployeeBenefits =>
            _employeeBenefits ??= new Repository<Models.Payroll.EmployeeBenefit>(_context);
        public IRepository<Models.Payroll.EmployeeDeduction> EmployeeDeductions =>
            _employeeDeductions ??= new Repository<Models.Payroll.EmployeeDeduction>(_context);
        public IRepository<Models.Payroll.LoanType> LoanTypes =>
            _loanTypes ??= new Repository<Models.Payroll.LoanType>(_context);
        public IRepository<Models.Payroll.Loan> Loans =>
            _loans ??= new Repository<Models.Payroll.Loan>(_context);
        public IRepository<Models.Payroll.LoanInstallment> LoanInstallments =>
            _loanInstallments ??= new Repository<Models.Payroll.LoanInstallment>(_context);
        public IRepository<Models.Payroll.LoanSettlement> LoanSettlements =>
            _loanSettlements ??= new Repository<Models.Payroll.LoanSettlement>(_context);
        public IRepository<Models.Payroll.SalaryMonth> SalaryMonths =>
            _salaryMonths ??= new Repository<Models.Payroll.SalaryMonth>(_context);
        public IRepository<Models.Payroll.SalaryProcess> SalaryProcesses =>
            _salaryProcesses ??= new Repository<Models.Payroll.SalaryProcess>(_context);
        public IRepository<Models.Payroll.SalaryUpdate> SalaryUpdates =>
            _salaryUpdates ??= new Repository<Models.Payroll.SalaryUpdate>(_context);
        public IRepository<Models.Payroll.BonusType> BonusTypes =>
            _bonusTypes ??= new Repository<Models.Payroll.BonusType>(_context);
        public IRepository<Models.Payroll.BonusProcess> BonusProcesses =>
            _bonusProcesses ??= new Repository<Models.Payroll.BonusProcess>(_context);
        public IRepository<Models.Payroll.EmployeeBonus> EmployeeBonuses =>
            _employeeBonuses ??= new Repository<Models.Payroll.EmployeeBonus>(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}