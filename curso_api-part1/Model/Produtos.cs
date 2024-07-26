using curso_api_part1.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace curso_api_part1.Model;

public class Produtos : IValidatableObject
{

    [Key]
    //[JsonIgnore]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    //[PrimeiraLetraMaiuscula] annotation personalizado, esta na pasta de validação
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

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
       if(!string.IsNullOrEmpty(this.Nome))
       {
            var primeiraLerta = this.Nome[0].ToString();
            if(primeiraLerta != primeiraLerta.ToUpper())
            {
                yield return new ValidationResult("A primera letra do produto deve ser maiúscula",
                    new[]
                    {
                        nameof(this.Nome),
                    });
            }

       }

       if(this.Estoque <= 0)
        {
            yield return new ValidationResult("A quantidade do estoque precisa ser maior que zero",
                   new[]
                   {
                        nameof(this.Nome),
                   });
        }
    }
}
