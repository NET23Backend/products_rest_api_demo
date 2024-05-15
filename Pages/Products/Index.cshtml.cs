using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using products_webb_app.Models;
using products_webb_app.Services;

namespace products_webb_app.Pages.Products
{
	public class IndexModel : PageModel
    {
        private readonly ProductService _productService;

        public IndexModel(ProductService productService)
        {
            _productService = productService;
        }

        public List<ProductDTO> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _productService.GetProductsAsync();
        }
    }
}
