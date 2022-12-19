﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
  [Table("Produto")]
  public class Produto
  {
    [Key]
    public int ProdutoId { get; set; }

    [Column(TypeName = "varchar(100)")]
    [MaxLength(100)]
    [Required]
    public string? Nome { get; set; }

    [Column(TypeName = "varchar(200)")]
    [StringLength(200)]
    [Required]
    public string? Descricao { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Preco { get; set; }

    [Column(TypeName = "varchar(max)")]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public float Estoque { get; set; }


    public DateTime DataCadastro { get; set; }


    public int CategoriaId { get; set; }
    
    [JsonIgnore]
    public Categoria? Categoria { get; set; }

  }
}
