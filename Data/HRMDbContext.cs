using HRMS.Models.Authentication;
using HRMS.Models.EmployeeDetails;
using HRMS.Models.Organization;
using HRMS.Models.Payroll;
using HRMS.Models.Recruitment;
using HRMS.Models.TimeAttendance;
using HRMS.Models.Training;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{
    public class HRMDbContext : DbContext
    {
        public HRMDbContext(DbContextOptions<HRMDbContext> options) : base(options)
        {
        }

        // Phase 1: Auth
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        // Phase 2: Organization Structure
        public DbSet<Company> Companies { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<WorkStation> WorkStations { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientSite> ClientSites { get; set; }
        public DbSet<ClientRequirement> ClientRequirements { get; set; }
        public DbSet<ClientRemark> ClientRemarks { get; set; }

        // Phase 3: Employee Management
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeExperience> EmployeeExperiences { get; set; }
        public DbSet<EmployeeReference> EmployeeReferences { get; set; }
        public DbSet<EmployeeBackgroundCheck> EmployeeBackgroundChecks { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<EmployeeBankAccount> EmployeeBankAccounts { get; set; }
        public DbSet<EmployeeCashPayment> EmployeeCashPayments { get; set; }
        public DbSet<EmployeeLifeCycle> EmployeeLifeCycles { get; set; }
        public DbSet<EmployeeLifeCycleUpload> EmployeeLifeCycleUploads { get; set; }
        public DbSet<CVPool> CVPools { get; set; }

        // Phase 4: Recruitment
        public DbSet<JobRequisition> JobRequisitions { get; set; }
        public DbSet<RequisitionApproval> RequisitionApprovals { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<InterviewPanel> InterviewPanels { get; set; }
        public DbSet<InterviewEvaluation> InterviewEvaluations { get; set; }
        public DbSet<CandidateRelocation> CandidateRelocations { get; set; }

        // Phase 5: Training
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainingType> TrainingTypes { get; set; }
        public DbSet<TrainingCalendar> TrainingCalendars { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingAssignment> TrainingAssignments { get; set; }
        public DbSet<TrainingAttendance> TrainingAttendances { get; set; }
        public DbSet<TrainingEvaluation> TrainingEvaluations { get; set; }

        // Phase 6: Time & Attendance
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveYear> LeaveYears { get; set; }
        public DbSet<LeaveRule> LeaveRules { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<LeaveApplication> LeaveApplications { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<WorkingDay> WorkingDays { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftAssignment> ShiftAssignments { get; set; }
        public DbSet<AttendanceProcess> AttendanceProcesses { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<ManualAttendance> ManualAttendances { get; set; }

        // Phase 7: Payroll
        public DbSet<BenefitType> BenefitTypes { get; set; }
        public DbSet<BenefitParameterization> BenefitParameterizations { get; set; }
        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }
        public DbSet<DeductionType> DeductionTypes { get; set; }
        public DbSet<DeductionParameterization> DeductionParameterizations { get; set; }
        public DbSet<EmployeeDeduction> EmployeeDeductions { get; set; }
        public DbSet<TaxSlab> TaxSlabs { get; set; }
        public DbSet<EmployeeTaxInfo> EmployeeTaxInfos { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanInstallment> LoanInstallments { get; set; }
        public DbSet<LoanSettlement> LoanSettlements { get; set; }
        public DbSet<SalaryMonth> SalaryMonths { get; set; }
        public DbSet<SalaryProcess> SalaryProcesses { get; set; }
        public DbSet<SalaryBenefitDetail> SalaryBenefitDetails { get; set; }
        public DbSet<SalaryDeductionDetail> SalaryDeductionDetails { get; set; }
        public DbSet<SalaryUpdate> SalaryUpdates { get; set; }
        public DbSet<BonusType> BonusTypes { get; set; }
        public DbSet<BonusProcess> BonusProcesses { get; set; }
        public DbSet<EmployeeBonus> EmployeeBonuses { get; set; }
        public DbSet<BulkUpload> BulkUploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            // PHASE 1: Authentication & Authorization            
            // User - UserRole (One-to-Many with CASCADE)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Role - UserRole (One-to-Many with CASCADE)
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Role - RolePermission (One-to-Many with CASCADE)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Permission - RolePermission (One-to-Many with RESTRICT)
            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany()
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);

            // User - Employee (One-to-One with RESTRICT)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Employee)
                .WithMany()
                .HasForeignKey(u => u.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 1: Organization Structure           
            // Company - Location (One-to-Many with CASCADE)
            modelBuilder.Entity<Location>()
                .HasOne(l => l.Company)
                .WithMany(c => c.Locations)
                .HasForeignKey(l => l.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Company - Department (One-to-Many with CASCADE)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Company)
                .WithMany(c => c.Departments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Location - Department (One-to-Many with RESTRICT)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Location)
                .WithMany(l => l.Departments)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department Self-Reference (Parent-Child with RESTRICT)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.ParentDepartment)
                .WithMany(d => d.SubDepartments)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - Manager (Employee with RESTRICT)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - WorkStation (One-to-Many with CASCADE)
            modelBuilder.Entity<WorkStation>()
                .HasOne(ws => ws.Location)
                .WithMany(l => l.WorkStations)
                .HasForeignKey(ws => ws.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - WorkStation (One-to-Many with RESTRICT)
            modelBuilder.Entity<WorkStation>()
                .HasOne(ws => ws.Department)
                .WithMany(d => d.WorkStations)
                .HasForeignKey(ws => ws.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 1: Client Management            
            // Company - Client (One-to-Many with CASCADE)
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Company)
                .WithMany(co => co.Clients)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Client - ClientSite (One-to-Many with CASCADE)
            modelBuilder.Entity<ClientSite>()
                .HasOne(cs => cs.Client)
                .WithMany(c => c.ClientSites)
                .HasForeignKey(cs => cs.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Client - ClientRequirement (One-to-Many with CASCADE)
            modelBuilder.Entity<ClientRequirement>()
                .HasOne(cr => cr.Client)
                .WithMany(c => c.Requirements)
                .HasForeignKey(cr => cr.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Designation - ClientRequirement (One-to-Many with RESTRICT)
            modelBuilder.Entity<ClientRequirement>()
                .HasOne(cr => cr.Designation)
                .WithMany()
                .HasForeignKey(cr => cr.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Client - ClientRemark (One-to-Many with CASCADE)
            modelBuilder.Entity<ClientRemark>()
                .HasOne(cr => cr.Client)
                .WithMany(c => c.Remarks)
                .HasForeignKey(cr => cr.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            
            // PHASE 2: Employee Core            
            // Company - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Designation - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Designation)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Grade)
                .WithMany(g => g.Employees)
                .HasForeignKey(e => e.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Location)
                .WithMany(l => l.Employees)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // WorkStation - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.WorkStation)
                .WithMany(ws => ws.Employees)
                .HasForeignKey(e => e.WorkStationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee Self-Reference (Reporting Manager with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ReportingManager)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.ReportingManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Client - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            // ClientSite - Employee (One-to-Many with RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ClientSite)
                .WithMany(cs => cs.Employees)
                .HasForeignKey(e => e.ClientSiteId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 2: Employee Details           
            // Employee - EmployeeAddress (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeAddress>()
                .HasOne(ea => ea.Employee)
                .WithMany(e => e.Addresses)
                .HasForeignKey(ea => ea.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeEducation (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeEducation>()
                .HasOne(ee => ee.Employee)
                .WithMany(e => e.Educations)
                .HasForeignKey(ee => ee.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeExperience (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeExperience>()
                .HasOne(ee => ee.Employee)
                .WithMany(e => e.Experiences)
                .HasForeignKey(ee => ee.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeReference (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeReference>()
                .HasOne(er => er.Employee)
                .WithMany(e => e.References)
                .HasForeignKey(er => er.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeBackgroundCheck (One-to-One with CASCADE)
            modelBuilder.Entity<EmployeeBackgroundCheck>()
                .HasOne(ebc => ebc.Employee)
                .WithOne(e => e.BackgroundCheck)
                .HasForeignKey<EmployeeBackgroundCheck>(ebc => ebc.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeDocument (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeDocument>()
                .HasOne(ed => ed.Employee)
                .WithMany(e => e.Documents)
                .HasForeignKey(ed => ed.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            
            // PHASE 2: Bank & Payment         
            // Bank - BankBranch (One-to-Many with CASCADE)
            modelBuilder.Entity<BankBranch>()
                .HasOne(bb => bb.Bank)
                .WithMany(b => b.Branches)
                .HasForeignKey(bb => bb.BankId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeBankAccount (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeBankAccount>()
                .HasOne(eba => eba.Employee)
                .WithMany(e => e.BankAccounts)
                .HasForeignKey(eba => eba.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bank - EmployeeBankAccount (One-to-Many with RESTRICT)
            modelBuilder.Entity<EmployeeBankAccount>()
                .HasOne(eba => eba.Bank)
                .WithMany(b => b.EmployeeAccounts)
                .HasForeignKey(eba => eba.BankId)
                .OnDelete(DeleteBehavior.Restrict);

            // BankBranch - EmployeeBankAccount (One-to-Many with RESTRICT)
            modelBuilder.Entity<EmployeeBankAccount>()
                .HasOne(eba => eba.Branch)
                .WithMany(bb => bb.EmployeeAccounts)
                .HasForeignKey(eba => eba.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EmployeeCashPayment (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeCashPayment>()
                .HasOne(ecp => ecp.Employee)
                .WithMany()
                .HasForeignKey(ecp => ecp.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            
            // PHASE 2: Employee Life Cycle         
            // Employee - EmployeeLifeCycle (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.Employee)
                .WithMany(e => e.LifeCycles)
                .HasForeignKey(elc => elc.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // EmployeeLifeCycle - Previous/New Department (RESTRICT)
            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.PreviousDepartment)
                .WithMany()
                .HasForeignKey(elc => elc.PreviousDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.NewDepartment)
                .WithMany()
                .HasForeignKey(elc => elc.NewDepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmployeeLifeCycle - Previous/New Designation (RESTRICT)
            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.PreviousDesignation)
                .WithMany()
                .HasForeignKey(elc => elc.PreviousDesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.NewDesignation)
                .WithMany()
                .HasForeignKey(elc => elc.NewDesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmployeeLifeCycle - Previous/New Grade (RESTRICT)
            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.PreviousGrade)
                .WithMany()
                .HasForeignKey(elc => elc.PreviousGradeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.NewGrade)
                .WithMany()
                .HasForeignKey(elc => elc.NewGradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmployeeLifeCycle - Previous/New Location (RESTRICT)
            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.PreviousLocation)
                .WithMany()
                .HasForeignKey(elc => elc.PreviousLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EmployeeLifeCycle>()
                .HasOne(elc => elc.NewLocation)
                .WithMany()
                .HasForeignKey(elc => elc.NewLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 2: CV Management
            

            // Designation - CVPool (One-to-Many with RESTRICT)
            modelBuilder.Entity<CVPool>()
                .HasOne(cv => cv.Designation)
                .WithMany()
                .HasForeignKey(cv => cv.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 3: Recruitment Module           
            // Company - JobRequisition (One-to-Many with RESTRICT)
            modelBuilder.Entity<JobRequisition>()
                .HasOne(jr => jr.Company)
                .WithMany()
                .HasForeignKey(jr => jr.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - JobRequisition (One-to-Many with RESTRICT)
            modelBuilder.Entity<JobRequisition>()
                .HasOne(jr => jr.Department)
                .WithMany()
                .HasForeignKey(jr => jr.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Designation - JobRequisition (One-to-Many with RESTRICT)
            modelBuilder.Entity<JobRequisition>()
                .HasOne(jr => jr.Designation)
                .WithMany()
                .HasForeignKey(jr => jr.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade - JobRequisition (One-to-Many with RESTRICT)
            modelBuilder.Entity<JobRequisition>()
                .HasOne(jr => jr.Grade)
                .WithMany()
                .HasForeignKey(jr => jr.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - JobRequisition (One-to-Many with RESTRICT)
            modelBuilder.Entity<JobRequisition>()
                .HasOne(jr => jr.Location)
                .WithMany()
                .HasForeignKey(jr => jr.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - JobRequisition (One-to-Many with RESTRICT)
            modelBuilder.Entity<JobRequisition>()
                .HasOne(jr => jr.RequestedByEmployee)
                .WithMany()
                .HasForeignKey(jr => jr.RequestedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // JobRequisition - RequisitionApproval (One-to-Many with CASCADE)
            modelBuilder.Entity<RequisitionApproval>()
                .HasOne(ra => ra.Requisition)
                .WithMany(jr => jr.Approvals)
                .HasForeignKey(ra => ra.RequisitionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - RequisitionApproval (One-to-Many with RESTRICT)
            modelBuilder.Entity<RequisitionApproval>()
                .HasOne(ra => ra.Approver)
                .WithMany()
                .HasForeignKey(ra => ra.ApproverId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobRequisition - Interview (One-to-Many with CASCADE)
            modelBuilder.Entity<Interview>()
                .HasOne(i => i.Requisition)
                .WithMany(jr => jr.Interviews)
                .HasForeignKey(i => i.RequisitionId)
                .OnDelete(DeleteBehavior.Cascade);

            // CVPool - Interview (One-to-Many with RESTRICT)
            modelBuilder.Entity<Interview>()
                .HasOne(i => i.CVPool)
                .WithMany()
                .HasForeignKey(i => i.CVPoolId)
                .OnDelete(DeleteBehavior.Restrict);

            // Interview - InterviewPanel (One-to-Many with CASCADE)
            modelBuilder.Entity<InterviewPanel>()
                .HasOne(ip => ip.Interview)
                .WithMany(i => i.InterviewPanels)
                .HasForeignKey(ip => ip.InterviewId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - InterviewPanel (One-to-Many with RESTRICT)
            modelBuilder.Entity<InterviewPanel>()
                .HasOne(ip => ip.Interviewer)
                .WithMany()
                .HasForeignKey(ip => ip.InterviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Interview - InterviewEvaluation (One-to-One with CASCADE)
            modelBuilder.Entity<InterviewEvaluation>()
                .HasOne(ie => ie.Interview)
                .WithOne(i => i.Evaluation)
                .HasForeignKey<InterviewEvaluation>(ie => ie.InterviewId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - InterviewEvaluation (One-to-Many with RESTRICT)
            modelBuilder.Entity<InterviewEvaluation>()
                .HasOne(ie => ie.Evaluator)
                .WithMany()
                .HasForeignKey(ie => ie.EvaluatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Interview - CandidateRelocation (One-to-Many with CASCADE)
            modelBuilder.Entity<CandidateRelocation>()
                .HasOne(cr => cr.Interview)
                .WithMany()
                .HasForeignKey(cr => cr.InterviewId)
                .OnDelete(DeleteBehavior.Cascade);

            // Location - CandidateRelocation (One-to-Many with RESTRICT)
            modelBuilder.Entity<CandidateRelocation>()
                .HasOne(cr => cr.FromLocation)
                .WithMany()
                .HasForeignKey(cr => cr.FromLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateRelocation>()
                .HasOne(cr => cr.ToLocation)
                .WithMany()
                .HasForeignKey(cr => cr.ToLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 4: Training Module            
            // Employee - Trainer (One-to-One with RESTRICT)
            modelBuilder.Entity<Trainer>()
                .HasOne(t => t.Employee)
                .WithMany()
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // TrainingType - Training (One-to-Many with RESTRICT)
            modelBuilder.Entity<Training>()
                .HasOne(t => t.TrainingType)
                .WithMany(tt => tt.Trainings)
                .HasForeignKey(t => t.TrainingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Trainer - Training (One-to-Many with RESTRICT)
            modelBuilder.Entity<Training>()
                .HasOne(t => t.Trainer)
                .WithMany(tr => tr.Trainings)
                .HasForeignKey(t => t.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - Training (One-to-Many with RESTRICT)
            modelBuilder.Entity<Training>()
                .HasOne(t => t.Location)
                .WithMany()
                .HasForeignKey(t => t.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // TrainingCalendar - Training (One-to-Many with RESTRICT)
            modelBuilder.Entity<Training>()
                .HasOne(t => t.Calendar)
                .WithMany(tc => tc.Trainings)
                .HasForeignKey(t => t.TrainingCalendarId)
                .OnDelete(DeleteBehavior.Restrict);

            // Training - TrainingAssignment (One-to-Many with CASCADE)
            modelBuilder.Entity<TrainingAssignment>()
                .HasOne(ta => ta.Training)
                .WithMany(t => t.Assignments)
                .HasForeignKey(ta => ta.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - TrainingAssignment (One-to-Many with RESTRICT)
            modelBuilder.Entity<TrainingAssignment>()
                .HasOne(ta => ta.Employee)
                .WithMany()
                .HasForeignKey(ta => ta.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Training - TrainingAttendance (One-to-Many with CASCADE)
            modelBuilder.Entity<TrainingAttendance>()
                .HasOne(ta => ta.Training)
                .WithMany(t => t.Attendances)
                .HasForeignKey(ta => ta.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - TrainingAttendance (One-to-Many with RESTRICT)
            modelBuilder.Entity<TrainingAttendance>()
                .HasOne(ta => ta.Employee)
                .WithMany()
                .HasForeignKey(ta => ta.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Training - TrainingEvaluation (One-to-Many with CASCADE)
            modelBuilder.Entity<TrainingEvaluation>()
                .HasOne(te => te.Training)
                .WithMany(t => t.Evaluations)
                .HasForeignKey(te => te.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - TrainingEvaluation (One-to-Many with RESTRICT)
            modelBuilder.Entity<TrainingEvaluation>()
                .HasOne(te => te.Employee)
                .WithMany()
                .HasForeignKey(te => te.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 5: Time & Attendance Module
            // LeaveType - LeaveRule (One-to-Many with CASCADE)
            modelBuilder.Entity<LeaveRule>()
                .HasOne(lr => lr.LeaveType)
                .WithMany(lt => lt.LeaveRules)
                .HasForeignKey(lr => lr.LeaveTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Designation - LeaveRule (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveRule>()
                .HasOne(lr => lr.Designation)
                .WithMany()
                .HasForeignKey(lr => lr.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade - LeaveRule (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveRule>()
                .HasOne(lr => lr.Grade)
                .WithMany()
                .HasForeignKey(lr => lr.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - LeaveRule (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveRule>()
                .HasOne(lr => lr.Department)
                .WithMany()
                .HasForeignKey(lr => lr.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - LeaveRule (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveRule>()
                .HasOne(lr => lr.Location)
                .WithMany()
                .HasForeignKey(lr => lr.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - LeaveBalance (One-to-Many with CASCADE)
            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.Employee)
                .WithMany()
                .HasForeignKey(lb => lb.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // LeaveType - LeaveBalance (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.LeaveType)
                .WithMany(lt => lt.LeaveBalances)
                .HasForeignKey(lb => lb.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // LeaveYear - LeaveBalance (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveBalance>()
                .HasOne(lb => lb.LeaveYear)
                .WithMany(ly => ly.LeaveBalances)
                .HasForeignKey(lb => lb.LeaveYearId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - LeaveApplication (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveApplication>()
                .HasOne(la => la.Employee)
                .WithMany()
                .HasForeignKey(la => la.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // LeaveType - LeaveApplication (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveApplication>()
                .HasOne(la => la.LeaveType)
                .WithMany()
                .HasForeignKey(la => la.LeaveTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - LeaveApplication Approver (One-to-Many with RESTRICT)
            modelBuilder.Entity<LeaveApplication>()
                .HasOne(la => la.Approver)
                .WithMany()
                .HasForeignKey(la => la.ApprovedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - Holiday (One-to-Many with RESTRICT)
            modelBuilder.Entity<Holiday>()
                .HasOne(h => h.Location)
                .WithMany()
                .HasForeignKey(h => h.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - WorkingDay (One-to-Many with RESTRICT)
            modelBuilder.Entity<WorkingDay>()
                .HasOne(wd => wd.Location)
                .WithMany()
                .HasForeignKey(wd => wd.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - WorkingDay (One-to-Many with RESTRICT)
            modelBuilder.Entity<WorkingDay>()
                .HasOne(wd => wd.Department)
                .WithMany()
                .HasForeignKey(wd => wd.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Shift - ShiftAssignment (One-to-Many with RESTRICT)
            modelBuilder.Entity<ShiftAssignment>()
                .HasOne(sa => sa.Shift)
                .WithMany(s => s.ShiftAssignments)
                .HasForeignKey(sa => sa.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - ShiftAssignment (One-to-Many with CASCADE)
            modelBuilder.Entity<ShiftAssignment>()
                .HasOne(sa => sa.Employee)
                .WithMany()
                .HasForeignKey(sa => sa.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // AttendanceProcess - Attendance (One-to-Many with CASCADE)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Process)
                .WithMany(ap => ap.Attendances)
                .HasForeignKey(a => a.ProcessId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Attendance (One-to-Many with RESTRICT)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany()
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Shift - Attendance (One-to-Many with RESTRICT)
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Shift)
                .WithMany()
                .HasForeignKey(a => a.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - ManualAttendance (One-to-Many with RESTRICT)
            modelBuilder.Entity<ManualAttendance>()
                .HasOne(ma => ma.Employee)
                .WithMany()
                .HasForeignKey(ma => ma.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // PHASE 6: Payroll Module - Salary Structure
            

            // BenefitType - BenefitParameterization (One-to-Many with CASCADE)
            modelBuilder.Entity<BenefitParameterization>()
                .HasOne(bp => bp.BenefitType)
                .WithMany(bt => bt.Parameterizations)
                .HasForeignKey(bp => bp.BenefitTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Designation - BenefitParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<BenefitParameterization>()
                .HasOne(bp => bp.Designation)
                .WithMany()
                .HasForeignKey(bp => bp.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade - BenefitParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<BenefitParameterization>()
                .HasOne(bp => bp.Grade)
                .WithMany()
                .HasForeignKey(bp => bp.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - BenefitParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<BenefitParameterization>()
                .HasOne(bp => bp.Department)
                .WithMany()
                .HasForeignKey(bp => bp.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - BenefitParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<BenefitParameterization>()
                .HasOne(bp => bp.Location)
                .WithMany()
                .HasForeignKey(bp => bp.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EmployeeBenefit (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeBenefit>()
                .HasOne(eb => eb.Employee)
                .WithMany()
                .HasForeignKey(eb => eb.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // BenefitType - EmployeeBenefit (One-to-Many with RESTRICT)
            modelBuilder.Entity<EmployeeBenefit>()
                .HasOne(eb => eb.BenefitType)
                .WithMany(bt => bt.EmployeeBenefits)
                .HasForeignKey(eb => eb.BenefitTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // DeductionType - DeductionParameterization (One-to-Many with CASCADE)
            modelBuilder.Entity<DeductionParameterization>()
                .HasOne(dp => dp.DeductionType)
                .WithMany(dt => dt.Parameterizations)
                .HasForeignKey(dp => dp.DeductionTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Designation - DeductionParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<DeductionParameterization>()
                .HasOne(dp => dp.Designation)
                .WithMany()
                .HasForeignKey(dp => dp.DesignationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Grade - DeductionParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<DeductionParameterization>()
                .HasOne(dp => dp.Grade)
                .WithMany()
                .HasForeignKey(dp => dp.GradeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department - DeductionParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<DeductionParameterization>()
                .HasOne(dp => dp.Department)
                .WithMany()
                .HasForeignKey(dp => dp.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Location - DeductionParameterization (One-to-Many with RESTRICT)
            modelBuilder.Entity<DeductionParameterization>()
                .HasOne(dp => dp.Location)
                .WithMany()
                .HasForeignKey(dp => dp.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EmployeeDeduction (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeDeduction>()
                .HasOne(ed => ed.Employee)
                .WithMany()
                .HasForeignKey(ed => ed.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // DeductionType - EmployeeDeduction (One-to-Many with RESTRICT)
            modelBuilder.Entity<EmployeeDeduction>()
                .HasOne(ed => ed.DeductionType)
                .WithMany(dt => dt.EmployeeDeductions)
                .HasForeignKey(ed => ed.DeductionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - EmployeeTaxInfo (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeTaxInfo>()
                .HasOne(eti => eti.Employee)
                .WithMany()
                .HasForeignKey(eti => eti.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            
            // PHASE 6: Loan Management       
            // LoanType - Loan (One-to-Many with RESTRICT)
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.LoanType)
                .WithMany(lt => lt.Loans)
                .HasForeignKey(l => l.LoanTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Loan (One-to-Many with RESTRICT)
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Employee)
                .WithMany()
                .HasForeignKey(l => l.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - Loan Guarantor (One-to-Many with RESTRICT)
            modelBuilder.Entity<Loan>()
                .HasOne(l => l.Guarantor)
                .WithMany()
                .HasForeignKey(l => l.GuarantorEmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Loan - LoanInstallment (One-to-Many with CASCADE)
            modelBuilder.Entity<LoanInstallment>()
                .HasOne(li => li.Loan)
                .WithMany(l => l.Installments)
                .HasForeignKey(li => li.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Loan - LoanSettlement (One-to-Many with CASCADE)
            modelBuilder.Entity<LoanSettlement>()
                .HasOne(ls => ls.Loan)
                .WithMany()
                .HasForeignKey(ls => ls.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            
            // PHASE 6: Salary Processing
            

            // SalaryMonth - SalaryProcess (One-to-Many with CASCADE)
            modelBuilder.Entity<SalaryProcess>()
                .HasOne(sp => sp.SalaryMonth)
                .WithMany(sm => sm.SalaryProcesses)
                .HasForeignKey(sp => sp.SalaryMonthId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - SalaryProcess (One-to-Many with RESTRICT)
            modelBuilder.Entity<SalaryProcess>()
                .HasOne(sp => sp.Employee)
                .WithMany()
                .HasForeignKey(sp => sp.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmployeeBankAccount - SalaryProcess (One-to-Many with RESTRICT)
            modelBuilder.Entity<SalaryProcess>()
                .HasOne(sp => sp.BankAccount)
                .WithMany()
                .HasForeignKey(sp => sp.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            // SalaryProcess - SalaryBenefitDetail (One-to-Many with CASCADE)
            modelBuilder.Entity<SalaryBenefitDetail>()
                .HasOne(sbd => sbd.SalaryProcess)
                .WithMany(sp => sp.BenefitDetails)
                .HasForeignKey(sbd => sbd.SalaryProcessId)
                .OnDelete(DeleteBehavior.Cascade);

            // BenefitType - SalaryBenefitDetail (One-to-Many with RESTRICT)
            modelBuilder.Entity<SalaryBenefitDetail>()
                .HasOne(sbd => sbd.BenefitType)
                .WithMany()
                .HasForeignKey(sbd => sbd.BenefitTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // SalaryProcess - SalaryDeductionDetail (One-to-Many with CASCADE)
            modelBuilder.Entity<SalaryDeductionDetail>()
                .HasOne(sdd => sdd.SalaryProcess)
                .WithMany(sp => sp.DeductionDetails)
                .HasForeignKey(sdd => sdd.SalaryProcessId)
                .OnDelete(DeleteBehavior.Cascade);

            // DeductionType - SalaryDeductionDetail (One-to-Many with RESTRICT)
            modelBuilder.Entity<SalaryDeductionDetail>()
                .HasOne(sdd => sdd.DeductionType)
                .WithMany()
                .HasForeignKey(sdd => sdd.DeductionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee - SalaryUpdate (One-to-Many with RESTRICT)
            modelBuilder.Entity<SalaryUpdate>()
                .HasOne(su => su.Employee)
                .WithMany()
                .HasForeignKey(su => su.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // BonusType - BonusProcess (One-to-Many with RESTRICT)
            modelBuilder.Entity<BonusProcess>()
                .HasOne(bp => bp.BonusType)
                .WithMany()
                .HasForeignKey(bp => bp.BonusTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // BonusProcess - EmployeeBonus (One-to-Many with CASCADE)
            modelBuilder.Entity<EmployeeBonus>()
                .HasOne(eb => eb.BonusProcess)
                .WithMany(bp => bp.EmployeeBonuses)
                .HasForeignKey(eb => eb.BonusProcessId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee - EmployeeBonus (One-to-Many with RESTRICT)
            modelBuilder.Entity<EmployeeBonus>()
                .HasOne(eb => eb.Employee)
                .WithMany()
                .HasForeignKey(eb => eb.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // EmployeeBankAccount - EmployeeBonus (One-to-Many with RESTRICT)
            modelBuilder.Entity<EmployeeBonus>()
                .HasOne(eb => eb.BankAccount)
                .WithMany()
                .HasForeignKey(eb => eb.BankAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            
            // Composite Keys Configuration
            

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            
            // Indexes for Performance
            

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.EmployeeCode)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.Code)
                .IsUnique();

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Code)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .HasIndex(l => l.Code)
                .IsUnique();

            modelBuilder.Entity<Attendance>()
                .HasIndex(a => new { a.EmployeeId, a.Date });

            modelBuilder.Entity<LeaveApplication>()
                .HasIndex(la => new { la.EmployeeId, la.FromDate, la.ToDate });

            modelBuilder.Entity<SalaryProcess>()
                .HasIndex(sp => new { sp.EmployeeId, sp.Month, sp.Year });
        }
    }
}
