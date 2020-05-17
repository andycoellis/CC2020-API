using System;
using System.Collections.Generic;
using System.Linq;
using CC2020_API.Data.Repositories.IRepositories;
using CC2020_API.Data;
using CC2020_API.Models;

namespace CC2020_API.Data.Repositories
{
    public class TimesheetRepository : Repository<Timesheet>, ITimesheetRepository
    {
        public TimesheetRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext TimesheetContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
