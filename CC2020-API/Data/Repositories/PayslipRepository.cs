using System;
using CC2020_API.Data.Repositories.IRepositories;
using CC2020_API.Models;

namespace CC2020_API.Data.Repositories
{
    public class PayslipRepository : Repository<Payslip>, IPayslipRepository
    {
        public PayslipRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
