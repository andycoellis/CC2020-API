using System;
using CC2020_API.Data.Repositories.IRepositories;
using CC2020_API.Models;

namespace CC2020_API.Data.Repositories
{
    public class PayAgreementRepository : Repository<PayAgreement>, IPayAgreementRepository
    {
        public PayAgreementRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
