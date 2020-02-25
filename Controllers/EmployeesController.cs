using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private object employee;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees                           
        public async Task<IActionResult> Index()
        {
            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(a => a.IdentityUserId == userID).FirstOrDefault();

            var allCustomers = await _context.Customer.Include(c => c.Account).Include(c => c.Address).ToListAsync();
            var filteredCustomers = allCustomers.Where(c => (c.Account.PickUpDay == DateTime.Now.DayOfWeek || c.Account.OneTimePickup == DateTime.Today) && c.Address.Zip == employee.ZipCode).ToList();

            return View(filteredCustomers);
        }

        // GET: Employees/Details/5 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            Employee employee = new Employee();

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userID;

                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Customer.FindAsync(id);
                
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUser,FirstName,LastName,ZipCode")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
        public async Task<IActionResult> FilterCustomers()
        {
            //Get the filter from http request 
            var day = (DayOfWeek)int.Parse(this.HttpContext.Request.Form["dayOfWeekFilter"].ToString());

            var userID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Where(a => a.IdentityUserId == userID).FirstOrDefault();

            var allCustomers = await _context.Customer.Include(c => c.Account).Include(c => c.Address).ToListAsync();
            var filteredCustomers = allCustomers.Where(c => (c.Account.PickUpDay == day || c.Account.OneTimePickup.DayOfWeek == day) && c.Address.Zip == employee.ZipCode).ToList();

            return View(filteredCustomers);
        }

       
        public IActionResult PickupConfirmed(int accountid)
        {
            var account = _context.Account.Where(a => a.Id == accountid).FirstOrDefault();

            account.Balance = account.Balance + 10;
            account.IsPickedUp = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
