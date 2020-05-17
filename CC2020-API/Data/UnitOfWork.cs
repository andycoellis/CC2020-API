using System;
using CC2020_API.Data.Repositories;
using CC2020_API.Data.Repositories.IRepositories;

namespace CC2020_API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
            Employees = new EmployeeRepository(_context);
            PayAgreements = new PayAgreementRepository(_context);
            Timesheets = new TimesheetRepository(_context);
            Payslips = new PayslipRepository(_context);
        }

        public ICompanyRepository Companies { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IPayAgreementRepository PayAgreements { get; private set; }
        public ITimesheetRepository Timesheets { get; private set; }
        public IPayslipRepository Payslips { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
