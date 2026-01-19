using System.Linq.Expressions;
using HRMS.Models.Organization;
using HRMS.Models.EmployeeDetails;

namespace HRMS.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // Queries
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);

        // Paged Queries
        Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes);

        // Commands
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    }

    public interface IUnitOfWork : IDisposable
    {
        // Organization
        IRepository<Company> Companies { get; }
        IRepository<Department> Departments { get; }
        IRepository<Location> Locations { get; }
        IRepository<WorkStation> WorkStations { get; }
        IRepository<Designation> Designations { get; }
        IRepository<Grade> Grades { get; }

        // Employee
        IRepository<Employee> Employees { get; }
        IRepository<EmployeeAddress> EmployeeAddresses { get; }
        IRepository<EmployeeEducation> EmployeeEducations { get; }
        IRepository<EmployeeExperience> EmployeeExperiences { get; }
        IRepository<EmployeeReference> EmployeeReferences { get; }
        IRepository<EmployeeDocument> EmployeeDocuments { get; }
        IRepository<EmployeeBackgroundCheck> EmployeeBackgroundChecks { get; }
        IRepository<Bank> Banks { get; }
        IRepository<BankBranch> BankBranches { get; }
        IRepository<EmployeeBankAccount> EmployeeBankAccounts { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}