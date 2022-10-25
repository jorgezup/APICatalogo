namespace APICatalogo.Models;
//Classes Anêmicas - Classes que não tem comportamento - Classes que não tem métodos - Só possuem propriedades

public class Produto
{
    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }
    
    public int CategoriaId { get; set; } //Chave estrangeira
    public Categoria? Categoria { get; set; } //Propriedade de Navegação
}