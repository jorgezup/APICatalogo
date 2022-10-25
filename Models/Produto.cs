using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;
//Classes Anêmicas - Classes que não tem comportamento - Classes que não tem métodos - Só possuem propriedades

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string? Nome { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string? Descricao { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }
    
    [Required]
    [MaxLength(300)]
    public string? ImagemUrl { get; set; }
    
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    
    public int CategoriaId { get; set; } //Chave estrangeira
    public Categoria? Categoria { get; set; } //Propriedade de Navegação
}