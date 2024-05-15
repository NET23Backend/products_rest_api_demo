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
	public class EditModel : PageModel
    {
        private readonly ProductService _productService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(ProductService productService, ILogger<EditModel> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetProductByIdAsync(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var response = await _productService.UpdateProductAsync(Product.Id, Product);

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Failed to update product. Status Code: {StatusCode}", response.StatusCode);
                ModelState.AddModelError(string.Empty, "An error occurred while updating the product.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
