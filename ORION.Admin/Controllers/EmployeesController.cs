using System.Diagnostics;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using ORION.Admin.Commands;
using ORION.Admin.Models;
using ORION.Admin.Models.Employees;
using ORION.Admin.Queries;
using ORION.Domain.IRepositories;

namespace ORION.Admin.Controllers
{
    //ToDo Add commands and event handlers
    public class EmployeesController : Controller
    {
      [HttpGet]
        public async Task<IActionResult> Index([FromServices] IEmployeesListQuery query)
        {
            var results = await query.GetAllEmployees();
            var vm = new EmployeesListViewModel { Items = results };
            return View(vm);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit");
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(
            EmployeeFullEditViewModel vm,
            [FromServices] ICommandHandler<CreateEmployeeCommand> command)
        {
            if (ModelState.IsValid) { 
                await command.HandleAsync(new CreateEmployeeCommand(vm));
                return RedirectToAction(
                    nameof(EmployeesController.Index));
            }
            else
                return View("Edit", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(
            int id,
            [FromServices] IEmployeeRepository repo)
        {
            if (id == 0) return RedirectToAction(
                nameof(EmployeesController.Index));
            var aggregate = await repo.Get(id);
            if (aggregate == null) return RedirectToAction(
                nameof(EmployeesController.Index));
            var vm = new EmployeeFullEditViewModel(aggregate);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(
            EmployeeFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdateEmployeeCommand> command)
        {
            if (ModelState.IsValid)
            {
                await command.HandleAsync(new UpdateEmployeeCommand(vm));
                return RedirectToAction(
                    nameof(EmployeesController.Index));
            }
            else
                return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(
            int id,
            [FromServices] ICommandHandler<DeleteEmployeeCommand> command)
        {
            if (id>0)
            {
                await command.HandleAsync(new DeleteEmployeeCommand(id));
                
            }
            return RedirectToAction(
                    nameof(EmployeesController.Index));
        }
    }
}