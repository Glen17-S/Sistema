using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;
using Sistema.Web.Models.Almacen.Articulo;

namespace Sistema.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public ArticulosController(DbContextSistema context)
        {
            _context = context;
        }

        // GET: api/Articulos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ArticuloViewModel>> Listar()
        {
            var articulo = await _context.Articulos.Include(a => a.Categoria).ToListAsync();

            return articulo.Select(a => new ArticuloViewModel
            {
                idarticulo = a.idarticulo,
                idcategoria = a.idcategoria,
                categoria = a.Categoria.nombre,
                codigo = a.codigo,
                nombre = a.nombre,
                stock = a.stock,
                precio_venta = a.precio_venta,
                descripcion = a.descripcion,
                condicion = a.condicion
            });

        }

        // GET: api/Categorias/Mostrar/1
        /* [HttpGet("[action]/{id}")]
         public async Task<ActionResult> Mostrar([FromRoute] int id)
         {
             var categoria = await _context.Categorias.FindAsync(id);

             if (categoria == null)
             {
                 return NotFound();
             }

             return Ok(new CategoriaViewModels
             {
                 idcategoria = categoria.idcategoria,
                 nombre = categoria.nombre,
                 descripcion = categoria.descripcion,
                 condicion = categoria.condicion
             });
         }
        */

        // DELETE: api/Articulos/5
       /* [HttpDelete("{id}")]
        public async Task<ActionResult<Articulo>> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return articulo;
        }
       */

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.idarticulo == id);
        }
    }
}
