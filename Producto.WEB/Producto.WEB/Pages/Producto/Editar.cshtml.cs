using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Reglas;

namespace Producto.WEB.Pages.Producto
{
    public class EditarModel : PageModel
    {
        private readonly ProductoReglas _productoReglas;

        public EditarModel(ProductoReglas productoReglas)
        {
            _productoReglas = productoReglas;
        }

        [BindProperty]
        public ProductoRequest producto { get; set; } = default!;

        [BindProperty]
        public Guid Id { get; set; } 

        public async Task<IActionResult> OnGet(Guid id)
        {
            var prod = await _productoReglas.Obtener(id);
            if (prod == null) return NotFound();

            Id = prod.Id; 
            producto = new ProductoRequest
            {
                Nombre = prod.Nombre,
                Descripcion = prod.Descripcion,
                Precio = prod.Precio,
                Stock = prod.Stock,
                CodigoBarras = prod.CodigoBarras,
          
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

       
            await _productoReglas.Editar(Id, producto);

            return RedirectToPage("./Index");
        }
    }
}