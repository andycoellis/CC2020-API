using System;
using System.Collections.Generic;
using CC2020_API.Models;

namespace CC2020_API.Data.Repositories.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<PayAgreement> GetEmployeePayAgreements(string id);
    }
}
