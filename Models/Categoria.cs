using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
//Classes Anêmicas - Classes que não tem comportamento - Classes que não tem métodos - Só possuem propriedades

[Table("Categorias")]
public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>(); //Inicializando a coleção de produtos
    }
    [Key]
    public int CategoriaId { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string? Nome { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string? ImagemUrl { get; set; }
    
    public ICollection<Produto>? Produtos { get; set; } //Relacionamento 1 para N
}


// DataAnnotations
// key
// table(name)
// column(name)
// required
// stringlength
// datatype
// notmapped
// foreignkey