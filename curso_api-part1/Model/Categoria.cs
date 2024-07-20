using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace curso_api_part1.Model;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produtos>();
    }

    [Key]
    //[JsonIgnore]
    public int CategoriaId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    
    [StringLength(300)]
    public string? Imagem { get; set; }

    //[JsonIgnore]
    public ICollection<Produtos>? Produtos { get; set; }
}
