using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoriasController : ControllerBase
  {
    private readonly DataContext _context;

    public CategoriasController(DataContext context)
    {
      _context = context;
    }


    [HttpGet("produtos")]
    public ActionResult<IEnumerable<Categoria>> GetCategoriasProduto()
    {
      var categorias = _context.Categorias.Include(p => p.Produtos).ToList();
      //var categorias = _context.Categorias.Where(c=>c.CategoriaId<=5).ToList();
      //var categorias = _context.Categorias.Take(10).ToList();


      return Ok(categorias);
    }


    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> Get()
    {
      var categorias = _context.Categorias.AsNoTracking().ToList();

      if (categorias is null)
        return NotFound("categoria não encontrato");

      return Ok(categorias);
    }


    [HttpGet("{id:int}", Name= "Obtercategoria")]
    public ActionResult<Categoria> Get(int id)
    {
      
      try
      {
        var categorias = _context.Categorias.AsNoTracking().FirstOrDefault(categorias => categorias.CategoriaId == id);

        if (categorias is null)
          return NotFound("Produto não encontrato");

        return Ok(categorias);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError, "erro ao trata a sua solicitação");
      }


    
    }

    [HttpPost()]

    public ActionResult Post(Categoria categoria)
    {
      if (categoria is null)
        return BadRequest();

      _context.Categorias.Add(categoria);
      _context.SaveChanges();

      return new CreatedAtRouteResult("Obtercategoria", new { id = categoria.CategoriaId }, categoria);

    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int id, Categoria categoria)
    {

      if (id != categoria.CategoriaId)
        return BadRequest();

      _context.Entry(categoria).State = EntityState.Modified;
      _context.SaveChanges();

      return Ok(categoria);

    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
      var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);

      if (categoria is null)
        return NotFound();

      _context.Categorias.Remove(categoria);
      _context.SaveChanges();

      return Ok(categoria);

    }


  }
}
