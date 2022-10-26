using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriasController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            try
            {
                if (_context.Categorias == null) return NotFound("Categories not found");
            
                var categoriasProdutos = _context.Categorias.Include(
                    p => p.Produtos).AsNoTracking().ToList();
                return Ok(categoriasProdutos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            try
            {
                if (_context.Categorias == null) return NotFound("Categories not found");
            
                var categorias = _context.Categorias.AsNoTracking().ToList();
                return Ok(categorias);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Produto> Get(int id)
        {
            try
            {
                if (_context.Categorias == null) return NotFound("There's no category.");

                var categoria = _context.Categorias.FirstOrDefault(
                    p => p.CategoriaId == id);
                if (categoria is null)
                    return NotFound("Category not found");

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
            try
            {
                _context.Categorias?.Add(categoria);
                _context.SaveChanges();

                return new CreatedAtRouteResult("ObterCategoria", 
                    new { id = categoria.CategoriaId }, categoria);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.CategoriaId)
                    return BadRequest();

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (_context.Categorias == null) return NotFound("There's no category.");

                var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
            
                if (categoria is null)
                    return NotFound("Category not found");
            
                _context.Categorias.Remove(categoria);
                _context.SaveChanges();

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
