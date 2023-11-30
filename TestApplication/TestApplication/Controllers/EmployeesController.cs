using Microsoft.AspNetCore.Mvc;
using TestApplication.Services;
using TestApplication.ViewModels;

namespace TestApplication.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var emp = await _employeeService.GetEmployees();

            return View(emp);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emp = await _employeeService.GetEmployee(id);

            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName")] AddEmployeeViewModel model)
        {
            // We should do some error here
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var id = await _employeeService.AddEmployee(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var s = await _employeeService.GetEmployee(id);

            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,FirstName,LastName")] UpdateEmployeeViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var id = await _employeeService.UpdateEmployee(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var st = await _employeeService.GetEmployee(id);

            return View(st);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);

            return RedirectToAction(nameof(Index));
        }




    }
}
