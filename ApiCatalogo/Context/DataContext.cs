﻿using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
  public class DataContext: DbContext
  {

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }

  }
}
