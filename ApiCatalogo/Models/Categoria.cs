using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCatalogo.Models;

[Table("Categoria")]
public class Categoria
  {

    public Categoria()
    {
      Produtos = new Collection<Produto>();
    }

    [Key]
    public int CategoriaId { get; set; }

    [Column(TypeName = "varchar(100)")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Column(TypeName = "varchar(max)")]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto>? Produtos { get; set; }


}
