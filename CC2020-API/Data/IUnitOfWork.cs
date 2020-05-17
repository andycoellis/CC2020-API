using System;
using CC2020_API.Data.Repositories.IRepositories;

namespace CC2020_API.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IEmployeeRepository Employees { get; }
        IPayAgreementRepository PayAgreements { get; }
        ITimesheetRepository Timesheets { get; }
        IPayslipRepository Payslips { get; }
        int Complete();
    }
}
