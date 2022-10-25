namespace APICatalogo.Models;
//Classes Anêmicas - Classes que não tem comportamento - Classes que não tem métodos - Só possuem propriedades

public class Categoria
{
    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }
}