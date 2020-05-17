using System;
using System.Linq;
using System.Security.Cryptography;
using CC2020_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CC2020_API.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {


            using var dummy = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (dummy.Companies.Any())
                return;

            var hasher = new PasswordHasher<Employee>();

            var user1 = new Employee
            {
                Id = "1234",
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Ryan",
                UserName = "Ryan",
                NormalizedUserName = "RYAN@GOOGLE.COM",
                Email = "ryan@google.com",
                NormalizedEmail = "RYAN@GOOGLE.COM",
                TFN = "123456789",
                Address = "30 View Place",
                City = "Carlton",
                State = "QLD",
                PostCode = "3053",
                EmailConfirmed = true
            };
            user1.PasswordHash = hasher.HashPassword(user1, "Testing88!");

            var user2 = new Employee
            {
                Id = "1111",
                Name = "Alex Ng",
                UserName = "Alex Ng",
                NormalizedUserName = "ALEX@GOOGLE.COM",
                Email = "alex@google.com",
                NormalizedEmail = "ALEX@GOOGLE.COM",
                TFN = "987654321",
                Address = "40 Foo Street",
                City = "Melbourne",
                State = "VIC",
                PostCode = "3000",
                EmailConfirmed = true
            };
            user2.PasswordHash = hasher.HashPassword(user2, "Testing88!");
            user2.SecurityStamp = Guid.NewGuid().ToString();

            var user3 = new Employee
            {
                Id = "4444",
                Name = "Sarah Harry",
                UserName = "sarah@google.com",
                NormalizedUserName = "SARAH@GOOGLE.COM",
                Email = "sarah@google.com",
                NormalizedEmail = "SARAH@GOOGLE.COM",
                TFN = "473829175",
                Address = "13 Something",
                City = "Camberwell",
                State = "VIC",
                PostCode = "3052",
                EmailConfirmed = true
            };
            user3.PasswordHash = hasher.HashPassword(user3, "Testing88!");
            user3.SecurityStamp = Guid.NewGuid().ToString();

            var user4 = new Employee
            {
                Id = "3333",
                Name = "Lois Straus Claude",
                UserName = "PowerMan265",
                NormalizedUserName = "LOIS@GOOGLE.COM",
                Email = "lois@google.com",
                NormalizedEmail = "LOIS@GOOGLE.COM",
                TFN = "123456789",
                Address = "30 Summer Place",
                City = "Holding",
                State = "VIC",
                PostCode = "3012",
                EmailConfirmed = true
            };
            user4.PasswordHash = hasher.HashPassword(user4, "Testing88!");
            user4.SecurityStamp = Guid.NewGuid().ToString();

            dummy.Employees.AddRange(user1, user2, user3, user4);


            dummy.Companies.AddRange(
                new Company
                {
                    ABN = 12903767844,
                    CompanyName = "Square and Compass",
                    Address = "222 Clarendon Street, East Melbourne 3022",
                    Email = "andycoellis@gmail.com"
                }
                ,
                new Company
                {
                    ABN = 40907025013,
                    CompanyName = "Barry",
                    Address = "85 High Street, Northcote 3070",
                    Email = "andycoellis@gmail.com"
                },
                new Company
                {
                    ABN = 70102471414,
                    CompanyName = "Fifty Acres",
                    Address = "38 Bridge Road, Richmond 3012",
                    Email = "andycoellis@gmail.com"
                });


            dummy.PayAgreements.AddRange(
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 28,
                    SaturdayRate = 1.5,
                    SundayRate = 1.5,
                    PublicHolidayRate = 2,
                    EmployeeID = "4444",
                    CompanyABN = 12903767844
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 25,
                    SaturdayRate = 1.3,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.9,
                    EmployeeID = "4444",
                    CompanyABN = 70102471414
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 23,
                    SaturdayRate = 1.3,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.5,
                    EmployeeID = "3333",
                    CompanyABN = 70102471414
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 22,
                    SaturdayRate = 1.3,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.5,
                    EmployeeID = "1111",
                    CompanyABN = 70102471414
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 24,
                    SaturdayRate = 1,
                    SundayRate = 1,
                    PublicHolidayRate = 1.2,
                    EmployeeID = "4444",
                    CompanyABN = 40907025013
                });

            dummy.Timesheets.AddRange(
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 12),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "4444",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 13),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "4444",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 14),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "4444",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 15),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = "4444",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 12),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "1111",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 13),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "1111",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 16),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "1111",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 13),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = "1111",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 13),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "3333",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 14),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "3333",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 16),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "3333",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 18),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = "3333",
                 CompanyABN = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 13),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "4444",
                 CompanyABN = 40907025013
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 14),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "4444",
                 CompanyABN = 40907025013
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 16),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = "4444",
                 CompanyABN = 40907025013
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 5, 17),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = "4444",
                 CompanyABN = 40907025013
             });

            dummy.AddRange(
                new Payslip
                {
                    WeekBegininning = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek),
                    GrossPay = 900,
                    BaseHours = 19,
                    SatHours = 5,
                    Tax = 110,
                    PayYTD = 300,
                    EmployeeID = "3333",
                    CompanyABN = 70102471414
                },
                new Payslip
                {
                    WeekBegininning = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek),
                    GrossPay = 700,
                    BaseHours = 19,
                    SatHours = 5,
                    Tax = 110,
                    PayYTD = 300,
                    EmployeeID = "4444",
                    CompanyABN = 40907025013
                });


            dummy.SaveChanges();
        }
    }
}
