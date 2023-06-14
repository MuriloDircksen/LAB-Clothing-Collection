
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LABClothingCollection.Models
{
    public class Usuario : Pessoa
    {
        [Required(ErrorMessage ="Campo e-mail obrigatório")]        
        public string? Email { get; set; }

        [Required(ErrorMessage ="Campo requerido e deve seguir a lista de tipos possiveis"), EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario TipoUsuario{ get; set; }

        [Required(ErrorMessage = "Campo requerido e deve seguir a lista de tipos possiveis"), EnumDataType(typeof(StatusUsuario))]
        public StatusUsuario Status { get; set; }
        [JsonIgnore]
        public ICollection<Colecao>? Colecao { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusUsuario
    {
        ATIVO =1,
        INATIVO
    }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario
    {
        ADMINISTRADOR = 1,
        GERENTE,
        CRIADOR,
        OUTRO

    }
}
