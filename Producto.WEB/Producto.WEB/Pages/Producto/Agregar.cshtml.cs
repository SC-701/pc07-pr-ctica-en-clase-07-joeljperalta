using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reglas;

namespace Producto.WEB.Pages.Producto
{
    public class AgregarModel : PageModel
    {
        private readonly ProductoReglas _productoReglas;

        public AgregarModel(ProductoReglas productoReglas)
        {
            _productoReglas = productoReglas;
        }

        [BindProperty]
        public ProductoRequest producto { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            await _productoReglas.Agregar(producto);

            return RedirectToPage("./Index");
        }
    }
}