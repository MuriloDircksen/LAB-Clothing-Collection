
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LABClothingCollection.Models
{
    public class Colecao
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome da coleção é obrigatório")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(10, ErrorMessage = "Minimo de 10 caracteres")]
        public string NomeColecao { get; set; }

        [ForeignKey("Usuario")]
        public virtual int IdUsuario { get; set; }
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Nome da marca é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Orçamento é obrigatório")]
        public double? Orcamento { get; set; }

        [Required(ErrorMessage = "Data lançamento é obrigatório")]
        [DataType(DataType.Date)]
        public DateOnly? DataLancamento { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Estacao))]
        public Estacao Estacao { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(StatusColecao))]
        public StatusColecao Status { get; set; }

        [JsonIgnore]
        public ICollection<Modelo>? Modelo { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusColecao
    {
        ATIVO = 1,
        INATIVO
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Estacao
    {
        OUTONO =1,
        INVERNO,
        PRIMAVERA,
        VERÃO
    }
}
