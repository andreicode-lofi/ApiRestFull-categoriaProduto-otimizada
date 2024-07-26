using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace curso_api_part1.Model;

public class Categoria : IValidatableObject// herdando a interface IValidatableObject, para fazer vaçodações personaliada
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

    [JsonIgnore]
    public ICollection<Produtos>? Produtos { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.Nome))
        {
            var primeiraLetra = this.Nome[0].ToString();
            if(primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new ValidationResult("A primera letra da categorua deve ser maiúscula",
                    new[]
                    {
                        nameof(this.Nome),
                    });
            }

        }
    }
}
