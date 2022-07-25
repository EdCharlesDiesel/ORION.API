using System.Threading.Tasks;
using DDD.ApplicationLayer;
using Microsoft.AspNetCore.Mvc;
using ORION.Domain.IRepositories;
using COG.WEB.Models.Products;
using COG.WEB.Queries;
using COG.WEB.Commands;

namespace COG.WEB.Controllers
{
    public class ProductController: Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IProductsListQuery query)
        {
            var results = await query.GetAllProducts();
            var vm = new ProductsListViewModel { Items = results };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            ProductFullEditViewModel vm,
            [FromServices] ICommandHandler<CreateProductCommand> command)
        {
            if (ModelState.IsValid) { 
                await command.HandleAsync(new CreateProductCommand(vm));
                return RedirectToAction(
                    nameof(ProductController.Index));
            }
            else
                return View("Edit", vm);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(
            int id,
            [FromServices] IProductRepository repo)
        {
            if (id == 0) return RedirectToAction(
                nameof(ProductController.Index));
            var aggregate = await repo.Get(id);
            if (aggregate == null) return RedirectToAction(
                nameof(ProductController.Index));
            var vm = new ProductFullEditViewModel(aggregate);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            ProductFullEditViewModel vm,
            [FromServices] ICommandHandler<UpdateProductCommand> command)
        {
            if (ModelState.IsValid)
            {
                await command.HandleAsync(new UpdateProductCommand(vm));
                return RedirectToAction(
                    nameof(ProductController.Index));
            }
            else
                return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(
            int id,
            [FromServices] ICommandHandler<DeleteProductCommand> command)
        {
            if (id>0)
            {
                await command.HandleAsync(new DeleteProductCommand(id));
                
            }
            return RedirectToAction(
                    nameof(ProductController.Index));
        }
    }
}
