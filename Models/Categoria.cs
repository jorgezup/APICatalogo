using System.Collections.ObjectModel;

namespace APICatalogo.Models;
//Classes Anêmicas - Classes que não tem comportamento - Classes que não tem métodos - Só possuem propriedades

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>(); //Inicializando a coleção de produtos
    }
    
    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
    
    public ICollection<Produto>? Produtos { get; set; } //Relacionamento 1 para N
}