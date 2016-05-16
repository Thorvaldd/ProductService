using Microsoft.AspNet.Mvc;
using Repository.Services;

namespace Web.Controllers
{

    public class ProductController: Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        public JsonResult Products()
        {
            var products = _productService.GetAll();

            return Json(products);
        }
    }
}