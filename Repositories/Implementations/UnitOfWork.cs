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