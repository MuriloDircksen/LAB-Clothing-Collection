using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LABClothingCollection.Models
{
    public class Modelo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome do modelo requerido")]
        [MaxLength(200, ErrorMessage = "Máximo de 200 caracteres")]
        [MinLength(5, ErrorMessage = "Minimo de 5 caracteres")]
        public string? NomeModelo { get; set; }

        [ForeignKey("Colecao")]
        public virtual int IdColecao { get; set; }
        public Colecao? Colecao { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Tipo))]
        public Tipo Tipo { get; set; }

        [Required(ErrorMessage = "Campo requerido "), EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }


    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Tipo
    {
        BERMUDA =1,
        BIQUINI,
        BOLSA,
        BONÉ,
        CALÇA,
        CALÇADOS,
        CAMISA,
        CHAPÉU,
        SAIA
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Layout
    {
        BORDADO =1,
        ESTAMPA,
        LISO
    }
}
