using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Mvc;
using Repository.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Controllers
{
    [EnableCors("Sepcific")]
    [Route("api/product")]
    public class Product : Controller
    {
        private readonly IProductService _productService;

        public Product(IProductService productService)
        {

            _productService = productService;
        }


        [Route("all")]
        public IActionResult Products()
        {
         
           var products = _productService.GetAll();
            return Ok(products);
        }
    }
}
