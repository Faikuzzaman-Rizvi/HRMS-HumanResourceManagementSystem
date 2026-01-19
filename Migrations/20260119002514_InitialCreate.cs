using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "WorkStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "WorkStations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "WorkStations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Locations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Grades",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeReferences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeReferences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeReferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeReferences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeReferences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeLifeCycleUploads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeLifeCycleUploads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeLifeCycleUploads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeLifeCycleUploads",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeLifeCycleUploads",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeLifeCycles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeLifeCycles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeLifeCycles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeExperiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeExperiences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeExperiences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeEducations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeEducations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeEducations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeEducations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeEducations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeDocuments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeCashPayments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeCashPayments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeCashPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeCashPayments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeCashPayments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeBankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeBankAccounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeBankAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeBackgroundChecks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeBackgroundChecks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeBackgroundChecks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeBackgroundChecks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeBackgroundChecks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "EmployeeAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "EmployeeAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EmployeeAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "EmployeeAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "EmployeeAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Designations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Designations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Designations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Companies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ClientSites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ClientSites",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ClientSites",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ClientRequirements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ClientRequirements",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ClientRequirements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ClientRemarks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ClientRemarks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ClientRemarks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "ClientRemarks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Banks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Banks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Banks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Banks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BankBranches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "BankBranches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "BankBranches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "BankBranches",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WorkStations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "WorkStations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "WorkStations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeReferences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeReferences");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeReferences");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeReferences");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeReferences");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeLifeCycleUploads");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeLifeCycleUploads");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeLifeCycleUploads");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeLifeCycleUploads");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeLifeCycleUploads");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeLifeCycles");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeLifeCycles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeLifeCycles");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeExperiences");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeExperiences");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeExperiences");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeExperiences");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeEducations");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeCashPayments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeCashPayments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeCashPayments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeCashPayments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeCashPayments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeBankAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeBankAccounts");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeBankAccounts");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeBackgroundChecks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeBackgroundChecks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeBackgroundChecks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeBackgroundChecks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeBackgroundChecks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "EmployeeAddresses");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Designations");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClientSites");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientSites");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClientSites");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ClientRequirements");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientRequirements");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClientRequirements");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ClientRemarks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ClientRemarks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ClientRemarks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "ClientRemarks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BankBranches");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BankBranches");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BankBranches");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BankBranches");
        }
    }
}
