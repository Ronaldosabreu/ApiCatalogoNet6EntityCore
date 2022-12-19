﻿using ApiCatalogo.Context;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProdutosController : ControllerBase
  {
    private readonly DataContext _context;

    public ProdutosController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
      var produtos = _context.Produtos.AsNoTracking().ToList();

      if (produtos is null)
        return NotFound("Produto não encontrato");

      return Ok(produtos);
    }


    [HttpGet("{id:int}", Name="ObterProduto")]
    public ActionResult<Produto> Get(int id)
    {
      var produtos = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

      if (produtos is null)
        return NotFound("Produto não encontrato");

      return Ok(produtos);
    }

    [HttpPost()]

    public ActionResult Post(Produto produto)
    {
      if (produto is null)
        return BadRequest();

      _context.Produtos.Add(produto);
      _context.SaveChanges();

      return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto );

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
      var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

      if (produto is null)
        return NotFound();

      _context.Produtos.Remove(produto);
      _context.SaveChanges();

      return Ok(produto);

    }


  }
}