using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC2020_API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using CC2020_API.Models;

namespace CC2020_API.Controllers
{
    [Route("api/[controller]")]
    public class BusinessController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger _logger;


        public BusinessController(ApplicationDbContext context, ILogger<Company> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        [HttpGet]
        [Route("GetPayslips/{abn}")]
        public ActionResult<IEnumerable<Payslip>> GetPays(long abn)
        {
            try
            {
                return Ok(unitOfWork.Payslips.Find(x => x.CompanyABN == abn));
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetPayslips/{abn}/{empId}")]
        public ActionResult<IEnumerable<Payslip>> GetPays(long abn, string empId)
        {
            try
            {
                return Ok(unitOfWork.Payslips
                    .Find(x => x.CompanyABN == abn)
                    .Where(x => x.EmployeeID == empId));
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAgreements/{abn}")]
        public ActionResult<IEnumerable<PayAgreement>> GetAgreements(long abn)
        {
            try
            {
                return Ok(unitOfWork.PayAgreements.Find(x => x.CompanyABN == abn));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetAgreements/{abn}/{empId}")]
        public ActionResult<IEnumerable<PayAgreement>> GetPayAgreements(long abn, string empId)
        {
            try
            {
                return Ok(unitOfWork.PayAgreements
                    .Find(x => x.CompanyABN == abn)
                    .Where(x => x.EmployeeID == empId));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("AddPayAgreement/{abn}/{empId}/{payRate}")]
        public ActionResult Post(long abn, string empID, int payRate)
        {
            try
            {
                var check_emp = unitOfWork.Employees.SingleOrDefault(x => x.Id == empID);
                var check_cmp = unitOfWork.Companies.SingleOrDefault(x => x.ABN == abn);

                if(check_emp == null || check_cmp == null)
                {
                    return BadRequest("Employee or Company does not exist in system");
                }
                var agreement = new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    EmployeeID = empID,
                    CompanyABN = abn,
                    PayRate = payRate,
                    SaturdayRate = 1.2,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.9                    
                };

                unitOfWork.PayAgreements.Add(agreement);
                var response = unitOfWork.Complete();

                if(response > 0)
                {
                    return Ok();
                }

                return BadRequest("Agreement could not be saved");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }
                    
        [HttpPost]
        [Route("UpdateAgreement/{abn}/{empId}/{payRate}")]
        public ActionResult Put(long abn, string empId, int payRate)
        {
            try
            {
                var stored_agreement = unitOfWork.PayAgreements
                    .SingleOrDefault(x => x.CompanyABN == abn && x.EmployeeID  == empId);

                stored_agreement.PayRate = payRate;

                var response = unitOfWork.Complete();

                if(response > 0)
                {
                    return Ok();
                }

                return BadRequest("Could not update pay agreement");
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return BadRequest();
        }

    }
}
