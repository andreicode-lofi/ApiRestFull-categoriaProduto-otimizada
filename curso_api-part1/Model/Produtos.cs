using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace curso_api_part1.Model;

public class Produtos
{

    [Key]
    [JsonIgnore]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    public float Estoque { get; set; }
    public decimal ValorTotal { get; set; }
    public DateTime DataCadastro { get; set; }

    //relacionamento de um para muitos
    public int CategoriaId { get; set; }//para maperar a chaves de relacionamento
    [JsonIgnore]
    public Categoria? Categoria { get; set; }//para navegação
}
