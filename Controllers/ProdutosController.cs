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
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            if (_context.Produtos == null) return NotFound("Product not found");
            
            var produtos = _context.Produtos.AsNoTracking().ToList();
            return Ok(produtos);

        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            if (_context.Produtos == null) return NotFound("There's no product.");

            var produto = _context.Produtos.FirstOrDefault(
                p => p.ProdutoId == id);
            if (produto is null)
                return NotFound("Product not found");

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            _context.Produtos?.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
                return BadRequest();

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if (_context.Produtos == null) return NotFound("There's no product.");

            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            
            if (produto is null)
                return NotFound("Product not found");
            
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
        
    
    }
}
