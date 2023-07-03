using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList;
using PagedList.Mvc;
using PeginationCrudDemo.Data;
using PeginationCrudDemo.Models;
using PeginationCrudDemo.Models.Domian;

namespace PeginationCrudDemo.Controllers
{
    public class ProductsController : Controller
    {
        private readonly PDemoDbContext pDemoDbContext;



        public ProductsController(PDemoDbContext pDemoDbContext)
        {
            this.pDemoDbContext = pDemoDbContext;
        }

       


        [HttpGet]
        public async Task<IActionResult> Index()
        {


			
			var products = await pDemoDbContext.Products.ToListAsync();
            return View(products);

		}

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel addProductRequest) 
        {
            var product = new Product()

            {
                ProductId = Guid.NewGuid(),
                ProductName = addProductRequest.ProductName,
                CategoryId = Guid.NewGuid(),
                CategoryName = addProductRequest.CategoryName,
            };
            await  pDemoDbContext.Products.AddAsync(product);
            await  pDemoDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        } 


        [HttpGet]
        public async Task<IActionResult> View(Guid Id) 
        {
           var product = await pDemoDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == Id);

            if (product != null)
            {
                var viewModel = new UpdateProductViewModel()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    CategoryId = product.CategoryId,
                    CategoryName = product.CategoryName,
                };
                return await Task.Run(()=>View("View",viewModel));
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateProductViewModel model)
        {
            var product=await pDemoDbContext.Products.FindAsync(model.ProductId);
            if (product != null)
            {
                product.ProductName=model.ProductName;
                product.CategoryId=model.CategoryId;
                product.CategoryName=model.CategoryName;
                await pDemoDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var product = await pDemoDbContext.Products.FindAsync(model.ProductId);
            if (product != null) 
            {
                pDemoDbContext.Products.Remove(product);
                await pDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
   //     public IActionResult View()
   //     {
   //         int totalRecords = Product.Count();
   //         int Pagesize = 5;
   //         int totalPages =(int) Math.Ceiling(totalRecords /(double) Pagesize);
   //         Product = Product.skip((currentPage - 1) * Pagesize).Skip(Pagesize);
          //return View(); 
   //     }
   


	}
}
