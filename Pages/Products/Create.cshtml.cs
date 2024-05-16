using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using REST_API_Products.Models;
using products_webb_app.Services;

namespace products_webb_app.Pages.Products
{
	public class CreateModel : PageModel
    {
        private readonly ProductService _productService;

        public CreateModel(ProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Product = await _productService.AddProductAsync(Product);
            return RedirectToPage("./Index");
        }
    }
}
